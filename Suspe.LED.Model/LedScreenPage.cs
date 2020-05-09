using System;


namespace Suspe.LED.Model
{
    using System.ComponentModel;

    /// <summary>
    /// LED显示屏页面
    /// </summary>
    [Serializable]
    public partial class LedScreenPage : MetaData {
        public virtual string Id { get; set; }
        public virtual LedScreenConfig LedScreenConfig { get; set; }
        /// <summary>
        /// 页面序号
        /// </summary>
        [Description("页面序号")]
        public virtual int? PageNo { get; set; }
        /// <summary>
        /// 信息类别
        /// </summary>
        [Description("信息类别")]
        public virtual int? InfoType { get; set; }
        /// <summary>
        /// 信息类别描述
        /// </summary>
        [Description("信息类别描述")]
        public virtual string InfoTypeTxt { get; set; }
        /// <summary>
        /// 自定义信息内容
        /// </summary>
        [Description("自定义信息内容")]
        public virtual string CusContent { get; set; }
        /// <summary>
        /// 时长(秒)
        /// </summary>
        [Description("时长(秒)")]
        public virtual int? Times { get; set; }
        /// <summary>
        /// 刷新周期(秒)
        /// </summary>
        [Description("刷新周期(秒)")]
        public virtual int? RefreshCycle { get; set; }
        /// <summary>
        /// 生效
        /// </summary>
        [Description("生效")]
        public virtual bool? Enabled { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        [Description("录入时间")]
        public virtual DateTime? InsertTime { get; set; }

        /// <summary>
        /// 组编号
        /// </summary>
        public string GroupNo { set; get; }
    }
}
