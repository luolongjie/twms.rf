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
    public partial class frmTranMove : Form
    {
        public frmTranMove()
        {
            InitializeComponent();
        }

        Model.MShowList ms = null;
        private void btnData_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
            {
                MessageBox.Show("请先扫描单据");
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("/waitingTrans", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whCode=" + Comm.warehousecode);
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
            frm.txtname = "待转储列表";
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Model.Mmsg msg = null;
        Model.MTranMove mtrans = null;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txtorderid.Text == "")
            {
                MessageBox.Show("请扫描单号");
                return;
            }
            //try
            //{
            //    string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode;
            //    IDictionary<string, string> parameters = new Dictionary<string, string>();
            //    parameters.Add("orderId", this.txtorderid.Text);
            //    parameters.Add("lcCode", Comm.lcCode);
            //    parameters.Add("whId", Comm.warehousecode);

            //    string x = HttpHelper.CreatePostHttpResponse("submitTransOperate", parameters);
            //    MessageBox.Show(x);
            //    return;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    this.txtorderid.SelectAll();
            //    return;

            //}
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetTrans(false);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtorderid.SelectAll();
                return;

            }
            //this.labb.Text = mtrans.data.batchNo;
            if (this.txtorderid.Text != "")
            {
                this.txtorderid.Enabled = false;
                //this.txtSlId.Enabled = true;
                //this.txtSlId.Focus();
                this.txttraycode.Enabled = true;
                this.txttraycode.Focus();
            }

        }

        private void txtSlId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                mtrans = null;
                this.labmaterialname.Text = "";
                this.labneedqty.Text = "";
                this.labfromsIId.Text = "";
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
            if (this.txtSlId.Text != mtrans.data.fromSlName.ToString())
            {
                MessageBox.Show("来源库位不正确");
                this.txtSlId.SelectAll();
                return;
            }
            this.txtSlId.Enabled = false;
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
        }

        Model.MTrayStockByOrderType mt = null;
        Model.Mtray _mt;
         int maxquantity = 0;
         int maxminquantity = 0;
         int mmaxquantity = 0;
         int mmaxminquantity = 0;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txttraycode.Text = "";
                this.txttraycode.Enabled = false;
                //this.txtSlId.Enabled = true;
                //this.txtSlId.Text = "";
                //this.txtSlId.Focus();
                mtrans = null;
                this.labmaterialname.Text = "";
                this.labneedqty.Text = "";
                this.labfromsIId.Text = "";
                this.txtorderid.Enabled = true;
                this.txtorderid.Text = "";
                this.txtorderid.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txttraycode.Text == "")
                return;
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            //Model.MTrayByBox mm = null;
            //if (this.txttraycode.Text.Length < Comm.lcCode.Length || Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
            //{
            //    try
            //    {
            //        string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
            //        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //        if (msg == null)
            //            throw new Exception("错误信息捕捉失败");
            //        if (!msg.success)
            //            throw new Exception(msg.msg);
            //        mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
            //        if (mm == null)
            //            throw new Exception("错误信息捕捉失败");
            //        this.txttraycode.Text = mm.data;

            //    }
            //    catch (Exception ex)
            //    {
            //        this.txttraycode.SelectAll();
            //        MessageBox.Show(ex.Message);
            //        return;

            //    }
            //}
            //try
            //{
            //    //string x = HttpHelper.HttpPost("trayStock/findTrayStockByOrderType", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttraycode.Text + "&type=2" );
            //    string x = HttpHelper.HttpPost("trayStock/findTrayStockByOrderType", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttraycode.Text );
            //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //    if (msg == null)
            //        throw new Exception("错误信息捕捉失败");
            //    if (!msg.success)
            //        throw new Exception(msg.msg);
            //    mt = (Model.MTrayStockByOrderType)JsonConvert.DeserializeObject(x, typeof(Model.MTrayStockByOrderType));
            //    if (mt == null)
            //    {
            //        throw new Exception("findTrayStockByOrderType捕捉失败");
            //    }
               
            //    if (mt.data.materialCode != mtrans.data.materialCode)
            //    {
            //        throw new Exception("托盘物料和提示物料不同");
            //    }
            //    if (mt.data.batchNo != mtrans.data.batchNo)
            //    {
            //        throw new Exception("托盘批次和提示批次不同");
            //    }
            //    if (mt.data.slId != mtrans.data.fromSlId)
            //    {
            //        throw new Exception("托盘批次和提示批次不同");
            //    }
            //    this.labtrayqty.Text = mt.data.quantity.ToString() + mtrans.data.commonUnitName + mt.data.minQuantity.ToString() + mtrans.data.minUnitName;
            //    this.cmbmaterialCondition.SelectedValue = mt.data.materialStatus;
               
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;

            //}
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn = @"orderItemId=" + mtrans.data.orderItemId.ToString() + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode;
                if (this.txttraycode.Text.Length < Comm.lcCode.Length || Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
                {
                    conn += @"&boxCode=" + this.txttraycode.Text.Trim();
                }
                else
                {
                    conn += @"&trayCode=" + this.txttraycode.Text.Trim();
                }
                string x = HttpHelper.HttpPost("judgeTrayTransfer", conn);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                _mt = (Model.Mtray)JsonConvert.DeserializeObject(x, typeof(Model.Mtray));
                if (_mt == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                this.txttraycode.Text = _mt.data.trayCode;
                int imax = _mt.data.quantity * _mt.data.spec + _mt.data.minQuantity;
                //if (maxminquantity < 0 || maxminquantity < 0)
                //{
                maxquantity = _mt.data.quantity;
                maxminquantity = _mt.data.minQuantity;
                if (maxquantity < 0 || maxminquantity < 0)
                {
                    maxquantity = imax / _mt.data.spec;
                    maxminquantity = imax % _mt.data.spec;
                }
               this.labtrayqty.Text = maxquantity + mtrans.data.commonUnitName + maxminquantity + mtrans.data.minUnitName;

               int immax = mtrans.data.quantity * _mt.data.spec + mtrans.data.minQuantity;
               mmaxquantity = mtrans.data.quantity;
               mmaxminquantity = mtrans.data.minQuantity;
               if (mmaxquantity < 0 || mmaxminquantity < 0)
               {
                   mmaxquantity = immax / mtrans.data.spec;
                   mmaxminquantity = immax % mtrans.data.spec;
               }
                //if (mtrans.data.quantity > _mt.data.quantity)
                if(immax>imax)
                {
                    this.txtcommonqty.Text = maxquantity.ToString();
                    this.txtminqty.Text = maxminquantity.ToString();
                }
                else
                {
                      this.txtcommonqty.Text = mmaxquantity.ToString();
                      this.txtminqty.Text = mmaxminquantity.ToString();
                }
                //else
                //{
                //    this.txtcommonqty.Text = mtrans.data.quantity.ToString();
                //}
                //if (mtrans.data.minQuantity > _mt.data.minQuantity)
                //{
                //    this.txtminqty.Text = _mt.data.minQuantity.ToString();
                //}
                //else
                //{
                //    this.txtminqty.Text = mtrans.data.minQuantity.ToString();
                //}
              
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            this.txttraycode.Enabled = false;
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
            //if (!isNew)
            //{
            if (commonqty > maxquantity)
            {
                MessageBox.Show("输入数量大于托盘数量");
                this.txtcommonqty.SelectAll();
                return;
            }

            //if (commonqty > mtrans.data.quantity)
            if (commonqty > mmaxquantity)
            {
                MessageBox.Show("输入数量大于单据数量");
                this.txtminqty.SelectAll();
                return;
            }
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
            if (minqty < 0)
            {
                MessageBox.Show("数量不能小于0");
                this.txtcommonqty.SelectAll();
                return;
            }

            //2017-11-16
            if (minqty + commonqty * _mt.data.spec > _mt.data.minQuantity + _mt.data.quantity * _mt.data.spec)
            {
                MessageBox.Show("输入数量大于托盘数量");
                this.txtminqty.SelectAll();
                return;
            }
            if (minqty + commonqty * _mt.data.spec > mtrans.data.minQuantity + mtrans.data.quantity * _mt.data.spec)
            {
                MessageBox.Show("输入数量大于单据数量");
                this.txtminqty.SelectAll();
                return;
            }
            //}
            this.txtminqty.Enabled = false;
            this.cmbmaterialSurface.Enabled = true;
            this.cmbmaterialSurface.Focus();
            
        }

        private void txttotraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtminqty.Enabled = true;
                this.txttotraycode.Enabled = false;
                this.txttotraycode.Text = "";
                this.txtminqty.Focus();
                this.txtminqty.SelectAll();
                return;
            }
            
            if (e.KeyChar != 13)
                return;
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    string x = HttpHelper.HttpPost("getTrayCode", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
            //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //    if (msg == null)
            //        throw new Exception("getTrayCode失败");
            //    if (!msg.success)
            //        throw new Exception(msg.msg);
            //    mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
            //    if (mm == null)
            //        throw new Exception("错误信息捕捉失败");
            //    if (string.IsNullOrEmpty(mm.data))
            //    {
            //        throw new Exception("没有找到对应托盘");
            //    }
            //    this.txttotraycode.Text = mm.data;
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor.Current = Cursors.Default;
            //    this.txttotraycode.SelectAll();
            //    MessageBox.Show(ex.Message);
            //    return;

            //}

            //this.txttotraycode.Text = this.txttotraycode.Text.ToUpper();
            Model.MTrayByBox mm = null;
            if (this.txttotraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描移入托盘");
                this.txttraycode.SelectAll();
                return;
            }
            if (this.txttotraycode.Text == this.txttraycode.Text)
            {
                if (_mt.data.quantity != commonqty || _mt.data.minQuantity != minqty)
                {
                    MessageBox.Show("部分转储不允许使用同一托盘");
                    this.txttotraycode.SelectAll();
                    return;
                }
            }
            else
            {
                if (Comm.lcCode != this.txttotraycode.Text.Substring(0, Comm.lcCode.Length))
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode);
                        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                        if (msg == null)
                            throw new Exception("错误信息捕捉失败");
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
                        this.txttraycode.SelectAll();
                        MessageBox.Show(ex.Message);
                        return;

                    }
                }
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
                //        MessageBox.Show(ex.Message);
                //        return;

                //    }
                //}
            }
            Model.MTrayStockByOrderType nmt = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("trayStock/verifyToTrayCodeNotZC", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttotraycode.Text + "&whCode=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("trayStock/verifyToTrayCodeNotZC错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                nmt = (Model.MTrayStockByOrderType)JsonConvert.DeserializeObject(x, typeof(Model.MTrayStockByOrderType));
                if (nmt == null)
                {
                    throw new Exception("findTrayStockByOrderType捕捉失败");
                }
                if (!string.IsNullOrEmpty(nmt.data.trayCode))
                {
                    if (nmt.data.trayCode != this.txttotraycode.Text)
                    {
                        this.txttotraycode.Text = nmt.data.trayCode;
                    }
                }
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
                if (this.txttotraycode.Text != this.txttraycode.Text)
                {
                    if (nmt.data.slId != mtrans.data.toSlId)
                    {
                        MessageBox.Show("该托盘不在目标库位上,请换一个托盘");
                        this.txttotraycode.SelectAll();
                        return;
                    }
                }
                if (mtrans.data.materialCode != nmt.data.materialCode)
                {
                    MessageBox.Show("新托盘上的物料是" + nmt.data.materialName + ",不能合托,请换托盘");
                    this.txttotraycode.SelectAll();
                    return;
                }
                if (mtrans.data.batchNo != nmt.data.batchNo || nmt.data.inDate != mtrans.data.inDate || mtrans.data.pdate != nmt.data.pdate || mtrans.data.materialStatusCode != nmt.data.materialStatus)
                {
                    DialogResult dr = MessageBox.Show("移入托盘的批次、生产日期、物料状态、入库日期存在与待转入物料不一致的情况，确认是否合托?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dr != DialogResult.Yes)
                    {
                        this.txttotraycode.SelectAll();
                        return;
                    }
                }
            }

            this.txttotraycode.Enabled = false;
            this.txttoslid.Enabled = true;
            this.txttoslid.Focus();
        }

        int slid = 0;
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
            if (this.txttoslid.Text == "")
                return;
            //this.txttoslid.Text = this.txttoslid.Text.ToUpper();
            //if (this.txttoslid.Text == this.txtSlId.Text)
            //{
            //    MessageBox.Show("入出库位相同");
            //    this.txttoslid.SelectAll();
            //    return;
            //}
            slid = mtrans.data.toSlId;
            if (this.txttoslid.Text != mtrans.data.toSlName.ToString())
            {
                MessageBox.Show("请移入指定库位["+mtrans.data.toSlName+"]");
                this.txttoslid.SelectAll();
                return;
                //DialogResult dr = MessageBox.Show("移入库位不是指定库位,是否继续?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                //if (dr != DialogResult.Yes)
                //{
                //    this.txttoslid.SelectAll();
                //    return;
                //}
                //try
                //{
                //    string x = HttpHelper.HttpPost("trayStock/findSlIdBySlName", @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&slName=" + this.txttoslid.Text);
                //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                //    if (msg == null)
                //        throw new Exception("findSlIdBySlName错误信息捕捉失败");
                //    if (!msg.success)
                //        throw new Exception(msg.msg);
                    
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    return;

                //}
                //slid = ms.data.slId;   
            }
            //if(this)
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetTrans(false);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            
        }

        private void cmbmaterialSurface_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtminqty.Enabled = true;
                this.cmbmaterialSurface.Enabled = false;
               
                this.txtminqty.Focus();
                this.txtminqty.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.cmbmaterialSurface.Enabled = false;
            this.txttotraycode.Enabled = true;
            this.txttotraycode.Focus();
        }

        private void frmTranMove_Load(object sender, EventArgs e)
        {
            this.cmbmaterialSurface.DataSource = Comm.basein.data.transferMaterialSurfaces;
            this.cmbmaterialSurface.ValueMember = "code";
            this.cmbmaterialSurface.DisplayMember = "description";
            Clear();
            this.txtorderid.Enabled = true;
            this.txtorderid.Focus();
        }

        //int ci = 0;
        //int mi = 0;
        void GetTrans(bool benter)
        {
            string con=@"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode;
            if (mtrans != null && mtrans.data!=null && !benter)
            {
                con += "&orderItemId=" + mtrans.data.orderItemId.ToString() + "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&fromTrayCode=" + this.txttraycode.Text + "&toTrayCode=" + this.txttotraycode.Text + "&materialStatus=" + this.cmbmaterialSurface.SelectedValue.ToString() + "&updater=" + Comm.usercode + "&qtStatus=" + _mt.data.qtStatus;
            }
            if (benter)
            {
                con += "&orderItemId=" + mtrans.data.orderItemId.ToString();
            }
            string x = HttpHelper.HttpPost("submitTransOperate", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            mtrans = (Model.MTranMove)JsonConvert.DeserializeObject(x, typeof(Model.MTranMove));
            if (mtrans == null)
            {
                throw new Exception("数据信息捕捉失败");
            }
            Clear();
            if (mtrans.data == null)
            {
                MessageBox.Show("该单据已经操作完成");
                this.txtorderid.Enabled = true;
                this.txtorderid.Text = "";
                this.txtorderid.Focus();
                return;
            }

            //this.btnAssistance.Text = mtrans.data.assistance;
            this.btnAssistance.Text = mtrans.data.assistanceName;
            this.labfromsIId.Text = mtrans.data.fromSlName.ToString();
            this.labtoslname.Text = mtrans.data.toSlName;
            this.labmaterialname.Text = mtrans.data.materialName;
            //ci = mtrans.data.quantity + (int)(((double)(mtrans.data.minQuantity) / mtrans.data.spec));
            //mi = (mtrans.data.quantity * mtrans.data.spec + mtrans.data.minQuantity) % mtrans.data.spec;
            //this.labneedqty.Text = ci + mtrans.data.commonUnitName + mi + mtrans.data.minUnitName + " " + mtrans.data.batchNo;
            int imax = mtrans.data.quantity * mtrans.data.spec + mtrans.data.minQuantity;
            int maxquantity = mtrans.data.quantity;
            int maxminquantity = mtrans.data.minQuantity;
            if (maxminquantity < 0 || maxquantity < 0)
            {
                maxquantity = imax / mtrans.data.spec;
                maxminquantity = imax % mtrans.data.spec;
            }
            this.labneedqty.Text = maxquantity + mtrans.data.commonUnitName +maxminquantity + mtrans.data.minUnitName + " " + mtrans.data.batchNo;
            this.labmaterialStatusStr.Text = mtrans.data.materialStatusName;
            this.cmbmaterialSurface.Text = mtrans.data.materialStatusName;
            this.labcommonUnit.Text = mtrans.data.commonUnitName;
            this.labminunit.Text = mtrans.data.minUnitName;
            //this.txtSlId.Enabled = true;
            //this.txtSlId.Focus();
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
            
           
           
           
        }

        void Clear()
        {
            this.txtcommonqty.Text = "";
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Text = "";
            this.txtminqty.Enabled = false;
            //this.txtorderid.Text = "";
            this.txtorderid.Enabled = false;
            this.txtSlId.Text = "";
            this.txtSlId.Enabled = false;
            this.txttoslid.Text = "";
            this.txttoslid.Enabled = false;
            this.txttotraycode.Text = "";
            this.txttotraycode.Enabled = false;
            this.txttraycode.Text = "";
            this.txttraycode.Enabled = false;
            this.cmbmaterialSurface.Enabled = false;
            this.labcommonUnit.Text = "";
            this.labfromsIId.Text = "";
            this.labmaterialname.Text = "";
            this.labminunit.Text = "";
            this.labneedqty.Text = "";
            this.labtrayqty.Text = "";
            this.labtoslname.Text = "";
            this.labmaterialStatusStr.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetTrans(true);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtorderid.SelectAll();
                return;

            }
        }

        private void btnAssistance_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
            {
                MessageBox.Show("请先扫描单据");
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                return;
            }
            Ot.frmUpdAssistance frm = new Rf_Wms.Ot.frmUpdAssistance();
            frm.orderid = this.txtorderid.Text;
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

        private void cmbmaterialSurface_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtorderid_GotFocus(object sender, EventArgs e)
        {
            txtorderid.SelectAll();
        }

        private void txtSlid_GotFocus(object sender, EventArgs e)
        {
            
        }

        private void txtSlId_GotFocus(object sender, EventArgs e)
        {
            txtSlId.SelectAll();
        }

        private void txttraycode_GotFocus(object sender, EventArgs e)
        {
            txttraycode.SelectAll();
        }

        private void txtcommonqty_GotFocus(object sender, EventArgs e)
        {
            txtcommonqty.SelectAll();
        }

        private void txtminqty_GotFocus(object sender, EventArgs e)
        {
            txtminqty.SelectAll();
        }

        private void txttotraycode_GotFocus(object sender, EventArgs e)
        {
            txttotraycode.SelectAll();
        }

        private void txttoslid_GotFocus(object sender, EventArgs e)
        {
            txttoslid.SelectAll();
        }

        
    }
}