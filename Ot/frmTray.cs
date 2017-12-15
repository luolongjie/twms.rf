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
    public partial class frmTray : Form
    {
        public frmTray()
        {
            InitializeComponent();
        }

        Model.MTrayStockByOrderType mt = null;
        Model.Mmsg msg = null;
        Model.MTrayByBox mm = null;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            this.laberror.Text = "";

            this.labbatchno.Text = "";
            this.labpdate.Text = "";
            this.labinfo.Text = "";
            this.labindate.Text = "";
            this.labmaterialname.Text = "";
            this.labstr.Text = "";
            this.lblbarcode.Text = "";
            //this.lblmaterialcode.Text = "";
            this.lblslId.Text = "";
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            if (this.txttraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描条码");
                this.txttraycode.SelectAll();
                return;
            }
            if (Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("getTrayByBox错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                    if (mm == null)
                        throw new Exception("getTrayByBox错误信息捕捉失败1");
                    this.txttraycode.Text = mm.data.trayCode;


                    Cursor.Current = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    this.txttraycode.SelectAll();
                    MessageBox.Show(ex.Message);
                    return;

                }
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //string x = HttpHelper.HttpPost("trayStock/findTrayStockByOrderType", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttraycode.Text + "&type=2" );
                string x = HttpHelper.HttpPost("trayStock/findTrayStockByOrderType", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttraycode.Text + "&whId=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mt = (Model.MTrayStockByOrderType)JsonConvert.DeserializeObject(x, typeof(Model.MTrayStockByOrderType));
                if (mt == null)
                {
                    throw new Exception("findTrayStockByOrderType捕捉失败");
                }

               
                Cursor.Current = Cursors.Default;
                if (mt.data == null || string.IsNullOrEmpty(mt.data.materialCode))
                {
                    //this.laberror.Text = "该托盘没有任何物品";
                    MessageBox.Show("托盘不存在!");
                    this.txttraycode.SelectAll();
                    return;
                }
                //this.txttraycode.Text = "";
                this.labbatchno.Text = mt.data.batchNo;
                this.labpdate.Text = mt.data.pdate;
                this.labinfo.Text =  mt.data.quantity.ToString() + mt.data.commonUnitName + mt.data.minQuantity.ToString() + mt.data.minUnitName;
                //this.cmbmaterialSurface.Text = mt.data.materialStatusStr;
                this.labmaterialname.Text = "物料信息 "+mt.data.materialCode+" "+mt.data.materialName;
                this.labindate.Text = mt.data.inDate;
                this.labstr.Text = mt.data.materialStatusStr;
                this.lblslId.Text=mt.data.slIdName;
                //this.lblmaterialcode.Text=mt.data.materialCode;
                this.lblbarcode.Text = mt.data.barCode;
                this.txttraycode.SelectAll();
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

       
    }
}