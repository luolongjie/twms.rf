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
    public partial class frmSLSearch : Form
    {
        public frmSLSearch()
        {
            InitializeComponent();
        }

        Model.Mmsg msg = null;
        Model.MLocationTray ml = null;
        int i = 0;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (txttraycode.Text == "")
            {
                MessageBox.Show("请扫描条码");
                this.txttraycode.SelectAll();
                return;
            }
            Clear();
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

        void GetInfo()
        {
            string x = HttpHelper.HttpPost("trayStock/getLocationTray", @"lcCode=" + Comm.lcCode + "&slName=" + this.txttraycode.Text + "&whId=" + Comm.warehousecode);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            ml = (Model.MLocationTray)JsonConvert.DeserializeObject(x, typeof(Model.MLocationTray));
            if (ml == null)
            {
                throw new Exception("MLocationTray捕捉失败");
            }


           
            if (ml.data == null || ml.data.Count == 0)
            {
                //this.laberror.Text = "该托盘没有任何物品";
                MessageBox.Show("货位没有数据");
                this.txttraycode.SelectAll();
                return;
            }
            if (ml.data.Count == 1)
            {
                btnNext.Visible = false;
            }
            else
            {
                btnNext.Visible = true;
            }
            i = 0;
            //this.txttraycode.Text = "";
            Next();
            this.txttraycode.SelectAll();
        }

        void Clear()
        {
            this.labinfo.Text = "";
            this.labmaterialname.Text = "";
            this.lblbarcode.Text = "";
            this.lblshippername.Text = "";
            this.laberror.Text = "";
        }

        void Next()
        {
           
            this.labinfo.Text = ml.data[i].quantity.ToString() + ml.data[i].unit + ml.data[i].minQuantity.ToString() + ml.data[i].minUnit;
            //this.cmbmaterialSurface.Text = mt.data.materialStatusStr;
            this.labmaterialname.Text = "物料信息 " + ml.data[i].materialCode + " " + ml.data[i].materialName;
          
            //this.lblmaterialcode.Text=mt.data.materialCode;
            this.lblbarcode.Text = ml.data[i].materialCode;
            this.lblshippername.Text = ml.data[i].shipperName;
            this.laberror.Text = "共" + ml.data.Count.ToString() + "条信息,当前第" + (i + 1).ToString() + "条";
            this.laberror.ForeColor = Color.Black;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ml == null || ml.data.Count == 0)
                return;
            i++;
            if (i == ml.data.Count)
            {
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

            }
            else
            {
                Next();
            }
            this.txttraycode.Focus();
            this.txttraycode.SelectAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Control co = null;
        private void btnkeybord_Click(object sender, EventArgs e)
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

        private void frmSLSearch_Load(object sender, EventArgs e)
        {
            co = this.txttraycode;
            Clear();
        }

       

       
    }
}