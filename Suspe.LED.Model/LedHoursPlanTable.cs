using System;
using System.Text;
using System.Collections.Generic;


namespace Suspe.LED.Model
{
   
    using System.ComponentModel;
    
    /// <summary>
    /// LED小时计划表
    /// </summary>
    [Serializable]
    public partial class LedHoursPlanTable : MetaData {
        public virtual string Id { get; set; }
        /// <summary>
        /// 线号
        /// </summary>
        [Description("线号")]
        public virtual string LineNo { get; set; }
        /// <summary>
        /// 组别
        /// </summary>
        [Description("组别")]
        public virtual string GroupNo { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("是否启用")]
        public virtual bool? Enabled { get; set; }
    }
}
