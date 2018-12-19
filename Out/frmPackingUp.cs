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
    public partial class frmPackingUp : Form
    {
        public frmPackingUp()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         Model.Mmsg msg = null;
         //int fromtrayno = 20;
         Model.Mtray _mt;
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txttraycode.Text = "";
                this.txttraycode.Enabled = false;
                //this.txtslid.Enabled = true;
                //this.txtslid.Text = "";
                //this.txtslid.Focus();
                //this.labmaterialname.Text = "物料描述";
                //this.labneedqty.Text = "";
                //this.labSlname.Text = "";
                this.txtAssister.Text = "";
                this.txtAssister.Enabled = true;
                this.txtAssister.Focus();
                //this.cbxrr.Enabled = true;
                //this.cbxrr.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            if (this.txttraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描托盘条码");
                this.txttraycode.SelectAll();
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn = @"orderItemId=" + ms.data[c].recommendSlId.ToString() + "&lcCode=" + Comm.lcCode + "&whId="+Comm.warehousecode;
                if (this.txttraycode.Text.Length < Comm.lcCode.Length || Comm.lcCode != this.txttraycode.Text.Substring(0, Comm.lcCode.Length))
                {
                    conn += @"&boxCode=" + this.txttraycode.Text;
                }
                else
                {
                    conn += @"&trayCode=" + this.txttraycode.Text;
                }
                string x = HttpHelper.HttpPost("judgeTray", conn);
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
                this.labtrayqty.Text = _mt.data.quantity.ToString() + ms.data[c].commonUnitName + _mt.data.minQuantity.ToString() + ms.data[c].minUnitName;
                if (ms.data[c].quantity > _mt.data.quantity)
                {
                    this.txtcommonqty.Text = _mt.data.quantity.ToString();
                    commonqty = _mt.data.quantity;
                    if (ms.data[c].minQuantity > _mt.data.minQuantity)
                    {
                        this.txtminqty.Text = _mt.data.minQuantity.ToString();
                    }
                    else
                    {
                        this.txtminqty.Text = ms.data[c].minQuantity.ToString();
                    }
                }
                else
                {
                    this.txtcommonqty.Text = ms.data[c].quantity.ToString();
                    commonqty = ms.data[c].quantity;
                    if (ms.data[c].minQuantity > _mt.data.minQuantity)
                    {
                        int _spec = Convert.ToInt32(ms.data[c].spec);
                        int g = (_mt.data.quantity - ms.data[c].quantity) * _spec + _mt.data.minQuantity;
                        if (g < ms.data[c].minQuantity)
                        {
                            this.txtminqty.Text = g.ToString();
                        }
                        else
                        {
                            this.txtminqty.Text = ms.data[c].minQuantity.ToString();
                        }
                    }
                    else
                    {
                        this.txtminqty.Text = ms.data[c].minQuantity.ToString();
                    }
                   
                }

               
              
                //this.txtminqty.Text = ms.data[c].minQuantity.ToString();
               
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            this.txttraycode.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Focus();
            //this.txtcommonqty.Enabled = true;
            //this.txtcommonqty.Focus();

        }

        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
            if (e.KeyChar != 13)
                return;
            if (this.txtorderid.Text == "")
                return;
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    GetPick(false);
               
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor.Current = Cursors.Default;
            //    MessageBox.Show(ex.Message);
            //    this.txtorderid.SelectAll();
            //    return;

            //}
            //if (ms.data[c] == null)
            //{
            //    this.txtorderid.Focus();
            //    this.txtorderid.SelectAll();
            //    return;
            //}
            
            //this.txtorderid.Enabled = false;
            //this.txtslid.Enabled = true;
            //this.txtslid.Focus();
            Model.PickRrList rr = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getPickRrList", @"lcCode=" + Comm.lcCode + "&pickNo=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                rr = (Model.PickRrList)JsonConvert.DeserializeObject(x, typeof(Model.PickRrList));
                if (rr == null)
                {
                    throw new Exception("PickRrList捕捉失败");
                }
                if (rr.data == null)
                    throw new Exception("库区没有数据");
                if(rr.data.Count==0)
                    throw new Exception("单据已经完成");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            //this.btnAssistance.Text = rr.data[0].assistanceName;
            this.txtAssister.Text = rr.data[0].assistanceName;
            this.txtorderid.Enabled = false;
            this.cbxrr.DataSource = null;
            this.cbxrr.DataSource = rr.data;
            this.cbxrr.ValueMember = "rrId";
            this.cbxrr.DisplayMember = "rrName";
            this.cbxrr.SelectedItem = 1;
            this.txtToTraycode.Text = "";
            this.cbxrr.Enabled = true;
            this.cbxrr.Focus();
        }

        //Model.Mpick mp = null;
        void GetPick(bool benter)
        {
            string con = @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode;
            if (!this.cbxrr.Enabled && !benter)
            {
                //con += "&recommendSlId=" + ms.data[c].recommendSlId.ToString() + "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&fromTrayCode=" + this.txttraycode.Text + "&toSlId=" + this.cmbtoslname.SelectedValue.ToString() + "&updater=" + Comm.usercode + "&toTrayCode="+this.txtToTraycode.Text;
                con += "&recommendSlId=" + ms.data[c].recommendSlId.ToString() + "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&fromTrayCode=" + this.txttraycode.Text + "&toSlId=" + this.cmbtoslname.SelectedValue.ToString() + "&updater=" + Comm.usercode + "&toTrayCode=" + this.txtToTraycode.Text + "&materialCode=" + ms.data[c].materialCode;
                int imax = commonqty * ms.data[c].spec + minqty;
                int allqty = imax / ms.data[c].spec;
                int allminqty = imax % ms.data[c].spec;
                con += "&spec=" + ms.data[c].spec + "&convertQuantity" + allqty + "&convertMinQuantity" + allminqty;
                if (ma != null)
                {
                    con += "&assister=" + ma.data.code;
                }
               
            }
            if (benter)
            {
                con += "&recommendSlId=" + ms.data[c].recommendSlId.ToString();
            }
            con += "&rrId=" + this.cbxrr.SelectedValue.ToString();
            string x = HttpHelper.HttpPost("pickOperate", con);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            //mp = (Model.Mpick)JsonConvert.DeserializeObject(x, typeof(Model.Mpick));
            //if (mp == null)
            //{
            //    throw new Exception("数据信息捕捉失败");
            //}
            //Clear();
            //if (ms.data[c] == null)
            //{
            //    this.txtorderid.Enabled = true;
            //    this.txtorderid.Focus();
            //    this.txtorderid.SelectAll();
            //    throw new Exception("当前库区拣货完成！");
            //    return;
                
            //}
            //this.btnAssistance.Text = ms.data[c].assistance;
            //this.labSlname.Text = ms.data[c].slName.ToString();
            //this.labmaterialname.Text = "物料描述  "+ms.data[c].materialName;
            //this.labneedqty.Text = ms.data[c].quantity.ToString() + ms.data[c].commonUnitName + ms.data[c].minQuantity.ToString() + ms.data[c].minUnitName + " " +ms.data[c].pdate;
            //this.labcommonUnit.Text = ms.data[c].commonUnitName;
            //this.labminunit.Text = ms.data[c].minUnitName;
            //this.labtoslidname.Text = mtrans.data.toSlIdName;
            //this.txtSlId.Enabled = true;
            //this.txtSlId.Focus();

        }

        int c = 0;
        void GetPickSlList()
        {
            string x = HttpHelper.HttpPost("getPickSlList", @"lcCode=" + Comm.lcCode + "&pickNo=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode + "&rrId=" + this.cbxrr.SelectedValue.ToString());
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
                throw new Exception("当前库区拣货完成！");
            }
            c = 0;
            mShow();
        }

        void mShow()
        {
            this.labSlname.Text = ms.data[c].slName;
            this.labmaterialname.Text = "物料描述  " + ms.data[c].materialName;
            this.labneedqty.Text = ms.data[c].quantity.ToString() + ms.data[c].commonUnitName + ms.data[c].minQuantity.ToString() + ms.data[c].minUnitName + " " + ms.data[c].pdate;
            this.labcommonUnit.Text = ms.data[c].commonUnitName;
            this.labminunit.Text = ms.data[c].minUnitName;
           
        }

        bool bf = false;
        void Next()
        {
            c++;
            bf = false;
            if (c == ms.data.Count)
            {
                bf=true;
                foreach (Model.material v in ms.data)
                {
                    if ((v.quantity * v.spec + v.minQuantity) != 0)
                    {
                        bf = false;
                        break;
                    }
                }
                if (!bf)
                {
                    GetPickSlList();
                }
                else
                {
                    Clear();
                    return;
                }
            }
            mShow();

        }

        Model.MShowList ms = null;
        Model.MShowList ms1 = null;
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
                string x = HttpHelper.HttpPost("getPickSlList", @"lcCode=" + Comm.lcCode + "&pickNo=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode + "&rrId="+this.cbxrr.SelectedValue.ToString());
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                ms1 = (Model.MShowList)JsonConvert.DeserializeObject(x, typeof(Model.MShowList));
                if (ms1 == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (ms1.data.Count == 0)
                {
                    throw new Exception("当前库区拣货完成！");
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }

            DataTable dt = GetDT(ms1.data);
            Ot.frmList frm = new Rf_Wms.Ot.frmList();
            frm.dt = dt;
            frm.txtname = "待拣货列表";
            frm.ShowDialog();
            foreach (Control v in this.Controls)
            {
                if (v is TextBox)
                {
                    if (v.Enabled)
                        v.Focus();
                }
            }
        }

        public static DataTable GetDT(List<Model.material> mlist)
        {
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
            dt.Columns.Add("inDate");
            DataRow dr;
            foreach (Model.material v in mlist)
            {
                if (v.quantity == v.realQuantity && v.minQuantity == v.realMinquantity)
                    continue;
                dr = dt.NewRow();
                dr["materialCode"] = v.materialCode;
                dr["materialName"] = v.materialName;
                if (!string.IsNullOrEmpty(v.pdate))
                {
                    dr["pdate"] = v.pdate;
                }
                else
                {
                    dr["pdate"] = "";
                }
                if (!string.IsNullOrEmpty(v.batchNo))
                {
                    dr["batchNo"] = v.batchNo;
                }
                else
                {
                    dr["batchNo"] = "";
                }
                dr["slName"] = v.slName;
                int _quantity = v.quantity - v.realQuantity;
                if (_quantity < 0)
                    _quantity = 0;
                int _minquantity = v.minQuantity - v.realMinquantity;
                if (_minquantity < 0)
                    _minquantity = 0;
                dr["qty"] = _quantity.ToString() + v.commonUnitName + _minquantity.ToString() + v.minUnitName;
                dr["fromSlIdName"] = v.fromSlIdName;
                dr["toSlIdName"] = v.toSlIdName;
                dr["trayCode"] = v.trayCode;
                if (string.IsNullOrEmpty(v.pdate))
                {
                    v.pdate = "";
                }
                if (string.IsNullOrEmpty(v.batchNo))
                {
                    v.batchNo = "";
                }
                if (string.IsNullOrEmpty(v.inDate))
                {
                     v.inDate="";
                }
                dr["inDate"] = v.inDate;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void txtslid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                //mp = null;
                this.labmaterialname.Text = "物料描述";
                this.labneedqty.Text = "";
                this.labSlname.Text = "";
                this.txtslid.Text = "";
                this.txtslid.Enabled = false;
                //this.txtorderid.Enabled = true;
                //this.txtorderid.Text = "";
                //this.txtorderid.Focus();
                this.cbxrr.Enabled = true;
                this.cbxrr.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            //this.txtslid.Text = this.txtslid.Text.ToUpper();
            if (this.txtslid.Text != ms.data[c].slName.ToString())
            {
                MessageBox.Show("库位不正确");
                this.txtslid.SelectAll();
                return;
            }
            this.txtslid.Enabled = false;
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
        }

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.labtrayqty.Text = "";
                this.txtcommonqty.Enabled = false;
                this.txttraycode.Enabled = true;
                this.txttraycode.SelectAll();
                this.txtcommonqty.Text = "";
                this.txttraycode.Focus();
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
            //int _spec = Convert.ToInt32(ms.data[c].spec);
            //int r = commonqty * _spec;
            if (commonqty > _mt.data.quantity)
            {
                MessageBox.Show("输入数量大于托盘数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (commonqty > ms.data[c].quantity )
            {
                MessageBox.Show("输入数量大于单据数量");
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
            if (this.txtminqty.Text == "")
                this.txtminqty.Text = "0";
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
            if (commonqty == 0 && minqty == 0)
            {
                MessageBox.Show("必须有数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            //if (minqty > _mt.data.minQuantity)
            //{
            //    MessageBox.Show("输入数量大于托盘数量");
            //    this.txtcommonqty.SelectAll();
            //    return;
            //}
            if (minqty > ms.data[c].minQuantity)
            {
                MessageBox.Show("输入数量大于单据数量");
                this.txtcommonqty.SelectAll();
                return;
            }
            int _spec = Convert.ToInt32(ms.data[c].spec);
            int r = ms.data[c].quantity - commonqty;
            if (r > 0)
                r = 0;
            r = ms.data[c].minQuantity - minqty + r * _spec;
            if (r < 0)
            {
                MessageBox.Show("不能超单操作");
                this.txtminqty.SelectAll();
                return;
            }

            if (commonqty * _spec + minqty > _mt.data.quantity * _spec + _mt.data.minQuantity)
            {
                MessageBox.Show("输入数量大于托盘数量");
                this.txtminqty.SelectAll();
                return;
            }

            this.txtminqty.Enabled = false;
            this.txtToTraycode.Enabled = true;
            this.txtToTraycode.Focus();
        }

        Model.MTrayByBox mm = null;
        private void txtToTraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtminqty.Enabled = true;
                this.txtToTraycode.Enabled = false;
                this.txtToTraycode.Text = "";
                this.txtminqty.Focus();
                this.txtminqty.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txtToTraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描正确托盘码！");
                //this.txttraycode.SelectAll();
                this.txtToTraycode.Text = "";
                return;
            }
            //2017-04-11 add
            if (this.txtToTraycode.Text == this.txttraycode.Text)
            {
                //if (_mt.data.quantity != commonqty || _mt.data.minQuantity != minqty)
                if (_mt.data.quantity*ms.data[c].spec+_mt.data.minQuantity != commonqty*ms.data[c].spec+ minqty)
                {
                    MessageBox.Show("非整托拣货，移入托盘不能使用原托盘");
                    //this.txtToTraycode.SelectAll();
                    this.txtToTraycode.Text = "";
                    return;
                }
            }
            else
            {
                if (Comm.lcCode != this.txtToTraycode.Text.Substring(0, Comm.lcCode.Length))
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txtToTraycode.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                        if (msg == null)
                            throw new Exception("错误信息捕捉失败");
                        if (!msg.success)
                            throw new Exception(msg.msg);
                        mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
                        if (mm == null)
                            throw new Exception("错误信息捕捉失败");
                        this.txtToTraycode.Text = mm.data.trayCode;
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        //this.txtToTraycode.SelectAll();
                        this.txtToTraycode.Text = "";
                        MessageBox.Show(ex.Message);
                        return;

                    }
                }
                else
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        string x = HttpHelper.HttpPost("verifyTrayCode", @"trayCode=" + this.txtToTraycode.Text + "&lcCode=" + Comm.lcCode);
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
           
            //if (this.txttraycode.Text == this.txttotraycode.Text)
            //{
            //    this.txttraycode.SelectAll();
            //    MessageBox.Show("出入");
            //    return;
            //}
            this.txtToTraycode.Enabled = false;
            this.txttoslname.Enabled = true;
            this.txttoslname.Text = "";
            this.txttoslname.Focus();
            this.cmbtoslname.Enabled = true;
            //this.cmbtoslname.Focus();
        }

        string toslname = "";
        private void cmbtoslname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtToTraycode.Enabled = true;
                this.cmbtoslname.Enabled = false;
               
                this.txtToTraycode.Focus();
                this.txtToTraycode.SelectAll();
                return;
            }
            bf = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetPick(false);
                ms.data[c].quantity -= commonqty;
                ms.data[c].minQuantity -= minqty;
                Clear();
                if (ms.data[c].quantity == 0 && ms.data[c].minQuantity == 0)
                {
                    Next();
                }
                else
                {
                    mShow();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            this.cmbtoslname.Enabled = false;
            if (bf)
            {
                MessageBox.Show("当前库区拣货完成");
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                //this.txtslid.Enabled = true;
                //this.txtslid.Focus();
                //this.txtslid.SelectAll();
            }
            else
            {
                //this.cbxrr.Enabled = true;
                //this.cbxrr.Focus();
                this.txttraycode.Enabled = true;
                this.txttraycode.Focus();
            }
        }

        Model.MZcqSlList mz = null;
        private void frmPackingUp_Load(object sender, EventArgs e)
        {
            //this.cmbtoslname.Items.Add("ceshi", 60);
           
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getZcqSlList", "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mz = (Model.MZcqSlList)JsonConvert.DeserializeObject(x, typeof(Model.MZcqSlList));
                List<Model.zcq> zcql = new List<Rf_Wms.Model.zcq>();
                foreach (Model.zcq v in mz.data)
                {
                    if (v.status == "EFFECTIVE")
                    {
                        zcql.Add(v);
                    }
                }
                if (zcql.Count == 0)
                {
                    throw new Exception("没有可用的转储区信息");
                }
                this.cmbtoslname.DataSource = zcql;
                //this.cmbtoslname.DataSource = mz.data;
                this.cmbtoslname.ValueMember = "slId";
                this.cmbtoslname.DisplayMember = "slName";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.Close();
                return;
            }
            Clear();
            this.txtorderid.Enabled = true;
            this.txtorderid.Focus();
        }

        void Clear()
        {
            this.txttoslname.Text = "";
            this.txttoslname.Enabled = false;
            this.txtcommonqty.Text = "";
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Text = "";
            this.txtminqty.Enabled = false;
            //this.txtorderid.Text = "";
            this.txtorderid.Enabled = false;
            this.txtslid.Text = "";
            this.txtslid.Enabled = false;
            this.labSlname.Text = "";
            //this.txtToTraycode.Text = "";
            this.txtToTraycode.Enabled = false;
            this.txttraycode.Text = "";
            this.txttraycode.Enabled = false;
            this.cmbtoslname.Enabled = false;
            this.labcommonUnit.Text = "";
            this.labtrayqty.Text = "";
            this.labmaterialname.Text = "物料描述";
            //this.txtAssister.Text = "";

            this.labminunit.Text = "";
            this.labneedqty.Text = "";
          
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
            if (this.cbxrr.Enabled)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //GetPick(true);
                Next();
                this.txtslid.Text = "";
                this.txttraycode.Text = "";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtorderid.Enabled = true;
                this.txtorderid.SelectAll();
                return;

            }
           
            foreach (Control v in this.Controls)
            {
                if (v is TextBox)
                {
                    if (v.Enabled)
                        v.Focus();
                }
            }
            //this.txtslid.Enabled = true;
            //this.txtslid.Focus();
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
            frm.fun = "updateAssistance";
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

        private void txtorderid_GotFocus(object sender, EventArgs e)
        {
            txtorderid.SelectAll();
        }

        private void txtslid_GotFocus(object sender, EventArgs e)
        {
            txtslid.SelectAll();
        }

        private void txttraycode_GotFocus(object sender, EventArgs e)
        {
            txttraycode.SelectAll();
        }

        private void txtcommonqty_GotFocus(object sender, EventArgs e)
        {
            //this.txtcommonqty.Text = "0";
            txtcommonqty.SelectAll();
        }

        private void txtminqty_GotFocus(object sender, EventArgs e)
        {
            //this.txtminqty.Text = "0";
            txtminqty.SelectAll();
        }

        private void txtToTraycode_GotFocus(object sender, EventArgs e)
        {
            txtToTraycode.SelectAll();
        }

        private void txttoslname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtToTraycode.Enabled = true;
                this.cmbtoslname.Enabled = false;

                this.txtToTraycode.Focus();
                this.txtToTraycode.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txttoslname.Text != "")
            {
                var v = from x in mz.data where x.slName == this.txttoslname.Text select x;
                if (v.Count() == 0)
                {
                    MessageBox.Show("当前仓库暂存区未找到该库位");
                    this.txttoslname.SelectAll();
                    return;
                }
                else
                {
                    this.cmbtoslname.Text = this.txttoslname.Text;
                }
            }
            cmbtoslname_KeyPress(null,new KeyPressEventArgs((char)Keys.Enter));
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
                Cursor.Current = Cursors.WaitCursor;
                //GetPick(false);
                GetPickSlList();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtorderid.SelectAll();
                return;

            }
            if (ms.data[c] == null)
            {
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                return;
            }
            this.cbxrr.Enabled = false;
            this.txtorderid.Enabled = false;
            this.txtAssister.Enabled = true;
            this.txtAssister.Text = "";
            this.txtAssister.Focus();
            //this.txttraycode.Enabled = true;
            //this.txttraycode.Focus();
        }

        Model.MAssisterInfo ma = null;
        private void txtAssister_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtAssister.Text = "";
                this.txtAssister.Enabled = false;
                //this.txtslid.Enabled = true;
                //this.txtslid.Text = "";
                //this.txtslid.Focus();
                this.labmaterialname.Text = "物料描述";
                this.labneedqty.Text = "";
                this.labSlname.Text = "";
                this.cbxrr.Enabled = true;
                this.txtAssister.Enabled = false;
                this.cbxrr.Focus();
                //this.cbxrr.Enabled = true;
                //this.cbxrr.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txtAssister.Text == "")
            {
                ma = null;
                this.txtAssister.Enabled = false;
                this.txttraycode.Enabled = true;
                this.txttraycode.Focus();
                return;
            }
            try
            {
                string x = HttpHelper.HttpPost("getAssisterInfo", @"lcCode=" + Comm.lcCode + "&assisterCode=" + this.txtAssister.Text);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                ma = (Model.MAssisterInfo)JsonConvert.DeserializeObject(x, typeof(Model.MAssisterInfo));
                if (ma == null)
                {
                    throw new Exception("getAssisterInfo捕捉失败");
                }
                this.txtAssister.Text = ma.data.name;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtAssister.SelectAll();
                return;
            }
            this.txtAssister.Enabled = false;
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
        }
        
        
    }
}