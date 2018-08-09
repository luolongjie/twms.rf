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
    public partial class frmCheckVoByOrder : Form
    {
        public frmCheckVoByOrder()
        {
            InitializeComponent();
        }

        Model.Mmsg msg = null;
        private void frmCheckVoByOrder_Load(object sender, EventArgs e)
        {
            try
            {
                //http://10.115.2.216:7083/twms-hand/api/repeatReason
                //string x = HttpHelper.HttpPost("repeatReason", @"");
                //List<Model.MCVreason> mv = (List<Model.MCVreason>)JsonConvert.DeserializeObject(x, typeof(List<Model.MCVreason>));
                //if (msg == null)
                //    throw new Exception("错误信息捕捉失败");
                //if (!msg.success)
                //    throw new Exception(msg.msg);
                //mt = (Model.MTrayStockByOrderType)JsonConvert.DeserializeObject(x, typeof(Model.MTrayStockByOrderType));
                //if (mt == null)
                //{
                //    throw new Exception("findTrayStockByOrderType捕捉失败");
                //}
                //this.cmbreason.DataSource = mv;
                //this.cmbreason.ValueMember = "code";
                //this.cmbreason.DisplayMember = "des";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
            Clear();
            this.txtorderid.Enabled = true;
            this.txtorderid.Focus();
        }


        Model.McheckResult mc = null;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (txtorderid.Text == "")
                return;
            //try
            //{
            //    string x = HttpHelper.HttpPost("checkResult", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text+"&whCode="+Comm.warehousecode);
            //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //    if (msg == null)
            //        throw new Exception("错误信息捕捉失败");
            //    if (!msg.success)
            //        throw new Exception(msg.msg);
            //    mc = (Model.McheckResult)JsonConvert.DeserializeObject(x, typeof(Model.McheckResult));
            //    if (mc == null  )
            //    {
            //        throw new Exception("checkResult捕捉失败");
            //    }
            //    if(mc.data==null)
            //        throw new Exception("该单盘点完成");


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;

            //}
            //this.labsIname.Text = mc.data.slName;
            //this.labmaterialname.Text = mc.data.materialName;
            //this.labcommonUnit.Text = mc.data.commonUnitName;
            //this.labminunit.Text = mc.data.minUnitName;
            //this.labinfo.Text = mc.data.pdate;
            //if (!mc.data.blind)
            //{
            //    this.labinfo.Text += " " + mc.data.quantity.ToString() + mc.data.commonUnitName + mc.data.minQuantity.ToString() + mc.data.minUnitName;
            //}
            //this.txtorderid.Enabled = false;
             Model.getRegionList rr=null;
            try
            {
                string x = HttpHelper.HttpPost("getRegionList", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whCode=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                rr = (Model.getRegionList)JsonConvert.DeserializeObject(x, typeof(Model.getRegionList));
                if (rr == null)
                {
                    throw new Exception("getRegionList捕捉失败");
                }
                if (rr.data == null)
                    throw new Exception("库区没有数据");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
            this.txtorderid.Enabled = false;
            this.cbxrr.DataSource = null;
            this.cbxrr.DataSource = rr.data;
            this.cbxrr.ValueMember = "id";
            this.cbxrr.DisplayMember = "name";
            this.cbxrr.SelectedItem = 1;
            this.cbxrr.Enabled = true;
            this.cbxrr.Focus();
            //this.txtSlId.Enabled = true;
            //this.txtSlId.Focuslab
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSlId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                mc = null;
                this.labmaterialcode.Text = "";
                //this.labmaterialname.Text = "";
                this.labinfo.Text = "";
                this.labsIname.Text = "";
                this.txtSlId.Text = "";
                this.txtSlId.Enabled = false;
                this.cbxrr.Enabled = true;
                this.cbxrr.Focus();
                //this.txtorderid.Enabled = true;
                //this.txtorderid.Text = "";
                //this.txtorderid.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            //this.txtSlId.Text = this.txtSlId.Text.ToUpper();
            if (this.txtSlId.Text != mc.data.slName)
            {
                MessageBox.Show("盘点库位不正确");
                this.txtSlId.SelectAll();
                return;
            }
            this.txtSlId.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }

        Model.Mmaterialcodebody materialbody = null;
        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtbarcode.Text = "";
                this.txtbarcode.Enabled = false;
                this.txtSlId.Enabled = true;
                this.txtSlId.Text = "";
                this.txtSlId.Focus();
            }
            Model.Mmaterialcode m = null;
            if (e.KeyChar != 13)
                return;
            try
            {
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
                    throw new Exception("没有该条码对应的数据");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtbarcode.SelectAll();
                return;

            }
            for (int i = m.data.Count - 1; i >= 0; i--)
            {
                if (m.data[i].code != mc.data.materialCode)
                    m.data.RemoveAt(i);

            }
           
            if (m.data.Count == 0)
            {
                MessageBox.Show("该库位没有该条码物料");
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
            this.txtbarcode.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                //this.labtrayqty.Text = "";
                this.txtcommonqty.Enabled = false;
                this.txtSlId.Enabled = true;
                this.txtSlId.SelectAll();
                this.txtcommonqty.Text = "";
                this.txtSlId.Text = "";

                //this.labcommonUnit.Text = "";
                //this.labcount.Text = "";
                //this.labmaterialname.Text = "";
                //this.labminunit.Text = "";
                //this.labpdata.Text = "";
                //this.labqty.Text = "";
                //this.labstockOutNo.Text = "";
                this.txtSlId.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            //if (txtcommonqty.Text == "")
            //{
            //    this.txtcommonqty.Enabled = false;
            //    this.cmbreason.Enabled = true;
            //    this.cmbreason.Focus();
            //    return;
            //}
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
                MessageBox.Show("数量异常");
                this.txtcommonqty.SelectAll();
                return;
            }
           
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Focus();
        }


        void Save(bool isexception)
        {
            //string addcon = "";
            //if (commonqty != 0)
            //{
            //    if (commonqty > mc.data.quantity || (commonqty == mc.data.quantity && minqty > mc.data.minQuantity))
            //    {
            //        addcon = "&quantity=" + commonqty + "&minQuantity=" + minqty + "&repeatReason=5";
            //    }
            //    if (commonqty < mc.data.quantity || (commonqty == mc.data.quantity && minqty < mc.data.minQuantity))
            //    {
            //        addcon = "&quantity=" + commonqty + "&minQuantity=" + minqty + "&repeatReason=4";
            //    }
            //}

            string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&orderItemId=" + mc.data.orderItemId  + "&updater=" + Comm.usercode ;
            if (commonqty != mc.data.quantity || minqty != mc.data.minQuantity || isexception)
            {
                con += "&exception=1";
            }
            else
            {
                con += "&exception=0";
            }
            if (isexception)
            {
                con += "&quantity=0&minQuantity=0";
            }
            else if (commonqty != -1 || minqty != -1)
            {
                con += "&quantity=" + commonqty + "&minQuantity=" + minqty;
            }
            con+="&rrId="+this.cbxrr.SelectedValue.ToString();
            //if (k.Count != 0)
            //{
            //    con += "&repeatReason=[";
            //    foreach (Model.MCVreason y in k)
            //    {
            //        con += "{\"trayCode\":\""+y.code+"\",";
            //        con += "\"repeatReason\":" + y.des+"}," ;
            //    }
            //    con = con.Substring(0, con.Length - 1) + "]";
            //}
            string x = HttpHelper.HttpPost("checkResult", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);

            mc = (Model.McheckResult)JsonConvert.DeserializeObject(x, typeof(Model.McheckResult));
            if (mc == null)
            {
                throw new Exception("checkResult捕捉失败");
            }
           
            Clear();
            if (mc.data == null)
            {
                //this.txtorderid.Text = "";
                this.txtorderid.SelectAll();
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                throw new Exception("该库区盘点完成");
            }
            //k.Clear();
            this.labsIname.Text = mc.data.slName;
            this.labmaterialcode.Text = "物料信息 " + mc.data.materialCode + " " + mc.data.materialName;
            //this.labmaterialname.Text = mc.data.materialName;
            this.labcommonUnit.Text = mc.data.commonUnitName;
            this.labminunit.Text = mc.data.minUnitName;
            this.labinfo.Text = mc.data.pdate + " " + mc.data.batchNo;
            if (!mc.data.blind)
            {
                this.labinfo.Text += " " + mc.data.quantity.ToString() + mc.data.commonUnitName + mc.data.minQuantity.ToString() + mc.data.minUnitName;
                this.txtcommonqty.Text = mc.data.quantity.ToString();
                this.txtminqty.Text = mc.data.minQuantity.ToString();
            }
            this.txtorderid.Enabled = false;
            this.txtSlId.Enabled = true;
            this.txtSlId.Focus();
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
                MessageBox.Show("数量异常");
                this.txtminqty.SelectAll();
                return;
            }
            //this.cmbreason.Enabled = true;
            this.txtminqty.Enabled = false;
            //this.cmbreason.Focus();

            if (!mc.data.blind && (commonqty != mc.data.quantity || minqty != mc.data.minQuantity) || this.laberr.Text!="")
            {
                DialogResult dr=DialogResult.Yes;
                if (this.laberr.Text == "")
                {
                    dr = MessageBox.Show("盘点数量不正确,是否直接进入复盘?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                }
                this.laberr.Text = "";
                if (dr == DialogResult.Yes)
                {
                    
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        checkAgain();
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    return;
                }
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Save(false);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            
            
            //try
            //{
            //    Save();


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    this.txtminqty.SelectAll();
            //    return;

            //}
        }

        private void cmbreason_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 27)
            //{
            //    try
            //    {
            //        Save();


            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
                   
            //        return;

            //    }
            //    this.txtSlId.Enabled = true;
            //    this.txtSlId.Focus();
            //}
            if (e.KeyChar != 13)
                return;
            //this.txttraycode.Enabled = true;
            //this.txttraycode.Focus();
            //this.cmbreason.Enabled = false;
        }

        List<Model.MCVreason> k = new List<Model.MCVreason>();
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 27)
            //{
            //    //this.txttraycode.Text = "";
            //    //this.txttraycode.Enabled = false;
            //    this.cmbreason.Enabled = true;
            //    //this.txtorderid.Text = "";
            //    this.cmbreason.Focus();
            //    return;
            //}
            //if (e.KeyChar != 13)
            //    return;

            //Model.MTrayByBox mm = null;
            //if (this.txttraycode.Text.Length < Comm.lcCode.Length)
            //{
            //    MessageBox.Show("请扫描条码");
            //    this.txttraycode.SelectAll();
            //    return;
            //}
            //if ( Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
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
            //        MessageBox.Show(ex.Message);
            //        return;

            //    }
            //}
            //Model.MCVreason o = new Rf_Wms.Model.MCVreason();
            //o.code = this.txttraycode.Text;
            //o.des = cmbreason.SelectedValue.ToString();
            //k.Add(o);
            //this.txttraycode.Enabled = false;
            //this.txttraycode.Text = "";
            //this.cmbreason.Enabled = true;
            //this.cmbreason.Focus();
            //Save(true);
        }

        void Clear()
        {
            this.labsIname.Text = "";
            this.labmaterialcode.Text = "";
            //this.labmaterialname.Text = "";
            this.labcommonUnit.Text = "";
            this.labminunit.Text = "";
            this.labinfo.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            //this.txttraycode.Enabled = false;
            //this.cmbreason.Enabled = false;
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = false;
            this.txtbarcode.Enabled = false;
            this.txtbarcode.Text = "";
            //txttraycode.Text = "";
            this.txtSlId.Text = "";
            this.txtSlId.Enabled = false;
            this.cbxrr.Enabled = false;
            commonqty = -1;
            minqty = -1;
           
        }

        private void btnCheckAgain_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
            DialogResult dr = MessageBox.Show("是否直接进入复盘?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr != DialogResult.Yes)
            {
                this.laberr.Text = "本次操作后直接进入复盘";
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                checkAgain();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            //try
            //{
            //    string x = HttpHelper.HttpPost("checkResult", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text);
            //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //    if (msg == null)
            //        throw new Exception("错误信息捕捉失败");
            //    if (!msg.success)
            //        throw new Exception(msg.msg);
            //    mc = (Model.McheckResult)JsonConvert.DeserializeObject(x, typeof(Model.McheckResult));
            //    if (mc == null)
            //    {
            //        throw new Exception("checkResult捕捉失败");
            //    }
            //    if (mc.data == null)
            //        throw new Exception("该单盘点完成");


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;

            //}
        }

        Model.MrepeatInfos m;
        void checkAgain()
        {
            string con = @"orderId=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&orderItemId=" + mc.data.orderItemId + "&updater=" + Comm.usercode;

            con += "&exception=1";
            try
            {
                if (string.IsNullOrEmpty(this.txtcommonqty.Text))
                {
                    commonqty = -1;
                }
                else
                {
                    commonqty = Convert.ToInt32(this.txtcommonqty.Text);
                }
                if (string.IsNullOrEmpty(this.txtminqty.Text))
                {
                    minqty = -1;
                }
                else
                {
                    minqty = Convert.ToInt32(this.txtminqty.Text);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (commonqty != -1 || minqty != -1)
            {
                con += "&quantity=" + commonqty + "&minQuantity=" + minqty;
            }
            con += "&rrId=" + this.cbxrr.SelectedValue.ToString();
            //if (k.Count != 0)
            //{
            //    con += "&repeatReason=[";
            //    foreach (Model.MCVreason y in k)
            //    {
            //        con += "{\"trayCode\":\"" + y.code + "\",";
            //        con += "\"repeatReason\":" + y.des + "},";
            //    }
            //    con = con.Substring(0, con.Length - 1) + "]";
            //}
            string x = HttpHelper.HttpPost("checkRepeats", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);

            m = (Model.MrepeatInfos)JsonConvert.DeserializeObject(x, typeof(Model.MrepeatInfos));
            if (m == null)
            {
                throw new Exception("Mcheckrepeats捕捉失败");
            }
            Cursor.Current = Cursors.Default;
            frmCheckVoSecond frm = new frmCheckVoSecond();
            frm.m = m;
            frm.orderid = this.txtorderid.Text;
            frm.ShowDialog();

            x = HttpHelper.HttpPost("checkResult", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text + "&whCode=" + Comm.warehousecode + "&rrId=" + this.cbxrr.SelectedValue.ToString());
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            mc = (Model.McheckResult)JsonConvert.DeserializeObject(x, typeof(Model.McheckResult));
            if (mc == null)
            {
                throw new Exception("checkResult捕捉失败");
            }
            Clear();
            //k.Clear();

            if (mc.data == null)
            {
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                throw new Exception("该库区盘点完成");
            }
            this.labsIname.Text = mc.data.slName;
            this.labmaterialcode.Text = "物料信息 " + mc.data.materialCode + " " + mc.data.materialName;
            //this.labmaterialname.Text = mc.data.materialName;
            this.labcommonUnit.Text = mc.data.commonUnitName;
            this.labminunit.Text = mc.data.minUnitName;
            this.labinfo.Text = mc.data.pdate +" "+mc.data.batchNo;
            if (!mc.data.blind)
            {
                this.labinfo.Text += " " + mc.data.quantity.ToString() + mc.data.commonUnitName + mc.data.minQuantity.ToString() + mc.data.minUnitName;
                this.btnCheckAgain.Visible = true;
            }
            else
            {
                this.btnCheckAgain.Visible = false;
            }
            this.txtorderid.Enabled = false;
            this.txtSlId.Enabled = true;
            this.txtSlId.Focus();
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
             DialogResult dr = MessageBox.Show("确定找不到物料?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
             if (dr != DialogResult.Yes)
             {
                 return;
             }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Save(true);
                Cursor.Current = Cursors.Default;


            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
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

        private void txtcommonqty_GotFocus(object sender, EventArgs e)
        {
            txtcommonqty.SelectAll();
        }

        private void txtminqty_GotFocus(object sender, EventArgs e)
        {
            txtminqty.SelectAll();
        }

        private void txtbarcode_GotFocus(object sender, EventArgs e)
        {
            txtbarcode.SelectAll();
        }

        private void cbxrr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.cbxrr.Enabled = false;
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            try
            {
                string x = HttpHelper.HttpPost("checkResult", @"lcCode=" + Comm.lcCode + "&orderId=" + this.txtorderid.Text+"&whCode="+Comm.warehousecode+"&rrId="+this.cbxrr.SelectedValue.ToString());
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mc = (Model.McheckResult)JsonConvert.DeserializeObject(x, typeof(Model.McheckResult));
                if (mc == null  )
                {
                    throw new Exception("checkResult捕捉失败");
                }
                if(mc.data==null)
                    throw new Exception("该库区盘点完成");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
            this.labsIname.Text = mc.data.slName;
            this.labmaterialcode.Text = "物料信息 "+mc.data.materialCode+" "+mc.data.materialName;
            //this.labmaterialname.Text = mc.data.materialName;
            this.labcommonUnit.Text = mc.data.commonUnitName;
            this.labminunit.Text = mc.data.minUnitName;
            this.labinfo.Text = mc.data.pdate + " " + mc.data.batchNo;
            if (!mc.data.blind)
            {
                this.labinfo.Text += " " + mc.data.quantity.ToString() + mc.data.commonUnitName + mc.data.minQuantity.ToString() + mc.data.minUnitName;
                this.txtcommonqty.Text = mc.data.quantity.ToString();
                this.txtminqty.Text = mc.data.minQuantity.ToString();
            }
            //commonqty = mc.data.quantity;
            //minqty = mc.data.minQuantity;
            this.cbxrr.Enabled = false;
            this.txtSlId.Enabled = true;
            this.txtSlId.Focus();
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
        
    }
}