using DevExpress.XtraEditors;
using log4net;
using Microsoft.Data.ConnectionUI;
using SuspeSys.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Suspe.LED.Client
{
    public partial class Index : Form
    {
        private readonly static ILog log = LogManager.GetLogger(typeof(Index));
        public Index()
        {
            InitializeComponent();
            var windowServicePath = "ServicePath/Suspe.LED.WinService.exe";
            var fileInfo = new FileInfo(windowServicePath);
            servicePath = fileInfo.FullName;
            _frmServiceStatus = new SusStatus();
            _frmServiceStatus.SetServiceName(ServiceName);
            _frmServiceStatus.SetServiceFileName(ServiceFileName);
            _frmServiceStatus.MessageReceived += _frmServiceStatus_MessageReceived;
        }

        private void _frmServiceStatus_MessageReceived(object sender, MessageEventArgs e)
        {
            string status = sender?.ToString();
            switch (status)
            {
                case "install_success":
                    //btnInstallService.Enabled = false;
                    //btnUninstallService.Enabled = true;
                    break;
                case "install_error":
                    //btnInstallService.Enabled = true;
                    //btnUninstallService.Enabled = false;
                    break;
                case "uninstall_success":
                    //btnInstallService.Enabled = true;
                    //btnUninstallService.Enabled = false;
                    break;
                case "uninstall_error":
                    //btnInstallService.Enabled = false;
                    //btnUninstallService.Enabled = true;
                    break;
                case "start_success":
                    //btnStartService.Enabled = false;
                    //btnStopService.Enabled = true;
                    break;
                case "start_error":
                    //btnStartService.Enabled = true;
                    //btnStopService.Enabled = false;
                    break;
                case "stop_success":
                    //btnStartService.Enabled = true;
                    //btnStopService.Enabled = false;
                    break;
                case "stop_error":
                    //btnStartService.Enabled = false;
                    //btnStopService.Enabled = true;
                    break;
            }
        }

        private string servicePath;
        SusStatus _frmServiceStatus;
        private String ServiceName = "Suspe.LEDService";
        static string ServiceFileName = "Suspe.LED.WinService.exe";
        private void tsMenuItemInstallService_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var isExs = WinServiceUtils.ServiceIsExisted(ServiceName);
                if (isExs)
                {
                    XtraMessageBox.Show("服务已安装！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (string.IsNullOrEmpty(servicePath))
                {
                    XtraMessageBox.Show("服务不存在,请检查服务程序是否存在！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                _frmServiceStatus.SetServiceFileName(servicePath);
                _frmServiceStatus.ExecuteRes = "";
                _frmServiceStatus.SetExecuteMethod("install");
                if (_frmServiceStatus.ShowDialog(this) == DialogResult.OK)
                {
                    if (_frmServiceStatus.ExecuteRes == "install_success")
                    {
                        XtraMessageBox.Show("服务安装成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //btnInstallService.Enabled = false;
                        //btnUninstallService.Enabled = !btnInstallService.Enabled;
                    }
                    else if (_frmServiceStatus.ExecuteRes == "install_error")
                    {
                        XtraMessageBox.Show("服务安装失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // btnInstallService.Enabled = true;
                        // btnInstallService.Enabled = !btnInstallService.Enabled;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsMenuItemUnInstallService_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var isExs = WinServiceUtils.ServiceIsExisted(ServiceName);
                if (!isExs)
                {
                    XtraMessageBox.Show("服务未安装！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(servicePath))
                {
                    XtraMessageBox.Show("请选择服务文件(exe)！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _frmServiceStatus.SetServiceFileName(servicePath);
                _frmServiceStatus.ExecuteRes = "";
                _frmServiceStatus.SetExecuteMethod("uninstall");
                if (_frmServiceStatus.ShowDialog(this) == DialogResult.OK)
                {
                    if (_frmServiceStatus.ExecuteRes == "uninstall_success")
                    {
                        XtraMessageBox.Show("服务卸载成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //btnInstallService.Enabled = true;
                        //btnUninstallService.Enabled = !btnInstallService.Enabled;
                    }
                    else if (_frmServiceStatus.ExecuteRes == "uninstall_error")
                    {
                        XtraMessageBox.Show("服务卸载失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //btnInstallService.Enabled = false;
                        //btnUninstallService.Enabled = !btnInstallService.Enabled;
                    }

                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsMenuItemServiceStatus_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //if (string.IsNullOrEmpty(txtServiceExePath.Text.Trim()))
                //{
                //    MessageBox.Show("请选择服务文件(exe)！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (!WinServiceUtils.ISWindowsServiceInstalled(ServiceName))
                {
                    XtraMessageBox.Show("服务没有安装!");
                    return;
                }
                if (WinServiceUtils.ISStart(ServiceName))
                {
                    XtraMessageBox.Show("服务已在运行中...!");
                    return;
                }

                //string errMsg = string.Empty;
                //bool result = WinServiceUtils.StartService(ServiceName, ref errMsg);
                //if (result)
                //{
                //    MessageBox.Show("服务启动成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("启动失败!" + errMsg);
                //}
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsMenuItemDBSet_Click(object sender, EventArgs e)
        {
            Microsoft.Data.ConnectionUI.DataConnectionDialog connDialog = new Microsoft.Data.ConnectionUI.DataConnectionDialog();
            connDialog.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.AccessDataSource); // Access 
            connDialog.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.OdbcDataSource); // ODBC
            connDialog.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.OracleDataSource); // Oracle 
            connDialog.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.SqlDataSource); // Sql Server
            connDialog.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.SqlFileDataSource); // Sql Server File
            // 初始化
            connDialog.SelectedDataSource = Microsoft.Data.ConnectionUI.DataSource.SqlDataSource;
            connDialog.SelectedDataProvider = Microsoft.Data.ConnectionUI.DataProvider.SqlDataProvider;

            //// connDialog.ConnectionString = conn;
            // connDialog.Show();
            //var dr=DataConnectionDialog.Show(connDialog);
            if (Microsoft.Data.ConnectionUI.DataConnectionDialog.Show(connDialog) == DialogResult.OK)
            {

                string myConnect = connDialog.ConnectionString;
                try
                {
                    SetSuspeLEDClientDBConfig(myConnect);
                    SetSuspeLEDWindowsServiceDBConfig(myConnect);
                }
                catch (Exception ex) {
                    log.Error(ex);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static void SetSuspeLEDClientDBConfig(string myConnect)
        {
            XmlDocument myDoc = new XmlDocument();
            XmlElement myXmlElement;
            myDoc.Load(Application.StartupPath + "\\Suspe.LED.Client.exe.config");//加载启动目录下的App.config配置文件
            XmlNode myNode = myDoc.SelectSingleNode("//appSettings");//查找appSettings结点
            myXmlElement = (XmlElement)myNode.SelectSingleNode("//add [@key='ConnectionString']");//查找add结点中key=sql的结点
            myXmlElement.SetAttribute("value", myConnect);//获取该结点中value值
            myDoc.Save(Application.StartupPath + "//Suspe.LED.Client.exe.config");//保存到启动目录下的App.config配置文件
        }
        private static void SetSuspeLEDWindowsServiceDBConfig(string myConnect)
        {
            XmlDocument myDoc = new XmlDocument();
            XmlElement myXmlElement;
            myDoc.Load(Application.StartupPath + "\\ServicePath\\Suspe.LED.WinService.exe.config");//加载启动目录下的App.config配置文件
            XmlNode myNode = myDoc.SelectSingleNode("//appSettings");//查找appSettings结点
            myXmlElement = (XmlElement)myNode.SelectSingleNode("//add [@key='ConnectionString']");//查找add结点中key=sql的结点
            myXmlElement.SetAttribute("value", myConnect);//获取该结点中value值
            myDoc.Save(Application.StartupPath + "//ServicePath//Suspe.LED.WinService.exe.config");//保存到启动目录下的App.config配置文件
        }
        private void BindGridProcessDailyProducts()
        {
            dvProcessDailyProducts.Columns.Clear();

            dvProcessDailyProducts.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "MONo", HeaderText = "制单号" });
            dvProcessDailyProducts.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "TAim", HeaderText = "计划" });
            dvProcessDailyProducts.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "TOutput", HeaderText = "实际" });
            dvProcessDailyProducts.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "TEff", HeaderText = "达成率" });


            DataTable dt = new DataTable();
            dt.Columns.Add("MONo");
            dt.Columns.Add("TAim");
            dt.Columns.Add("TOutput");
            dt.Columns.Add("TEff");
            for (var index = 1; index < 6; index++)
            {
                DataRow dr = dt.NewRow();
                dr["MONo"] = "P0" + index.ToString();
                dr["TAim"] = 100 * index;
                dr["TOutput"] = 200 * index;
                dr["TEff"] = (10 * index) + "%";
                dt.Rows.Add(dr);
            }
            dvProcessDailyProducts.DataSource = dt;
        }
        private void BindGridHourlyRate()
        {
            dvHourlyRate.Columns.Clear();

            dvHourlyRate.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "vRow", HeaderText = "Time" });
            dvHourlyRate.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "PlanQty", HeaderText = "Plan" });
            dvHourlyRate.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "TOutput", HeaderText = "Actual" });
            dvHourlyRate.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Eff", HeaderText = "Fulfill" });
            dvHourlyRate.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EffFail", HeaderText = "FPY" });

            DataTable dt = new DataTable();
            dt.Columns.Add("vRow");
            dt.Columns.Add("PlanQty");
            dt.Columns.Add("TOutput");
            dt.Columns.Add("Eff");
            dt.Columns.Add("EffFail");
            for (var index = 1; index < 6; index++)
            {
                DataRow dr = dt.NewRow();
                dr["vRow"] = string.Format("{0}pm-{1}pm", index * 1, index * 2);
                dr["PlanQty"] = 100 * index;
                dr["TOutput"] = 200 * index;
                dr["Eff"] = (10 * index) + "%";
                dr["EffFail"] = (10 * index) + "%";
                dt.Rows.Add(dr);
            }
            dvHourlyRate.DataSource = dt;
        }
        ScreenCfg cg;
        private void Index_Load(object sender, EventArgs e)
        {
            cg = new ScreenCfg();
            cg.guid = new Guid();
            cg.ScreenNo = 1;
            cg.ScreenType = 1;
            cg.CommType = 1;
            cg.Width = 320;
            cg.Height = 64;
            cg.IpAdress = "192.168.1.250";
            cg.NetPort = 5005;
            cg.ColorType = 1;
            cg.Line_guid = new Guid();

            BindGridProcessDailyProducts();
            BindGridHourlyRate();
        }
        //推送小时计划达成率
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                btnStop.Cursor = Cursors.WaitCursor;
                var dt = (dvHourlyRate.DataSource as DataTable).Copy();
                new SendAction().PageHourPlanV2(cg, false, true, dt);
                MessageBox.Show("推送完成!");
            }
            finally
            {
                btnStop.Cursor = Cursors.Default;
            }


        }
        //推送制单日产量/
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Cursor = Cursors.WaitCursor;
                var dt = (dvProcessDailyProducts.DataSource as DataTable).Copy();
                new SendAction().PageDailyPlan(cg, false, true, dt);
                MessageBox.Show("推送完成!");
            }
            finally
            {
                btnStart.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                btnStart.Cursor = Cursors.WaitCursor;
                var text = txtContent.Text.Trim();
                var productName = txtContent.Text.Trim();
                new SendAction().sendCustInfo(cg, text, productName);
                MessageBox.Show("推送完成!");
            }
            finally
            {
                btnStart.Cursor = Cursors.Default;
            }
        }

        private void btnServiceDocktopTest_Click(object sender, EventArgs e)
        {
            btnServiceDocktopTest.Cursor = Cursors.WaitCursor;
            try
            {
                new WinService.SusLedMain().OnStart();
                MessageBox.Show("任务已启动");
            }
            finally
            {
                btnServiceDocktopTest.Cursor = Cursors.Default;
            }
        }

        private void tsMenuItemStopService_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!WinServiceUtils.ISWindowsServiceInstalled(ServiceName))
                {
                    XtraMessageBox.Show("服务没有安装!");
                    return;
                }
                Exception err = null;
                if (WinServiceUtils.StopService(ServiceName,ref err))
                {
                    XtraMessageBox.Show("服务已停止!");
                    return;
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsMenuItemStartService_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!WinServiceUtils.ISWindowsServiceInstalled(ServiceName))
                {
                    XtraMessageBox.Show("服务没有安装!");
                    return;
                }
                if (WinServiceUtils.ISStart(ServiceName))
                {
                    XtraMessageBox.Show("服务已在运行中...!");
                    return;
                }

                Exception err = null;
                if (WinServiceUtils.StartService(ServiceName, ref err))
                {
                    XtraMessageBox.Show("服务已启动!");
                    return;
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
