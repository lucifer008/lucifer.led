using log4net.Config;
using SuspeSys.WinService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.WinService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            var appPath = ServiceUtils.GetWindowsServiceInstallPath(ServicesToRun[0].ServiceName);
            var log4Path = string.Format("{0}\\Config\\log4net.cfg.xml", appPath);
            XmlConfigurator.Configure(new FileInfo(log4Path));
            ServiceBase.Run(ServicesToRun);
        }
    }
}
