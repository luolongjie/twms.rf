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
    public partial class frmBalOper : Form
    {
        public frmBalOper()
        {
            InitializeComponent();
        }

        Model.Mmsg msg = null;
        Model.MBalanceBarcode mb = null;
        Model.BalanceBarcodes mbody = null;

        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            try
            {
             
                Cursor.Current = Cursors.WaitCursor;
                string con = @"&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&barCode=" + this.txtbarcode.Text.Trim() ;
                string x = HttpHelper.HttpPost("", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mb = (Model.MBalanceBarcode)JsonConvert.DeserializeObject(x, typeof(Model.MBalanceBarcode));
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            if (mb.data.Count > 1)
            {
                Ot.frmBalMaterial frm = new Rf_Wms.Ot.frmBalMaterial();
                frm.mb = mb;
                frm.ShowDialog();
                if (frm.mbs != null)
                    mbody = frm.mbs;
                FindBalPdate();
                this.txtbarcode.Enabled = false;
                this.cbopdate.Enabled = true;
                this.cbopdate.Focus();
                return;
            }
            mbody = mb.data[0];
            this.txtblno.Enabled = true;
            this.txtbarcode.Enabled = false;
            this.txtblno.Focus();
        }

        void Show()
        {
        }

        public string tcod = "";
        void FindBalPdate()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                string con = @"&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&materialCode=" + this.txtbarcode.Text.Trim() + "&tcod=" + tcod;
                string x = HttpHelper.HttpPost("", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.MbalPdate mp = (Model.MbalPdate)JsonConvert.DeserializeObject(x, typeof(Model.MbalPdate));
                Cursor.Current = Cursors.Default;
                this.cbopdate.DataSource = mp.data;
                this.cbopdate.DisplayMember = "pDate";
                this.cbopdate.SelectedItem = 1;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
        }


        private void cbopdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.cbopdate.Enabled = false;
            this.txtblno.Enabled = true;
            this.txtblno.Focus();
        }

        Model.balBlnos mbs = null;
        private void txtblno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                return;
            }
            if (e.KeyChar != 13)
                return;
            Model.MbalBlno mbl = null;
            if (this.txtblno.Text == "")
            {
                try
                {

                    Cursor.Current = Cursors.WaitCursor;
                    string con = @"&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&materialCode=" + mbody.materialCode + "&tcod=" + tcod;
                    //outletcode
                    string x = HttpHelper.HttpPost("", con);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mbl = (Model.MbalBlno)JsonConvert.DeserializeObject(x, typeof(Model.MbalBlno));
                    Cursor.Current = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);

                    return;
                }
                if (mbl.data.Count == 1)
                {
                    this.txtblno.Text = mbl.data[0].blNo;
                    mbs = mbl.data[0];
                }
                else
                {
                    frmBalBlnoSearch frm = new frmBalBlnoSearch();
                    frm.tcod = tcod;
                    frm.materialCode = mbody.materialCode;
                    frm.ShowDialog();
                    if (!string.IsNullOrEmpty(frm.blNo))
                    {
                        mbs=(from xx in mbl.data where xx.blNo==frm.blNo select xx).First();
                        this.txtblno.Text = frm.blNo;
                    }
                    else
                    {
                        return;
                    }
                }
                 this.txtcommonqty.Enabled = true;
                    this.txtblno.Enabled = false;
                    this.txtcommonqty.Focus();
                    
            }
        }

        private void txtminqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                return;
            }
            if (e.KeyChar != 13)
                return;
            try
            {
                minqty = Convert.ToInt32(this.txtminqty.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数量");
                this.txtminqty.SelectAll();
                return;
            }
            if (minqty > mbs.realMinquantity)
            {
                MessageBox.Show("不能大于结余数量");
                this.txtminqty.SelectAll();
                return;
            }
            this.txtminqty.Enabled = false;
            this.btnOK.Focus();
        }

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                return;
            }
            if (e.KeyChar != 13)
                return;
            try
            {
                commonqty = Convert.ToInt32(this.txtcommonqty.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (commonqty > mbs.realQuantity)
            {
                MessageBox.Show("不能大于结余数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Focus();
            this.txtminqty.SelectAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (minqty == 0)
                return;
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

                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Save()
        {
            string con = @"&lcCode=" + Comm.lcCode + "&stockOutNo=" + mbs.stockOutNo + "&materialCode=" + mbody.materialCode + "&pDate=" + this.cbopdate.Text + "&balanceQuantity=" + commonqty + "&balanceMinQuantity="+minqty;
            //outletcode
            string x = HttpHelper.HttpPost("", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
        }
    }
}