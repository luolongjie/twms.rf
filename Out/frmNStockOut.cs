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
    public partial class frmNStockOut : Form
    {
        public frmNStockOut()
        {
            InitializeComponent();
        }

        Model.Mmsg msg = null;
        public Model.MstartSecondarySorting mss;
        int mssrow = 0;
        public bool isCheck = false;
        bool isqie = false;
       
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void btnData_Click(object sender, EventArgs e)
        {
            //if (this.txtorderid.Enabled)
            //    return;
            Model.MShowList mx = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("/getPickOperateList", @"lcCode=" + Comm.lcCode + "&pickNo=" + this.lblpickno.Text + "&whId=" + Comm.warehousecode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mx = (Model.MShowList)JsonConvert.DeserializeObject(x, typeof(Model.MShowList));
                if (mx == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (mx.data.Count == 0)
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
            //DataTable dt = Comm.GetDT(mx.data);
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
            foreach (Model.material v in mx.data)
            {
                //if (v.quantity == v.realQuantity && v.minQuantity == v.realMinquantity)
                //    continue;
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
                if (string.IsNullOrEmpty(v.pdate))
                {
                    v.pdate = "";
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

        void Clear()
        {
            //this.txttraycode.Text = "";
           
            //this.labcommonUnit.Text = "";
            ////this.labcount.Text = "";
            //this.labmaterialname.Text = "物料描述";
            //this.labminunit.Text = "";
            //this.labpdata.Text = "";
            //this.labqty.Text = "";
            ////this.labstockOutNo.Text = "";
            //this.txtcommonqty.Text = "";
            //this.txtminqty.Text = "";
            //this.txtminqty.Enabled = false;
            ////this.labtrayqty.Text = "";
            //this.labbatch.Text = "";
            //this.labpickType.Text = "";
            //quantity = 0;
            //minquantity = 0;
        }

        void ShowHead()
        {
            this.lblpickno.Text = mss.data.pickNo;
            this.lbltraycode.Text = mss.data.trayCode;
            this.labmaterialname.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].materialCode + " " + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].materialName;
            this.labpdata.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pDate;
            this.labbatch.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].batchNo;
            this.labcommonUnit.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].commonUnitName;
            this.labminunit.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].minUnitName;
            if (!isqie)
            {
                this.labqty.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].commonUnitName + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].minUnitName;
            }
            else
            {
                this.labqty.Text = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderQuantity + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].commonUnitName + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderMinQuantity + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].minUnitName;
            }
        }

        void getSecondarySortingInfo()
        {
            string x = HttpHelper.HttpPost("getSecondarySortingInfo", @"sortingType=" + mss.data.sortingType.ToString() + "&lcCode=" + Comm.lcCode + "&pickOperateId=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOperateId);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            msec = (Model.MgetSecondarySortingInfo)JsonConvert.DeserializeObject(x, typeof(Model.MgetSecondarySortingInfo));
            if (msec == null)
            {
                throw new Exception("数据信息捕捉失败");
            }
            secrow = 0;
        }

        void ShowBody()
        {
            if (mss.data.sortingType == 1)
            {
                this.labtype.Text = "提单号";
                this.labpickType.Text = msec.data[secrow].blNo;
                this.labstockoutno.Text = "出库单号    "+msec.data[secrow].stockOutNo;
            }
            if (mss.data.sortingType == 2)
            {
                this.labtype.Text = "车辆信息";
                this.labpickType.Text = msec.data[secrow].plateNo + " " + msec.data[secrow].trainFrequency;
                this.labstockoutno.Text = msec.data[secrow].platePlan;
               
            }
            if (mss.data.sortingType == 3)
            {
                this.labtype.Text = "";
                this.labpickType.Text = "";
                this.labstockoutno.Location = new System.Drawing.Point(3, 174);
                this.labstockoutno.Size = new System.Drawing.Size(220, 40);
                this.labstockoutno.Text = "送达方  " + msec.data[secrow].sendToName;
            }
            else
            {
                this.labstockoutno.Location = new System.Drawing.Point(3, 198);
                this.labstockoutno.Size = new System.Drawing.Size(220, 16);
            }
            this.labsoqty.Text = "未分拣数量 " + msec.data[secrow].pickQuantity + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].commonUnitName + msec.data[secrow].pickMinQuantity + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].minUnitName;
        }

        Model.MgetSecondarySortingInfo msec = null;
        int secrow = 0;
        int orgsortingType = 0;
        private void frmStockOut_Load(object sender, EventArgs e)
        {
            if (sender != null)
                orgsortingType = (int)mss.data.sortingType;
            //this.txtcommonqty.Enabled = false;
            if(orgsortingType==1)
            {
                this.btnchange.Visible = false;
            }
            if (mss.data.sortingType == 1 )
            {
                this.Text = "出库单";
               
            }
            if (mss.data.sortingType == 2)
            {
                this.Text = "车辆";
            }
            if (mss.data.sortingType == 3)
            {
                this.Text = "送达方";
            }
            if (isCheck)
            {
                isqie = true;
                this.btnchange.Visible = true;
                this.btnchange.Text = "复核";
            }
            mssrow = 0;
            while (true)
            {
                int cqty = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity;
                int mqty = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity;
                if (isqie)
                {
                    cqty = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderQuantity;
                    mqty = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderMinQuantity;
                }
                if (cqty == 0 && mqty == 0)
                    mssrow++;
                else
                {
                    break;
                }
                if (mssrow == mss.data.pickOperateSecondarySortingRFDTOS.Count)
                {
                    MessageBox.Show("该托盘物料已全部分拣！");
                    this.Close();
                    return;
                }
            }
            ShowHead();
            //this.txtminqty.Enabled = false;
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                getSecondarySortingInfo();
                Cursor.Current = Cursors.Default;
                
                ShowBody();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                //this.txttraycode.SelectAll();
                return;

            }
            Init();
            //this.txtcommonqty.Enabled = true;
            //this.txtcommonqty.Focus();
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

      

        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (this.txttraycode.Enabled)
            //    return;
            //if (ms == null || ms.data == null)
            //    return;
            //c++;
            //if (ms.data.Count <= c)
            //    c = 0;
            //MyShow();
            //this.txtcommonqty.Enabled = true;
            //this.txtcommonqty.Focus();
        }

        void Init()
        {
            commonqty = 0;
            minqty = 0;
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            this.txtminqty.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }
     
        private void btnnext_Click_1(object sender, EventArgs e)
        {
            if (secrow == msec.data.Count-1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    getSecondarySortingInfo();


                    Cursor.Current = Cursors.Default;
                    ShowHead();
                    ShowBody();
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    //this.txttraycode.SelectAll();
                    return;

                }
                Init();
                return;
            }
            secrow++;
            ShowHead();
            ShowBody();
            Init();
          
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            int i = (int)mss.data.sortingType;
            if (mssrow == mss.data.pickOperateSecondarySortingRFDTOS.Count-1)
            {
                try
                {
                    string x = HttpHelper.HttpPost("startSecondarySorting", @"trayCode=" + mss.data.trayCode + "&lcCode=" + Comm.lcCode+"&whId=" + Comm.warehousecode);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    mss = (Model.MstartSecondarySorting)JsonConvert.DeserializeObject(x, typeof(Model.MstartSecondarySorting));
                    if (mss == null)
                    {
                        throw new Exception("数据信息捕捉失败");
                    }
                    mss.data.sortingType = i;
                    //this.labstockUpConfirmMsg.Text = v.data.stockUpConfirmMsg;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                    return;

                }
                frmStockOut_Load(null, null);
                return;
            }
            mssrow++;
            while (true)
            {
                int cqty =  mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity;
                int mqty = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity;
                if (isqie)
                {
                    cqty = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderQuantity;
                    mqty = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderMinQuantity;
                }
                if (cqty == 0 && mqty == 0)
                    mssrow++;
                else
                {
                    break;
                }
                if (mssrow == mss.data.pickOperateSecondarySortingRFDTOS.Count)
                {
                    try
                    {
                        string x = HttpHelper.HttpPost("startSecondarySorting", @"trayCode=" + mss.data.trayCode + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
                        msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                        if (msg == null)
                            throw new Exception("错误信息捕捉失败");
                        if (!msg.success)
                            throw new Exception(msg.msg);
                        mss = (Model.MstartSecondarySorting)JsonConvert.DeserializeObject(x, typeof(Model.MstartSecondarySorting));
                        if (mss == null)
                        {
                            throw new Exception("数据信息捕捉失败");
                        }
                        mss.data.sortingType = i;
                        //this.labstockUpConfirmMsg.Text = v.data.stockUpConfirmMsg;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        return;

                    }
                    frmStockOut_Load(null, null);
                    return;
                }
            }
            ShowHead();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                getSecondarySortingInfo();
                Cursor.Current = Cursors.Default;
                ShowBody();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                //this.txttraycode.SelectAll();
                return;

            }
            Init();
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            if (isCheck)
            {
                this.Close();
                return;
            }
            if (orgsortingType == 2)
            {
                if (mss.data.sortingType == 1)
                {
                    
                    this.btnchange.Text = "提单";
                    mss.data.sortingType = 2;
                }
                else
                {
                    
                    this.btnchange.Text = "车辆";
                    mss.data.sortingType = 1;
                }
            }
            else
            {
                if (mss.data.sortingType == 1)
                {
                    this.btnchange.Text = "提单";
                    mss.data.sortingType = 3;
                }
                else
                {
                    this.btnchange.Text = "送达";
                    mss.data.sortingType = 1;
                }
            }
            isqie = !isqie;
            frmStockOut_Load(null, null);
        }

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
            int mq = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity;
            if (isqie)
            {
               mq= mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderQuantity;
            }
            if (mq < commonqty)
            {
                MessageBox.Show("不能超托盘量复核");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (msec.data[secrow].pickQuantity < commonqty)
            {
                MessageBox.Show("不能超量复核");
                this.txtcommonqty.SelectAll();
                return;
            }
            
            


            this.txtcommonqty.Enabled = false;
            this.txtminqty.Enabled = true;
            this.txtminqty.Focus();
        }

        public bool isf=false;
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
            int mq = mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity;
            if (isqie)
            {
                mq=mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderMinQuantity;
            }
            if (mq < minqty)
            {
                MessageBox.Show("不能超托盘量复核");
                this.txtcommonqty.SelectAll();
                return;
            }
            if (msec.data[secrow].pickMinQuantity < minqty)
            {
                MessageBox.Show("不能超量复核");
                this.txtcommonqty.SelectAll();
                return;
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
                this.txtminqty.SelectAll();
                return;
            }
            msec.data[secrow].pickMinQuantity -= minqty;
            msec.data[secrow].pickQuantity -= commonqty;
            if (!isqie)
            {
                mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity -= minqty;
                mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity -= commonqty;
            }
            else
            {
                mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderMinQuantity -= minqty;
                mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderQuantity -= commonqty;
            }

            bool isfinish = true;
            if (!isqie)
            {
                foreach (Model.pickOperateSecondarySortingRFDTOSs v in mss.data.pickOperateSecondarySortingRFDTOS)
                {
                    if (v.pickQuantity > 0 || v.pickMinQuantity > 0)
                    {
                        isfinish = false;
                        break;
                    }
                }
            }
            else
            {
                foreach (Model.pickOperateSecondarySortingRFDTOSs v in mss.data.pickOperateSecondarySortingRFDTOS)
                {
                    if (v.pickOrderQuantity > 0 || v.pickOrderMinQuantity > 0)
                    {
                        isfinish = false;
                        break;
                    }
                }
            }
            if (isfinish)
            {
                isf = true;
                this.Close();
                return;
            }
            if (!isqie)
            {
                if (mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickMinQuantity <= 0 && mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickQuantity <= 0)
                {
                    btnNext1_Click(null, null);
                    return;
                }
            }
            else
            {
                if (mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderMinQuantity <= 0 && mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOrderQuantity <= 0)
                {
                    btnNext1_Click(null, null);
                    return;
                }
            }
            if (msec.data[secrow].pickQuantity <= 0 && msec.data[secrow].pickMinQuantity <= 0)
            {
                btnnext_Click_1(null, null);
               
                return;
            }
            ShowHead();
            ShowBody();
            Init();
            
        }

        void Save()
        {
            string conn = @"pickNo=" + mss.data.pickNo + "&lcCode=" + Comm.lcCode + "&checkQuantity=" + commonqty.ToString() + "&checkMinQuantity=" + minqty.ToString() + "&updater=" + Comm.usercode + "&trayCode=" + mss.data.trayCode + "&sortingType=" + mss.data.sortingType + "&pickType=" + mss.data.pickType + "&checkType=" + mss.data.checkType;
            conn += "&pickOperateId=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOperateId + "&fromTrayCode=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].fromTrayCode + "&toTrayCode=" + mss.data.pickOperateSecondarySortingRFDTOS[mssrow].toTrayCode;
            if (mss.data.sortingType == 1)
            {
                conn += "&stockOutNo=" + msec.data[secrow].stockOutNo + "&stockOutItemId=" + msec.data[secrow].stockOutItemId;
            }
            if (mss.data.sortingType == 2)
            {
                conn += "&plateNo=" + msec.data[secrow].plateNo + "&trainFrequency=" + msec.data[secrow].trainFrequency + "&platePlan=" + msec.data[secrow].platePlan;
            }
            if (mss.data.sortingType == 3)
            {
                conn += "&sendToCode=" + msec.data[secrow].sendToCode + "&sendToName=" + msec.data[secrow].sendToName;
            }
            string x = HttpHelper.HttpPost("doSecondarySorting", conn);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            Model.Mccode c = (Model.Mccode)JsonConvert.DeserializeObject(x, typeof(Model.Mccode));
            if (!string.IsNullOrEmpty(c.data))
            {
                MessageBox.Show(c.data);
            }
        }
    }
}