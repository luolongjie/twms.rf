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
    public partial class frmOrderAssister : Form
    {
        public frmOrderAssister()
        {
            InitializeComponent();
        }


        Model.Mmsg msg = null;
        Model.MOperationByOrder mo = null;
        private void txtorderid_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txtorderid.Text == "")
            {
                //MessageBox.Show("请扫描容器条码");
                //this.txttraycode.SelectAll();
                return;
            }
            try
            {
                string x = HttpHelper.HttpPost("getOperationByOrder", @"lcCode=" + Comm.lcCode + "&orderNo=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mo = (Model.MOperationByOrder)JsonConvert.DeserializeObject(x, typeof(Model.MOperationByOrder));
                if (mo == null)
                {
                    throw new Exception("MOperationByOrder捕捉失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (mo.data.Count == 0)
            {
                MessageBox.Show("没有作业类型");
                return;
                
            }
            this.cmboperation.DataSource = mo.data;
            this.cmboperation.ValueMember = "code";
            this.cmboperation.DisplayMember = "name";
            this.txtorderid.Enabled = false;
            this.cmboperation.Enabled = true;
            this.cmboperation.Focus();
        }

        Model.MAssisterInfo ma = null;
        private void txtAssister_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.labinfo.Text = "";

                this.txtAssister.Enabled = false;
                this.txtAssister.Text = "";
                this.cmbunit.Enabled = true;
                this.cmbunit.Focus();
               
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txtAssister.Text == "")
                return;
            try
            {
                string x = HttpHelper.HttpPost("getAssisterInfo", @"lcCode=" + Comm.lcCode + "&assisterCode=" + this.txtAssister.Text);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                ma = (Model.MAssisterInfo)JsonConvert.DeserializeObject(x, typeof(Model.MAssisterInfo));
                if (ma == null)
                {
                    throw new Exception("getAssisterInfo捕捉失败");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtAssister.SelectAll();
                return;
            }
            //if()
            bool badd = true;
            foreach (Model.Assisters v in malist.data)
            {
                if (v.code == ma.data.code)
                {
                    malist.data.Remove(v);
                    badd = false;
                    break;
                }
            }
            if (badd)
            {
                malist.data.Add(ma.data);
            }
            ShowInfo();
            this.txtAssister.Text = "";
           
        }

        Model.MAssisterByOperation malist = null;
        private void cmboperation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                malist = null;
                this.cmboperation.Enabled = false;
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            try
            {
                string x = HttpHelper.HttpPost("getAssisterByOperation", @"operatorCode=" + this.cmboperation.SelectedValue.ToString() + "&orderNo="+this.txtorderid.Text+"&lcCode=" + Comm.lcCode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                malist = (Model.MAssisterByOperation)JsonConvert.DeserializeObject(x, typeof(Model.MAssisterByOperation));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (malist == null)
            {
                malist = new Rf_Wms.Model.MAssisterByOperation();

            }
            if (malist.data == null)
            {
                malist.data = new List<Rf_Wms.Model.Assisters>();
            }
            else
            {
                ShowInfo();
            }
            this.cmboperation.Enabled = false;
            this.cmbunit.Enabled = true;
            this.cmbunit.Focus();
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.txtAssister.Enabled)
                return;
            if (malist == null || malist.data == null || malist.data.Count == 0)
            {
                MessageBox.Show("请先录入协助人");
                return;
            }
            string conn = @"lcCode=" + Comm.lcCode + "&orderNo=" + this.txtorderid.Text + "&unit=" + this.cmbunit.Text + "&operatorCode=" + this.cmboperation.SelectedValue.ToString() + "&comAssisters=";
            foreach (Model.Assisters v in malist.data)
            {
                conn += v.companyCode + "-" + v.code+",";
            }
            conn = conn.Substring(0, conn.Length - 1);
            try
            {
                string x = HttpHelper.HttpPost("createBillAssister", conn);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                //malist = (Model.MAssisterByOperation)JsonConvert.DeserializeObject(x, typeof(Model.MAssisterByOperation));
                //if (mm == null)
                //{
                //    throw new Exception("getAssisterInfo捕捉失败");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Init();
        }

        private void frmOrderAssister_Load(object sender, EventArgs e)
        {
            this.cmbunit.SelectedIndex = 0;
            Init();
        }

        void ShowInfo()
        {
            this.labinfo.Text = "";
            foreach (Model.Assisters v in malist.data)
            {
                this.labinfo.Text += v.name+"\n\r";
            }
        }

        private void cmbunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.cmboperation.Enabled = true;
                this.cmbunit.Enabled = false;
                this.cmboperation.Focus();
             
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.txtAssister.Enabled = true;
            this.txtAssister.Focus();
        }

        void Init()
        {
            this.cmbunit.Enabled = false;
            this.cmboperation.Enabled = false;
            this.labinfo.Text = "";
            this.txtAssister.Text = "";
            this.txtorderid.Text = "";
            this.txtorderid.Enabled = true;
            this.txtorderid.Focus();
            this.txtAssister.Enabled = false;
        }
    }
}