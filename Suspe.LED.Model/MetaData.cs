using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Model
{
    [Serializable]
    public abstract class MetaData
    {
        /// <summary>
        /// 插入时间
        /// </summary>
        public virtual DateTime? InsertDateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? UpdateDateTime { get; set; }
        /// <summary>
        /// 插入用户
        /// </summary>
        public virtual string InsertUser { get; set; }
        /// <summary>
        /// 更新用户
        /// </summary>
        public virtual string UpdateUser { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public virtual byte? Deleted { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public virtual string CompanyId { get; set; }
    }
}
