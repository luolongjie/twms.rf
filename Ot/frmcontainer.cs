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
    public partial class frmcontainer : Form
    {
        public frmcontainer()
        {
            InitializeComponent();
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

        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (txttraycode.Text == "")
            {
                //MessageBox.Show("请扫描容器条码");
                //this.txttraycode.SelectAll();
                return;
            }
            //Clear();
            this.lblcombineContent.Text = "";
            this.lblpickTypeName.Text = "";
            this.lblpickno.Text = "";
            this.lblqty.Text = "";
            mm = null;
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

        Model.Mmsg msg = null;
        Model.MContainer mm = null;
        void GetInfo()
        {
            string x = HttpHelper.HttpPost("containerQuery", @"lcCode=" + Comm.lcCode + "&toTrayCode=" + this.txttraycode.Text + "&whId=" + Comm.warehousecode);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            mm = (Model.MContainer)JsonConvert.DeserializeObject(x, typeof(Model.MContainer));
            if (mm == null)
            {
                throw new Exception("containerQuery捕捉失败");
            }
            mm.data.toTrayCode = this.txttraycode.Text;
            if (!string.IsNullOrEmpty(mm.data.combineTypeName))
            {
                this.lblcombineContent.Text = mm.data.combineTypeName;
            }
            if (!string.IsNullOrEmpty(mm.data.combineTypeName) && !string.IsNullOrEmpty(mm.data.combineContent))
            {
                this.lblcombineContent.Text += "-";

            }
            if (!string.IsNullOrEmpty(mm.data.combineContent))
            {
                this.lblcombineContent.Text += mm.data.combineContent;
            }
            this.lblpickTypeName.Text = mm.data.pickTypeName;
            this.lblpickno.Text = mm.data.pickNo;
            this.lblqty.Text = mm.data.pickQuantity + "箱" + mm.data.pickMinQuantity + "件";
            this.lblsortingTypeName.Text = mm.data.sortingTypeName;

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            if (mm == null)
                return;
            
            DataTable dt = new DataTable();
            dt.Columns.Add("materialCode");
            dt.Columns.Add("materialName");
            dt.Columns.Add("serial");
            dt.Columns.Add("batchNo");
            dt.Columns.Add("slName");
            dt.Columns.Add("qty");

            DataRow dr;
            int i=0;
            foreach (Model.pickOperateDTOSs v in mm.data.pickOperateDTOS)
            {
                i++;
                dr = dt.NewRow();
                dr["serial"] = i;
                dr["materialCode"] = v.materialCode;
                dr["materialName"] = v.materialName;
                dr["batchNo"] = v.batchNo;
                dr["slName"] = v.fromSlName;
                dr["qty"] = v.quantity + v.commonUnitName + v.minQuantity + v.minUnitName;
                dt.Rows.Add(dr);
            }
            frmNcontainerList frm = new frmNcontainerList();
            frm.dt = dt;
            frm.ShowDialog();
            this.txttraycode.Focus();
            this.txttraycode.SelectAll();
        }
       
    }
}