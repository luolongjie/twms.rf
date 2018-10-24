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
    public partial class frmreplenish : Form
    {
        public frmreplenish()
        {
            InitializeComponent();
        }

        Model.MShowList ms = null;
        private void btnData_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
            {
                //MessageBox.Show("请先扫描单据");
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("replenishOrder/findWaitMachineList", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text);
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
            frm.txtname = "待补货列表";
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Model.Mmsg msg = null;
        Model.Mreplenish mtrans = null;
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
            }
            if (e.KeyChar != 13)
                return;
            if (this.txttraycode.Text == "")
                return;
            ////this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn = @"orderItemId=" + mtrans.data.orderItemId.ToString() + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&recommendId=" + mtrans.data.recommendId;
                if (this.txttraycode.Text.Length < Comm.lcCode.Length)
                {
                    MessageBox.Show("请扫描条码");
                    this.txttraycode.SelectAll();
                    return;
                }
                if ( Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
                {
                    conn += @"&boxCode=" + this.txttraycode.Text;
                }
                else
                {
                    conn += @"&trayCode=" + this.txttraycode.Text;
                }
                string x = HttpHelper.HttpPost("replenishOrder/judgeTrayForReplenishOrder", conn);
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
                //this.labtrayqty.Text = _mt.data.quantity.ToString() + mtrans.data.commonUnitName + _mt.data.minQuantity.ToString() + mtrans.data.minUnitName;
                this.labtrayqty.Text = _mt.data.quantity.ToString() + mtrans.data.commonUnitName;
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
            if (commonqty <= 0)
            {
                MessageBox.Show("输入的数量必须大于0");
                this.txtcommonqty.Text = "";
                return;
            }
            if (commonqty > _mt.data.quantity)
            {
                MessageBox.Show("输入数量大于托盘数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (commonqty > mtrans.data.quantity)
            {
                MessageBox.Show("输入数量大于单据数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            //replenishOrder lockReplenishRecommend 方法 
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn = @"lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&recommendId=" + mtrans.data.recommendId;
              
                string x = HttpHelper.HttpPost("replenishOrder/lockReplenishRecommend", conn);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                //if (!msg.success)
                //    throw new Exception(msg.msg);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            if (!msg.success)
            {
                DialogResult drs = MessageBox.Show(msg.msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (drs == DialogResult.No)
                    return;
                //throw new Exception(msg.msg);
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string conn = @"lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&recommendId=" + mtrans.data.recommendId+"&updater=" + Comm.usercode;

                    string x = HttpHelper.HttpPost("replenishOrder/replenishRecommendAgain", conn);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("replenishRecommendAgain错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    Model.MreplenishRecommendAgain mmr = (Model.MreplenishRecommendAgain)JsonConvert.DeserializeObject(x, typeof(Model.MreplenishRecommendAgain));
                    if (mmr == null)
                    {
                        throw new Exception("数据信息捕捉失败");
                    }
                    mtrans.data.fromSlId = mmr.data.fromSlId;
                    mtrans.data.fromSlIdName = mmr.data.fromSlIdName;
                    mtrans.data.quantity = mmr.data.quantity;
                    mtrans.data.minQuantity = mmr.data.minQuantity;
                    mtrans.data.pdate = mmr.data.pdate;
                    mtrans.data.recommendId = mmr.data.recommendId;
                    this.labfromsIId.Text = mtrans.data.fromSlIdName.ToString();
                    this.labneedqty.Text = "应补数量 " + mtrans.data.quantity.ToString() + mtrans.data.commonUnitName + " " + mtrans.data.pdate;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;

                }
                this.txtcommonqty.Enabled = false;
                this.txttraycode.Enabled = true;
                this.txttraycode.SelectAll();
                this.txtcommonqty.Text = "";
                this.txttraycode.Focus();
                return;
            }
            this.txtcommonqty.Enabled = false;
            //this.txtminqty.Enabled = true;
            //this.txtminqty.Focus();
            //this.cmbmaterialCondition.Enabled = true;
            //this.cmbmaterialCondition.Focus();
            this.txttotraycode.Enabled = true;
            this.txttotraycode.Focus();
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
            if (minqty > _mt.data.minQuantity)
            {
                MessageBox.Show("输入数量大于托盘数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (minqty > mtrans.data.minQuantity)
            {
                MessageBox.Show("输入数量大于单据数量");
                this.txtcommonqty.SelectAll();
                return;
            }
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

                
                this.txttotraycode.Enabled = false;
                this.txttotraycode.Text = "";
                if (txtminqty.Visible == true)
                {
                    this.txtminqty.Enabled = true;
                    this.txtminqty.Focus();
                    this.txtminqty.SelectAll();
                }
                else
                {
                    this.txtcommonqty.Enabled = true;
                    this.txtcommonqty.Focus();
                    this.txtcommonqty.SelectAll();
                }
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txttotraycode.Text.Length == 0)
                return;
            if (this.txttotraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描条码");
                this.txttotraycode.SelectAll();
                return;
            }
            //this.txttotraycode.Text = this.txttotraycode.Text.ToUpper();
            if ( Comm.lcCode != this.txttotraycode.Text.Substring(0, Comm.lcCode.Length))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
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

            if (this.txttraycode.Text == this.txttotraycode.Text)
            {
                if (_mt.data.quantity != commonqty || _mt.data.minQuantity != minqty)
                {
                    MessageBox.Show("数量不同，不能整托补货");
                    this.txttotraycode.SelectAll();
                    return;
                }
            }
            else
            {

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string conn = @"orderItemId=" + mtrans.data.orderItemId.ToString() + "&lcCode=" + Comm.lcCode;


                    conn += @"&trayCode=" + this.txttotraycode.Text+"&recommendId=" + mtrans.data.recommendId;;

                    string x = HttpHelper.HttpPost("replenishOrder/judgeSourceTrayCode", conn);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("replenishOrder/judgeSourceTrayCode错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    this.txttotraycode.SelectAll();
                    return;

                }
            }
            
            //if (this.txttraycode.Text == this.txttotraycode.Text)
            //{
            //    this.txttraycode.SelectAll();
            //    MessageBox.Show("出入");
            //    return;
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
            //if (this.txttoslid.Text != this.labtoslidname.Text)
            //{
            //    MessageBox.Show("目的库位有问题");
            //    this.txttoslid.SelectAll();
            //    return;
            //}
            //if (this.txttoslid.Text == this.txtSlId.Text)
            //{
            //    MessageBox.Show("入出库位不能同一个");
            //    this.txttoslid.SelectAll();
            //    return;
            //}
            if (this.txttoslid.Text != mtrans.data.toSlIdName.ToString())
            {
                MessageBox.Show("移入库位不是指定库位");
                this.txttoslid.SelectAll();
                return;
            }
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

                //this.txtminqty.Enabled = true;
                this.cmbmaterialCondition.Enabled = false;

                //this.txtminqty.Focus();
                //this.txtminqty.SelectAll();
                this.txtcommonqty.Enabled = true;
                this.txtcommonqty.Focus();
                this.txtcommonqty.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            this.cmbmaterialCondition.Enabled = false;
            this.txttotraycode.Enabled = true;
            this.txttotraycode.Focus();
        }

        private void frmreplenish_Load(object sender, EventArgs e)
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
            //releaseQuantityLockStock();//test
            string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode;
            if (mtrans != null && mtrans.data!=null && !benter)
            {
                con += "&orderItemId=" + mtrans.data.orderItemId.ToString() + "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&fromTrayCode=" + this.txttraycode.Text + "&toTrayCode=" + this.txttotraycode.Text + "&updater=" + Comm.usercode + "&fromSlId=" + this.mtrans.data.fromSlId + "&materialCode=" + mtrans.data.materialCode + "&recommendId="+mtrans.data.recommendId;
            }
            if (benter)
            {
                con += "&orderItemId=" + mtrans.data.orderItemId.ToString() + "&recommendId=" + mtrans.data.recommendId;
            }
            string x = HttpHelper.HttpPost("replenishOrder/processorSourceOperate", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            mtrans = (Model.Mreplenish)JsonConvert.DeserializeObject(x, typeof(Model.Mreplenish));
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

            }
            else
            {
                this.btnAssistance.Text = mtrans.data.assistanceName;
                this.labfromsIId.Text = mtrans.data.fromSlIdName.ToString();
                this.labmaterialname.Text ="物料描述  " +mtrans.data.materialName;
                //this.labneedqty.Text = mtrans.data.quantity.ToString() + mtrans.data.commonUnitName + mtrans.data.minQuantity.ToString() + mtrans.data.minUnitName + " " + mtrans.data.batchNo;
                this.labneedqty.Text ="应补数量 " +mtrans.data.quantity.ToString() + mtrans.data.commonUnitName + " " +mtrans.data.pdate;
                this.labcommonUnit.Text = mtrans.data.commonUnitName;
                //this.labminunit.Text = mtrans.data.minUnitName;
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
            frm.fun = "replenishOrder/updateAssistance";
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

        void releaseQuantityLockStock()
        {
            if (this.txtcommonqty.Text == "")
                return;
            //string conn = @"quantity=" + commonqty + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&recommendId=" + mtrans.data.recommendId;
            string conn = "lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&recommendId=" + mtrans.data.recommendId;
            //string x = HttpHelper.HttpPost("replenishOrder/releaseQuantityLockStock", conn);
            string x = HttpHelper.HttpPost("replenishOrder/releaseLockStock", conn);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("replenishOrder/releaseLockStock错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
           
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                releaseQuantityLockStock();
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
            txttoslid.SelectAll();
        }
       
    }
}