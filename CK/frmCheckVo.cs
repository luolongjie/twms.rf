using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Rf_Wms.CK
{
    public partial class frmCheckVo : Form
    {
        public frmCheckVo()
        {
            InitializeComponent();
        }

        Model.Mmsg msg = null;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            try
            {
                string x = HttpHelper.HttpPost("getCheckItem", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtorderid.SelectAll();
                return;

            }
            //this.labbatchNo.Text = mtrans.data.batchNo;
            this.txtorderid.Enabled = false;
            this.txtSlId.Enabled = true;
            this.txtSlId.Focus();
        }

        private void txtorderid_GotFocus(object sender, EventArgs e)
        {
            txtorderid.SelectAll();
        }

        
    }
}