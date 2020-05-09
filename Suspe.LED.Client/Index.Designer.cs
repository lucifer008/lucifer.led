namespace Suspe.LED.Client
{
    partial class Index
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemInstallService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemUnInstallService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemServiceStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemDBSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemStopService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemStartService = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnServiceDocktopTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtFre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dvProcessDailyProducts = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dvHourlyRate = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvProcessDailyProducts)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvHourlyRate)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemInstallService,
            this.tsMenuItemUnInstallService,
            this.tsMenuItemServiceStatus,
            this.tsMenuItemDBSet,
            this.tsMenuItemStopService,
            this.tsMenuItemStartService});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem1.Text = "服务管理";
            // 
            // tsMenuItemInstallService
            // 
            this.tsMenuItemInstallService.Name = "tsMenuItemInstallService";
            this.tsMenuItemInstallService.Size = new System.Drawing.Size(160, 22);
            this.tsMenuItemInstallService.Text = "安装服务";
            this.tsMenuItemInstallService.Click += new System.EventHandler(this.tsMenuItemInstallService_Click);
            // 
            // tsMenuItemUnInstallService
            // 
            this.tsMenuItemUnInstallService.Name = "tsMenuItemUnInstallService";
            this.tsMenuItemUnInstallService.Size = new System.Drawing.Size(160, 22);
            this.tsMenuItemUnInstallService.Text = "卸载服务";
            this.tsMenuItemUnInstallService.Click += new System.EventHandler(this.tsMenuItemUnInstallService_Click);
            // 
            // tsMenuItemServiceStatus
            // 
            this.tsMenuItemServiceStatus.Name = "tsMenuItemServiceStatus";
            this.tsMenuItemServiceStatus.Size = new System.Drawing.Size(160, 22);
            this.tsMenuItemServiceStatus.Text = "服务运行状态";
            this.tsMenuItemServiceStatus.Click += new System.EventHandler(this.tsMenuItemServiceStatus_Click);
            // 
            // tsMenuItemDBSet
            // 
            this.tsMenuItemDBSet.Name = "tsMenuItemDBSet";
            this.tsMenuItemDBSet.Size = new System.Drawing.Size(160, 22);
            this.tsMenuItemDBSet.Text = "数据库服务配置";
            this.tsMenuItemDBSet.Click += new System.EventHandler(this.tsMenuItemDBSet_Click);
            // 
            // tsMenuItemStopService
            // 
            this.tsMenuItemStopService.Name = "tsMenuItemStopService";
            this.tsMenuItemStopService.Size = new System.Drawing.Size(160, 22);
            this.tsMenuItemStopService.Text = "停止服务";
            this.tsMenuItemStopService.Click += new System.EventHandler(this.tsMenuItemStopService_Click);
            // 
            // tsMenuItemStartService
            // 
            this.tsMenuItemStartService.Name = "tsMenuItemStartService";
            this.tsMenuItemStartService.Size = new System.Drawing.Size(160, 22);
            this.tsMenuItemStartService.Text = "启动服务";
            this.tsMenuItemStartService.Click += new System.EventHandler(this.tsMenuItemStartService_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem2.Text = "帮助";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnServiceDocktopTest);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.txtFre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 100);
            this.panel1.TabIndex = 1;
            // 
            // btnServiceDocktopTest
            // 
            this.btnServiceDocktopTest.Location = new System.Drawing.Point(727, 29);
            this.btnServiceDocktopTest.Name = "btnServiceDocktopTest";
            this.btnServiceDocktopTest.Size = new System.Drawing.Size(75, 23);
            this.btnServiceDocktopTest.TabIndex = 4;
            this.btnServiceDocktopTest.Text = "服务界面化测试";
            this.btnServiceDocktopTest.UseVisualStyleBackColor = true;
            this.btnServiceDocktopTest.Visible = false;
            this.btnServiceDocktopTest.Click += new System.EventHandler(this.btnServiceDocktopTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "自定义发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(448, 23);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(122, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "推送小时计划达成率";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(287, 23);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(122, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "推送制单日产量";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtFre
            // 
            this.txtFre.Location = new System.Drawing.Point(96, 26);
            this.txtFre.Name = "txtFre";
            this.txtFre.Size = new System.Drawing.Size(140, 21);
            this.txtFre.TabIndex = 1;
            this.txtFre.Text = "5";
            this.txtFre.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "推送间隔";
            this.label1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 478);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(830, 478);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dvProcessDailyProducts);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(822, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "制单日产量";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dvProcessDailyProducts
            // 
            this.dvProcessDailyProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvProcessDailyProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvProcessDailyProducts.Location = new System.Drawing.Point(3, 3);
            this.dvProcessDailyProducts.Name = "dvProcessDailyProducts";
            this.dvProcessDailyProducts.RowTemplate.Height = 23;
            this.dvProcessDailyProducts.Size = new System.Drawing.Size(816, 446);
            this.dvProcessDailyProducts.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dvHourlyRate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1362, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "小时计划达成率";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dvHourlyRate
            // 
            this.dvHourlyRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvHourlyRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvHourlyRate.Location = new System.Drawing.Point(3, 3);
            this.dvHourlyRate.Name = "dvHourlyRate";
            this.dvHourlyRate.RowTemplate.Height = 23;
            this.dvHourlyRate.Size = new System.Drawing.Size(1356, 483);
            this.dvHourlyRate.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Wheat;
            this.tabPage3.Controls.Add(this.txtContent);
            this.tabPage3.Controls.Add(this.txtCompany);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1362, 489);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "自定义";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(92, 133);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(313, 102);
            this.txtContent.TabIndex = 1;
            this.txtContent.Text = "3B11组\r\n组长：王兴发";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(92, 66);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(313, 21);
            this.txtCompany.TabIndex = 1;
            this.txtCompany.Text = "厦门市麦仕德智能科技有限公司";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "内容:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "公司:";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Index";
            this.Text = "LED服务配置程序";
            this.Load += new System.EventHandler(this.Index_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvProcessDailyProducts)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvHourlyRate)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemInstallService;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemUnInstallService;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemServiceStatus;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemDBSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFre;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dvProcessDailyProducts;
        private System.Windows.Forms.DataGridView dvHourlyRate;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnServiceDocktopTest;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemStopService;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemStartService;
    }
}

