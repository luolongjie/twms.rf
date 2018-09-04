using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
namespace Rf_Wms.Out
{
    public partial class frmMachiningOut : Form
    {
        public frmMachiningOut()
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
                string x = HttpHelper.HttpPost("/packOrder/findWaitMachinePackOrderList", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text);
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
            frm.txtname = "待加工列表";
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Model.Mmsg msg = null;
        Model.MTran mtrans = null;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txtorderid.Text == "")
                return;
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
            //this.labbatchNo.Text = mtrans.data.batchNo;
            this.txtorderid.Enabled = false;
            //this.txtSlId.Enabled = true;
            //this.txtSlId.Focus();
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();

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
            if (this.txtSlId.Text != mtrans.data.fromSlIdName.ToString())
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
                //this.txtSlId.Text = "";
                //this.txtSlId.Enabled = false;
                this.txtorderid.Enabled = true;
                this.txtorderid.Text = "";
                this.txtorderid.Focus();
                return;
                return;
            }
            if (e.KeyChar != 13)
                return;
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            if (this.txttraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描条码");
                this.txttraycode.SelectAll();
                return;
            }
            //if (Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
            //{
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string conn = @"orderItemId=" + mtrans.data.orderItemId.ToString() + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode;
                    if (Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
                    {
                        conn += @"&boxCode=" + this.txttraycode.Text;
                    }
                    else
                    {
                        conn += @"&trayCode=" + this.txttraycode.Text;
                    }
                    string x = HttpHelper.HttpPost("packOrder/judgeTrayForPackOrder", conn);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    _mt = (Model.Mtray)JsonConvert.DeserializeObject(x, typeof(Model.Mtray));
                    if (_mt == null)
                    {
                        throw new Exception("judgeTray数据信息捕捉失败");
                    }
                    this.txttraycode.Text = _mt.data.trayCode;
                    this.labtrayqty.Text = _mt.data.quantity.ToString() + mtrans.data.commonUnitName + _mt.data.minQuantity.ToString() + mtrans.data.minUnitName;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;

                }
            //}

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
            if (commonqty > _mt.data.quantity)
            {
                MessageBox.Show("输入数量不能大于托盘数量");
                this.txtcommonqty.SelectAll();
                return;
            }

            int r = (mtrans.data.quantity - commonqty)*mtrans.data.spec+mtrans.data.minQuantity ;

            if (r < 0)
            {
                MessageBox.Show("不能超量");
                this.txtminqty.SelectAll();
                return;
            }
            //if (_mt.data.quantity > mtrans.data.quantity)
            //{
            //    if (commonqty > mtrans.data.quantity)
            //    {
            //        MessageBox.Show("输入数量不能大于单据数量");
            //        this.txtcommonqty.SelectAll();
            //        return;
            //    }
            //}
            //else
            //{
                
            //}
            //if (commonqty > _mt.data.quantity)
            //{
            //    MessageBox.Show("输入数量大于托盘数量");
            //    this.txtcommonqty.SelectAll();
            //    return;
            //}
            //if (commonqty > mtrans.data.quantity)
            //{
            //    MessageBox.Show("输入数量大于单据数量");
            //    this.txtcommonqty.SelectAll();
            //    return;
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
                this.txtminqty.SelectAll();
                return;
            }
            if (minqty > mtrans.data.minQuantity)
            {
                MessageBox.Show("输入数量不能大于单据量");
                this.txtcommonqty.SelectAll();
                return;
            }
            int r = mtrans.data.quantity - commonqty;
            if (r > 0)
                r = 0;
            r = mtrans.data.minQuantity - minqty + r * mtrans.data.spec;
            if (r < 0)
            {
                MessageBox.Show("不能超单操作");
                this.txtminqty.SelectAll();
                return;
            }

            if (commonqty * mtrans.data.spec + minqty > _mt.data.quantity * mtrans.data.spec + _mt.data.minQuantity)
            {
                MessageBox.Show("输入数量大于托盘数量");
                this.txtminqty.SelectAll();
                return;
            }
            //if (_mt.data.minQuantity > mtrans.data.minQuantity)
            //{
            //    if (minqty > mtrans.data.minQuantity)
            //    {
            //        MessageBox.Show("输入数量不能大于单据数量");
            //        this.txtcommonqty.SelectAll();
            //        return;
            //    }
            //}
            //else
            //{
                
            //}
            this.txtminqty.Enabled = false;
            //this.cmbmaterialCondition.Enabled = true;
            //this.cmbmaterialCondition.Focus();
            this.txttotraycode.Enabled = true;
            this.txttotraycode.Focus();

        }

        Model.MTrayByBox mm = null;
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
            //this.txttotraycode.Text = this.txttotraycode.Text.ToUpper();
            if (this.txttotraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描移入托盘");
                this.txttraycode.SelectAll();
                return;
            }

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

            if (this.txttraycode.Text == this.txttotraycode.Text)
            {
                if (minqty != _mt.data.minQuantity || commonqty != _mt.data.quantity)
                {
                    MessageBox.Show("不是整托转移,入出托盘不能是同一个");
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
                else
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        string x = HttpHelper.HttpPost("verifyTrayCode", @"trayCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode);
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
            }
            //Model.MTrayStockByOrderType nmt = null;
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    string x = HttpHelper.HttpPost("trayStock/findTrayStockByOrderType", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttotraycode.Text + "&whCode=" + Comm.warehousecode);
            //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //    if (msg == null)
            //        throw new Exception("trayStock/findTrayStockByOrderType错误信息捕捉失败");
            //    if (!msg.success)
            //        throw new Exception(msg.msg);
            //    nmt = (Model.MTrayStockByOrderType)JsonConvert.DeserializeObject(x, typeof(Model.MTrayStockByOrderType));
            //    if (nmt == null)
            //    {
            //        throw new Exception("findTrayStockByOrderType捕捉失败");
            //    }

            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor.Current = Cursors.Default;
            //    MessageBox.Show(ex.Message);
            //    return;

            //}
          
            //else if (!string.IsNullOrEmpty(nmt.data.materialCode))//不是空托盘
            //{
            //    if (mtrans.data.toSlId != nmt.data.slId)
            //    {
            //        MessageBox.Show("该托盘不在目标库位上,请换一个托盘");
            //        this.txttotraycode.SelectAll();
            //        return;
            //    }
            //    if (mtrans.data.materialCode != nmt.data.materialCode)
            //    {
            //        MessageBox.Show("新托盘上的物料是" + nmt.data.materialName + ",不能合托,请换托盘");
            //        this.txttotraycode.SelectAll();
            //        return;
            //    }
            //    if (mtrans.data.batchNo != nmt.data.batchNo  || mtrans.data.pdate != nmt.data.pdate )
            //    {
            //        DialogResult dr = MessageBox.Show("批次 生产日期 状态 入库日期有和原来的不同的属性，是否合托?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //        if (dr != DialogResult.Yes)
            //        {
            //            this.txttotraycode.SelectAll();
            //            return;
            //        }
            //    }
            //}
            this.txttotraycode.Enabled = false;
            this.txttoslid.Enabled = true;
            this.txttoslid.Focus();
        }

        int toslid = 0;
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
            //this.txttoslid.Text = this.txttoslid.Text.ToUpper();
            if (this.txttoslid.Text != this.labtoslidname.Text)
            {
                MessageBox.Show("移入库位有问题");
                this.txttoslid.SelectAll();
                return;
            }
            //if (this.txttoslid.Text == this.txtSlId.Text)
            //{
            //    MessageBox.Show("入出库位不能同一个");
            //    this.txttoslid.SelectAll();
            //    return;
            //}
            //if (this.txttoslid.Text != mtrans.data.toSlIdName.ToString())
            //{
            //    DialogResult dr = MessageBox.Show("移入库位不是指定库位,是否继续?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //    if (dr != DialogResult.Yes)
            //    {
            //        this.txttoslid.SelectAll();
            //        return;
            //    }
            //}
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

        private void cmbmaterialCondition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtminqty.Enabled = true;
                this.cmbmaterialCondition.Enabled = false;

                this.txtminqty.Focus();
                this.txtminqty.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.cmbmaterialCondition.Enabled = false;
            this.txttotraycode.Enabled = true;
            this.txttotraycode.Focus();
        }

        private void frmTranMove_Load(object sender, EventArgs e)
        {
            this.cmbmaterialCondition.DataSource = Comm.basein.data.materialConditions;
            this.cmbmaterialCondition.ValueMember = "code";
            this.cmbmaterialCondition.DisplayMember = "description";
            Clear();
            this.txtorderid.Enabled = true;
            this.txtorderid.Focus();
        }

        void GetTrans(bool benter)
        {
            string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode;
             if (mtrans != null && mtrans.data!=null && !benter)
            {
                con += "&orderItemId=" + mtrans.data.orderItemId.ToString() + "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&fromTrayCode=" + this.txttraycode.Text + "&toTrayCode=" + this.txttotraycode.Text + "&updater=" + Comm.usercode + "&fromSlId=" + this.mtrans.data.fromSlId + "&materialCode="+mtrans.data.materialCode; 
            }
             if (benter)
             {
                 con += "&orderItemId=" + mtrans.data.orderItemId.ToString();
             }
            string x = HttpHelper.HttpPost("packOrder/processorSourceOperate", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            mtrans = (Model.MTran)JsonConvert.DeserializeObject(x, typeof(Model.MTran));
            if (mtrans == null)
            {
                throw new Exception("数据信息捕捉失败");
            }
            Clear();
            if (mtrans==null || mtrans.data == null)
            {
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                throw new Exception("该单已经操作完成");
                
            }
            else
            {
                this.btnAssistance.Text = mtrans.data.assistanceName;
                this.labfromsIId.Text = mtrans.data.fromSlIdName.ToString();
                this.labmaterialname.Text = mtrans.data.materialName;
                this.labneedqty.Text = mtrans.data.quantity.ToString() + mtrans.data.commonUnitName + mtrans.data.minQuantity.ToString() + mtrans.data.minUnitName + " " + mtrans.data.batchNo;
                this.labcommonUnit.Text = mtrans.data.commonUnitName;
                this.labminunit.Text = mtrans.data.minUnitName;
                this.labtoslidname.Text = mtrans.data.toSlIdName;
                //this.txtSlId.Enabled = true;
                //this.txtSlId.Focus();
                this.txttraycode.Enabled = true;
                this.txttraycode.Focus();
            }

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
            this.cmbmaterialCondition.Enabled = false;
            this.labcommonUnit.Text = "";
            this.labfromsIId.Text = "";
            this.labmaterialname.Text = "";
            this.labminunit.Text = "";
            this.labneedqty.Text = "";
            this.labtrayqty.Text = "";
        }

        private void frmMachiningOut_Load(object sender, EventArgs e)
        {
            this.cmbmaterialCondition.DataSource = Comm.basein.data.materialConditions;
            this.cmbmaterialCondition.ValueMember = "code";
            this.cmbmaterialCondition.DisplayMember = "description";
            Clear();
            this.txtorderid.Enabled = true;
            this.txtorderid.Focus();
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
            frm.fun = "packOrder/updateAssistance";
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

        private void txtorderid_GotFocus(object sender, EventArgs e)
        {
            txtorderid.SelectAll();
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
            this.txttoslid.Text = this.labtoslidname.Text;
            txttoslid.SelectAll();
        }
    }
}