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
    public partial class frmMaterialInfo : Form
    {
        public frmMaterialInfo()
        {
            InitializeComponent();
        }

        Model.Mmsg msg = null;
        Model.MgetMaterialsByBar mm = null;
        int row = 0;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txttraycode.Text == "")
                return;
            //this.labcode.Text = "";
            this.labbarcode.Text = "";
            this.labmaterialname.Text = "";
            this.labspec.Text = "";
            this.labcommonunit.Text = "";
            this.labminunit.Text = "";
            this.labplate.Text = "";
            //this.labbarcode.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getMaterialsByBar", @"barCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode );
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("MgetMaterialsByBar错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mm = (Model.MgetMaterialsByBar)JsonConvert.DeserializeObject(x, typeof(Model.MgetMaterialsByBar));
                if (mm == null)
                    throw new Exception("MgetMaterialsByBar错误信息捕捉失败1");
                //this.txttraycode.Text = mm.data.trayCode;
                row = 0;

                Cursor.Current = Cursors.Default;
                if (mm.data.Count == 1)
                {
                    this.btnNext.Visible = false;
                }
                else
                {
                    this.btnNext.Visible = true;
                }
                //this.txttraycode.Text = "";
                ShowTXT();
                this.txttraycode.SelectAll();
                
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                this.txttraycode.SelectAll();
                MessageBox.Show(ex.Message);
                return;

            }
        }

        void ShowTXT()
        {
            this.labmaterialname.Text = "物料名称   " + mm.data[row].name;
            this.labspec.Text = mm.data[row].spec.ToString();
            this.labcommonunit.Text = mm.data[row].commonUnitName;
            this.labminunit.Text = mm.data[row].minUnitName;
            //int max = mm.data[row].plateX * mm.data[row].plateY;
            //this.labplate.Text = mm.data[row].plateX + "*" + mm.data[row].plateY + "=" + mm.data[row].plateCount;
            this.labplate.Text =  mm.data[row].plateCount.ToString();
            this.labbarcode.Text = mm.data[row].code;
            this.labcustomer.Text = mm.data[row].shipperName;
            //this.labcode.Text = mm.data[row].barCode;
            this.txttraycode.Focus();
            this.txttraycode.SelectAll();
        }

        private void frmMaterialInfo_Load(object sender, EventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            row++;
            if (row >= mm.data.Count)
                row = 0;
            ShowTXT();
        }

        
    }
}