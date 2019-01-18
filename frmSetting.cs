using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Rf_Wms
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Control co = null;
        private void btnkeyboard_Click(object sender, EventArgs e)
        {
            RIL_IME.ShowIME("Letter Recognizer");
            //foreach (Control v in this.Controls)
            //{
            //    if (v is TextBox)
            //    {
            //        if (v.Enabled)
            //            v.Focus();
            //    }
            //}
            co.Focus();
            (co as TextBox).SelectionStart = (co as TextBox).Text.Length;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            this.txturl.Text = Comm.url;
            this.txtupd.Text = Comm.upd;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Comm.url = this.txturl.Text;
            Comm.upd = this.txtupd.Text;
            string filePath = System.IO.Path.GetDirectoryName
               (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (filePath.Substring(0, 6) == @"file:\")
            {
                filePath = filePath.Substring(6);
            }
            filePath = System.IO.Path.Combine(filePath, "setting.txt");
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine(this.txturl.Text);
                sw.WriteLine(this.txtupd.Text);
                sw.Close();
            }
            this.Close();
        }

        private void txturl_GotFocus(object sender, EventArgs e)
        {
            co = txturl;
        }

        private void txtupd_GotFocus(object sender, EventArgs e)
        {
            co = txtupd;
        }

       

        private void btnConnect_Click(object sender, EventArgs e)
        {
            frmConn obj = new frmConn();
            obj.ShowDialog();
        }
    }
}