using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suspe.LED.ServiceTests;
using Suspe.LED.WinService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Suspe.LED.WinService.Tests
{
    [TestClass()]
    public class SusLedMainTests: TestBase
    {
        [TestMethod()]
        public void OnStartTest()
        {
            SusLedMain m_ledMain=new SusLedMain();
            m_ledMain.OnStart();
            Thread.CurrentThread.Join();
        }

        [TestMethod()]
        public void OnPauseTest()
        {
           
        }

        [TestMethod()]
        public void OnContinueTest()
        {
           
        }

        [TestMethod()]
        public void OnStopTest()
        {
            
        }
    }
}