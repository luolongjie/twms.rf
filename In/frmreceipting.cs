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
    public partial class frmreceipting : Form
    {
        public frmreceipting()
        {
            InitializeComponent();
        }
        bool isNew = true;
        public bool isRed = false;

        private void btnExit_Click(object sender, EventArgs e)
        {
            CloseOrderid();
            this.Close();
        }

        void CloseOrderid()
        {
            if (!isNew)
                return;
            if (this.txtorderid.Enabled)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn=@"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode+"&whId="+Comm.warehousecode+"&updater=" + Comm.usercode;
                string x = HttpHelper.HttpPost("deleteStockInOrder", conn);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                
            }
        }

        Model.Mmsg msg = null;
        //Model.MgetCustomersByLcCodeBody customer = null;
        Model.MstockIn stockin = null;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
            if (e.KeyChar != 13)
                return;
            this.txtorderid.Text = this.txtorderid.Text.Trim();

            if (this.txtorderid.Text == "")
            {
                Ot.frmCustomer frm = new Rf_Wms.Ot.frmCustomer();
                frm.isRed = isRed;
                frm.ShowDialog();
                if (!string.IsNullOrEmpty(frm.ccode))
                {
                    //customer=frm.customer;
                    //this.labcustomer.Text = customer.code + " " + customer.name;
                    this.txtorderid.Text = frm.ccode;
                }
                else
                {
                    return;
                }
                btnData.Visible = false;
                panel1.Visible = true;
                isNew = true;
            }
            else
            {
                panel1.Visible = false;
                isNew = false;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn=@"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode+"&whId="+Comm.warehousecode;
                if (isRed)
                {
                    conn += @"&refund=1";
                }
                else
                {
                    conn += @"&refund=0";
                }
                string x = HttpHelper.HttpPost("stockInValidate", conn);
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
                this.labcustomer.Text = stockin.data.shipperInfo.shipperCode + " " + stockin.data.shipperInfo.shipperName;
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            //if(1==2)
            //{
            this.txtorderid.Enabled = false;
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
            //}
        }

        Model.Mmaterialcodebody materialbody = null;
        Model.MgetMaterial getmaterial = null;
        int row = 0;
        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtbarcode.Text = "";
                this.txtbarcode.Enabled = false;
                this.txttraycode.Enabled = true;
                this.txttraycode.Text = "";
                this.txttraycode.Focus();
            }
            Model.Mmaterialcode m = null;
            if (e.KeyChar != 13)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getMaterialCode", @"barCode=" + this.txtbarcode.Text + "&lcCode=" + Comm.lcCode + "&shipperCode="+stockin.data.shipperInfo.shipperCode);
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
                if (m.data.Count == 0 || m.data[0].code==null)
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
            if (!isNew)
            {
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

                this.labmaterialname.Text = "物料代码 "+materialbody.code+" 描述 "+materialbody.name;
                this.labcommonUnit.Text = materialbody.commonUnit;
                this.labminunit.Text = materialbody.minUnit;
               
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
            if (!isNew)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //string x = HttpHelper.HttpPost("verifyMaterialStockInOrder", @"materialCode=" + materialbody.code + "&lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode);
                    //msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    //if (msg == null)
                    //    throw new Exception("错误信息捕捉失败");
                    //if (!msg.success)
                    //    throw new Exception(msg.msg);
                    //getmaterial = (Model.MgetMaterial)JsonConvert.DeserializeObject(x, typeof(Model.MgetMaterial));
                    //if (m == null)
                    //{
                    //    throw new Exception("getMaterial捕捉失败");
                    //}
                    //this.labneedqty.Text = "待收数量 "+getmaterial.data.quantity.ToString() + materialbody.commonUnit + getmaterial.data.minQuantity.ToString() + materialbody.minUnit + " 已收 " + getmaterial.data.realQuantity.ToString() + materialbody.commonUnit + getmaterial.data.realMinquantity.ToString() + materialbody.minUnit;
                    GetMaterialStockInOrder();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;

                }
            }
            if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.boxcode))
            {
                if (!isNew)
                {
                    this.txtbarcode.Enabled = false;
                    this.dtdate.Enabled = true;
                    this.dtdate.Focus();
                }
                else
                {
                    //this.cbisqt.Enabled = true;
                    //this.cbisqt.Focus();
                    this.txtbarcode.Enabled = false;
                    this.cmbisqt.Enabled = true;
                    this.cmbisqt.Focus();
                }
            }
            else 
            {
                this.txtbarcode.Enabled = false;
                this.txtbatch.Enabled = true;
                this.txtbatch.Focus();
                //this.cmbmaterialCondition.Enabled = true;
                //this.cmbmaterialCondition.Focus();
                //this.txtcommonqty.Enabled = true;
                //this.txtcommonqty.Focus();
            }
            
            //else
            //{
            //    this.cbisqt.Enabled = true;
            //    this.cbisqt.Focus();
            //}
            
        }

        int ci = 0;
        int mi = 0;
        void GetMaterialStockInOrder()
        {
            //if (getmaterial == null || getmaterial.data.Count == 0 || row >= getmaterial.data.Count)
            //{
            string x = HttpHelper.HttpPost("verifyMaterialStockInOrder", @"materialCode=" + materialbody.code + "&lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode);
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
            //}
            //ci = getmaterial.data[row].quantity - getmaterial.data[row].realQuantity + (int)(Math.Ceiling(((double)(getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity) / materialbody.spec)));
            //if (getmaterial.data[row].minQuantity > getmaterial.data[row].realMinquantity)
            //{
            //    ci = getmaterial.data[row].quantity - getmaterial.data[row].realQuantity;
            //}
            //else
            //{
            //    ci--;
            //}
            //mi = (getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity) % materialbody.spec;
           
            //if (mi < 0)
            //{
            //    mi += materialbody.spec;
            //}
            //else
            //{
            //    mi=getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity;
            //}
            ci = getmaterial.data[0].quantity - getmaterial.data[0].realQuantity - getmaterial.data[0].surplusQuantity;
            mi = getmaterial.data[0].minQuantity - getmaterial.data[0].realMinquantity - getmaterial.data[0].surplusMinQuantity;
            int imax = ci * getmaterial.data[0].spec + mi;

            if (ci < 0 || mi < 0)
            {
                ci = imax / getmaterial.data[0].spec;
                mi = imax % getmaterial.data[0].spec;

            }

            this.labneedqty.Text = "待收 " + ci + materialbody.commonUnit + mi + materialbody.minUnit + " 已收 " + getmaterial.data[row].realQuantity.ToString() + materialbody.commonUnit + getmaterial.data[row].realMinquantity.ToString() + materialbody.minUnit;
            if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.batchNo))
            {
                this.txtbatch.Text = getmaterial.data[row].batchNo;
            }
            DateTime? dat=null;
            if (!string.IsNullOrEmpty(getmaterial.data[row].pdate))
            {
                try
                {
                    dat = Convert.ToDateTime(getmaterial.data[row].pdate);
                }
                catch (Exception)
                {


                }
            }
            if(dat!=null)
            {
                if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.pdate))
                {
                    this.dtdate.Value = (DateTime)dat;
                }
            }
            //this.labmaterialcode.Text = materialbody.code;
            this.labmaterialname.Text = "物料代码 " + materialbody.code + " 描述 " + materialbody.name;
            this.labcommonUnit.Text = materialbody.commonUnit;
            this.labminunit.Text = materialbody.minUnit;
            this.txtbarcode.Enabled = false;
            this.dtdate.Enabled = true;
            this.dtdate.Focus();
        }

        Model.MTrayByBox mm = null;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.labcustomer.Text = "";
                this.txttraycode.Text = "";
                this.txttraycode.Enabled = false;
                this.txtorderid.Enabled = true;
                this.txtorderid.Text = "";
                this.txtorderid.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            ////this.txttraycode.Text = this.txttraycode.Text.ToUpper();
           
            if (this.txttraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描条码");
                this.txttraycode.SelectAll();
                return;
            }
            if (Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("getTrayByBox错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                    if (mm == null)
                        throw new Exception("getTrayByBox错误信息捕捉失败1");
                    mm.data.boxcode = this.txttraycode.Text;
                    this.txttraycode.Text = mm.data.trayCode;
                    this.txtbarcode.Text = mm.data.barCode;
                    this.dtdate.Value = Convert.ToDateTime(mm.data.pdate);
                    this.txtbatch.Text = mm.data.batchNo;
                    //this.cmbmaterialCondition.Text = mm.data.materialStatus;
                    //this.labmaterialcode.Text = mm.data.materialCode;
                    //this.labmaterialname.Text = mm.data.materialName;
                    Cursor.Current = Cursors.Default;
                    //materialbody = new Rf_Wms.Model.Mmaterialcodebody();
                    //materialbody.code = mm.data.materialCode;
                    //materialbody.spec = mm.data.spec;
                    //this.labcommonUnit.Text = mm.data.commonUnit;
                    //this.labminunit.Text = mm.data.minUnit;
                    //materialbody.commonUnit=mm.data.min
                    KeyPressEventArgs xx = new KeyPressEventArgs((char)Keys.Enter);
                    this.txtbarcode.Enabled = true;
                    this.txttraycode.Enabled = false;
                    this.txtbarcode_KeyPress(null, xx);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;

                }
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("verifyTrayCode", @"trayCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode );
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("verifyTrayCode错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    Cursor.Current = Cursors.Default;
                   
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;

                }
            }

            if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.boxcode))
            {
                this.txttraycode.Enabled = false;
                this.txtbarcode.Enabled = true;
                this.txtbarcode.Focus();
            }
           
            
        }

        private void frmPicking_Load(object sender, EventArgs e)
        {
            //if (!isRed)
            //{
            //    this.cmbmaterialCondition.DataSource = Comm.basein.data.stockInMaterialSurfaces;
            //}
            //else
            //{
            this.cmbmaterialCondition.DataSource = Comm.basein.data.transferMaterialSurfaces;
            //}
            this.cmbmaterialCondition.ValueMember = "code";
            this.cmbmaterialCondition.DisplayMember = "description";
            if (isRed)
            {
                this.Text = "退货收货";
                this.label1.Text = "退货单号";
            }
            else
            {
                this.Text = "正常收货";
            }
            this.cmbisqt.SelectedIndex = 0;
            init();
            //this.txtorderid.Text = "RK" + Comm.lcCode;
            this.txtorderid.Focus();
            this.txtorderid.SelectAll();
        }

        void init()
        {
            this.txttraycode.Enabled = false;
            this.txtbarcode.Enabled = false;
            this.dtdate.Enabled=false;
            this.txtbatch.Enabled = false;
            this.cmbmaterialCondition.Enabled = false;
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = false;
            this.cmbisqt.Enabled = false;
        }

        private void dtdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
               
                this.dtdate.Enabled = false;
                if (panel1.Visible)
                {
                    //this.cbisqt.Enabled = true;
                    //this.cbisqt.Focus();
                    this.cmbisqt.Enabled = true;
                    this.cmbisqt.Focus();
                }
                else
                {
                    this.labcommonUnit.Text = "";
                    this.labminunit.Text = "";
                    this.txtbarcode.Text = "";
                    //this.labmaterialcode.Text = "";
                    this.labmaterialname.Text = "";
                    this.txtbarcode.Enabled = true;
                    this.txtbarcode.Focus();
                }


                this.labneedqty.Text = "数量";
             
               
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (dtdate.Value > DateTime.Today.AddDays(1))
            {
                MessageBox.Show("生产日期不能选择当天以后的日期");
                return;
            }
            this.dtdate.Enabled = false;
            //if (string.IsNullOrEmpty(batchno))
            //{
                
                this.txtbatch.Enabled = true;
                if (string.IsNullOrEmpty(this.txtbatch.Text))
                {
                    this.txtbatch.Text = dtdate.Value.ToString("yyyyMMdd");
                }
                this.txtbatch.Focus();
                this.txtbatch.SelectAll();
            //}
            //else
            //{
            //    this.txtbatch.Text = batchno;
            //    this.txtbatch.Enabled = true;
            //    this.txtbatch.Focus();
            //    this.txtbatch.SelectAll();
            //    //this.cmbmaterialCondition.Enabled = true;
            //    //this.cmbmaterialCondition.Focus();
            //}
        }

        private void txtbatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                //this.dtdate.Enabled = true;
                this.txtbatch.Enabled = false; 
                this.txtbatch.Text = "";
                //this.dtdate.Focus();
                if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.boxcode))
                {

                    this.dtdate.Enabled = true;


                    this.dtdate.Focus();
                }
                else
                {
                    mm = null;
                    this.txtbarcode.Text = "";
                    //this.labmaterialcode.Text = "";
                    this.labmaterialname.Text = "";
                    this.labneedqty.Text = "";
                    this.txttraycode.Enabled = true;
                    this.txttraycode.Text = "";
                    this.txttraycode.Focus();
                }
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.txtbatch.Text = this.txtbatch.Text.ToUpper();
            if (this.txtbatch.Text.Length == 0)
            {
                MessageBox.Show("批次格式不对");
                this.txtbatch.SelectAll();
                return;
            }
            if (this.txtbatch.Text.Length > 30)
            {
                MessageBox.Show("批次过长");
                this.txtbatch.SelectAll();
                return;
            }
            this.txtbatch.Enabled = false;

            this.cmbmaterialCondition.Enabled = true;
            this.cmbmaterialCondition.Focus();
            //this.txtcommonqty.Enabled = true;
            //this.txtcommonqty.Focus();
        }

        private void cmbmaterialCondition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                //this.cmbmaterialCondition.Enabled = false;
                //if (string.IsNullOrEmpty(batchno))
                //{
                //    this.txtbatch.Enabled = true;

                //    this.txtbatch.SelectAll();
                //    this.txtbatch.Focus();
                //}
                //else
                //{
                //    this.dtdate.Enabled = true;
                //    this.dtdate.Focus();
                //}
                this.cmbmaterialCondition.Enabled = false;
                this.txtcommonqty.Enabled = false;
                this.txtcommonqty.Text = "";
                //if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.boxcode))
                //{

                    //this.cmbmaterialCondition.Enabled = true; ;

                    //this.cmbmaterialCondition.Focus();
                    this.txtbatch.Enabled = true;

                    this.txtbatch.SelectAll();
                    this.txtbatch.Focus();
                //}
                //else
                //{
                //    this.txttraycode.Enabled = true;
                //    this.txttraycode.Text = "";
                //    this.txttraycode.Focus();
                //}
                //return;
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (mm == null || mm.data == null)
            {
            }
            else
            {
                this.txtcommonqty.Text = (mm.data.quantity - mm.data.realQuantity).ToString();
                this.txtminqty.Text = (mm.data.minQuantity - mm.data.realMinquantity).ToString();
            }
            this.cmbmaterialCondition.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtcommonqty.Enabled = false;
                this.txtcommonqty.Text = "";
                this.txtminqty.Text = "";
                //if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.boxcode))
                //{
                    
                    this.cmbmaterialCondition.Enabled = true; ;
                   
                    this.cmbmaterialCondition.Focus();
                //}
                //else
                //{
                    //this.txttraycode.Enabled = true;
                    //this.txttraycode.Text = "";
                    //this.txttraycode.Focus();
                //}
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
            if (!stockin.data.overchargesFlag)
            {
                int r = (getmaterial.data[row].quantity - commonqty - getmaterial.data[row].realQuantity) * materialbody.spec + getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity;
                //int r = ci - commonqty;
                if (r<0)
                {
                    MessageBox.Show("不能超收");
                    this.txtcommonqty.SelectAll();
                    return;
                }
            }
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Text = "0";
            btnShelve.Visible = true;
            this.txtminqty.Focus();
            this.txtminqty.SelectAll();
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
            if (minqty<0)
            {
                throw new Exception("不能输入负数");

            }
            if (!stockin.data.overchargesFlag)
            {
                //int r = getmaterial.data[row].quantity - commonqty - getmaterial.data[row].realQuantity;
                //if (r > 0)
                //    r = 0;
                //r = getmaterial.data[row].minQuantity - minqty - getmaterial.data[row].realMinquantity - (r * -1) * materialbody.spec;
                int r = (getmaterial.data[row].quantity - commonqty - getmaterial.data[row].realQuantity) * materialbody.spec + getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity-minqty;
                if (r < 0)
                {
                    throw new Exception("不能超收");

                }
              
            }
            if (commonqty <= 0 && minqty <= 0)
            {
                throw new Exception("数量过小");
                
            }
        }

        private void txtminqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtcommonqty.Enabled = true;
                this.txtminqty.Enabled = false;
                this.txtminqty.Text = "";
                this.txtcommonqty.Focus();
                btnShelve.Visible = false;
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
            this.btnShelve.Visible = false;
        }

        void Save()
        {

            string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&materialCode=" + materialbody.code + "&quantity=" + commonqty + "&minQuantity=" + minqty + "&pDate=" + this.dtdate.Value.ToString("yyyy-MM-dd") + "&batchNo=" + this.txtbatch.Text + "&materialStatus=" + this.cmbmaterialCondition.SelectedValue.ToString() + "&trayCode=" + this.txttraycode.Text + "&updater=" + Comm.usercode;
            if (getmaterial != null && getmaterial.data.Count > 0)
            {
                con += "&itemId=" + getmaterial.data[row].itemId.ToString();
            }
            if (!isNew)
            {
                con += "&noOrder=false";
            }
            else
            {
                con += "&noOrder=true";
            }
            if (panel1.Visible)
            {
                string isqt = "false";
                if (this.cmbisqt.Text == "是")
                    isqt = "true";
                con += "&isQt=" + isqt;
            }
            //if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.boxcode))
            //{
            //    if (string.IsNullOrEmpty(batchno))
            //    {
            //        con += "&checkBatchNo=false";
            //    }
            //    else
            //    {
            //        con += "&checkBatchNo=true";
            //    }
            //}
            //else
            //{
            //    con += "&checkBatchNo=false";
            //}
            string x = HttpHelper.HttpPost("submitOperate", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);

            traycode = this.txttraycode.Text;
            //this.btnShelve.Visible = true;
            //getmaterial.data.minQuantity -= minqty;
            //getmaterial.data.quantity -= commonqty;
            Clear();
           
           
        }

        string traycode = "";
        string batchno = "";
        void Clear()
        {
            getmaterial = null;
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
            this.txttraycode.Text = "";
            //this.txttraycode.SelectAll();
            this.txtbarcode.Text = "";
            //this.labmaterialcode.Text = "";
            this.labmaterialname.Text = "";
            this.labneedqty.Text = "待收";
            this.txtbatch.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            this.labminunit.Text = "";
            this.labcommonUnit.Text = "";
            batchno = "";
            this.txtminqty.Enabled = false;
        }

        private void btnkeybord_Click(object sender, EventArgs e)
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

        private void btnShelve_Click(object sender, EventArgs e)
        {

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

            //if (traycode == "")
            //    return;
            if (!isRed)
            {
                frmshelve frm = new frmshelve();
                //frmrefundshelveOne frm = new frmrefundshelveOne();
                frm.traycode = traycode;
                frm.ShowDialog();
            }
            else
            {
                frmrefundshelveOne frm = new frmrefundshelveOne();
                frm.traycode = traycode;
                frm.ShowDialog();
            }
        }

        Model.MShowList ms = null;
        private void btnData_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("/allWaitingStockinItem", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                ms = (Model.MShowList)JsonConvert.DeserializeObject(x, typeof(Model.MShowList));
                if (ms == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (ms.data.Count == 0)
                {
                    throw new Exception("该单据已经操作完成");
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            DataTable dt = Comm.GetDT(ms.data);
            
            Ot.frmList frm = new Rf_Wms.Ot.frmList();
            frm.dt = dt;
            frm.txtname = "待收货列表";
            frm.ShowDialog();
        }

        private void txtorderid_GotFocus(object sender, EventArgs e)
        {
            txtorderid.SelectAll();
        }

        private void txttraycode_GotFocus(object sender, EventArgs e)
        {
            txttraycode.SelectAll();
        }

        private void txtbarcode_GotFocus(object sender, EventArgs e)
        {
            txtbarcode.SelectAll();
        }

        private void txtbatch_GotFocus(object sender, EventArgs e)
        {
            txtbatch.SelectAll();
        }

        private void txtcommonqty_GotFocus(object sender, EventArgs e)
        {
            txtcommonqty.SelectAll();
        }

        private void txtminqty_GotFocus(object sender, EventArgs e)
        {
            txtminqty.SelectAll();
        }

        private void cbisqt_Click(object sender, EventArgs e)
        {
            //this.cbisqt.Enabled = false;
            //this.dtdate.Enabled = true;
            //this.dtdate.Focus();
        }

        private void cbisqt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.labcommonUnit.Text = "";
                this.labminunit.Text = "";
                this.txtbarcode.Text = "";
                //this.labmaterialcode.Text = "";
                this.labmaterialname.Text = "";
                //this.cbisqt.Enabled = false;
                this.txtbarcode.Enabled = true;
                this.txtbarcode.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;

            //this.cbisqt.Enabled = false;
            this.dtdate.Enabled = true;
            this.dtdate.Focus();
            
        }

        private void cmbisqt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.labcommonUnit.Text = "";
                this.labminunit.Text = "";
                this.txtbarcode.Text = "";
                //this.labmaterialcode.Text = "";
                this.labmaterialname.Text = "";
                this.cmbisqt.Enabled = false;
                this.txtbarcode.Enabled = true;
                this.txtbarcode.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;

            this.cmbisqt.Enabled = false;
            this.dtdate.Enabled = true;
            this.dtdate.Focus();
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            if (getmaterial == null || getmaterial.data.Count == 0)
                return;
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            row++;
            if (row == getmaterial.data.Count)
            {
                try
                {
                    GetMaterialStockInOrder();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                //this.labneedqty.Text = "待收数量 " + getmaterial.data[row].quantity.ToString() + materialbody.commonUnit + getmaterial.data[row].minQuantity.ToString() + materialbody.minUnit + " 已收 " + getmaterial.data[row].realQuantity.ToString() + materialbody.commonUnit + getmaterial.data[row].realMinquantity.ToString() + materialbody.minUnit;
                this.labneedqty.Text = "待收 " + (getmaterial.data[row].quantity - getmaterial.data[row].realQuantity) + materialbody.commonUnit + (getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity) + materialbody.minUnit + " 已收 " + getmaterial.data[row].realQuantity.ToString() + materialbody.commonUnit + getmaterial.data[row].realMinquantity.ToString() + materialbody.minUnit;
                this.txtbatch.Text = getmaterial.data[row].batchNo;
                //this.labmaterialcode.Text = materialbody.code;
                this.labmaterialname.Text = "物料代码 " + materialbody.code + " 描述 " + materialbody.name;
                this.labcommonUnit.Text = materialbody.commonUnit;
                this.labminunit.Text = materialbody.minUnit;
                DateTime? dat = null;
                if (!string.IsNullOrEmpty(getmaterial.data[row].pdate))
                {
                    try
                    {
                        dat = Convert.ToDateTime(getmaterial.data[row].pdate);
                    }
                    catch (Exception)
                    {


                    }
                }
                if (dat != null)
                {
                    this.dtdate.Value = (DateTime)dat;
                }
                this.txtbarcode.Enabled = false;
                this.dtdate.Enabled = true;
                this.dtdate.Focus();
            }
        }

        private void frmreceipting_Closing(object sender, CancelEventArgs e)
        {
            CloseOrderid();
        }

        private void label6_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}