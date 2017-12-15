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
    public partial class frmbalance : Form
    {
        public frmbalance()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Model.Mmsg msg = null;
        Model.MstockIn stockin = null;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
            if (e.KeyChar != 13)
                return;
            this.txtorderid.Text = this.txtorderid.Text.Trim();

            if (this.txtorderid.Text == "")
            {
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode;

                string x = HttpHelper.HttpPost("mergeRefundValidate", conn);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                stockin = (Model.MstockIn)JsonConvert.DeserializeObject(x, typeof(Model.MstockIn));
                if (stockin == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                //this.labcustomer.Text = stockin.data.shipperInfo.shipperCode + " " + stockin.data.shipperInfo.shipperName;
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            this.txtorderid.Enabled = false;
            this.txtbarcode.Enabled = true;
            this.txtbarcode.Focus();
           
        }

        Model.Mmaterialcodebody materialbody = null;
        Model.MgetMaterial getmaterial = null;
        int row = 0;
        Model.MTrayByBox mm = null;
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
                string x = HttpHelper.HttpPost("getMaterialCode", @"barCode=" + this.txtbarcode.Text + "&lcCode=" + Comm.lcCode + "&shipperCode=" + stockin.data.shipperInfo.shipperCode + "&whId=" + Comm.warehousecode);
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

            for (int i = m.data.Count - 1; i >= 0; i--)
            {
                bool ih = false;
                foreach (Model.material x in stockin.data.materialList)
                {
                    if (x.materialCode == m.data[i].code)
                    {
                        ih = true;
                        break;
                    }
                }
                if (!ih)
                {
                    m.data.RemoveAt(i);
                }
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
                MessageBox.Show("单据中不存在该条码的信息");
                return;
            }
            else
            {
                materialbody = m.data[0];
            }
            if (materialbody != null)
            {
                //this.labmaterialcode.Text = materialbody.code;
                //this.labmaterialname.Text = materialbody.name;
                //this.labcommonUnit.Text = materialbody.commonUnit;
                //this.labminunit.Text = materialbody.minUnit;

            }
            else
            {
                this.txtbarcode.SelectAll();
                return;
            }

            //var b = from x in stockin.data.materialList where x.materialCode == materialbody.code select x;
            //if (b.Count() != 0)
            //{
            //    batchno = b.First().batchNo;
            //}
            //else
            //{
            //    batchno = null;
            //}
            //17-02-16
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

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GetMaterialStockInOrder();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }

            //if (getmaterial == null || getmaterial.data == null || string.IsNullOrEmpty(mm.data.boxcode))
            //{
              
            //}
            //else
            //{
           
            //maxminquantity = getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity - getmaterial.data[0].surplusMinQuantity + mb.data.minQuantity;
           
                this.txtbarcode.Enabled = false;
                this.txtsorderid.Enabled = true;
                this.txtsorderid.Focus();
               
            //}
        }

        int ci = 0;
        int mi = 0;
        void GetMaterialStockInOrder()
        {
            //if (getmaterial == null || getmaterial.data.Count == 0 || row >= getmaterial.data.Count)
            //{
            string x = HttpHelper.HttpPost("verifyMaterialMergeRefundOrder", @"materialCode=" + materialbody.code + "&lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode+"&balance=true");
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            getmaterial = (Model.MgetMaterial)JsonConvert.DeserializeObject(x, typeof(Model.MgetMaterial));
            if (getmaterial == null)
            {
                throw new Exception("getMaterial捕捉失败");
            }
            for (int i = getmaterial.data.Count - 1; i >= 0; i--)
            {
                if (getmaterial.data[i].quantity - getmaterial.data[i].realQuantity <= 0 && getmaterial.data[i].minQuantity - getmaterial.data[i].realMinquantity <= 0)
                {
                    getmaterial.data.Remove(getmaterial.data[i]);
                    //studentList.RemoveAt(i);
                }
            }
            row = 0;
            //maxquantity = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity - getmaterial.data[0].surplusQuantity;
            //maxminquantity = getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity - getmaterial.data[0].surplusMinQuantity;
            //ci = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity - getmaterial.data[0].surplusQuantity + (int)(Math.Ceiling(((double)(getmaterial.data[row].minQuantity - getmaterial.data[0].realMinquantity - getmaterial.data[0].surplusMinQuantity) / getmaterial.data[0].spec)));
            //if (getmaterial.data[0].minQuantity > getmaterial.data[0].realMinquantity + getmaterial.data[0].surplusMinQuantity)
            //{
            //    ci = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity - getmaterial.data[0].surplusMinQuantity;
            //}
            //else
            //{
            //    ci--;
            //}
            //mi = (getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity - getmaterial.data[0].surplusMinQuantity) % getmaterial.data[0].spec;

            //if (mi < 0)
            //{
            //    mi += getmaterial.data[0].spec;
            //}
            //else
            //{
            //    mi = getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity - getmaterial.data[0].surplusMinQuantity;
            //}
            //this.labmaterialcode.Text = materialbody.code;
            this.labmaterialname.Text = materialbody.code+" "+materialbody.name;
            this.labminunit.Text = materialbody.minUnit;
            this.labcommonUnit.Text = materialbody.commonUnit;
            //this.labsurplus.Text = ci + materialbody.commonUnit + mi + materialbody.minUnit;
            //if (allqty == null)
            //{
                allqty = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity;
                allminqty = getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity;
            //}
            if (allqty < 0 || allminqty < 0)
            {
                int? imax = allqty * getmaterial.data[0].spec + allminqty;
                allqty = imax / getmaterial.data[0].spec;
                allminqty = imax % getmaterial.data[0].spec;
            }
            this.labsurplus.Text = allqty + materialbody.commonUnit + allminqty + materialbody.minUnit;
            //}
           
        }
        int? allqty = null;
        int? allminqty = null;

        Model.MergeRefundOrder mf = null;
        private void txtsorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtsorderid.Text = "";
                this.txtsorderid.Enabled = false;
                //this.labmaterialcode.Text = "";
                this.labsurplus.Text = "";
                this.labmaterialname.Text = "";
                this.txtbarcode.Enabled = true;
                this.txtbarcode.Text = "";
                allqty = null;
                allminqty = null;
                this.txtbarcode.Focus();
            }
            if (e.KeyChar != 13)
                return;
            Findsoorderid();
        }

        void Findsoorderid()
        {
            row = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("verifyStockInOrderInMerge", @"stockInOrderId=" + this.txtsorderid.Text + "&lcCode=" + Comm.lcCode + "&refundOrderId=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode + @"&materialCode=" + materialbody.code);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mf = (Model.MergeRefundOrder)JsonConvert.DeserializeObject(x, typeof(Model.MergeRefundOrder));
                if (mf == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                ShowVal();
                //this.labneedqty.Text =  mf.data[row].quantity + materialbody.commonUnit + mf.data[row].minQuantity + materialbody.minUnit;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                //this.txtbarcode.Text = "";
                MessageBox.Show(ex.Message);
                return;

            }
            this.txtsorderid.Enabled = false;
            this.txtminqty.Enabled = false;
            this.txtminqty.Text = "";
            this.txtcommonqty.Text = "";
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }

        Model.MRefundBanlance mb = null;
        int maxquantity = 0;
        int maxminquantity = 0;
        void ShowVal()
        {

            string x = HttpHelper.HttpPost("getRefundBanlance", @"stockInOrderId=" + this.txtsorderid.Text + "&lcCode=" + Comm.lcCode + "&refundOrderId=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode + @"&stockInItemId=" + mf.data[row].itemId + "&refundItemId=" + getmaterial.data[0].itemId);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            mb = (Model.MRefundBanlance)JsonConvert.DeserializeObject(x, typeof(Model.MRefundBanlance));
            if (mb == null)
            {
                throw new Exception("数据信息捕捉失败");
            }
            //maxquantity = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity - getmaterial.data[0].surplusQuantity + mb.data.quantity;
            maxquantity = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity - getmaterial.data[0].surplusQuantity;
            maxminquantity = getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity - getmaterial.data[0].surplusMinQuantity;
            int imax = maxquantity * getmaterial.data[0].spec + maxminquantity;
            
            if (maxminquantity < 0 || maxminquantity < 0)
            {
                maxquantity = imax / getmaterial.data[0].spec;
                maxminquantity = imax % getmaterial.data[0].spec;

            }
            //maxminquantity = getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity - getmaterial.data[0].surplusMinQuantity + mb.data.minQuantity;
            //this.labsurplus.Text = maxquantity + materialbody.commonUnit + maxminquantity + materialbody.minUnit;
                //this.labsurplus.Text = mb.data.quantity + materialbody.commonUnit + mb.data.minQuantity + materialbody.minUnit;
                if (allqty < 0 || allminqty < 0)
                {
                    imax = (int)(allqty * getmaterial.data[0].spec + allminqty);
                    allqty = imax / getmaterial.data[0].spec;
                    allminqty = imax % getmaterial.data[0].spec;
                }
               
                this.labsurplus.Text = allqty + materialbody.commonUnit + allminqty + materialbody.minUnit;
            this.labneedqty.Text = "单量 "+mf.data[row].quantity + materialbody.commonUnit + mf.data[row].minQuantity + materialbody.minUnit + " 结余量 " + mb.data.quantity + materialbody.commonUnit + mb.data.minQuantity + materialbody.minUnit;
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            
        }

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtcommonqty.Enabled = false;
                this.txtcommonqty.Text = "";
                this.labneedqty.Text = "";
                
                this.txtsorderid.Enabled = true;
                this.txtsorderid.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txtcommonqty.Text == "")
                this.txtcommonqty.Text = "0";
            try
            {
                commonqty = Convert.ToInt32(this.txtcommonqty.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (commonqty > 1000000)
            {
                MessageBox.Show("数量过大");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (commonqty < 0)
            {
                MessageBox.Show("不能输入负数");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (mf.data[row].minQuantity + mf.data[row].quantity * getmaterial.data[0].spec < commonqty * getmaterial.data[0].spec )
            {
                MessageBox.Show("基本单位结余数量已超出可结余量");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (maxminquantity + mb.data.minQuantity + (mb.data.quantity + maxquantity) * getmaterial.data[0].spec < commonqty * getmaterial.data[0].spec )
            {
                MessageBox.Show("基本单位结余数量已超出可结余的量");
                this.txtcommonqty.SelectAll();
                return;
            }
            //if (mf.data[row].quantity < commonqty || (maxquantity + mb.data.quantity )< commonqty)
            //{
            //    MessageBox.Show("基本单位结余数量已超出可结余量");
            //    this.txtcommonqty.SelectAll();
            //    return;
            //}
            //if (!stockin.data.overchargesFlag)
            //{
            //    int r = (getmaterial.data[row].quantity - commonqty - getmaterial.data[row].realQuantity) * materialbody.spec + getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity;
            //    if (r < 0)
            //    {
            //        MessageBox.Show("不能超收");
            //        this.txtcommonqty.SelectAll();
            //        return;
            //    }
            //}
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Text = "0";
            //btnShelve.Visible = true;
            this.txtminqty.Focus();
            this.txtminqty.SelectAll();
        }

        private void txtminqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtcommonqty.Enabled = true;
                this.txtminqty.Enabled = false;
                this.txtminqty.Text = "";
                this.txtcommonqty.Focus();
                //btnShelve.Visible = false;
                this.txtcommonqty.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txtminqty.Text == "")
                this.txtminqty.Text = "0";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                checkmin();
                Save();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            this.txtminqty.Enabled = false;
            this.txtminqty.Text = "";
            this.txtcommonqty.Text = "";
            //maxquantity = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity - getmaterial.data[0].surplusQuantity + mb.data.quantity;
            //maxminquantity = getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity - getmaterial.data[0].surplusMinQuantity + mb.data.minQuantity;
            maxquantity = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity ;
            maxminquantity = getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity ;
            allqty -= commonqty;
            allminqty -= minqty;
            if (maxquantity <= 0 && maxminquantity <= 0)
            {
                mf = null;
                this.labneedqty.Text = "";
                this.labsurplus.Text = "";
                this.txtcommonqty.Text = "";
                this.txtminqty.Text = "";
                this.txtsorderid.Text = "";
                this.labmaterialname.Text = "";
                this.labminunit.Text = "";
                this.labcommonUnit.Text = "";
                this.txtbarcode.Text = "";
                this.txtbarcode.Enabled = true;
                this.txtbarcode.Focus();
                return;
            }
            //if (commonqty == mf.data[row].quantity && minqty == mf.data[row].minQuantity)
            //{
                Next();
               
                return;
            //}
           
            //this.labneedqty.Text = "";
            //this.labsurplus.Text = "";
            //this.txtcommonqty.Text = "";
            //this.txtminqty.Text = "";
            //this.txtsorderid.Text = "";
            //this.txtsorderid.Enabled = true;
            //this.txtsorderid.Focus();
            //return;
           
        }

        void checkmin()
        {
            try
            {
                minqty = Convert.ToInt32(this.txtminqty.Text);
            }
            catch (Exception)
            {
                throw new Exception("请输入正确数量");

            }
            if (minqty > 1000000)
            {
                throw new Exception("数量过大");

            }
            if (minqty < 0)
            {
                throw new Exception("不能输入负数");

            }
           
            if (commonqty < 0 || minqty < 0)
            {
                throw new Exception("数量过小");

            }
            if (mf.data[row].minQuantity + mf.data[row].quantity * getmaterial.data[0].spec < commonqty * getmaterial.data[0].spec + minqty)
            {
                throw new Exception("最小单位结余数量已超出可结余量");
            }
            if (maxminquantity + mb.data.minQuantity + (mb.data.quantity+maxquantity) * getmaterial.data[0].spec < commonqty * getmaterial.data[0].spec + minqty)
            {
                throw new Exception("最小单位结余数量已超出可结余的量");
            }
            //if (mf.data[row].minQuantity < minqty || maxminquantity + (mb.data.minQuantity) < minqty)
            //{
            //    throw new Exception("最小单位结余数量已超出可结余量");
               
            //}
        }

        void Save()
        {

            string con = @"stockInOrderId=" + this.txtsorderid.Text + "&lcCode=" + Comm.lcCode + "&refundOrderId=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode + @"&stockInItemId=" + mf.data[row].itemId + "&refundItemId=" + getmaterial.data[0].itemId + "&updater=" + Comm.usercode + "&quantity=" + commonqty + "&minQuantity=" + minqty+"&materialCode="+materialbody.code;
           
            string x = HttpHelper.HttpPost("addRefundBanlance", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);

            //traycode = this.txttraycode.Text;
            //this.btnShelve.Visible = true;
            getmaterial.data[0].surplusQuantity = getmaterial.data[0].surplusQuantity - mb.data.quantity + commonqty;
            getmaterial.data[0].surplusMinQuantity = getmaterial.data[0].surplusMinQuantity - mb.data.minQuantity + minqty;
            mb.data.quantity = commonqty;
            mb.data.quantity = minqty;
            Clear();


        }

        void Clear()
        {
            this.labneedqty.Text = "";
            
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
            if (mf == null)
                return;
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = false;
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            Next();
        }


        void Next()
        {
           
            row++;
            if (row == mf.data.Count)
            {
                mf = null;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    GetMaterialStockInOrder();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;

                }
                //Findsoorderid();
                this.labneedqty.Text = "";
                this.txtsorderid.Text = "";
                this.txtsorderid.Enabled = true;
                this.txtsorderid.Focus();
                return;
            }
            else
            {
                ShowVal();
                this.txtcommonqty.Enabled = true;
                this.txtcommonqty.Focus();
                return;
            }
           
        }

        private void txtsorderid_GotFocus(object sender, EventArgs e)
        {
            this.txtsorderid.SelectAll();
        }

        private void frmbalance_Load(object sender, EventArgs e)
        {
            this.txtorderid.Enabled = true;
            this.txtorderid.Focus();
        }

        private void label2_ParentChanged(object sender, EventArgs e)
        {

        }

        private void labmaterialname_ParentChanged(object sender, EventArgs e)
        {

        }
       
       

       
    }
}