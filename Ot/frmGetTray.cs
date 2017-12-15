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
    public partial class frmGetTray : Form
    {
        public frmGetTray()
        {
            InitializeComponent();
        }

        Model.MStockInOrderInfoByFromTray mt = null;
        Model.Mmsg msg = null;

        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            this.laberror.Text = "";

            this.labbatchno.Text = "";
            this.labpdate.Text = "";
            this.labinfo.Text = "";
            //this.labindate.Text = "";
            this.labmaterialname.Text = "";
            this.labstr.Text = "";
            this.lblbarcode.Text = "";
            this.labblNo.Text = "";
            this.laboid.Text = "";
            //this.lblmaterialcode.Text = "";
            //this.lblslId.Text = "";
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            if (this.txttraycode.Text.Length==0)
            {
                MessageBox.Show("请扫描托盘条码");
                this.txttraycode.SelectAll();
                return;
            }
           
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetInfo();
                Cursor.Current = Cursors.Default;
              
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
               

            }
            this.txttraycode.SelectAll();
            
        }

        private void frmTray_Load(object sender, EventArgs e)
        {
            this.txttraycode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnkeybord_Click(object sender, EventArgs e)
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

        int i = 0;
        void Next()
        {
            this.labbatchno.Text = mt.data.batchNo;
            this.labpdate.Text = mt.data.pdate;
            this.labinfo.Text = mt.data.quantity.ToString() + mt.data.unit + mt.data.minQuantity.ToString() + mt.data.minUnit;
            //this.cmbmaterialSurface.Text = mt.data.materialStatusStr;
            this.labmaterialname.Text = "物料信息 " + mt.data.materialCode + " " + mt.data.materialName;
            //this.labindate.Text = mt.data.inDate;
            this.labstr.Text = mt.data.materialStatus;
            //this.lblslId.Text=mt.data.slIdName;
            //this.lblmaterialcode.Text=mt.data.materialCode;
            this.lblbarcode.Text = mt.data.barCode;
            this.laboid.Text = mt.data.oid;
            this.labblNo.Text = mt.data.blNo;
            this.txttraycode.SelectAll();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
          
        }

        void GetInfo()
        {
            string x = HttpHelper.HttpPost("getStockInOrderInfoByFromTray", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttraycode.Text + "&whId=" + Comm.warehousecode);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            mt = (Model.MStockInOrderInfoByFromTray)JsonConvert.DeserializeObject(x, typeof(Model.MStockInOrderInfoByFromTray));
            if (mt == null)
            {
                throw new Exception("getStockInOrderInfoByFromTray捕捉失败");
            }



            if (mt.data == null)
            {
                //this.laberror.Text = "该托盘没有任何物品";
                MessageBox.Show("货位没有数据");
                this.txttraycode.SelectAll();
                return;
            }
           
            //this.txttraycode.Text = "";
            Next();
            this.txttraycode.SelectAll();
        }
       
    }
}