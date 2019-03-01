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
    public partial class frmrefund : Form
    {
        public frmrefund()
        {
            InitializeComponent();
        }
        bool isNew = true;
        public bool isRed = false;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                return;
            }
           
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn=@"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode+"&whCode="+Comm.warehousecode;

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
                string x = HttpHelper.HttpPost("getMaterialCode", @"barCode=" + this.txtbarcode.Text + "&lcCode=" + Comm.lcCode + "&shipperCode=" + stockin.data.shipperInfo.shipperCode + "&whCode=" + Comm.warehousecode);
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
                this.labmaterialcode.Text = materialbody.code;
                this.labmaterialname.Text = materialbody.name;
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
                    dtdate.Enabled = true;
                    dtdate.Focus();
                  
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
            
            
        }

        int ci = 0;
        int mi = 0;
        void GetMaterialStockInOrder()
        {
            //if (getmaterial == null || getmaterial.data.Count == 0 || row >= getmaterial.data.Count)
            //{
            string x = HttpHelper.HttpPost("verifyMaterialMergeRefundOrder", @"materialCode=" + materialbody.code + "&lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whCode=" + Comm.warehousecode);
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
                //ci = getmaterial.data[row].quantity - getmaterial.data[row].realQuantity - getmaterial.data[row].surplusQuantity + (int)(Math.Ceiling(((double)(getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity - getmaterial.data[row].surplusMinQuantity) / materialbody.spec)));
                ci = getmaterial.data[row].quantity - getmaterial.data[row].realQuantity - getmaterial.data[row].surplusQuantity;
                //if (getmaterial.data[row].minQuantity > getmaterial.data[row].realMinquantity + getmaterial.data[row].surplusMinQuantity)
                //{
                //    ci = getmaterial.data[row].quantity - getmaterial.data[row].realQuantity- getmaterial.data[row].surplusQuantity;
                //}
                //else
                //{
                //    ci--;
                //}
                mi = getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity - getmaterial.data[row].surplusMinQuantity;

                //if (mi < 0)
                //{
                //    mi += materialbody.spec;
                //}
                //else
                //{
                //    mi = getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity - getmaterial.data[row].surplusMinQuantity;
                //}
                int imax = ci * materialbody.spec + mi;
                if (ci < 0 || mi < 0)
                {
                    ci = imax / materialbody.spec;
                    mi = imax % materialbody.spec;
                }


                int irmax = getmaterial.data[row].realMinquantity + getmaterial.data[row].realQuantity * materialbody.spec;
               int realqty = getmaterial.data[row].realQuantity;
                int realminqty = getmaterial.data[row].realMinquantity;
                if (realqty < 0 || realminqty < 0)
                {
                    realqty = irmax / materialbody.spec;
                    realminqty = irmax % materialbody.spec;
                }
                //this.labneedqty.Text = "待收 " + (getmaterial.data[row].quantity - getmaterial.data[row].realQuantity - getmaterial.data[row].surplusQuantity) + materialbody.commonUnit + (getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity - getmaterial.data[row].surplusMinQuantity) + materialbody.minUnit + " 已收 " + getmaterial.data[row].realQuantity.ToString() + materialbody.commonUnit + getmaterial.data[row].realMinquantity.ToString() + materialbody.minUnit;
                this.labneedqty.Text = "待收 " + ci + materialbody.commonUnit + mi + materialbody.minUnit + " 已收 " + realqty + materialbody.commonUnit + realminqty + materialbody.minUnit;
            this.txtbatch.Text = getmaterial.data[row].batchNo;
            this.labmaterialcode.Text = materialbody.code;
            this.labmaterialname.Text = materialbody.name;
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
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
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
          
            //this.cmbisqt.SelectedIndex = 0;
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
           
        }

        private void dtdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
               
                this.dtdate.Enabled = false;
                
                    this.labcommonUnit.Text = "";
                    this.labminunit.Text = "";
                    this.txtbarcode.Text = "";
                    this.labmaterialcode.Text = "";
                    this.labmaterialname.Text = "";
                    this.txtbarcode.Enabled = true;
                    this.txtbarcode.Focus();
                


                this.labneedqty.Text = "待收";
             
               
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
                    this.txttraycode.Enabled = true;
                    this.txttraycode.Text = "";
                    this.txttraycode.Focus();
                }
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.txtbatch.Text = this.txtbatch.Text.Trim();
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
                this.txtcommonqty.Enabled = false;
                this.txtcommonqty.Text = "";
                if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.boxcode))
                {

                    //this.cmbmaterialCondition.Enabled = true; ;

                    //this.cmbmaterialCondition.Focus();
                    this.txtbatch.Enabled = true;

                    this.txtbatch.SelectAll();
                    this.txtbatch.Focus();
                }
                else
                {
                    this.txttraycode.Enabled = true;
                    this.txttraycode.Text = "";
                    this.txttraycode.Focus();
                }
                //return;
                return;
            }
            if (e.KeyChar != 13)
                return;
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
                if (mm == null || mm.data == null || string.IsNullOrEmpty(mm.data.boxcode))
                {
                    
                    this.cmbmaterialCondition.Enabled = true; ;
                   
                    this.cmbmaterialCondition.Focus();
                }
                else
                {
                    this.txttraycode.Enabled = true;
                    this.txttraycode.Text = "";
                    this.txttraycode.Focus();
                }
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
                int r = (getmaterial.data[row].quantity - getmaterial.data[row].realQuantity - getmaterial.data[row].surplusQuantity - commonqty) * materialbody.spec + getmaterial.data[row].minQuantity - getmaterial.data[row].realMinquantity - getmaterial.data[row].surplusMinQuantity;
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
                int r = getmaterial.data[row].quantity - getmaterial.data[row].realQuantity - getmaterial.data[row].surplusQuantity - commonqty;
                //if (r > 0)
                //    r = 0;
                r = r*getmaterial.data[row].spec+ (getmaterial.data[row].minQuantity- getmaterial.data[row].realMinquantity- getmaterial.data[row].surplusMinQuantity)-minqty;
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
            if (string.IsNullOrEmpty(this.txtbatch.Text))
            {
                MessageBox.Show("批次不能为空");
                return;
            }
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

            string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&materialCode=" + materialbody.code + "&quantity=" + commonqty + "&minQuantity=" + minqty + "&pDate=" + this.dtdate.Value.ToString("yyyy-MM-dd") + "&batchNo=" + this.txtbatch.Text + "&materialStatus=" + this.cmbmaterialCondition.SelectedValue.ToString() + "&trayCode=" + this.txttraycode.Text + "&updater=" + Comm.usercode + "&shipperCode=" + stockin.data.shipperInfo.shipperCode;
            if (getmaterial != null && getmaterial.data.Count > 0)
            {
                con += "&itemId=" + getmaterial.data[row].itemId.ToString();
            }
            con += "&isQt=false";
            string x = HttpHelper.HttpPost("submitRefundOperate", con);
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
            this.labmaterialcode.Text = "";
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
            if (string.IsNullOrEmpty(this.txtbatch.Text))
            {
                MessageBox.Show("批次不能为空");
                return;
            }
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
            //frmshelve frm = new frmshelve();
            frmrefundshelve frm = new frmrefundshelve();
            frm.traycode = traycode;
            frm.ShowDialog();
        }

        Model.MShowList ms = null;
        private void btnData_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("allWaitingRefundItem", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text+"&whCode=" + Comm.warehousecode);
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
            //DataTable dt = Comm.GetDT(ms.data);
            DataTable dt = new DataTable();
            dt.Columns.Add("materialCode");
            dt.Columns.Add("materialName");
            dt.Columns.Add("pdate");
            dt.Columns.Add("batchNo");
            dt.Columns.Add("qty");
            dt.Columns.Add("slName");
            dt.Columns.Add("fromSlIdName");
            dt.Columns.Add("toSlIdName");
            dt.Columns.Add("trayCode");
            DataRow dr;
            foreach (Model.material v in ms.data)
            {
                //if (v.quantity == v.realQuantity && v.minQuantity == v.realMinquantity)
                //    continue;
                dr = dt.NewRow();
                dr["materialCode"] = v.materialCode;
                dr["materialName"] = v.materialName;
                //if (!string.IsNullOrEmpty(v.pDate))
                //{
                //    dr["pdate"] = v.pDate;
                //}
                //else
                //{
                    dr["pdate"] = "";
                //}
                if (!string.IsNullOrEmpty(v.batchNo))
                {
                    dr["batchNo"] = v.batchNo;
                }
                else
                {
                    dr["batchNo"] = "";
                }
                dr["slName"] = v.slName;
                //int _quantity = v.quantity-v.realQuantity-v.surplusQuantity;
                ////if (_quantity < 0)
                ////    _quantity = 0;
                //int _minquantity = v.minQuantity-v.realMinquantity-v.surplusMinQuantity;
                ////if (_minquantity < 0)
                ////    _minquantity = 0;
                //dr["qty"] = _quantity.ToString() + v.commonUnitName + _minquantity.ToString() + v.minUnitName;
                int _quantity = v.quantity - v.realQuantity-v.surplusQuantity;
                //if (_quantity < 0)
                //    _quantity = 0;
                int _minquantity = v.minQuantity - v.realMinquantity-v.surplusMinQuantity;
                //if (_minquantity < 0)
                //    _minquantity = 0;

                if (_quantity < 0 || _minquantity<0)
                {
                    int imax = _quantity * v.spec + _minquantity;
                    //_quantity = (int)(Math.Ceiling(((double)(imax) / v.spec)));
                    _quantity = imax / v.spec;
                    _minquantity = imax % v.spec;

                }
                dr["qty"] = _quantity.ToString() + v.commonUnitName + _minquantity.ToString() + v.minUnitName;
                dr["fromSlIdName"] = "";
                dr["toSlIdName"] = "";
                dr["trayCode"] = "";
                //if (string.IsNullOrEmpty(v.pDate))
                //{
                //    v.pDate = "";
                //}
                if (string.IsNullOrEmpty(v.batchNo))
                {
                    v.batchNo = "";
                }
                dt.Rows.Add(dr);
            }
            Ot.frmList frm = new Rf_Wms.Ot.frmList();
            frm.dt = dt;
            frm.txtname = "合单待收货列表";
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
                this.labmaterialcode.Text = "";
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
                this.labmaterialcode.Text = "";
                this.labmaterialname.Text = "";
                this.txtbarcode.Enabled = true;
                this.txtbarcode.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;

          
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
        }
    }
}