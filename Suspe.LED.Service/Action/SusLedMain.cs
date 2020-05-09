using log4net;
using Suspe.LED.Service;
using Suspe.LED.Service.Ext;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Suspe.LED.WinService
{
    public class SusLedMain
    {
        readonly ILog log = LogManager.GetLogger(typeof(SusLedMain));
        public void OnStart()
        {
            //log.InfoFormat("SusLedMain--->{0}", "OnStart");
            if (this.m_task == null)
            {
                this.m_cts = new CancellationTokenSource();
                this.m_task = new Task(new Action<object>(this.TaskMethod), this.m_cts.Token);
                this.m_task.Start();
                log.InfoFormat("开启服务-->{0}", new object[1] { "SusLedMain" });
            }
        }
        private bool InitDbConn()
        {
            bool result = false;
            using (DataTable dataTable = new DataTable("tDbList"))
            {
                //LdSysInfo.SQLiteHelper.FillDataTable(dataTable, string.Format("SELECT * FROM {0}", "tDbList"));
                //DataRow[] array = dataTable.Select(null, "EffDate DESC", DataViewRowState.CurrentRows);
                //if (array.Length > 0)
                //{
                //    DataRow dr = array[0];
                //    LdBLLCommon.InitDbHelper(dr.LdToString("SvrName"), dr.LdToString("DbName"), dr.LdToString("UserName"), dr.LdToString("Password"));
                //    result = true;
                //}
                //else
                //{
                //    LdLogManager.WriteLog("无有效数据库连接，请正确配置后重新启动服务", new object[0]);
                //}
            }
            result = true;
            return result;
        }
        private void TaskMethod(object obj)
        {
            try
            {
                //throw new NotImplementedException();
                log.InfoFormat("进入TaskMethod...");
                if (!this.InitDbConn())
                {
                    return;
                }
                log.InfoFormat("DB初始成功...");
                CancellationToken cancellationToken = (CancellationToken)obj;
                using (LedData ledData = new LedData(log))
                {
                    bool flag = false;
                    while (!flag)
                    {
                        log.InfoFormat("任务处理开始...");
                        if (ledData.Start())
                        {
                            log.InfoFormat("ledData.RefreshLed() begin...");

                            ledData.RefreshLed();
                            log.InfoFormat("ledData.RefreshLed() sucess");
                        }
                        log.InfoFormat("任务处理结束...");
                        int num = 5;
                        while (num-- > 0)
                        {
                            if (cancellationToken.IsCancellationRequested)
                            {
                                flag = true;
                                log.InfoFormat("退出任务", new object[0]);
                                break;
                            }
                            log.InfoFormat("任务线程休眠1秒,递减数-->{0}", num);
                            Thread.Sleep(1000);
                        }
                        if (flag)
                        {
                            log.InfoFormat("退出任务推送", new object[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void OnPause()
        {
            string format = "服务暂停";
            log.InfoFormat(format, new object[0]);
        }
        public void OnContinue()
        {
            string format = "服务继续运行";
            log.InfoFormat(format, new object[0]);
        }
        public void OnStop()
        {
            try
            {
                if (this.m_task != null)
                {
                    uint tickCount = LdAPI.GetTickCount();
                    while (!this.m_task.IsCompleted)
                    {
                        this.m_cts.Cancel();
                        Thread.Sleep(100);
                        uint num = LdAPI.GetTickCount() - tickCount;
                        if (num > 5000u)
                        {
                            break;
                        }
                    }
                    this.m_task.Dispose();
                    this.m_cts.Dispose();
                    log.InfoFormat("停止服务", new object[0]);
                }
            }
            catch (Exception ex)
            {
                //log.InfoFormat(ex.Message, new object[0]);
                log.Error(ex);
            }
            finally
            {
                this.m_task = null;
                this.m_cts = null;
            }
        }

        // Token: 0x17000016 RID: 22
        // (get) Token: 0x0600006D RID: 109 RVA: 0x00002608 File Offset: 0x00000808
        public bool IsRunning
        {
            get
            {
                bool result = false;
                if (this.m_task != null)
                {
                    result = (this.m_task.Status == TaskStatus.Running);
                }
                return result;
            }
        }
        // Token: 0x040000B0 RID: 176
        public const string ProductName = "Leadingsoft电子看板管理系统";

        // Token: 0x040000B1 RID: 177
        public const string InstallTool = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\InstallUtil.exe";

        // Token: 0x040000B2 RID: 178
        public const string ServerFileName = "Suspe.LED.WinService.exe";

        // Token: 0x040000B3 RID: 179
        public const string ServerName = "Suspe.LEDService";

        // Token: 0x040000B4 RID: 180
        private Task m_task;

        // Token: 0x040000B5 RID: 181
        private CancellationTokenSource m_cts;
    }
}
