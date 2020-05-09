using System;
using System.Text;
using System.Collections.Generic;


namespace Suspe.LED.Model
{

    using System.ComponentModel;
    
    /// <summary>
    /// LED小时计划表明细
    /// </summary>
    [Serializable]
    public partial class LedHoursPlanTableItem : MetaData {
        public virtual string Id { get; set; }
        /// <summary>
        /// 组号
        /// </summary>
        [Description("组号")]
        public virtual string GroupNo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Description("开始时间")]
        public virtual DateTime? BeginDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Description("结束时间")]
        public virtual DateTime? EndDate { get; set; }
        /// <summary>
        /// 计划数量
        /// </summary>
        [Description("计划数量")]
        public virtual int? PlanNum { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        [Description("录入时间")]
        public virtual DateTime? InsertDate { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("是否启用")]
        public virtual bool? Enabled { get; set; }
    }
}
