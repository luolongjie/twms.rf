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
    public partial class frmshelve : Form
    {
        public frmshelve()
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
            if (string.IsNullOrEmpty(this.txtcarton.Text))
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
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txtcarton.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&updater=" + Comm.usercode);
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
                if (string.IsNullOrEmpty(this.txtcarton.Text))
                    throw new Exception("请扫描托盘码");
                string x = HttpHelper.HttpPost("stockinReceive", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txtcarton.Text + "&whCode=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("stockinReceive错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mRec = (Model.MstockinReceive)JsonConvert.DeserializeObject(x, typeof(Model.MstockinReceive));
                if (mRec == null)
                {
                    throw new Exception("getMaterial捕捉失败");
                }
                this.labmaterialname.Text = mRec.data.material.materialName;
                //this.labrecommendSlId.Text = mRec.data.recommendSlId.ToString();
                this.labrecommendSlId.Text = mRec.data.recommendSlName;
                this.labcode.Text = mRec.data.material.materialCode;
                this.labqty.Text = mRec.data.material.quantity.ToString() + mRec.data.material.commonUnit + mRec.data.material.minQuantity.ToString() + mRec.data.material.minUnit;
                this.txtshelve.Enabled = true;
                this.txtshelve.Focus();
                this.txtcarton.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtcarton.Focus();
                this.txtcarton.SelectAll();
                return;

            }
            this.txtcarton.Enabled = false;
            this.txtshelve.Enabled = true;
            this.txtshelve.Focus();
        }

        Model.MSlIdBySlName ms = null;
        private void txtshelve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtshelve.Text = "";
                this.txtshelve.Enabled = false;
                this.txtcarton.Enabled = true;
                this.txtcarton.Text = "";
                this.labmaterialname.Text = "";
                this.labrecommendSlId.Text = "";
                this.labcode.Text ="";
                this.labqty.Text = "";
                this.txtcarton.Focus();
            }
            if (e.KeyChar != 13)
                return;
            if (this.txtshelve.Text == "")
                return;
            //this.txtshelve.Text = this.txtshelve.Text.ToUpper();
            int slid = mRec.data.recommendSlId;
            if (this.labrecommendSlId.Text == "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("trayStock/findSlIdBySlNameNoZC", @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&slName=" + this.txtshelve.Text);
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
                    string x = HttpHelper.HttpPost("trayStock/findSlIdBySlNameNoZC", @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&slName=" + this.txtshelve.Text);
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
                string x = HttpHelper.HttpPost("storeOperate", @"lcCode=" + Comm.lcCode + "&fromTrayCode=" + this.txtcarton.Text + "&whCode=" + Comm.warehousecode + "&slId=" + slid.ToString() + "&updater=" + Comm.usercode + "&recommendSlId=" + mRec.data.recommendSlId + "&toTrayCode=" + this.txtcarton.Text);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("storeOperate错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
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

        void Init()
        {
            this.txtcarton.Text = "";
            this.txtshelve.Text = "";
            this.labcode.Text = "";
            this.labmaterialname.Text = "";
            this.labqty.Text = "";
            this.labrecommendSlId.Text = "";
            this.txtshelve.Enabled = false;

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
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("unbindTray", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txtcarton.Text + "&whCode=" + Comm.warehousecode  + "&updater=" + Comm.usercode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("unbindTray错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                //getmaterial = (Model.MgetMaterial)JsonConvert.DeserializeObject(x, typeof(Model.MgetMaterial));
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

       
    }
}