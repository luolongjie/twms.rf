using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Rf_Wms.CK
{
    public partial class frmCheckVoSecond : Form
    {
        public frmCheckVoSecond()
        {
            InitializeComponent();
        }

        public Model.MrepeatInfos m=null;
        
        public string orderid = "";

        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txtorderid.Text.Length < 5)
            {
                MessageBox.Show("请输入正确的盘点单号");
                this.txtorderid.Text = "";
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetVouch();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            this.txtorderid.Enabled = false;
            this.txtSlId.Enabled = true;
            this.txtSlId.Focus();
        }

        Model.Mmsg msg = null;
        //Model.McheckResult mc = null;
        void GetVouch()
        {
            //m = null;
            string conn = @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whCode=" + Comm.warehousecode;
            if (m != null)
            {
                conn+="&orderItemId="+m.data.nextItemId;
            }
            //if (isSave)
            //{
            //    conn += "&orderItemId=" + o.orderItemId + "&updater=" + Comm.usercode + "&quantity=" + commonqty + "&minQuantity=" + minqty; ;
            //}
            string x = HttpHelper.HttpPost("repeatInfos", conn);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            m = (Model.MrepeatInfos)JsonConvert.DeserializeObject(x, typeof(Model.MrepeatInfos));
            if (m == null || m.data==null)
            {
                this.txtminqty.Enabled = false;
                this.txttraycode.Text = "";
                this.txtcommonqty.Text = "";
                this.txtminqty.Text = "";
                this.labminunit.Text = "";
                this.labmaterialcode.Text = "";
                this.labbatch.Text = "";
                this.labcommonUnit.Text = "";
                this.labsIname.Text = "";
                this.labinfo.Text = "";
                this.labqtyall.Text = "";
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                //return;
                m = null;
                throw new Exception("没有可复盘的复盘明细");
            }
            //this.labsIname.Text = m.data.slName;
            //this.labmaterialname.Text = m.data.materialName;
            //this.labcommonUnit.Text = m.data.commonUnitName;
            //this.labminunit.Text = m.data.minUnitName;
            //this.labinfo.Text = m.data.pdate;
            ShowLAB();
            //this.labinfo.Text += " " + m.data.quantity.ToString() + m.data.commonUnitName +m.data.minQuantity.ToString() + m.data.minUnitName;
            
        }

        private void txtSlId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                //if (m != null)
                //    return;
                this.labmaterialcode.Text = "";
                this.labbatch.Text = "";
                this.labinfo.Text = "";
                this.labsIname.Text = "";
                this.txtSlId.Text = "";
                this.txtSlId.Enabled = false;
                this.txtorderid.Enabled = true;
                this.txtorderid.Text = "";
                this.txtorderid.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            //this.txtSlId.Text = this.txtSlId.Text.ToUpper();
            if (this.txtSlId.Text != m.data.slName)
            {
                MessageBox.Show("盘点库位不正确");
                this.txtSlId.SelectAll();
                return;
            }
            this.txtSlId.Enabled = false;
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
        }

        bool iscv = false;
        private void frmCheckVoSecond_Load(object sender, EventArgs e)
        {
            this.txttraycode.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            this.labminunit.Text = "";
            this.labmaterialcode.Text = "";
            this.labbatch.Text = "";
            this.labcommonUnit.Text = "";
            this.labsIname.Text = "";
            this.labinfo.Text = "";
            this.labqtyall.Text = "";
            if (orderid != "")
            {
                this.txtorderid.Text = orderid;
                iscv = true;
                ShowLAB();
                this.txtSlId.Text = labsIname.Text;
                this.txtorderid.Enabled = false;
                this.txtSlId.Enabled = false;
                this.txttraycode.Enabled = true;
                this.txttraycode.Focus();
                //this.txtSlId.Focus();
            }
            else
            {
                this.txtorderid.Focus();
                this.btnNext.Visible = true;
                this.txtSlId.Enabled = false;
                this.txttraycode.Enabled = false;
            }
          
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = false;
        }

        int checkcount = 0;
        void ShowLAB()
        {
            this.txtminqty.Enabled = false;
            this.txttraycode.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            this.labminunit.Text = m.data.minUnitName;
            this.labmaterialcode.Text = "物料描述 "+m.data.materialCode+" "+m.data.materialName;
            this.labbatch.Text = "批次 "+m.data.batchNo+" 生产日期 "+m.data.pdate;
            this.labcommonUnit.Text = m.data.commonUnitName;
            this.labsIname.Text = m.data.slName;
            checkcount = (from r in m.data.trayRepeats where r.ischecked select r).Count();
            this.labinfo.Text = "共有" + m.data.trayRepeats.Count.ToString() + "托,已盘"+checkcount.ToString()+"托";
            bool t = true;;
            if (m.data.realQuantity > m.data.quantity)
            {
                t = false;

            }
            if (t)
            {
                this.labqtyall.Text = "账面数比初盘数多了" + (m.data.quantity - m.data.realQuantity).ToString() + m.data.commonUnitName;
            }
            else
            {
                this.labqtyall.Text = "账面数比初盘数少了" + (m.data.realQuantity - m.data.quantity).ToString() + m.data.commonUnitName;
            }
            t = true; 
            if ( m.data.minQuantity < m.data.realMinquantity)
            {
                t = false;
            }
            if (t)
            {
                this.labqtyall.Text += "多了"+(m.data.minQuantity - m.data.realMinquantity).ToString() + m.data.minUnitName;
            }
            else
            {
                this.labqtyall.Text += "少了"+ (m.data.realMinquantity - m.data.minQuantity).ToString() + m.data.minUnitName;
            }
            //this.txtcommonqty.Text = m.data.quantity.ToString();
            //this.txtminqty.Text = m.data.minQuantity.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Model.repeatTraycode o = null;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {


                this.txttraycode.Text = "";
                this.txttraycode.Enabled = false;
                this.txtSlId.Enabled = true;
                this.txtSlId.Text = "";
                this.txtSlId.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            Model.MTrayByBox mm = null;
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
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                    if (mm == null)
                        throw new Exception("getTrayByBox错误信息捕捉失败");
                    this.txttraycode.Text = mm.data.trayCode;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    this.txttraycode.SelectAll();
                    MessageBox.Show(ex.Message);
                    return;

                }
               
            }
            var q = from r in m.data.trayRepeats where r.trayCode == this.txttraycode.Text select r;
            if (q.Count() == 0)
            {
                MessageBox.Show("本次复盘数据中没有该托盘");
                this.txttraycode.SelectAll();
                return;
            }
            o = q.First();
            this.labinfo.Text = "共有" + m.data.trayRepeats.Count.ToString() + "托,已盘" + checkcount.ToString() + "托 托盘库存:" + o.quantity + m.data.commonUnitName + o.minQuantity + m.data.minUnitName;
            this.txtcommonqty.Text = o.quantity.ToString();
            this.txtminqty.Text = o.minQuantity.ToString();
            this.txttraycode.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
            //this.txtbarcode.Enabled = true;
            //this.txtbarcode.Focus();
        }

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                if (iscv)
                    return;
                this.txtcommonqty.Enabled = false;
                this.txttraycode.Enabled = true; ;
                this.txtcommonqty.Text = "";
                this.txttraycode.Focus();
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
                MessageBox.Show("请输入正确数量");
                this.txtminqty.SelectAll();
                return;
            }
            if (minqty > 1000000)
            {
                MessageBox.Show("数量过大");
                this.txtminqty.SelectAll();
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn = @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whCode=" + Comm.warehousecode;
                conn += "&orderItemId=" + m.data.orderItemId + "&updater=" + Comm.usercode + "&quantity=" + commonqty + "&minQuantity=" + minqty + "&trayCode="+this.txttraycode.Text;
                conn += "&batchNo=" + m.data.batchNo + "&pdate=" + m.data.pdate + "&inDate=" + m.data.inDate + "&materialStatus=" + (from r in Comm.basein.data.transferMaterialSurfaces where r.description == m.data.materialStatus select r).First().code;
                string x = HttpHelper.HttpPost("repeatResult", conn);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Cursor.Current = Cursors.Default;
                o.ischecked = true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            m.data.realQuantity += o.quantity - commonqty;//
            m.data.realMinquantity += o.minQuantity - minqty;
            ShowLAB();
            if (checkcount == m.data.trayRepeats.Count)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Finishtraycode();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("提交成功,但是完成复盘失败"+ex.Message);
                    return;
                }
                if (!string.IsNullOrEmpty(orderid))
                {
                    this.Close();
                    return;
                }
                else
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        GetVouch();
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show( ex.Message);
                        return;
                    }
                   
                    this.txtSlId.Text = "";
                    this.txtSlId.Enabled = true;
                    this.txtSlId.Focus();
                    return;
                }
            }
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetVouch();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
            {
                this.txtorderid.Focus();
                MessageBox.Show("请先扫描盘点单号");
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Finishtraycode();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            if (!string.IsNullOrEmpty(orderid))
            {
                this.Close();
                return;
            }
            KeyPressEventArgs arg=new KeyPressEventArgs((char)(Keys.Enter));
            txtorderid_KeyPress(null, arg);
        }

        void Finishtraycode()
        {
            string conn = @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whCode=" + Comm.warehousecode;
            conn += "&orderItemId=" + m.data.orderItemId + "&updater=" + Comm.usercode;
            string x = HttpHelper.HttpPost("finishRepeat", conn);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("finishRepeat错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
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
        
    }
}