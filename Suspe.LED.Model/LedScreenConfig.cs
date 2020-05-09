using System;


namespace Suspe.LED.Model
{
    using System.ComponentModel;

    /// <summary>
    /// LED屏配置
    /// </summary>
    [Serializable]
    public partial class LedScreenConfig : MetaData {
        public LedScreenConfig() { }
        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// 屏号
        /// </summary>
        [Description("屏号")]
        public virtual string ScreenNo { get; set; }
        /// <summary>
        /// 控制器类型(EQ2011)
        /// </summary>
        [Description("控制器类型(EQ2011)")]
        public virtual string ControllerTypeTxt { get; set; }
        /// <summary>
        /// 控制器类型Key
        /// </summary>
        [Description("控制器类型Key")]
        public virtual string ControllerKey { get; set; }
        /// <summary>
        /// 通信方式(0:串口;1:网络)
        /// </summary>
        [Description("通信方式(0:串口;1:网络)")]
        public virtual int? CommunicationWay { get; set; }
        /// <summary>
        /// 通信方式描述
        /// </summary>
        [Description("通信方式描述")]
        public virtual string CommunicationWayTxt { get; set; }
        /// <summary>
        /// 显示屏宽度
        /// </summary>
        [Description("显示屏宽度")]
        public virtual int? SWidth { get; set; }
        /// <summary>
        /// 显示屏高度
        /// </summary>
        [Description("显示屏高度")]
        public virtual int? SHeight { get; set; }
        /// <summary>
        /// 颜色类型
        /// </summary>
        [Description("颜色类型")]
        public virtual int? ColorType { get; set; }
        /// <summary>
        /// 颜色类型描述
        /// </summary>
        [Description("颜色类型描述")]
        public virtual string ColorTypeTxt { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        [Description("IP地址")]
        public virtual string IpAddress { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        [Description("端口号")]
        public virtual int? Port { get; set; }
        /// <summary>
        /// 生产组
        /// </summary>
        [Description("生产组")]
        public virtual string GroupNo { get; set; }
        /// <summary>
        /// 启用(0：否:1:是)
        /// </summary>
        [Description("启用(0：否:1:是)")]
        public virtual bool? Enable { get; set; }
    }
}
