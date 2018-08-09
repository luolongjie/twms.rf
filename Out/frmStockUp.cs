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
    public partial class frmStockUp : Form
    {
        public frmStockUp()
        {
            InitializeComponent();
        }

        private void btnkeyboard_Click(object sender, EventArgs e)
        {
            //RIL_IME.ShowIME("键盘");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Model.Mmsg msg = null;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            this.labstockUpConfirmMsg.Text = "";
            this.labpick.Text = "";
            this.labcheck.Text = "";
            this.labcheckorder.Text = "";
            this.txtorderid.Text = this.txtorderid.Text.Trim();
            if (this.txtorderid.Text == "")
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("doStockUpConfirm", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&updater=" + Comm.usercode + "&whCode=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.MdoStockUpConfirm v = (Model.MdoStockUpConfirm)JsonConvert.DeserializeObject(x, typeof(Model.MdoStockUpConfirm));
                if (v == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                this.labstockUpConfirmMsg.Text = v.data.stockUpConfirmMsg;
                this.labpick.Text = v.data.pickQuantity + "箱" + v.data.pickMinQuantity + "个";
                this.labcheck.Text = v.data.checkQuantity + "箱" + v.data.checkMinQuantity + "个";
                this.labcheckorder.Text = v.data.checkOrderQuantity + "箱" + v.data.checkOrderMinQuantity + "个";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtorderid.SelectAll();
                return;

            }
        }

        private void frmStockUp_Load(object sender, EventArgs e)
        {
            this.labstockUpConfirmMsg.Text = "";
            this.labpick.Text = "";
            this.labcheck.Text = "";
            this.labcheckorder.Text = "";
        }

      
    }
}