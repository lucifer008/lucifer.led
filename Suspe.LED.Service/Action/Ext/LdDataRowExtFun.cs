using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Service.Ext
{
    public static class LdDataRowExtFun
    {
        // Token: 0x06000065 RID: 101 RVA: 0x00003138 File Offset: 0x00001338
        private static bool LdCheckColumn(DataRow dr, string colName)
        {
            bool result = false;
            if (dr.Table.Columns.Contains(colName))
            {
                result = true;
            }
            return result;
        }

        // Token: 0x06000066 RID: 102 RVA: 0x00003160 File Offset: 0x00001360
        public static bool IsNullOrEmpty(this DataRow dr, string colName)
        {
            bool result = false;
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return result;
            }
            if (dr[colName] == DBNull.Value)
            {
                result = true;
            }
            else if (dr[colName].GetType() == typeof(string))
            {
                result = string.IsNullOrWhiteSpace(dr[colName].ToString());
            }
            return result;
        }

        // Token: 0x06000067 RID: 103 RVA: 0x000031BC File Offset: 0x000013BC
        public static Guid LdToGuid(this DataRow dr, string colName)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return Guid.Empty;
            }
            if (DBNull.Value != dr[colName])
            {
                return (Guid)dr[colName];
            }
            return Guid.Empty;
        }

        // Token: 0x06000068 RID: 104 RVA: 0x000031ED File Offset: 0x000013ED
        public static bool LdToBoolean(this DataRow dr, string colName)
        {
            return LdDataRowExtFun.LdCheckColumn(dr, colName) && dr[colName] != DBNull.Value && Convert.ToBoolean(dr[colName]);
        }

        // Token: 0x06000069 RID: 105 RVA: 0x00003216 File Offset: 0x00001416
        public static bool LdToBoolean(this DataRow dr, string colName, DataRowVersion ver)
        {
            return LdDataRowExtFun.LdCheckColumn(dr, colName) && dr[colName, ver] != DBNull.Value && Convert.ToBoolean(dr[colName, ver]);
        }

        // Token: 0x0600006A RID: 106 RVA: 0x00003241 File Offset: 0x00001441
        public static int LdToInt32(this DataRow dr, string colName)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return 0;
            }
            if (dr[colName] != DBNull.Value)
            {
                return Convert.ToInt32(dr[colName]);
            }
            return 0;
        }

        // Token: 0x0600006B RID: 107 RVA: 0x0000326A File Offset: 0x0000146A
        public static int LdToInt32(this DataRow dr, string colName, DataRowVersion ver)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return 0;
            }
            if (dr[colName, ver] != DBNull.Value)
            {
                return Convert.ToInt32(dr[colName, ver]);
            }
            return 0;
        }

        // Token: 0x0600006C RID: 108 RVA: 0x00003295 File Offset: 0x00001495
        public static uint LdToUInt32(this DataRow dr, string colName)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return 0u;
            }
            if (DBNull.Value == dr[colName])
            {
                return 0u;
            }
            return Convert.ToUInt32(dr[colName]);
        }

        // Token: 0x0600006D RID: 109 RVA: 0x000032BE File Offset: 0x000014BE
        public static short LdToInt16(this DataRow dr, string colName)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return 0;
            }
            if (DBNull.Value == dr[colName])
            {
                return 0;
            }
            return Convert.ToInt16(dr[colName]);
        }

        // Token: 0x0600006E RID: 110 RVA: 0x000032E7 File Offset: 0x000014E7
        public static long LdToInt64(this DataRow dr, string colName)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return 0L;
            }
            if (DBNull.Value == dr[colName])
            {
                return 0L;
            }
            return Convert.ToInt64(dr[colName]);
        }

        // Token: 0x0600006F RID: 111 RVA: 0x00003312 File Offset: 0x00001512
        public static byte LdToByte(this DataRow dr, string colName)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return 0;
            }
            if (DBNull.Value == dr[colName])
            {
                return 0;
            }
            return Convert.ToByte(dr[colName]);
        }

        // Token: 0x06000070 RID: 112 RVA: 0x0000333B File Offset: 0x0000153B
        public static string LdToString(this DataRow dr, string colName)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return string.Empty;
            }
            if (dr[colName] != DBNull.Value)
            {
                return dr[colName].ToString();
            }
            return string.Empty;
        }

        // Token: 0x06000071 RID: 113 RVA: 0x0000336C File Offset: 0x0000156C
        public static string LdToString(this DataRow dr, string colName, DataRowVersion ver)
        {
            if (!LdDataRowExtFun.LdCheckColumn(dr, colName))
            {
                return string.Empty;
            }
            if (dr[colName, ver] != DBNull.Value)
            {
                return dr[colName, ver].ToString();
            }
            return string.Empty;
        }
    }
}
