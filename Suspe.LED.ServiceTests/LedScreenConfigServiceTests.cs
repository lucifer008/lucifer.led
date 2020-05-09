using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suspe.LED.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Service.Tests
{
    [TestClass()]
    public class LedScreenConfigServiceTests
    {
        [TestMethod()]
        public void GetLedScreenConfigListTest()
        {
            var list =LedScreenConfigService.Instance.GetLedScreenConfigList();
            var list2 = LedScreenConfigService.Instance.GetLedScreenPageList(list[0].Id);
            var list3= LedScreenConfigService.Instance.GetTodayProcessOrderYield(list[0].GroupNo);
            var list4 = LedScreenConfigService.Instance.HoursPlanInfo("A");
            log.Info(list4.Rows.Count);
            var list5 = LedScreenConfigService.Instance.HoursPlanInfo("A");
            log.Info(list5.Rows.Count);
        }
        public static ILog log = null;
        [TestInitialize]
        public void Init()
        {
            var log4netFileInfo = new FileInfo("Config/log4net.cfg.xml");
            XmlConfigurator.Configure(log4netFileInfo);

            log = LogManager.GetLogger(typeof(LedScreenConfigServiceTests));
        }
    }
}