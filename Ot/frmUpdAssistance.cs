using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Rf_Wms.Ot
{
    public partial class frmUpdAssistance : Form
    {
        public frmUpdAssistance()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string orderid = "";
        public string fun = "";
        public string assistance = "";
        private void txtassistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            Model.Mmsg msg = null;
            Model.MUserInfo mu = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getUserInfo", @"lcCode=" + Comm.lcCode + "&account="  + this.txtassistance.Text );
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mu = (Model.MUserInfo)JsonConvert.DeserializeObject(x, typeof(Model.MUserInfo));
                if(mu==null || mu.data==null || mu.data.userCode=="")
                    throw new Exception("错误信息捕捉失败");
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                this.txtassistance.SelectAll();
                MessageBox.Show(ex.Message);
                return;

            }
           

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost(fun, @"lcCode=" + Comm.lcCode + "&orderId=" + orderid + "&assistance=" + mu.data.userCode + "&whId=" + Comm.warehousecode+"&updater="+Comm.usercode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            MessageBox.Show("完成");
            //assistance = mu.data.userCode;
            assistance = mu.data.assistanceName;
            //assistance = mu.data.userName;
            this.Close();
        }

        private void frmUpdAssistance_Load(object sender, EventArgs e)
        {
            this.labcode.Text = orderid;
            this.txtassistance.SelectAll();
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