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
    public partial class frmStockOutCheck : Form
    {
        public frmStockOutCheck()
        {
            InitializeComponent();
        }

        public Model.MstartSecondarySorting mss;
        bool sortingFlg = false;
        Model.Mmsg msg = null;
        //private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar != 13)
        //        return;
        //    this.txtorderid.Text = this.txtorderid.Text.Trim();
        //    if (this.txtorderid.Text == "")
        //        return;
        //    try
        //    {
        //        string x = HttpHelper.HttpPost("getSortingFlg", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
        //        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
        //        if (msg == null)
        //            throw new Exception("错误信息捕捉失败");
        //        if (!msg.success)
        //            throw new Exception(msg.msg);
        //        Model.SortingFlg v = (Model.SortingFlg)JsonConvert.DeserializeObject(x, typeof(Model.SortingFlg));
        //        if (v == null )
        //        {
        //            throw new Exception("数据信息捕捉失败");
        //        }
        //        sortingFlg = v.data.sortingFlg;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        this.txtorderid.SelectAll();
        //        return;

        //    }
        //    if (sortingFlg)
        //    {
        //        MessageBox.Show("当前单据没有登记拣货结余，需执行二次分拣！");
        //        this.txtorderid.SelectAll();
        //        return;
               
        //    }
        //    this.txttraycode.Enabled = true;
        //    this.txtorderid.Enabled = false;
        //    this.txttraycode.Focus();
        //}

        Model.MSumQuantityByTray ms = null;
        int sqty = 0, sminqty = 0; 
        //private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 27)
        //    {
        //        this.txttraycode.Text = "";
        //        this.txttraycode.Enabled = false;
        //        this.txtorderid.Enabled = true;
        //        this.txtorderid.Text = "";
        //        this.txtorderid.Focus();
        //        return;
        //    }
        //    if (e.KeyChar != 13)
        //        return;
        //    this.txttraycode.Text = this.txttraycode.Text.Trim();
        //    if (this.txttraycode.Text == "")
        //    {
        //        MessageBox.Show("请扫描托盘条码");
        //        return;
        //    }
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        string x = HttpHelper.HttpPost("getSumQuantityByTray", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&toTrayCode=" + this.txttraycode.Text);
        //        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
        //        if (msg == null)
        //            throw new Exception("错误信息捕捉失败");
        //        if (!msg.success)
        //            throw new Exception(msg.msg);
        //        ms = (Model.MSumQuantityByTray)JsonConvert.DeserializeObject(x, typeof(Model.MSumQuantityByTray));
        //        if (ms == null || ms.data == null)
        //        {
        //            throw new Exception("数据信息捕捉失败");
        //        }
        //        this.labqty.Text = ms.data.quantity.ToString() + "箱" + ms.data.minQuantity.ToString() + "个";
        //        sqty = ms.data.quantity;
        //        sminqty = ms.data.minQuantity;
        //        if (ms.data.checkMinQuantity != null)
        //        {
        //            this.txtminqty.Text = ms.data.checkMinQuantity.ToString();
        //            sminqty = (int)ms.data.checkMinQuantity;
        //        }
        //        else
        //        {
        //            //this.txtminqty.Text = "0";
        //        }
        //        if (ms.data.checkQuantity != null)
        //        {
        //            this.txtcommonqty.Text = ms.data.checkQuantity.ToString();
        //            sqty = (int)ms.data.checkQuantity;
        //            this.txtminqty.Enabled = true;
        //            this.txtminqty.Focus();
        //        }
        //        else
        //        {
        //            //this.txtcommonqty.Text = "0";
        //            this.txtcommonqty.Enabled = true;
        //            this.txtcommonqty.Focus();
        //        }

               
        //        Cursor.Current = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor.Current = Cursors.Default;
        //        this.labqty.Text = "";
        //        MessageBox.Show(ex.Message);
        //        this.txttraycode.SelectAll();
        //        return;

        //    }
          
        //    //if (sortingFlg)
        //    //{
        //    //    MessageBox.Show("当前单据没有登记拣货结余，需执行二次分拣！");
        //    //    this.txtorderid.SelectAll();
        //    //    return;
        //    //    //try
        //    //    //{
        //    //    //    getQuantityListByTray();
        //    //    //}
        //    //    //catch (Exception ex)
        //    //    //{
        //    //    //    MessageBox.Show(ex.Message);
        //    //    //    this.txttraycode.SelectAll();
        //    //    //    return;
        //    //    //}
        //    //    //this.txtcheckqty.Enabled = true;
        //    //    //this.txtcheckqty.Focus();
        //    //}
        //    //else
        //    //{

               
               
        //    //}
        //    this.txttraycode.Enabled = false;
        //}

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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
            if (commonqty > mss.data.trayPickQuantity)
            {
                MessageBox.Show("复核量不能大于托盘量");
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
                commonqty = Convert.ToInt32(this.txtcommonqty.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入主数量");
                this.txtcommonqty.SelectAll();
                return;
            }
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
            if (minqty > mss.data.trayPickMinQuantity)
            {
                MessageBox.Show("复核量不能大于托盘量");
                this.txtminqty.SelectAll();
                return;
            }
            if (commonqty == mss.data.trayPickQuantity && minqty == mss.data.trayPickMinQuantity)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string conn = @"pickNo=" + mss.data.pickNo + "&lcCode=" + Comm.lcCode + "&checkQuantity=" + commonqty.ToString() + "&checkMinQuantity=" + minqty.ToString() + "&updater=" + Comm.usercode + "&trayCode=" + mss.data.trayCode + "&sortingType=" + mss.data.sortingType + "&pickType=" + mss.data.pickType + "&checkType=" + mss.data.checkType;
                    
                    //if (mss.data.sortingType == null)
                    //{
                    //    conn += "&pdateString=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pDate + "&batchNo=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].batchNo+"&materialCode="+mss.data.pickOperateSecondarySortingRFDTOS[mssrow].materialCode;
                    //}
                   
                    string x = HttpHelper.HttpPost("doSecondarySorting", conn);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    Cursor.Current = Cursors.Default;
                    //clear();
                    //this.txtorderid.Enabled = true;
                    //this.txtorderid.Focus();
                    //this.txtorderid.SelectAll();
                    this.Close();
                    return;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    this.txtminqty.SelectAll();
                    return;

                }
               
            }
            try
            {
                //getQuantityListByTray();
                mssrow = 0;
                ShowBody();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtminqty.SelectAll();
                return;
            }


        }

        int mssrow;
        void ShowBody()
        {
            if (mssrow == mss.data.pickOperateSecondarySortingRFDTOS.Count)
                return;
            this.labmaterialname.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].materialCode + " " + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].materialName;
            this.labpdata.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pDate;
            this.labbatch.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].batchNo;
            this.labcommonUnit.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].commonUnitName;
            this.labminunit.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].minUnitName;
            this.labcheckqty.Text ="商品数量 "+ mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].commonUnitName + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].minUnitName;
            this.txtcheckminqty.Text = "";
            this.txtcheckqty.Text = "";
            this.txtcheckqty.Enabled = true;
            this.txtcheckqty.Focus();
            this.txtcheckminqty.Enabled = false;
            this.txtminqty.Enabled = false;
        }

        Model.MQuantityListByTray mq = null;
        int c = 0;
        void getQuantityListByTray()
        {
            c = 0;
            //string x = HttpHelper.HttpPost("getQuantityListByTray", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&toTrayCode=" + this.txttraycode.Text );
            //msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //if (msg == null)
            //    throw new Exception("错误信息捕捉失败");
            //if (!msg.success)
            //    throw new Exception(msg.msg);
            //mq = (Model.MQuantityListByTray)JsonConvert.DeserializeObject(x, typeof(Model.MQuantityListByTray));
            //if (mq == null || mq.data == null)
            //{
            //    throw new Exception("MQuantityListByTray数据信息捕捉失败");
            //}
            //checkSO();
        }

        void ShowTxt()
        {
            this.labmaterialname.Text = "物料描述  " + mq.data[c].materialName;
            this.labpdata.Text = mq.data[c].pDate;
            this.labbatch.Text = mq.data[c].batchNo;

            this.labcheckqty.Text = "商品数量 "+mq.data[c].quantity.ToString() + mq.data[c].commonUnitName + mq.data[c].minQuantity.ToString() + mq.data[c].minUnitName;
            //if (mq.data[c].checkQuantity==null)
            //{
            //    this.labcheckqty.Text += "0";
            //}
            //else
            //{
            //    this.labcheckqty.Text += mq.data[c].checkQuantity.ToString();
            //}
            //this.labcheckqty.Text += mq.data[c].commonUnitName;
            //if (mq.data[c].checkMinQuantity==null)
            //{
            //    this.labcheckqty.Text += "0";
            //}
            //else
            //{
            //    this.labcheckqty.Text += mq.data[c].checkMinQuantity.ToString();
            //}
            //this.labcheckqty.Text += mq.data[c].minUnitName;
            this.labcommonUnit.Text = mq.data[c].commonUnitName;
            this.labminunit.Text = mq.data[c].minUnitName;
            this.txtcheckminqty.Text = "";
            this.txtcheckminqty.Enabled = false;
            this.txtcheckqty.Text = "";
            this.txtminqty.Enabled = false;
            if (mq.data[c].checkMinQuantity == null)
            {
                //this.txtcheckminqty.Text = "0";

            }
            else
            {
                this.txtcheckminqty.Text = mq.data[c].checkMinQuantity.ToString();
            }
            if (mq.data[c].checkQuantity == null)
            {
                //this.txtcheckqty.Text = "0";
                this.txtcheckqty.Enabled = true;
                this.txtcheckqty.Focus();
            }
            else
            {
                this.txtcheckqty.Text = mq.data[c].checkQuantity.ToString();
                this.txtcheckminqty.Enabled = true;
                this.txtcheckminqty.Focus();
            }
            
            
        }

        int checkqty = 0;
        int checkminqty = 0;
        private void txtcheckqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.labbatch.Text = "";
                this.labmaterialname.Text = "";
                this.labpdata.Text = "";
                //this.labqty.Text = "";
                this.labcheckqty.Text = "";
                this.txtcheckqty.Text = "";
                this.txtcheckqty.Enabled = false;
                if (sortingFlg)
                {
                    //this.txttraycode.Enabled = true;
                    //this.txttraycode.Text = "";
                    //this.txttraycode.Focus();
                }
                else
                {
                    this.txtminqty.Enabled = true;
                    this.txtminqty.Text = "";
                    this.txtminqty.Focus();
                }
                return;
            }
            if (e.KeyChar != 13)
                return;
            try
            {
                checkqty = Convert.ToInt32(this.txtcheckqty.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数量");
                this.txtcheckqty.SelectAll();
                return;
            }
            if (checkqty < 0)
            {
                MessageBox.Show("数量不能小于0");
                this.txtcheckqty.SelectAll();
                return;
            }
            if (checkqty > mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity)
            {
                MessageBox.Show("复核量不能大于商品数量");
                this.txtcheckqty.SelectAll();
                return;
            }
            this.txtcheckqty.Enabled = false;
            this.txtcheckminqty.Enabled = true;
            this.txtcheckminqty.Focus();
        }

        private void txtcheckminqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {

                this.txtcheckqty.Enabled = true;
                this.txtcheckminqty.Enabled = false;
                this.txtcheckminqty.Text = "";
                this.txtcheckqty.Focus();
                this.txtcheckqty.SelectAll();
                return;
            }
            if (e.KeyChar != 13)
                return;
            try
            {
                checkminqty = Convert.ToInt32(this.txtcheckminqty.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数量");
                this.txtcheckminqty.SelectAll();
                return;
            }
            if (checkminqty < 0)
            {
                MessageBox.Show("数量不能小于0");
                this.txtcheckminqty.SelectAll();
                return;
            }
            if (checkminqty > mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity)
            {
                MessageBox.Show("复核量不能大于商品数量");
                this.txtcheckminqty.SelectAll();
                return;
            }
            try
            {
                checkqty = Convert.ToInt32(this.txtcheckqty.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数量");
                this.txtcheckqty.SelectAll();
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string conn = @"pickNo=" + mss.data.pickNo + "&lcCode=" + Comm.lcCode + "&checkQuantity=" + checkqty.ToString() + "&checkMinQuantity=" + checkminqty.ToString() + "&updater=" + Comm.usercode + "&trayCode=" + mss.data.trayCode + "&pickType=" + mss.data.pickType + "&checkType=" + mss.data.checkType;
                if (mss.data.sortingType != null)
                {
                    conn += "&sortingType=" + mss.data.sortingType;
                }
                else
                {
                    conn += "&pdateString=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pDate + "&batchNo=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].batchNo;
                }
                conn += "&pickOperateId=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOperateId + "&fromTrayCode=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].fromTrayCode + "&toTrayCode=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].toTrayCode+"&materialCode="+mss.data.pickOperateSecondarySortingRFDTOS[mssrow].materialCode;;

                string x = HttpHelper.HttpPost("doSecondarySorting", conn);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Cursor.Current = Cursors.Default;
                //clear();
                //this.txtorderid.Enabled = true;
                //this.txtorderid.Focus();
                //this.txtorderid.SelectAll();
               
               
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtminqty.SelectAll();
                return;

            }
            mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity -= checkminqty;
            mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity -= checkqty;
            mssrow++;
            //if (mss.data.pickOperateSecondarySortingRFDTOS.Count == mssrow)
            //{
            //    this.Close();
            //    return;
            //}
            GetRow();
            ShowBody();
         
        }

        void GetRow()
        {
            bool bo = false;
            foreach (Model.pickOperateSecondarySortingRFDTOSs v in mss.data.pickOperateSecondarySortingRFDTOS)
            {
                if (v.pickQuantity > 0 || v.pickMinQuantity > 0)
                {
                    bo = true;
                    break;
                }
            }
            if (!bo)
            {
                this.Close();
                return;
            }
            while (true)
            {
                if (mss.data.pickOperateSecondarySortingRFDTOS.Count == mssrow)
                {
                    mssrow = 0;
                }
                if (mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity <= 0 && mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity <= 0)
                {
                    mssrow++;
                }
                else
                {
                    break;
                }
            }
        }

        void clear()
        {
            mq = null;
            this.txtcheckminqty.Text = "";
            this.txtcheckqty.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            //this.txttraycode.Text = "";
            this.txtcheckminqty.Enabled = false;
            this.labbatch.Text = "";
            this.labcheckqty.Text = "";
            this.labcommonUnit.Text = "";
            this.labmaterialname.Text = "";
            this.labminunit.Text = "";
            this.labpdata.Text = "";
            this.labqty.Text = "";
            sqty = 0;
            sminqty = 0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!txtcheckminqty.Enabled && !txtcheckqty.Enabled)
            {
                foreach (Control v in this.Controls)
                {
                    if (v is TextBox)
                    {
                        if (v.Enabled)
                            v.Focus();
                    }
                }
                return;
            }
            if (mssrow == mss.data.pickOperateSecondarySortingRFDTOS.Count - 1)
            {
               
                   
                    mssrow = 0;
                    ShowBody();
                    return;
               
            }
        
            
            mssrow++;
            GetRow();
            ShowBody();
            //if (this.labpdata.Text=="")
            //    return;
            //c++;
            //try
            //{
            //    checkSO();
            //}
            //catch (Exception)
            //{
            //    clear();
            //    return;
            //}
        }

        void checkSO()
        {
            int e = c;
            bool b = true;
            while(true)
            {
                if (mq.data.Count < c)
                {
                    c = 0;

                }
                if (!b)
                {
                    if (c == e)
                        throw new Exception("该单据下该托盘已经全部复核完毕");
                }
                if (mq.data.Count == c)
                {
                    c = 0;

                }
                if (string .IsNullOrEmpty(mq.data[c].scan))
                {
                    ShowTxt();
                    break;
                }
                c++;
                b = false;
               
            }
           
        }

        private void frmStockOutCheck_Load(object sender, EventArgs e)
        {
            if (mss.data.sortingType != 0)
            {
                this.btnchange.Visible = false;
            }
            this.lblpickno.Text = mss.data.pickNo;
            this.lbltraycode.Text = mss.data.trayCode;
            this.labqty.Text = mss.data.trayPickQuantity.ToString() + "箱" + mss.data.trayPickMinQuantity.ToString() + "个";
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
            //clear();
            //this.txtorderid.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnData_Click(object sender, EventArgs e)
        {
            //if (this.txttraycode.Enabled || this.txtorderid.Enabled)
            //    return;
            //if (mq == null)
            //{
            try
            {
                string x = HttpHelper.HttpPost("getQuantityListByTray", @"pickNo=" + this.lblpickno.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&toTrayCode=" + this.lbltraycode.Text);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mq = (Model.MQuantityListByTray)JsonConvert.DeserializeObject(x, typeof(Model.MQuantityListByTray));
                if (mq == null || mq.data == null)
                {
                    throw new Exception("MQuantityListByTray数据信息捕捉失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            //}
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
            foreach (Model.QuantityListByTrays v in mq.data)
            {
                //if (v.quantity == v.realQuantity && v.minQuantity == v.realMinquantity)
                //    continue;
                dr = dt.NewRow();
                dr["materialCode"] = v.materialCode;
                dr["materialName"] = v.materialName;
                if (!string.IsNullOrEmpty(v.pDate))
                {
                    dr["pdate"] = v.pDate;
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
                //dr["slName"] = v.slName;
                dr["slName"] = "";
                int _quantity = v.quantity;
                if (_quantity < 0)
                    _quantity = 0;
                int _minquantity = v.minQuantity;
                if (_minquantity < 0)
                    _minquantity = 0;
                dr["qty"] = _quantity.ToString() + v.commonUnitName + _minquantity.ToString() + v.minUnitName;
                dr["fromSlIdName"] = "";
                dr["toSlIdName"] = "";
                dr["trayCode"] = "";
                if (string.IsNullOrEmpty(v.pDate))
                {
                    v.pDate = "";
                }
                if (string.IsNullOrEmpty(v.batchNo))
                {
                    v.batchNo = "";
                }
                dt.Rows.Add(dr);
            }
            
            Ot.frmList frm = new Rf_Wms.Ot.frmList();
            frm.dt = dt;
            frm.txtname = "复核列表";
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

        private void txtcheckqty_GotFocus(object sender, EventArgs e)
        {
            //if (mq.data[c].checkQuantity == null)
            //{
            //    this.txtcheckqty.Text = "0";

            //}
            //else
            //{
            //    this.txtcheckqty.Text = mq.data[c].checkQuantity.ToString();
            //}
            this.txtcheckqty.SelectAll();
        }

        private void txtcheckminqty_GotFocus(object sender, EventArgs e)
        {
            //if (mq.data[c].checkMinQuantity == null)
            //{
            //    this.txtcheckminqty.Text = "0";

            //}
            //else
            //{
            //    this.txtcheckminqty.Text = mq.data[c].checkMinQuantity.ToString();
            //}
            this.txtcheckminqty.SelectAll();
        }

        private void txtcommonqty_GotFocus(object sender, EventArgs e)
        {
            this.txtcommonqty.SelectAll();
        }

        private void txtminqty_GotFocus(object sender, EventArgs e)
        {
            this.txtminqty.SelectAll();
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            frmNStockOut frm = new frmNStockOut();
            mss.data.sortingType = 1;
            frm.mss = mss;
            frm.isCheck = true;
            frm.ShowDialog();
            if(frm.isf)
            {
                this.Close();
                return;
            }
            mss.data.sortingType = 0;
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