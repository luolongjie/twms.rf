using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Rf_Wms.In
{
    public partial class frmrefundshelveOne : Form
    {
        public frmrefundshelveOne()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string traycode = "";
        Model.Mmsg msg = null;
        Model.MstockinReceive mRec = null;
        private void txtcarton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txtcarton.Text == "")
                return;
            GetValue();
        }

        void GetValue()
        {
            
            this.txtcarton.Text = this.txtcarton.Text.ToUpper();
            Model.MTrayByBox mm = null;
            if (this.txtcarton.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描条码");
                this.txtcarton.SelectAll();
                return;
            }
            if (Comm.lcCode != this.txtcarton.Text.Substring(0, Comm.lcCode.Length))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txtcarton.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                    if (mm == null)
                        throw new Exception("错误信息捕捉失败");
                    this.txtcarton.Text = mm.data.trayCode;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    this.txtcarton.SelectAll();
                    MessageBox.Show(ex.Message);
                    return;

                }
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("stockinReceive", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txtcarton.Text + "&whId=" + Comm.warehousecode + "&updater=" + Comm.usercode + "&refund=true");
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("stockinReceive错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mRec = (Model.MstockinReceive)JsonConvert.DeserializeObject(x, typeof(Model.MstockinReceive));
                if (mRec == null)
                {
                    throw new Exception("stockinReceive捕捉失败");
                }
                this.labmaterialname.Text = mRec.data.material.materialName;
                //this.labrecommendSlId.Text = mRec.data.recommendSlId.ToString();
                this.labrecommendSlId.Text = mRec.data.recommendSlName;
                this.labcode.Text = mRec.data.material.materialCode;
                this.labqty.Text = mRec.data.material.quantity.ToString() + mRec.data.material.commonUnit + mRec.data.material.minQuantity.ToString() + mRec.data.material.minUnit;
                //this.txtshelve.Enabled = true;
                //this.txtshelve.Focus();
                //this.txtcarton.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            this.txtcarton.Enabled = false;
            this.txttotraycode.Enabled = true;
            this.txttotraycode.Focus();
        }

        Model.MSlIdBySlName ms = null;
        int slid;
        private void txtshelve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtshelve.Text = "";
                this.txtshelve.Enabled = false;
                //this.txtcarton.Enabled = true;
                //this.txtcarton.Text = "";
                //this.labmaterialname.Text = "";
                //this.labrecommendSlId.Text = "";
                //this.labcode.Text ="";
                //this.labqty.Text = "";
                //this.txtcarton.Focus();
                this.txttotraycode.Enabled = true;
                this.txttotraycode.Focus();
                this.txttotraycode.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (string.IsNullOrEmpty(this.txtshelve.Text.Trim()))
            {
                this.txtshelve.Enabled = false;
                this.txttotraycode.Enabled = true;
                this.txttotraycode.Focus();
                return;
            }
            //this.txtshelve.Text = this.txtshelve.Text.ToUpper();
            slid = mRec.data.recommendSlId;
            if (this.labrecommendSlId.Text == "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("trayStock/findSlIdBySlName", @"lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&slName=" + this.txtshelve.Text);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("findSlIdBySlName错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    ms = (Model.MSlIdBySlName)JsonConvert.DeserializeObject(x, typeof(Model.MSlIdBySlName));
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    this.txtshelve.SelectAll();
                    return;
                }
                slid = ms.data.slId;   
            }
            else if (this.txtshelve.Text != this.labrecommendSlId.Text)
            {
                DialogResult dr = MessageBox.Show("移入库位不是指定库位,是否继续?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr != DialogResult.Yes)
                {
                    this.txtshelve.SelectAll();
                    return;
                }
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("trayStock/findSlIdBySlName", @"lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&slName=" + this.txtshelve.Text);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("findSlIdBySlName错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    ms = (Model.MSlIdBySlName)JsonConvert.DeserializeObject(x, typeof(Model.MSlIdBySlName));
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    this.txtshelve.SelectAll();
                    return;
                }
                slid = ms.data.slId;   

            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Save();
                //getmaterial = (Model.MgetMaterial)JsonConvert.DeserializeObject(x, typeof(Model.MgetMaterial));
                //if (m == null)
                //{
                //    throw new Exception("getMaterial捕捉失败");
                //}
                //this.labneedqty.Text = getmaterial.data.quantity.ToString() + materialbody.commonUnit + getmaterial.data.minQuantity.ToString() + materialbody.minUnit;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtshelve.SelectAll();
                return;

            }
            //MessageBox.Show("上架完成");
            Init();
        }

        void Save()
        {
            string fun = "storeOperate";
            string con = @"lcCode=" + Comm.lcCode + "&fromTrayCode=" + this.txtcarton.Text + "&whId=" + Comm.warehousecode   + "&updater=" + Comm.usercode + "&recommendSlId=" + mRec.data.recommendSlId;
            if (!string.IsNullOrEmpty(this.txtshelve.Text))
            {
                con += "&slId=" + slid.ToString();
                //fun = "storeOperate";
            }
            else
            {
                con += "&toTrayCode=" + this.txttotraycode.Text;
                //fun = "storeRefundOperate";
            }
            string x = HttpHelper.HttpPost(fun, con);
           
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception(fun+"错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
        }

        void Init()
        {
            this.txtcarton.Text = "";
            this.txtshelve.Text = "";
            this.txttotraycode.Text = "";
            this.labcode.Text = "";
            this.labmaterialname.Text = "";
            this.labqty.Text = "";
            this.labrecommendSlId.Text = "";
            this.txtshelve.Enabled = false;
            this.txttotraycode.Enabled = false;
            this.txtcarton.Enabled = true;
            this.txtcarton.Focus();
        }

        private void frmshelve_Load(object sender, EventArgs e)
        {
            Init();
            if (!string.IsNullOrEmpty(traycode))
            {
                this.txtcarton.Text = traycode;
                GetValue();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.txtcarton.Enabled)
                return;
            DialogResult dr = MessageBox.Show("确定要删除托盘数据?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr != DialogResult.Yes)
            {
                //this.txtshelve.SelectAll();
                return;
            }
            try
            {

                string x = HttpHelper.HttpPost("unbindTray", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txtcarton.Text + "&whId=" + Comm.warehousecode + "&updater=" + Comm.usercode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("unbindTray错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                //getmaterial = (Model.MgetMaterial)JsonConvert.DeserializeObject(x, typeof(Model.MgetMaterial));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtshelve.SelectAll();
                return;

            }
            Init();
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

        private void txtcarton_GotFocus(object sender, EventArgs e)
        {
            txtcarton.SelectAll();
        }

        private void txttotraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtshelve.Text = "";
                this.txttotraycode.Text = "";
                this.txttotraycode.Enabled = false;
                this.txtcarton.Enabled = true;
                this.txtcarton.Text = "";
                this.labmaterialname.Text = "";
                this.labrecommendSlId.Text = "";
                this.labcode.Text = "";
                this.labqty.Text = "";
                this.txtcarton.Focus();
            }
            if (e.KeyChar != 13)
                return;
            if (string.IsNullOrEmpty(this.txttotraycode.Text.Trim()) || this.txttotraycode.Text==this.txtcarton.Text)
            {
                this.txttotraycode.Enabled = false;
                this.txtshelve.Enabled = true;
                this.txtshelve.Focus();
                return;
            }
            Model.MTrayByBox mm = null;
            if (this.txttotraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描条码");
                this.txttotraycode.SelectAll();
                return;
            }
            if (Comm.lcCode != this.txttotraycode.Text.Substring(0, Comm.lcCode.Length))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                    if (mm == null)
                        throw new Exception("错误信息捕捉失败");
                    this.txtcarton.Text = mm.data.trayCode;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    this.txtcarton.SelectAll();
                    MessageBox.Show(ex.Message);
                    return;

                }
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //string x = HttpHelper.HttpPost("toTrayCodeRefundVerify", @"toTrayCodeRefundVerify=" + this.txttotraycode.Text.Trim() + "&lcCode=" + Comm.lcCode + "&fromTrayCode=" + this.txtcarton.Text.Trim());
                string x = HttpHelper.HttpPost("toTrayCodeStockInVerify", @"toTrayCode=" + this.txttotraycode.Text.Trim() + "&lcCode=" + Comm.lcCode + "&fromTrayCode=" + this.txtcarton.Text.Trim());
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Cursor.Current = Cursors.Default;
                Model.Mccode mcc = (Model.Mccode)JsonConvert.DeserializeObject(x, typeof(Model.Mccode));
                if (!string.IsNullOrEmpty(mcc.data))
                {
                    DialogResult dr = MessageBox.Show(mcc.data, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dr != DialogResult.Yes)
                    {
                        this.txtshelve.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtshelve.SelectAll();
                return;

            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Save();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtshelve.SelectAll();
                return;

            }
            Init();
        }

        private void txttotraycode_GotFocus(object sender, EventArgs e)
        {
            this.txttotraycode.SelectAll();
        }

        private void txtshelve_GotFocus(object sender, EventArgs e)
        {
            this.txtshelve.SelectAll();
        }

       
    }
}