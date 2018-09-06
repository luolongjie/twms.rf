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
    public partial class frmDirTranMove : Form
    {
        public frmDirTranMove()
        {
            InitializeComponent();
        }

        private void frmDirTranMove_Load(object sender, EventArgs e)
        {
            //Ot.frmTMcustomer frm = new Rf_Wms.Ot.frmTMcustomer();
            //frm.ShowDialog();
            //if (frm.ccode == "")
            //{
            //    this.Close();
            //}
            //else
            //{
            //    this.laborderid.Text = frm.ccode;
            //}
            this.cmbmaterialSurface.DataSource = Comm.basein.data.transferMaterialSurfaces;
            this.cmbmaterialSurface.ValueMember = "code";
            this.cmbmaterialSurface.DisplayMember = "description";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("createNoOrderTransfer", @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&updater=" + Comm.usercode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.Mccode m = (Model.Mccode)JsonConvert.DeserializeObject(x, typeof(Model.Mccode));
                if (m == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (m.data == "")
                {
                    throw new Exception("生单有问题，请退出再进");
                }
                this.laborderid.Text = m.data;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();

            
            //this.txtSlname.Focus();
        }

        Model.MTrayByBox mm = null;
        Model.Mmsg msg = null;
        Model.MTrayStockByOrderType mt = null;
        int maxquantity = 0;
        int maxminquantity = 0;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 27)
            //{
            //    this.txttraycode.Text = "";
            //    this.txttraycode.Enabled = false;
            //    this.txtSlname.Enabled = true;
            //    this.txtSlname.Text = "";
            //    this.txtSlname.Focus();
            //    return;
            //}
            if(e.KeyChar!=13)
                return;
            if (this.txttraycode.Text == "")
            {
                return;
            }
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            if (this.txttraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描条码");
                this.txttraycode.SelectAll();
                return;
            }
            //if (Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
            //{
            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        string x = HttpHelper.HttpPost("trayStock/getTrayStockByBoxCode", @"boxCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
            //        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //        if (msg == null)
            //            throw new Exception("getTrayByBox错误信息捕捉失败");
            //        if (!msg.success)
            //            throw new Exception(msg.msg);
            //        mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
            //        if (mm == null)
            //            throw new Exception("getTrayByBox错误信息捕捉失败1");
            //        //if (mm.data == null)
            //        //{
            //        //    throw new Exception("该托盘是空托盘");
            //        //}
            //        this.txttraycode.Text =mm.data.trayCode;
                  
                   
            //        Cursor.Current = Cursors.Default;
                   
            //    }
            //    catch (Exception ex)
            //    {
            //        Cursor.Current = Cursors.Default;
            //        txttraycode.SelectAll();
            //        MessageBox.Show(ex.Message);
            //        return;

            //    }
            //}
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //string x = HttpHelper.HttpPost("trayStock/findTrayStockByOrderType", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttraycode.Text + "&type=2" );
                string x = HttpHelper.HttpPost("trayStock/verifyFromTrayCodeNotZC", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttraycode.Text + "&whCode=" + Comm.warehousecode + "&transferType=1");
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mt = (Model.MTrayStockByOrderType)JsonConvert.DeserializeObject(x, typeof(Model.MTrayStockByOrderType));
                if (mt == null)
                {
                    throw new Exception("verifyFromTrayCodeNotZC捕捉失败");
                }
                if (mt.data == null || string.IsNullOrEmpty(mt.data.materialCode))
                {
                    throw new Exception("该容器没有商品");
                }

                //if (mt.data.materialCode != mtrans.data.materialCode)
                //{
                //    throw new Exception("托盘物料和提示物料不同");
                //}
                //if (mt.data.batchNo != mtrans.data.batchNo)
                //{
                //    throw new Exception("托盘批次和提示批次不同");
                //}
                //if (mt.data.slId != mtrans.data.fromSlId)
                //{
                //    throw new Exception("托盘批次和提示批次不同");
                //}
                //this.labtrayqty.Text = mt.data.quantity.ToString() + mtrans.data.commonUnitName + mt.data.minQuantity.ToString() + mtrans.data.minUnitName;
                //this.cmbmaterialCondition.SelectedValue = mt.data.materialStatus;
                if (!string.IsNullOrEmpty(mt.data.trayCode))
                {
                    if (mt.data.trayCode != this.txttraycode.Text)
                    {
                        this.txttraycode.Text = mt.data.trayCode;
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                this.txttraycode.SelectAll();
                MessageBox.Show(ex.Message);
                return;

            }
            //if (mt.data==null || mt.data.slId != ms.data.slId)
            //{
            //    MessageBox.Show("该托盘不在该库位上");
            //    this.txttraycode.SelectAll();
            //    return;
            //}
            this.labmaterialStatusStr.Text = mt.data.materialStatusStr;
            this.labminunit.Text = mt.data.minUnitName;
            this.labcommonUnit.Text = mt.data.commonUnitName;
            this.labinfo.Text = mt.data.pdate;
            int imax = mt.data.quantity * mt.data.spec + mt.data.minQuantity;
            maxquantity = mt.data.quantity;
            maxminquantity = mt.data.minQuantity;
            if (maxminquantity < 0 || maxminquantity < 0)
            {

                maxquantity = imax / mt.data.spec;
                maxminquantity = imax % mt.data.spec;
            }
            this.labinfo.Text += " " + maxquantity + mt.data.commonUnitName + maxminquantity + mt.data.minUnitName;
            this.cmbmaterialSurface.Text = mt.data.materialStatusStr;
            this.labmaterialname.Text = mt.data.materialName;
            this.txttraycode.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            CloseOrderid();
            this.Close();
        }

        void CloseOrderid()
        {
           
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn = @"orderId=" + this.laborderid.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&updater=" + Comm.usercode;
                Comm.islog = false;
                string x = HttpHelper.HttpPost("deleteOrSubmitTransferOrder", conn);
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

        Model.MSlIdBySlName ms = null;
        Model.MSlIdBySlName ms1 = null;
        private void txtSlname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            //if (this.txtSlname.Text == "")
            //    return;
            //this.txtSlname.Text = this.txtSlname.Text.ToUpper();
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    string x = HttpHelper.HttpPost("trayStock/findSlIdBySlName", @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&slName=" + this.txtSlname.Text);
            //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //    if (msg == null)
            //        throw new Exception("findSlIdBySlName错误信息捕捉失败");
            //    if (!msg.success)
            //        throw new Exception(msg.msg);
            //    ms = (Model.MSlIdBySlName)JsonConvert.DeserializeObject(x, typeof(Model.MSlIdBySlName));
            //    Cursor.Current = Cursors.Default;

            //}
            //catch (Exception ex)
            //{
            //    Cursor.Current = Cursors.Default;
            //    this.txtSlname.SelectAll();
            //    MessageBox.Show(ex.Message);
            //    return;

            //}
            //this.txtSlname.Enabled = false;
            //this.txttraycode.Enabled = true;
            //this.txttraycode.Focus();
        }

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.labmaterialname.Text = "";
                this.labinfo.Text = "";
                this.txtcommonqty.Enabled = false;
                this.txttraycode.Enabled = true;
                this.txttraycode.SelectAll();
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
                MessageBox.Show("请输入数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (commonqty < 0)
            {
                MessageBox.Show("数量不能小于0");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (commonqty > maxquantity)
            {
                MessageBox.Show("输入数量大于托盘数量");
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
                MessageBox.Show("请输入数量");
                this.txtminqty.SelectAll();
                return;
            }
            if (minqty < 0)
            {
                MessageBox.Show("数量不能小于0");
                this.txtminqty.SelectAll();
                return;
            }
            if (minqty+commonqty*mt.data.spec > mt.data.minQuantity+mt.data.quantity*mt.data.spec)
            {
                MessageBox.Show("输入数量大于托盘数量");
                this.txtminqty.SelectAll();
                return;
            }
            this.txtminqty.Enabled = false;
            this.cmbmaterialSurface.Enabled = true;
            this.cmbmaterialSurface.Focus();
        }

        private void cmbmaterialSurface_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtminqty.Enabled = true;
                this.cmbmaterialSurface.Enabled = false; ;
                this.txtminqty.SelectAll();
                this.txtminqty.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.cmbmaterialSurface.Enabled = false;
            this.txttotraycode.Enabled = true;
            this.txttotraycode.Focus();
        }

        Model.MTrayStockByOrderType nmt = null;
        private void txttotraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.cmbmaterialSurface.Enabled = true;
                this.txttotraycode.Enabled = false;
                this.txttotraycode.Text = "";
                this.cmbmaterialSurface.Focus();
               
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txttotraycode.Text == "")
                return;
            //this.txttotraycode.Text = this.txttotraycode.Text.ToUpper();
            if (this.txttotraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描条码");
                this.txttraycode.SelectAll();
                return;
            }
            if (Comm.lcCode != this.txttotraycode.Text.Substring(0, Comm.lcCode.Length))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //string x = HttpHelper.HttpPost("replenishOrder/getTrayByBox", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("getTrayByBox错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                    if (mm == null)
                        throw new Exception("错误信息捕捉失败");
                    this.txttotraycode.Text = mm.data.trayCode;
                    Cursor.Current = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    this.txttotraycode.SelectAll();
                    MessageBox.Show(ex.Message);
                    return;

                }
            }
            if (this.txttotraycode.Text == this.txttraycode.Text)
            {
                if (mt.data.quantity*mt.data.spec+mt.data.minQuantity != commonqty*mt.data.spec+ minqty)
                {
                    MessageBox.Show("部分转储不允许使用同一托盘");
                    this.txttotraycode.SelectAll();
                    return;
                }
            }
            else
            {
                //if (Comm.lcCode != this.txttotraycode.Text.Substring(0, Comm.lcCode.Length))
                //{
                //    try
                //    {
                //        Cursor.Current = Cursors.WaitCursor;
                //        //string x = HttpHelper.HttpPost("replenishOrder/getTrayByBox", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
                //        string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
                //        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                //        if (msg == null)
                //            throw new Exception("getTrayByBox错误信息捕捉失败");
                //        if (!msg.success)
                //            throw new Exception(msg.msg);
                //        mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                //        if (mm == null)
                //            throw new Exception("错误信息捕捉失败");
                //        this.txttotraycode.Text = mm.data.trayCode;
                //        Cursor.Current = Cursors.Default;

                //    }
                //    catch (Exception ex)
                //    {
                //        Cursor.Current = Cursors.Default;
                //        this.txttotraycode.SelectAll();
                //        MessageBox.Show(ex.Message);
                //        return;

                //    }
                //}
                //else
                //{
                //    try
                //    {
                //        Cursor.Current = Cursors.WaitCursor;
                //        string x = HttpHelper.HttpPost("verifyTrayCode", @"trayCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode);
                //        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                //        if (msg == null)
                //            throw new Exception("verifyTrayCode错误信息捕捉失败");
                //        if (!msg.success)
                //            throw new Exception(msg.msg);
                //        Cursor.Current = Cursors.Default;

                //    }
                //    catch (Exception ex)
                //    {
                //        Cursor.Current = Cursors.Default;
                //        txttotraycode.SelectAll();
                //        MessageBox.Show(ex.Message);
                //        return;

                //    }
                //}
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("trayStock/verifyToTrayCodeNotZC", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttotraycode.Text + "&whCode=" + Comm.warehousecode + "&transferType=1");
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
                  
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    txttotraycode.SelectAll();
                    MessageBox.Show(ex.Message);
                    return;

                }

                if (nmt.data != null)//不是空托盘
                {
                    //if (nmt.data.slId != mt.data.t)
                    //{
                    //    MessageBox.Show("该托盘不在目标库位上,请换一个托盘");
                    //    this.txttotraycode.SelectAll();
                    //    return;
                    //}
                    if (mt.data.materialCode != nmt.data.materialCode)
                    {
                        MessageBox.Show("新托盘上的物料是" + nmt.data.materialName + ",不能合托,请换托盘");
                        this.txttotraycode.SelectAll();
                        return;
                    }
                    if (mt.data.inDate != nmt.data.inDate || mt.data.batchNo != nmt.data.batchNo || mt.data.pdate != nmt.data.pdate || mt.data.materialStatus != nmt.data.materialStatus)
                    {
                        DialogResult dr = MessageBox.Show("移入托盘的批次、生产日期、物料状态、入库日期存在与待转入物料不一致的情况，确认是否合托?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (dr != DialogResult.Yes)
                        {
                            this.txttotraycode.SelectAll();
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(nmt.data.trayCode))
                    {
                        if (nmt.data.trayCode != this.txttotraycode.Text)
                        {
                            this.txttotraycode.Text = nmt.data.trayCode;
                        }
                    }
                }
            }
           
            
          
            this.txttotraycode.Enabled = false;
            this.txttoslid.Enabled = true;
            this.txttoslid.Focus();
        }

        private void txttoslid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txttotraycode.Enabled = true;
                this.txttoslid.Enabled = false;
                this.txttoslid.Text = "";
                this.txttotraycode.Focus();
                this.txttotraycode.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            //if (this.txttoslid.Text != this.labtoslidname.Text)
            //{
            //    MessageBox.Show("目的库位有问题");
            //    this.txttoslid.SelectAll();
            //    return;
            //}
            //this.txttoslid.Text = this.txttoslid.Text.ToUpper();
            ms1 = null;
            if (this.txttoslid.Text != "")
            {

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("trayStock/findSlIdBySlNameNoZC", @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&slName=" + this.txttoslid.Text);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("findSlIdBySlName错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    ms1 = (Model.MSlIdBySlName)JsonConvert.DeserializeObject(x, typeof(Model.MSlIdBySlName));
                    Cursor.Current = Cursors.Default;
                    if (this.txttraycode.Text != this.txttotraycode.Text)
                    {
                        if (nmt.data!=null)
                        {
                            if (nmt.data.slId != ms1.data.slId)
                                throw new Exception("该托盘不属于该库位,请换托盘或库位");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    this.txttoslid.SelectAll();
                    return;
                }
            }
            else
            {
                if (this.txttotraycode.Text == this.txttraycode.Text)
                {
                    if (nmt == null || nmt.data == null)
                    {
                        MessageBox.Show("整托转储移入库位不能为空");
                        this.txttoslid.SelectAll();
                        return;
                    }
                }
                else if (nmt == null || nmt.data == null)
                {
                    MessageBox.Show("新托盘移入库位不能为空");
                    this.txttoslid.SelectAll();
                    return;
                }
            }
            //slid = ms.data.slId;   
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn=@"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&orderId=" + this.laborderid.Text;
                conn += "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&fromTrayCode=" + this.txttraycode.Text + "&toTrayCode=" + this.txttotraycode.Text + "&updater=" + Comm.usercode + "&fromSlId=" + mt.data.slId + "&materialCode=" + mt.data.materialCode + "&pdate=" + mt.data.pdate + "&batchNo=" + mt.data.batchNo + "&oldMaterialStatus=" + mt.data.materialStatus + "&newMaterialStatus=" + this.cmbmaterialSurface.SelectedValue.ToString() + "&inDate=" + mt.data.inDate + "&shipperCode=" + mt.data.shipperCode + "&qtStatus=" + mt.data.qtStatus;
                if (ms1 != null)
                {
                    conn += "&toSlId=" + ms1.data.slId;
                }
                string x = HttpHelper.HttpPost("submitNoOrderTransfer", conn);
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
                return;

            }
            this.labmaterialStatusStr.Text = "";
            this.labminunit.Text = "";
            this.labcommonUnit.Text = "";
            this.labinfo.Text = "";
            this.labmaterialname.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            //this.txtSlname.Text = "";
            this.txttoslid.Text = "";
            this.txttotraycode.Text = "";
            this.txttraycode.Text = "";
            //this.txtSlname.Enabled = true;
            this.txttoslid.Enabled = false;
            //this.txtSlname.Focus();
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
        }

        private void btnAssistance_Click(object sender, EventArgs e)
        {
            
            Ot.frmUpdAssistance frm = new Rf_Wms.Ot.frmUpdAssistance();
            frm.orderid = this.laborderid.Text;
            frm.fun = "updateTransferAssistance";
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(frm.assistance))
            {
                this.btnAssistance.Text = frm.assistance;
            }
            foreach (Control v in this.Controls)
            {
                if (v is TextBox)
                {
                    if (v.Enabled)
                    {
                        v.Focus();
                    }
                }
            }
        }

        private void frmDirTranMove_Closing(object sender, CancelEventArgs e)
        {
            //CloseOrderid();
        }

       
       

       
    }
}