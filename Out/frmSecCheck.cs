using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Rf_Wms.Out
{
    public partial class frmSecCheck : Form
    {
        public frmSecCheck()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Model.Mmsg msg = null;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            //this.txtorderid.Text = this.txtorderid.Text.Trim();
            if (this.txttraycode.Text == "")
                return;
            Model.MstartSecondarySorting v = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("startSecondarySorting", @"trayCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode+"&whCode=" + Comm.warehousecode );
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                 v = (Model.MstartSecondarySorting)JsonConvert.DeserializeObject(x, typeof(Model.MstartSecondarySorting));
                if (v == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                //this.labstockUpConfirmMsg.Text = v.data.stockUpConfirmMsg;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txttraycode.SelectAll();
                return;

            }
            if (v.data.pickType == 0 && v.data.checkType == 1)
            {
                frmNStockOutMaterial frm = new frmNStockOutMaterial();
                frm.mss = v;
                frm.ShowDialog();
            }
            else if (v.data.sortingType == 1 || v.data.sortingType == 2 || v.data.sortingType == 3)
            {
                frmNStockOut frm = new frmNStockOut();
                frm.mss = v;
                frm.ShowDialog();
            }
            else
            {
                frmStockOutCheck frm = new frmStockOutCheck();
                frm.mss = v;
                frm.ShowDialog();
            }
            this.txttraycode.Focus();
            this.txttraycode.SelectAll();
        }

        private void btnkeyboard_Click(object sender, EventArgs e)
        {
            RIL_IME.ShowIME("Letter Recognizer");
            foreach (Control v in this.Controls)
            {
                if (v is TextBox)
                {
                    if (v.Enabled)
                        v.Focus();
                }
            }
        }

     
    }
}