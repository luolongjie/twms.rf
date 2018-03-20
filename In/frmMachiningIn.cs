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
    public partial class frmMachiningIn : Form
    {
        public frmMachiningIn()
        {
            InitializeComponent();
        }

        Model.Mmsg msg = null;
        Model.MproductPackorder mp = null;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txtorderid.Text == "")
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode;
                
                string x = HttpHelper.HttpPost("packOrder/getProductPackOrder", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mp = (Model.MproductPackorder)JsonConvert.DeserializeObject(x, typeof(Model.MproductPackorder));
                if (mp == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtorderid.SelectAll();
                return;

            }
            //this.labbatchNo.Text = mtrans.data.batchNo;
            this.labmaterialname.Text = mp.data.materialName;
            this.labqty.Text = mp.data.quantity.ToString() + mp.data.commonUnitName + mp.data.minQuantity.ToString() + mp.data.minUnitName;
            this.labcommonUnit.Text = mp.data.commonUnitName;
            this.labminunit.Text = mp.data.minUnitName;
            this.labslname.Text = mp.data.toSlIdName;
            this.txtorderid.Enabled = false;
            this.txtbarcode.Enabled = true;
            this.txtbarcode.Focus();
        }

        void ShowTxt()
        {
            this.labmaterialname.Text = mp.data.materialName;
            this.labqty.Text = mp.data.quantity.ToString() + mp.data.commonUnitName + mp.data.minQuantity.ToString() + mp.data.minUnitName;
            this.labcommonUnit.Text = mp.data.commonUnitName;
            this.labminunit.Text = mp.data.minUnitName;
            this.txtorderid.Enabled = false;
            this.txtbarcode.Enabled = true;
            this.txtbarcode.Focus();
        }

        Model.Mmaterialcodebody materialbody = null;
        Model.MgetMaterial getmaterial = null;
        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtbarcode.Text = "";
                this.txtbarcode.Enabled = false;
                this.txtorderid.Enabled = true;
                this.txtorderid.Text = "";
                this.txtorderid.Focus();
            }
            Model.Mmaterialcode m = null;
            if (e.KeyChar != 13)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getMaterialCode", @"barCode=" + this.txtbarcode.Text + "&lcCode=" + Comm.lcCode);
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
                    throw new Exception("没有该商品码对应的数据");
                }
               
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtbarcode.SelectAll();
                return;

            }
            for (int i = m.data.Count - 1; i >= 0; i--)
            {
               if(m.data[i].code!=mp.data.materialCode)
                    m.data.RemoveAt(i);
                
            }
            if (m.data.Count > 1)
            {
                Ot.frmMaterial frm = new Rf_Wms.Ot.frmMaterial();
                frm.m = m;
                frm.ShowDialog();
                if (frm.mbody != null)
                    materialbody = frm.mbody;
            }
            else if (m.data.Count == 0)
            {
                MessageBox.Show("单据中不存在该商品码的信息");
                this.txtbarcode.SelectAll();
                return;
            }
            else
            {
                materialbody = m.data[0];
            }
            if (materialbody != null)
            {
                //this.labmaterialname.Text = materialbody.name;
                //this.labcommonUnit.Text = materialbody.commonUnit;
                //this.labminunit.Text = materialbody.minUnit;
            }
            else
            {
                this.txtbarcode.SelectAll();
                return;
            }
            try
            {
                Convert.ToInt32(materialbody.spec);
            }
            catch (Exception)
            {
                MessageBox.Show("请检查规则字段是不是int");
                this.txtbarcode.SelectAll();
                return;
            }
            this.txtbarcode.Enabled = false;
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        void Clear()
        {
            this.labqty.Text = "";
            this.labcommonUnit.Text = "";
            this.labminunit.Text = "";
            this.labmaterialname.Text = "";
            this.labminunit.Text = "";
            this.txtbarcode.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            this.txtorderid.Text = "";
            this.txttraycode.Text = "";
            this.txtslname.Text = "";
            this.txtassistance.Text = "";
            this.labassistance.Text = "";
            this.labslname.Text = "";
            this.txtbarcode.Enabled = false;
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = false;
            this.txttraycode.Enabled = false;
            this.txtassistance.Enabled = false;
            this.txtslname.Enabled = false;
            this.txtorderid.Enabled = true;
            this.txtorderid.Focus();
        }

        private void frmMachiningIn_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txttraycode.Text = "";
                this.txttraycode.Enabled = false;
                this.txtbarcode.Enabled = true;
                this.txtbarcode.Text = "";
                this.txtbarcode.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txttraycode.Text == "")
                return;
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            Model.MTrayByBox mm = null;
            if (this.txttraycode.Text.Length < Comm.lcCode.Length || Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                    if (mm == null)
                        throw new Exception("错误信息捕捉失败");

                    this.txttraycode.Text = mm.data.trayCode;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;

                }
            }
            Model.MTrayStockByOrderType nmt = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("trayStock/findTrayStockByOrderType", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttraycode.Text + "&whId=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("trayStock/findTrayStockByOrderType错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                nmt = (Model.MTrayStockByOrderType)JsonConvert.DeserializeObject(x, typeof(Model.MTrayStockByOrderType));
                if (nmt == null)
                {
                    throw new Exception("findTrayStockByOrderType捕捉失败");
                }
                //if (nmt.data == null)
                //{
                //    throw new Exception("findTrayStockByOrderType返回data信息为空");
                //}
               
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            if (nmt.data!=null && !string.IsNullOrEmpty(nmt.data.materialCode))//不是空托盘
            {
               
                    if (nmt.data.slId != mp.data.toSlId)
                    {
                        MessageBox.Show("该托盘不在目标库位上,请换一个托盘");
                        this.txttraycode.SelectAll();
                        return;
                    }
                
                if (mp.data.materialCode != nmt.data.materialCode)
                {
                    MessageBox.Show("新托盘上的物料是" + nmt.data.materialName + ",不能合托,请换托盘");
                    this.txttraycode.SelectAll();
                    return;
                }
                if (mp.data.batchNo != nmt.data.batchNo  || mp.data.pdate != nmt.data.pdate )
                {
                    DialogResult dr = MessageBox.Show("批次 生产日期 状态 入库日期有和原来的不同的属性，是否合托?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dr != DialogResult.Yes)
                    {
                        this.txttraycode.SelectAll();
                        return;
                    }
                }
            }
            this.txttraycode.Enabled = false;
            this.txtslname.Enabled = true;
            this.txtslname.Focus();
        }

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtcommonqty.Enabled = false;
                this.txtslname.Enabled = true; ;
                this.txtcommonqty.Text = "";
                this.txtslname.Text = "";
                this.txtslname.Focus();
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
            int r = (mp.data.quantity - commonqty) * materialbody.spec + mp.data.minQuantity;
            if (r<0)
            {
                MessageBox.Show("不能超单操作");
                this.txtcommonqty.SelectAll();
                return;
            }
            //if (!isNew)
            //{
            //    if (commonqty > getmaterial.data.quantity)
            //    {
            //        MessageBox.Show("输入数量大于计划数量");
            //        this.txtcommonqty.SelectAll();
            //        return;
            //    }
            //}
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Focus();
        }

        private void txtminqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtcommonqty.Enabled = true;
                this.txtminqty.Enabled = false;
                this.txtminqty.Text = "";
                this.txtcommonqty.Focus();
                this.txtcommonqty.SelectAll();
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
            //int r = mp.data.quantity - commonqty;
            //if (r < 0)
            //    r = 0;
            //r = r * materialbody.spec + mp.data.minQuantity - minqty;
            //if (r<0)
            //{
            //    MessageBox.Show("不能超单操作");
            //    this.txtminqty.SelectAll();
            //    return;
            //}
            int r = mp.data.quantity - commonqty;
            if (r > 0)
                r = 0;
            r = mp.data.minQuantity - minqty + r * materialbody.spec;
            if (r < 0)
            {
                MessageBox.Show("不能超单操作");
                this.txtminqty.SelectAll();
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
                return;
            }
            mp.data.quantity -= commonqty;
            mp.data.minQuantity -= minqty;
            if (mp.data.quantity > 0 || mp.data.minQuantity>0)
            {
                //this.txtorderid.Text = mp.data.orderId;
                //this.labmaterialname.Text = mp.data.materialName;
                this.labqty.Text = mp.data.quantity.ToString() + mp.data.commonUnitName + mp.data.minQuantity.ToString() + mp.data.minUnitName;
                //this.labcommonUnit.Text = mp.data.commonUnitName;
                //this.labminunit.Text = mp.data.minUnitName;
                this.txtminqty.Enabled = false;
                this.txtminqty.Text = "";
                this.txtcommonqty.Text = "";
                this.txttraycode.Text = "";
                this.txttraycode.Enabled = true;
                this.txttraycode.Focus();
            }
            else
            {
                Clear();
            }
        }

        void Save()
        {

            string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&materialCode=" + materialbody.code + "&quantity=" + commonqty + "&minQuantity=" + minqty + "&toTrayCode=" + this.txttraycode.Text + "&fromTrayCode=" + this.txttraycode.Text + "&operatorCode=" + Comm.usercode + "&fromSlId=" + mp.data.toSlId + "&assistance=" + this.labassistance.Text; ;

            string x = HttpHelper.HttpPost("packOrder/machineingPackOrder", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);


           
        }

        private void btnkeyboard_Click(object sender, EventArgs e)
        {
            //RIL_IME.ShowIME("键盘");
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

        private void txtassistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtassistance.Enabled = false;
                this.txtslname.Enabled = true; ;
                this.txtassistance.Text = "";
                this.txtslname.Text = "";
                this.txtslname.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            Model.MUserInfo mu = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getUserInfo", @"lcCode=" + Comm.lcCode + "&account=" + this.txtassistance.Text);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mu = (Model.MUserInfo)JsonConvert.DeserializeObject(x, typeof(Model.MUserInfo));
                if (mu == null || mu.data == null || mu.data.userCode == "")
                    throw new Exception("错误信息捕捉失败");
                this.labassistance.Text = mu.data.userCode;
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            this.txtassistance.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }

        private void txtslname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtslname.Enabled = false;
                this.txttraycode.Enabled = true; ;
                this.txtslname.Text = "";
                this.txttraycode.Text = "";
                this.txttraycode.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.txtslname.Text = this.txtslname.Text.ToUpper();
            if (this.txtslname.Text != this.labslname.Text)
            {
                MessageBox.Show("不是指定库位");
                this.txtslname.SelectAll();
                return;
            }
            this.txtslname.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }

        private void txtorderid_GotFocus(object sender, EventArgs e)
        {
            txtorderid.SelectAll();
        }

        private void txtbarcode_GotFocus(object sender, EventArgs e)
        {
            txtbarcode.SelectAll();
        }

        private void txttraycode_GotFocus(object sender, EventArgs e)
        {
            txttraycode.SelectAll();
        }

        private void txtslname_GotFocus(object sender, EventArgs e)
        {
            txtslname.SelectAll();
        }

        private void txtcommonqty_GotFocus(object sender, EventArgs e)
        {
            txtcommonqty.SelectAll();
        }

        private void txtminqty_GotFocus(object sender, EventArgs e)
        {
            txtminqty.SelectAll();
        }

       
    }
}