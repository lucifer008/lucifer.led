using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.WinService
{
    public partial class Service1 : ServiceBase
    {
        ILog log = LogManager.GetLogger(typeof(Service1));
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            log.InfoFormat("悬挂LED服务开启开始......");
            var url = ConfigurationManager.AppSettings["ConnectionString"];
            log.InfoFormat("ConnectionString:{0}", url);
            if (this.m_ledMain == null)
            {
                this.m_ledMain = new SusLedMain();
            }
            this.m_ledMain.OnStart();
            log.InfoFormat("悬挂LED服务开启完成！");
        }

        protected override void OnStop()
        {
            log.InfoFormat("悬挂LED服务已停止！");
        }

        // Token: 0x040000AF RID: 175
        private SusLedMain m_ledMain;
    }
}
