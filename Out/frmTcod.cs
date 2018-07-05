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
    public partial class frmTcod : Form
    {
        public string tcod = "";
        public string plateNo = "";
        public frmTcod()
        {
            InitializeComponent();
        }

        int i = 0;
        Model.Mmsg msg = null;
        Model.Mtcod mt = null;
        private void frmTcod_Load(object sender, EventArgs e)
        {
            Init();
        }

        void Init()
        {
            try
            {
                i = 0;
                Cursor.Current = Cursors.WaitCursor;
                string con = @"&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&tcod=" + tcod;
                string x = HttpHelper.HttpPost("loadTcodQuantityList", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mt = (Model.Mtcod)JsonConvert.DeserializeObject(x, typeof(Model.Mtcod));
                if (mt == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                //if (mt.data == "")
                //{
                //    throw new Exception("没有数据");
                //}
                Cursor.Current = Cursors.Default;
                ShowTxt();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void ShowTxt()
        {
            this.labblnum.Text = mt.data.blNum.ToString();
            this.labdriver.Text = mt.data.driver;
            this.labload.Text = mt.data.loadQuantity + "箱" + mt.data.loadMinQuantity + "件";
            this.labreal.Text = mt.data.realQuantity + "箱" + mt.data.realMinQuantity + "件";
            this.labplantNo.Text = plateNo;
            this.labtcod.Text = tcod;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                i = 0;
                Cursor.Current = Cursors.WaitCursor;
                string con = @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&tcod=" + tcod;
                string x = HttpHelper.HttpPost("loadConfirm", con);
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
            this.Close();
        }

        private void btnbalance_Click(object sender, EventArgs e)
        {
            frmBalOper frm = new frmBalOper();
            frm.tcod = tcod;
            frm.ShowDialog();
            Comm.islog = false;
            Init();
        }
     

       
    }
}