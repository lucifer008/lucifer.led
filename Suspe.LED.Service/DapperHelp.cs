using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Reflection;
using Suspe.LED.Service;
using log4net;
using System.Data;

namespace SuspeSys.Dao
{
    public class DapperHelp
    {
        public static string AppPath;

        #region 属性
        private static string _connectionString;
        static readonly ILog log = LogManager.GetLogger(typeof(DapperHelp));
        public static string ConnectionString
        {
            get
            {
                //if (string.IsNullOrEmpty(_connectionString))
                //{
                //    //string path = string.Empty;
                //    //if (string.IsNullOrEmpty(AppPath))
                //    //{
                //    //    path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Config/hibernate.cfg.xml");
                //    //}
                //    //else
                //    //    path = string.Format("{0}\\Config\\hibernate.cfg.xml", AppPath);// System.IO.Path.Combine(AppPath, "\\Config\\hibernate.cfg.xml");

                //    //LogManager.GetLogger(typeof(DapperHelp)).Info("path==="+ path);

                //    //Configuration conf = new Configuration();
                //    //conf = conf.Configure(path);
                //    //_connectionString = conf.Properties[NHibernate.Cfg.Environment.ConnectionString];
                //}
                if (null == _connectionString)
                    _connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                return _connectionString;
            }
        }

        private static string UserId
        {
            get
            {
                //if (CurrentUser.Instance.User != null)
                //    return CurrentUser.Instance.UserId;
                //else
                return string.Empty;
            }
        }
        #endregion

        #region Add
        public static string Add<T>(T obj)
        {
            Object id = null;
            //if (obj is MetaData)
            //{
            //    MetaData metaData = obj as MetaData;
            //    metaData.CompanyId = "c001";
            //    metaData.Deleted = 0;
            //    metaData.InsertDateTime = DateTime.Now;
            //    metaData.InsertUser = UserId;
            //}

            var sql = GetInsertSql<T>(obj, out id);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, obj);
            }

            return id?.ToString();
        }
        #endregion

        #region Edit
        public static int Edit<T>(T obj)
        {
            //if (obj is MetaData)
            //{
            //    MetaData metaData = obj as MetaData;
            //    metaData.CompanyId = "c001";
            //    metaData.UpdateDateTime = DateTime.Now;
            //    metaData.UpdateUser = UserId;

            //    if (!metaData.Deleted.HasValue)
            //        metaData.Deleted = 0;


            //}

            //Stopwatch stopwatch1 = new Stopwatch();


            var sql = GetUpdateSql(obj);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute(sql, obj);
            }
        }


        #endregion

        #region Query
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T QueryForObject<T>(string sql, object obj=null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<T>(sql, obj);
            }
        }
        public static DataTable Query(string sql)
        {
            var dataset = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    sql, connection);
                adapter.Fill(dataset);
                return dataset.Tables[0];
            }
        }
        #endregion

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(string sql, object obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.ExecuteScalar<T>(sql, obj);
            }
        }

        /// <summary>
        /// 例如： SELECT * FROM t WHERE ID = @ID
        /// obj : new Object{ID = ID} 或者对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="obj"> new Object{ID = ID}</param>
        /// <returns></returns>
        public static int Execute(string sql, object obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute(sql, obj);
            }
        }
        #endregion

        #region Query
        /// <summary>
        /// 返回指定实体
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static IEnumerable<U> Query<U>(string sql, object para = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<U>(sql, para);
            }
        }

        public static T FirstOrDefault<T>(string sql, object para)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<T>(sql, para);
            }
        }
        #endregion


        #region SqlMap
        public static string GetInsertSql<T>(T t, out Object pk)
        {
            if (null == t)
            {
                var ex = new ApplicationException("实体不能未空!");
                throw ex;
            }
            Type type = t.GetType();
            PropertyInfo[] pds = type.GetProperties().Where(p => p.GetMethod.IsVirtual).ToArray();
            if (pds.Length == 0)
            {
                var ex = new ApplicationException("没有Virtual属性");
                throw ex;
            }

            StringBuilder columns = new StringBuilder();
            StringBuilder valuePara = new StringBuilder();

            foreach (var pi in pds)
            {
                if (columns.Length > 0)
                    columns.Append(",");

                if (valuePara.Length > 0)
                    valuePara.Append(",");

                columns.AppendFormat(pi.Name);

                valuePara.AppendFormat("@{0}", pi.Name);
                //if (!pi.Name.ToLower().Equals("id"))
                //{
                //    sqlStringBuilder.AppendFormat("{0},", pi.Name);
                //}
            }

            pk = GUIDHelper.GetGuidString();
            if (pds != null && pds.Any(o => o.Name.ToLower() == "id"))
            {
                var para = pds.Where(o => o.Name.ToLower() == "id").First();
                para.SetValue(t, pk);
            }


            var sqlStringBuilder = new StringBuilder();
            sqlStringBuilder.AppendFormat("INSERT INTO {0} ({1}) values ({2}) ", type.Name, columns, valuePara);


            return sqlStringBuilder.ToString();
        }

        public static string GetUpdateSql<T>(T t)
        {
            if (null == t)
            {
                var ex = new ApplicationException("实体不能未空!");
                throw ex;
            }
            Type type = t.GetType();
            PropertyInfo[] pds = type.GetProperties().Where(p => p.GetMethod.IsVirtual).ToArray();
            if (pds.Length == 0)
            {
                var ex = new ApplicationException("没有Virtual属性");
                throw ex;
            }

            var sqlStringBuilder = new StringBuilder();
            var builderWhere = new StringBuilder();
            var builderColumn = new StringBuilder();
            foreach (var pi in pds)
            {
                if (pi.Name.ToLower().Equals("id"))
                {
                    if (builderWhere.Length > 0)
                        builderWhere.Append(" And ");

                    builderWhere.Append(" Id = @Id");

                }
                else
                {
                    //if (pi.GetValue(t) != null)
                    builderColumn.AppendFormat("{0}=@{0},", pi.Name);
                }
            }

            sqlStringBuilder.AppendFormat("UPDATE {0} SET {1} WHERE {2}", type.Name, builderColumn.ToString().Trim(','), builderWhere);

            return sqlStringBuilder.ToString();
        }
        #endregion
    }
}
