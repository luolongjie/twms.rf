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
    public partial class frmBalTranMove : Form
    {
        public frmBalTranMove()
        {
            InitializeComponent();
        }

        Model.MZcqSlList mz = null;
        Model.Mmsg msg = null;
        private void frmBalTranMove_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getZcqSlList", "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mz = (Model.MZcqSlList)JsonConvert.DeserializeObject(x, typeof(Model.MZcqSlList));
                this.cmbtoslname.DataSource = mz.data;
                this.cmbtoslname.ValueMember = "slId";
                this.cmbtoslname.DisplayMember = "slName";

                x = HttpHelper.HttpPost("getBalanceTransferOrderNumber", "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&updater=" + Comm.usercode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.Mccode mc=  (Model.Mccode)JsonConvert.DeserializeObject(x, typeof(Model.Mccode));
                this.labccode.Text = mc.data;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                
                return;
            }
        }

        private void txttoslname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txttoslname.Text != "")
            {
                var v = from x in mz.data where x.slName == this.txttoslname.Text select x;
                if (v.Count() == 0)
                {
                    MessageBox.Show("没有该暂存区");
                    this.txttoslname.SelectAll();
                    return;
                }
                else
                {
                    this.cmbtoslname.Text = this.txttoslname.Text;
                }
            }
            cmbtoslname_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void cmbtoslname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            this.cmbtoslname.Enabled = false;
            this.txttoslname.Enabled = false;
            this.txtbarcode.Enabled = true;
            this.txtbarcode.Focus();
        }

        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtbarcode.Text = "";
                this.txtbarcode.Enabled = false;
                this.cmbtoslname.Enabled = true;
                this.txttoslname.Enabled = true;
                this.txttoslname.Text = "";
                this.txttoslname.Focus();
            }
            Model.Mmaterialcode m = null;
            if (e.KeyChar != 13)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getMaterialCode", @"barCode=" + this.txtbarcode.Text + "&lcCode=" + Comm.lcCode );
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                m = (Model.Mmaterialcode)JsonConvert.DeserializeObject(x, typeof(Model.Mmaterialcode));
                if (m == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (m.data.Count == 0 || m.data[0].code == null)
                {
                    throw new Exception("没有该条码对应的数据");
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                this.txtbarcode.Text = "";
                MessageBox.Show(ex.Message);
                return;

            }
            Model.Mmaterialcodebody materialbody = null;
            if (m.data.Count > 1)
            {
                Ot.frmMaterial frm = new Rf_Wms.Ot.frmMaterial();
                frm.m = m;
                frm.ShowDialog();
                if (frm.mbody != null)
                    materialbody = frm.mbody;
            }
            else
            {
                materialbody = m.data[0];
            }
            if (materialbody != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("getlocationStockList", @"&whId=" + Comm.warehousecode + "&lcCode=" + Comm.lcCode + "&materialCode=" + materialbody.code + "&slId=" + this.cmbtoslname.SelectedValue.ToString());
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    m = (Model.Mmaterialcode)JsonConvert.DeserializeObject(x, typeof(Model.Mmaterialcode));
                    if (m == null)
                    {
                        throw new Exception("数据信息捕捉失败");
                    }
                   
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    this.txtbarcode.Text = "";
                    MessageBox.Show(ex.Message);
                    return;

                }
               

            }
            else
            {
                this.txtbarcode.SelectAll();
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

      
    }
}