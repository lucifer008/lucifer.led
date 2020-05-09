using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.ServiceProcess;
using log4net;

namespace SuspeSys.Server
{
    public partial class SusStatus : DevExpress.XtraEditors.XtraForm
    {
        private ILog log = LogManager.GetLogger(typeof(SusStatus));
        public string ExecuteRes = "";
        /// <summary>
        /// 线程执行完回调方法
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;

        public SusStatus()
        {
            InitializeComponent();
        }
        private string ExecuteMethod = "";
        public void SetExecuteMethod(string extMethod)
        {
            this.ExecuteMethod = extMethod;
        }
        private string ServiceFileName;
        public void SetServiceFileName(string svcFileName)
        {
            this.ServiceFileName = svcFileName;
        }
        private string ServiceName;
        public void SetServiceName(string svcName)
        {
            this.ServiceName = svcName;
        }
        private void SusStatus_Load(object sender, EventArgs e)
        {
            progressBarControl1.EditValue = 0;

            //   timer1.Enabled = true;

            if (ExecuteMethod == "install")
            {
                label1.Text = "程序正在尝试安装 本地计算机 上的以下服务...";
                progressBarControl1.EditValue = 50;
                //创建线程对象 传入要线程执行的方法
                Thread th = new Thread(InstallService);
                //将线程设置为后台线程（当所有的前台线程结束后，后台线程会自动退出)
                //   th.IsBackground = true;
                //启动线程执行方法
                th.Start();
            }
            else if (ExecuteMethod == "uninstall")
            {
                label1.Text = "程序正在尝试卸载 本地计算机 上的以下服务...";
                progressBarControl1.EditValue = 50;
                Thread th = new Thread(UnInstallService);
                //   th.IsBackground = true;
                th.Start();
            }
            else if (ExecuteMethod == "start")
            {
                label1.Text = "正在开启服务......";
                progressBarControl1.EditValue = 50;
                Thread th = new Thread(StartService);
                // th.IsBackground = true;
                th.Start();

            }

            else if (ExecuteMethod == "stop")
            {
                label1.Text = "正在停止服务......";
                progressBarControl1.EditValue = 50;
                Thread th = new Thread(StopService);
                //  th.IsBackground = true;
                th.Start();
            }
        }
        private void StopService()
        {
            try
            {
                ExecuteRes = "stop_error";
                Exception errMsg = null;
                bool sucess = WinServiceUtils.StopService(ServiceName, ref errMsg);
                //if (sucess)
                //{
                //    ExecuteRes = "stop_success";
                //    this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
                //    return;
                //}

                if (null != errMsg)
                {
                    log.Error("StopService", errMsg);
                }

                ExecuteRes = "stop_success";
                this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
                return;
                //if (null != errMsg)
                //{
                //    log.Error("StopService", errMsg);
                //    this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
                //}
            }
            catch (Exception ex)
            {
                ExecuteRes = "stop_error";
                log.Error("StopService", ex);
                this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
                //  this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
                return;
            }
        }

        private void StartService()
        {
            try
            {
                ExecuteRes = "start_error";
                Exception errMsg = null;
                bool result = WinServiceUtils.StartService(ServiceName, ref errMsg);
                if (result)
                {
                    ExecuteRes = "start_success";
                    this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
                    return;
                }
                if (null!= errMsg) {
                    log.Error("StartService", errMsg);
                    this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
                }
            }
            catch (Exception ex)
            {
                ExecuteRes = "start_error";
                log.Error("StartService", ex);
                this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
            }
        }
        void ControlProgessBar(object state, EventArgs e)
        {
            string status = state?.ToString();
            switch (status)
            {
                case "install_success":
                    label1.Text = "服务安装成功!";
                    break;
                case "install_error":
                    label1.Text = "服务安装失败!";
                    break;
                case "uninstall_success":
                    label1.Text = "服务卸载成功!";
                    break;
                case "uninstall_error":
                    label1.Text = "服务卸载失败!";
                    break;
                case "start_success":
                    label1.Text = "服务开启成功!";
                    break;
                case "start_error":
                    label1.Text = "服务开启失败!";
                    break;
                case "stop_success":
                    label1.Text = "服务停止成功!";
                    break;
                case "stop_error":
                    label1.Text = "服务停止失败!";
                    break;
            }
            progressBarControl1.EditValue = 100;
            if (null != MessageReceived)
            {
                MessageReceived(state, null);
            }
        }
        private void InstallService()
        {
            //string[] args = { string.Format(@"E:\source\cong\ZhuantouRemotingService\ZhuanTou.WinService\bin\Debug\ZhuanTou.WinService.exe") };// { ServiceFileName };//要安装的服务文件（就是用 InstallUtil.exe 工具安装时的参数）
            string[] args = { ServiceFileName };
            ServiceController svcCtrl = new ServiceController(ServiceName);

            try
            {
                System.Configuration.Install.ManagedInstallerClass.InstallHelper(args);
                //MessageBox.Show("服务安装成功！");
                ExecuteRes = "install_success";
                this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ExecuteRes = "install_error";
                log.Error("InstallService", ex);
                this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
                return;
            }
            try
            {
                svcCtrl.Start();
            }
            catch (Exception ex)
            {
                log.Error("安装服务完成，但是启动服务失败:", ex);
            }
        }

        private void UnInstallService()
        {
            try
            {
                //UnInstall Service
                System.Configuration.Install.AssemblyInstaller myAssemblyInstaller = new System.Configuration.Install.AssemblyInstaller();
                myAssemblyInstaller.UseNewContext = true;
                myAssemblyInstaller.Path = ServiceFileName;
                myAssemblyInstaller.Uninstall(null);
                myAssemblyInstaller.Dispose();

                //MessageBox.Show("卸载服务成功！");
                ExecuteRes = "uninstall_success";
                this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("卸载服务失败！");
                ExecuteRes = "uninstall_error";
                log.Error("UnInstallService", ex);
                this.Invoke(new EventHandler(this.ControlProgessBar), ExecuteRes);
            }
        }

        private bool ServiceIsExisted(string svcName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == svcName)
                {
                    return true;
                }
            }
            return false;
        }

    }
}