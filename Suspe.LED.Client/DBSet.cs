using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suspe.LED.Client
{

    public partial class DBSet : Form
    {
        private readonly static ILog log = LogManager.GetLogger(typeof(Index));
        public DBSet()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveSetConfig_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveSetConfig.Cursor = Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                btnSaveSetConfig.Cursor = Cursors.Default;
            }
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveSetConfig.Cursor = Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                btnSaveSetConfig.Cursor = Cursors.Default;
            }

        }
    }
}
