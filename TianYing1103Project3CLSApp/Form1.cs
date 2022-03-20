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

namespace TianYing1103Project3CLSApp
{
    public partial class frmCreative : Form
    {
        private Icon m_ready=new Icon(SystemIcons.Information,40,40);

        public frmCreative()
        {
            InitializeComponent();
        }

        private void frmCreative_Load(object sender, EventArgs e)
        {
            txtSource.Text = "D:\\Creative\\Source\\";
            txtProcessedFile.Text = "D:\\Creative\\Processed\\";
            txtDest.Text = "D:\\Creative\\Destination\\";
            opsGenerateLog.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Source
            if (!Directory.Exists(txtSource.Text))
            {
                errMessage.SetError(txtSource, "Invalid Source Directory");
                txtSource.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtSource, "");
            //ProcessedFile
            if (!Directory.Exists(txtProcessedFile.Text))
            {
                errMessage.SetError(txtProcessedFile, "Invalid Processed File Directory");
                txtProcessedFile.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtProcessedFile, "");
          //  dest
            if (!Directory.Exists(txtDest.Text))
            {
                errMessage.SetError(txtDest, "Invalid Destination Directory");
                txtDest.Focus();
                tabControl1.SelectedTab = tabDest;
                return;
            }
            else
                errMessage.SetError(txtDest, "");
            //end vaildation

            //activate watching
            watchDir.EnableRaisingEvents = true;
            watchDir.Path= txtSource.Text;
            //notification
            mnuNotify.Icon = m_ready;
            mnuNotify.Visible = true;
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            //validate source
            if (Directory.Exists(txtSource.Text))
            {
                //no error
                txtSource.BackColor = Color.White;
            }
            else
            {
                //error
                txtSource.BackColor= Color.Pink;
            }
        }

        private void txtProcessedFile_KeyUp(object sender, KeyEventArgs e)
        {
 //validate Processed
            if (Directory.Exists(txtProcessedFile.Text))
            {
                //no error
                txtProcessedFile.BackColor = Color.White;
            }
            else
            {
                //error
                txtProcessedFile.BackColor = Color.Pink;
            }
        }

        private void txtDest_KeyUp(object sender, KeyEventArgs e)
        {
 //validate Destination
            if (Directory.Exists(txtDest.Text))
            {
                //no error
                txtDest.BackColor = Color.White;
            }
            else
            {
                //error
                txtDest.BackColor = Color.Pink;
            }
        }

        private void configureApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuNotify.Visible= false;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuNotify_DoubleClick(object sender, EventArgs e)
        {
            mnuNotify.Visible = false;
            this.ShowInTaskbar= true;
            this.Show();
        }
    }
}
