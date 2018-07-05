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
    public partial class frmBalTranMove : Form
    {
        public frmBalTranMove()
        {
            InitializeComponent();
        }

        Model.MZcqSlList mz = null;
        Model.Mmsg msg = null;
        private void frmBalTranMove_Load(object sender, EventArgs e)
        {
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
                //var v = from q in mz.data where q.status == "EFFECTIVE" select q;
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
                this.cmbtoslname.ValueMember = "slId";
                this.cmbtoslname.DisplayMember = "slName";

                x = HttpHelper.HttpPost("getBalanceTransferOrderNumber", "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&updater=" + Comm.usercode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.Mccode mc=  (Model.Mccode)JsonConvert.DeserializeObject(x, typeof(Model.Mccode));
                this.labccode.Text = mc.data;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                
                return;
            }
            init();
            this.txtbarcode.Text = "";
            this.txttoslname.Enabled = true;
            this.cmbtoslname.Enabled = true;
            this.txttoslname.Focus();

        }

        private void txttoslname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.txttoslname.Text != "")
            {
                var v = from x in mz.data where x.slName == this.txttoslname.Text && x.status  == "EFFECTIVE" select x;
                if (v.Count() == 0)
                {
                    MessageBox.Show("暂存区没有该库位");
                    this.txttoslname.SelectAll();
                    return;
                }
                else
                {
                    this.cmbtoslname.Text = this.txttoslname.Text;
                }
            }
            cmbtoslname_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void cmbtoslname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            this.cmbtoslname.Enabled = false;
            this.txttoslname.Enabled = false;
            this.txtbarcode.Enabled = true;
            this.txtbarcode.Focus();
        }

        Model.locationStockList ml;
        int row = 0;
        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtbarcode.Text = "";
                this.txtbarcode.Enabled = false;
                this.cmbtoslname.Enabled = true;
                this.txttoslname.Enabled = true;
                this.txttoslname.Text = "";
                this.txttoslname.Focus();
            }
            Model.Mmaterialcode m = null;
            if (e.KeyChar != 13)
                return;
            if (this.txtbarcode.Text == "")
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getMaterialCode", @"barCode=" + this.txtbarcode.Text + "&lcCode=" + Comm.lcCode );
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
               
                MessageBox.Show(ex.Message);
                this.txtbarcode.SelectAll();
                return;

            }
            Model.Mmaterialcodebody materialbody = null;
            if (m.data.Count > 1)
            {
                Ot.frmMaterial frm = new Rf_Wms.Ot.frmMaterial();
                frm.m = m;
                frm.ShowDialog();
                if (frm.mbody != null)
                    materialbody = frm.mbody;
            }
            else
            {
                materialbody = m.data[0];
            }
            if (materialbody != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("getlocationStockList", @"&whId=" + Comm.warehousecode + "&lcCode=" + Comm.lcCode + "&materialCode=" + materialbody.code + "&slId=" + this.cmbtoslname.SelectedValue.ToString());
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    ml = (Model.locationStockList)JsonConvert.DeserializeObject(x, typeof(Model.locationStockList));
                    if (ml == null)
                    {
                        throw new Exception("数据信息捕捉失败");
                    }
                    if (ml.data.Count == 0)
                    {
                        throw new Exception("未找到待转储库存");
                    }
                    row = 0;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    this.txtbarcode.SelectAll();
                    MessageBox.Show(ex.Message);
                    return;

                }
               

            }
            else
            {
                this.txtbarcode.SelectAll();
                return;
            }
            showTxt();
            this.txtbarcode.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Focus();
            //this.txtcommonqty.Enabled = true;
            //this.txtcommonqty.Focus();
        }

        int maxquantity = 0;
        int maxminquantity = 0;
        void showTxt()
        {
            this.labbatchno.Text = ml.data[row].batchNo;
            this.labpdate.Text = ml.data[row].pdateStr;
            this.labmaterial.Text = ml.data[row].materialCodeName;
            int imax = ml.data[row].totalQuantity * ml.data[row].spec + ml.data[row].minTotalQuantity;
            //int imax = ml.data[row].canUseTotalQuantity * ml.data[row].spec + ml.data[row].canUseMinTotalQuantity;
            //if (maxminquantity < 0 || maxminquantity < 0)
            //{
            maxquantity = ml.data[row].totalQuantity;
            maxminquantity = ml.data[row].minTotalQuantity;
            if (maxquantity < 0 || maxminquantity < 0)
            {
                maxquantity = imax / ml.data[row].spec;
                maxminquantity = imax % ml.data[row].spec;
            }

            this.labqty.Text = maxquantity + ml.data[row].unit + maxminquantity + ml.data[row].minUnit;
            commonqty = maxquantity;
            minqty = maxminquantity;
            this.txtcommonqty.Text = maxquantity.ToString();
            this.txtminqty.Text = maxminquantity.ToString();
            this.labcommonUnit.Text = ml.data[row].unit;
            this.labminunit.Text = ml.data[row].minUnit;
            this.labshippername.Text = ml.data[row].shipperCodeName;
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
                string conn = @"orderId=" + this.labccode.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&updater=" + Comm.usercode;
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

        int commonqty;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtcommonqty.Enabled = false;
                this.txtbarcode.Enabled = true;
                this.txtbarcode.SelectAll();
                this.labqty.Text = "";
                this.labbatchno.Text = "";
                this.labpdate.Text = "";
                this.labminunit.Text = "";
                this.labcommonUnit.Text = "";
                this.labshippername.Text = "";
                this.labbatchno.Text = "";
                this.txtcommonqty.Text = "";
                this.labmaterial.Text = "";
                this.txtbarcode.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txtcommonqty.Text == "")
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
            //if (commonqty * ml.data[row].spec > ml.data[row].canUseMinTotalQuantity + ml.data[row].canUseTotalQuantity * ml.data[row].spec)
            if (commonqty > maxquantity)
            {
                MessageBox.Show("输入数量大于待转储量");
                this.txtcommonqty.SelectAll();
                return;
            }

            
            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Focus();
        }

        int minqty;
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
            if (commonqty == 0 && minqty == 0)
            {
                MessageBox.Show("转储数量必须大于0");
                this.txtminqty.SelectAll();
                return;
            }

            if (minqty + commonqty * ml.data[row].spec > ml.data[row].minTotalQuantity + ml.data[row].totalQuantity * ml.data[row].spec)
            {
                MessageBox.Show("输入数量大于待转储量");
                this.txtminqty.SelectAll();
                return;
            }

                this.txtminqty.Enabled = false;
                this.txttotraycode.Enabled = true;
                this.txttotraycode.Focus();
            

        }



        Model.MTrayStockByOrderType nmt = null;
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
            if(this.txttotraycode.Text=="")
                return;
            if (this.txttotraycode.Text.Length < Comm.lcCode.Length)
            {
                MessageBox.Show("请扫描正确托盘码！");
                //this.txttraycode.SelectAll();
                this.txttotraycode.Text = "";
                return;
            }
            //if (Comm.lcCode != this.txttotraycode.Text.Substring(0, Comm.lcCode.Length))
            //    {
            //        try
            //        {
            //            Cursor.Current = Cursors.WaitCursor;
            //            string x = HttpHelper.HttpPost("getTrayByBox", @"boxCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
            //            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //            if (msg == null)
            //                throw new Exception("错误信息捕捉失败");
            //            if (!msg.success)
            //                throw new Exception(msg.msg);
            //            Model.MTrayByBox mm = (Model.MTrayByBox)JsonConvert.DeserializeObject(x, typeof(Model.MTrayByBox));
            //            if (mm == null)
            //                throw new Exception("错误信息捕捉失败");
            //            this.txttotraycode.Text = mm.data.trayCode;
            //            Cursor.Current = Cursors.Default;
            //        }
            //        catch (Exception ex)
            //        {
            //            Cursor.Current = Cursors.Default;
            //            //this.txtToTraycode.SelectAll();
            //            txttotraycode.SelectAll();
            //            MessageBox.Show(ex.Message);
            //            return;

            //        }
            //    }
              
                    //try
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    string x = HttpHelper.HttpPost("verifyTrayCode", @"trayCode=" + this.txttotraycode.Text + "&lcCode=" + Comm.lcCode);
                    //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    //    if (msg == null)
                    //        throw new Exception("verifyTrayCode错误信息捕捉失败");
                    //    if (!msg.success)
                    //        throw new Exception(msg.msg);
                    //    Cursor.Current = Cursors.Default;

                    //}
                    //catch (Exception ex)
                    //{
                    //    Cursor.Current = Cursors.Default;
                    //    MessageBox.Show(ex.Message);
                    //    return;

                    //}
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //string x = HttpHelper.HttpPost("trayStock/findTrayStockByOrderType", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttotraycode.Text + "&whId=" + Comm.warehousecode+"&transferType=2");
                string x = HttpHelper.HttpPost("trayStock/verifyToTrayCodeNotZC", @"lcCode=" + Comm.lcCode + "&trayCode=" + this.txttotraycode.Text + "&whId=" + Comm.warehousecode + "&transferType=2");
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
            //if (!string.IsNullOrEmpty(nmt.data.status))
            //{
            //    MessageBox.Show("该托盘是暂存区托盘");
            //    this.txttotraycode.SelectAll();
            //    return;
            //}

            if (nmt.data!=null)//不是空托盘
            {
               
                //if (nmt.data.slId != mt.data.t)
                //{
                //    MessageBox.Show("该托盘不在目标库位上,请换一个托盘");
                //    this.txttotraycode.SelectAll();
                //    return;
                //}
                if (ml.data[row].materialCode != nmt.data.materialCode)
                {
                    MessageBox.Show("新托盘上的物料是" + nmt.data.materialName + ",不能合托,请换托盘");
                    this.txttotraycode.SelectAll();
                    return;
                }
                if (ml.data[row].inDateStr != nmt.data.inDate || ml.data[row].batchNo != nmt.data.batchNo || ml.data[row].pdateStr != nmt.data.pdate || ml.data[row].materialStatusCode != nmt.data.materialStatus)
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
            this.txttotraycode.Enabled = false;
            this.txttoslid.Enabled = true;
            this.txttoslid.Text = "";
            this.txttoslid.Focus();
        }

        int slid;
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
            var o = from x in mz.data where x.slName == this.txttoslid.Text select x;
            if (o.Count() >0)
            {
                MessageBox.Show("不能输入暂存区库位");
                this.txttoslid.SelectAll();
                return;
            }
            if (this.txttoslid.Text != "")
            {
                Model.MSlIdBySlName ms;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string x = HttpHelper.HttpPost("trayStock/findSlIdBySlNameNoZC", @"lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&slName=" + this.txttoslid.Text);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("findSlIdBySlName错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    ms = (Model.MSlIdBySlName)JsonConvert.DeserializeObject(x, typeof(Model.MSlIdBySlName));
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    this.txttoslid.SelectAll();
                    return;
                }
                slid = ms.data.slId;
            }
            else
            {
                if (nmt.data == null)
                {
                    MessageBox.Show("新托盘移入库位不能为空");
                    this.txttoslid.SelectAll();
                    return;
                }
            }
            try
            {
                 Cursor.Current = Cursors.WaitCursor;
                 Save();
                 Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            ml.data[row].totalQuantity -= commonqty;
            ml.data[row].minTotalQuantity -= minqty;
            this.txttoslid.Enabled = false;
            bool isfinish = true;
            foreach (Model.locationStockLists v in ml.data)
            {
                if (v.minTotalQuantity + v.totalQuantity * v.spec != 0)
                {
                    isfinish = false;
                    break;
                }
            }
            if (isfinish)
            {
                init();
                this.txtbarcode.Text = "";
                this.txttoslname.Enabled = true;
                this.cmbtoslname.Enabled = true;
                this.txttoslname.Focus();
                return;
            }
            if (ml.data[row].minTotalQuantity + ml.data[row].totalQuantity * ml.data[row].spec == 0)
            {
                row++;
            }
            row--;
            btnNext1_Click(null, null);
            //showTxt();
            //this.txttoslid.Text = "";
            //this.txttotraycode.Text = "";
           
            //this.txtminqty.Enabled = true;
            //this.txtminqty.Focus();
            //this.txtminqty.SelectAll();
        }

        void Save()
        {
            string conn = @"lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&updater=" + Comm.usercode + "&fromSlId=" + ml.data[row].slId + "&toTrayCode=" + this.txttotraycode.Text + "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&materialCode=" + ml.data[row].materialCode + "&orderId=" + this.labccode.Text + "&batchNo=" + ml.data[row].batchNo + "&pdate=" + ml.data[row].pDate + "&inDate=" + ml.data[row].inDate + "&shipperCode=" + ml.data[row].shipperCode + "&oldMaterialStatus=" + ml.data[row].materialStatusCode;
            if (nmt.data!=null)
            {
                conn += "&materialStatus=" + nmt.data.materialStatus;
            }
              if (this.txttoslid.Text != "")
            {
                conn += "&toSlId=" + slid.ToString() ;
            }
            string x = HttpHelper.HttpPost("submitBalanceTransferOrder",conn );
          
            //string xx = HttpHelper.HttpPost("submitBalanceTransferOrder", x);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("submitBalanceTransferOrder错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
        }

        void init()
        {
            ml = null;
            this.labmaterial.Text = "";
            this.labpdate.Text = "";
            this.labminunit.Text = "";
            this.labcommonUnit.Text = "";
            this.labshippername.Text = "";
            this.labbatchno.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            this.txttoslid.Text = "";
            this.txttotraycode.Text = "";
            this.labqty.Text = "";
            //this.labcommonUnit.Text = "";
            //this.labminunit.Text = "";
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            if (ml == null)
                return;
            while (true)
            {
                row++;
                if (row == ml.data.Count)
                {
                    row = 0;
                }
                if (ml.data[row].minTotalQuantity + ml.data[row].totalQuantity * ml.data[row].spec != 0)
                {
                    showTxt();
                    this.txttoslid.Text = "";
                    this.txttotraycode.Text = "";
                    //this.txtcommonqty.Text = "";
                    //this.txtminqty.Text = "";
                    this.txttoslid.Enabled = false;
                    this.txttotraycode.Enabled = false;
                    this.txtminqty.Enabled = true;
                    //this.txtcommonqty.Enabled = true;
                    this.txtminqty.SelectAll();
                    this.txtminqty.Focus();
                    break;
                }
           
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            if (ml == null)
                return;
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
            foreach (Model.locationStockLists v in ml.data)
            {
                //if (v.quantity == v.realQuantity && v.minQuantity == v.realMinquantity)
                //    continue;
                dr = dt.NewRow();
                dr["materialCode"] = v.materialCode;
                dr["materialName"] = v.materialCodeName;
                if (!string.IsNullOrEmpty(v.pdateStr))
                {
                    dr["pdate"] = v.pdateStr;
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
                dr["slName"] = "";
                int _quantity = v.totalQuantity;
                //if (_quantity < 0)
                //    _quantity = 0;
                int _minquantity = v.minTotalQuantity;
                //if (_minquantity < 0)
                //    _minquantity = 0;

                if (_quantity < 0 || _minquantity < 0)
                {
                    int imax = _quantity * v.spec + _minquantity;
                    //_quantity = (int)(Math.Ceiling(((double)(imax) / v.spec)));
                    _quantity = imax / v.spec;
                    _minquantity = imax % v.spec;

                }
                if (_quantity * v.spec + _minquantity == 0)
                    continue;
                dr["qty"] = _quantity.ToString() + v.unit + _minquantity.ToString() + v.minUnit;
                dr["fromSlIdName"] = "";
                dr["toSlIdName"] = "";
                dr["trayCode"] = "";
                if (string.IsNullOrEmpty(v.pdateStr))
                {
                    v.pdateStr = "";
                }
                if (string.IsNullOrEmpty(v.batchNo))
                {
                    v.batchNo = "";
                }
                dt.Rows.Add(dr);
            }
            Ot.frmList frm = new Rf_Wms.Ot.frmList();
            frm.dt = dt;
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

      

       
    }
}