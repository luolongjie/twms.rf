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
    public partial class frmStockOut : Form
    {
        public frmStockOut()
        {
            InitializeComponent();
        }

        bool bst = true;//提货单方式
        Model.Mmsg msg = null;
        int quantity = 0;
        int minquantity = 0;
        int spec = 0;
        public Model.MstartSecondarySorting mss;
        int mssrow = 0;
        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            //和复核一样的代码
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getSortingFlg", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode);
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
                this.txtorderid.SelectAll();
                return;

            }
            if (this.txtorderid.Text == "")
                return;
            this.txtorderid.Enabled = false;
            this.txttraycode.Enabled = true;
            this.txttraycode.Focus();
        }

       
        private void txttraycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txttraycode.Text = "";
                this.txttraycode.Enabled = false;
                this.txtorderid.Enabled = true;
                this.txtorderid.Text = "";
                this.txtorderid.Focus();
                return;
            }
            if (e.KeyChar != 13)
                return;
            if (this.txttraycode.Text == "")
            {
                MessageBox.Show("请扫描托盘条码");
                return;
            }
            //this.txttraycode.Text = this.txttraycode.Text.ToUpper();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                GetMultiMaterialList();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtorderid.SelectAll();
                return;

            }
          
            //MyShow();
            this.txttraycode.Enabled = false;
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }

        int commonqty = 0;
        int minqty = 0;
        int c = 0;//当前行号
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                //this.labtrayqty.Text = "";
                this.labsoqty.Text = "";
                this.labstockoutno.Text = "";
                this.labpickType.Text = "";
                this.txtcommonqty.Enabled = false;
                this.txttraycode.Enabled = true;
                this.txttraycode.SelectAll();
                //this.txtcommonqty.Text = "";
                this.txttraycode.Text = "";
                this.labbatch.Text = "";
                this.labcommonUnit.Text = "";
                //this.labcount.Text = "";
                this.labmaterialname.Text = "物料描述";
                this.labminunit.Text = "";
                this.labpdata.Text = "";
                this.labqty.Text = "";
                //this.labtoTrayCode.Text = "";
                //this.labtrayqty.Text="";
                //this.labstockOutNo.Text = "";
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
            if (bst)
            {
                if (mm.data[c].quantity < commonqty)
                {
                    MessageBox.Show("不能超托盘量复核");
                    this.txtcommonqty.SelectAll();
                    return;
                }
                if (st.data[d].orderQuantity < commonqty)
                {
                    MessageBox.Show("不能超送达方量复核");
                    this.txtcommonqty.SelectAll();
                    return;
                }
            }
            else
            {
                if (mm.data[0].pickType == "1")//按单
                {
                    if (mm.data[c].quantity - mm.data[c].sumRealQuantity < commonqty)
                    {
                        MessageBox.Show("不能超托盘量复核");
                        this.txtcommonqty.SelectAll();
                        return;
                    }
                }
                else
                {
                    if (mm.data[c].quantity < commonqty)
                    {
                        MessageBox.Show("不能超托盘量复核");
                        this.txtcommonqty.SelectAll();
                        return;
                    }
                }

                if (ms != null)
                {
                    if (ms.data[d].orderQuantity < commonqty)
                    {
                        MessageBox.Show("不能超出库单复核");
                        this.txtcommonqty.SelectAll();
                        return;
                    }
                }
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
                this.txtcommonqty.SelectAll();
                return;
            }
            if (bst)
            {
                if (mm.data[c].minQuantity < minqty)
                {
                    MessageBox.Show("不能超托盘量复核");
                    this.txtcommonqty.SelectAll();
                    return;
                }
                if (st.data[d].orderMinQuantity < minqty)
                {
                    MessageBox.Show("不能超送达方量复核");
                    this.txtcommonqty.SelectAll();
                    return;
                }
            }
            else
            {
                if (mm.data[0].pickType == "1")//按单
                {
                    if (mm.data[c].minQuantity - mm.data[c].sumRealMinQuantity < minqty)
                    {
                        MessageBox.Show("不能超托盘量复核");
                        this.txtcommonqty.SelectAll();
                        return;
                    }
                }
                else
                {
                    if (mm.data[c].minQuantity < minqty)
                    {
                        MessageBox.Show("不能超托盘量复核");
                        this.txtcommonqty.SelectAll();
                        return;
                    }
                }

                if (ms != null)
                {
                    if (ms.data[d].orderMinQuantity < minqty)
                    {
                        MessageBox.Show("不能超出库单复核");
                        this.txtcommonqty.SelectAll();
                        return;
                    }
                }
            }
           
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (bst)
                {
                    Savest();
                }
                else
                {
                    Saveso();
                }
                if (bst)//加上已操作数量
                {
                    mm.data[c].outletMinQuantity += minqty;
                    mm.data[c].outletQuantity += commonqty;
                }
                else if (mm.data[0].pickType == "1")//合并
                {
                    mm.data[c].sumRealMinQuantity += minqty;
                    mm.data[c].sumRealQuantity += commonqty;
                    mm.data[c].scan = "1";
                    if (ms != null)
                    {
                        ms.data[d].orderQuantity -= commonqty;
                        ms.data[d].orderMinQuantity -= minqty;
                    }
                }
                else
                {
                    mm.data[c].sumRealMinQuantity = minqty;
                    mm.data[c].sumRealQuantity = commonqty;
                }
                if (bst)
                {
                    this.labqty.Text = (mm.data[c].quantity - mm.data[c].outletQuantity).ToString() + mm.data[c].commonUnitName + (mm.data[c].minQuantity - mm.data[c].outletMinQuantity).ToString() + mm.data[c].minUnitName;
                }
                else
                {
                    if (mm.data[0].pickType == "1")//按单 add
                    {
                        this.labqty.Text = (mm.data[c].quantity - mm.data[c].sumRealQuantity).ToString() + mm.data[c].commonUnitName + (mm.data[c].minQuantity - mm.data[c].sumRealMinQuantity).ToString() + mm.data[c].minUnitName;
                    }
                    else
                    {
                        this.labqty.Text = (mm.data[c].quantity).ToString() + mm.data[c].commonUnitName + (mm.data[c].minQuantity).ToString() + mm.data[c].minUnitName;
                    }
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtminqty.SelectAll();
                return;

            }
            bool isfinish = true;
            if (bst)
            {
                foreach (Model.MultiMaterialLists v in mm.data)
                {
                    if (v.quantity <= v.outletQuantity || v.minQuantity <= v.outletMinQuantity)
                    {
                        isfinish = false;
                        break;
                    }
                }
            }
            else
            {
                foreach (Model.MultiMaterialLists v in mm.data)
                {
                    if (v.quantity <= v.sumRealQuantity || v.minQuantity <= v.sumRealMinQuantity)
                    {
                        isfinish = false;
                        break;
                    }
                }
            }
            if (isfinish)//整单完成
            {
                Clear();
                this.labstockoutno.Text = "";
                this.labsoqty.Text = "";
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                this.txtorderid.SelectAll();
                return;
            }
            this.labstockoutno.Text = "";
            this.labsoqty.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            if (bst)//送达方
            {
                if ((mm.data[c].quantity - mm.data[c].outletQuantity) == 0 && (mm.data[c].minQuantity - mm.data[c].outletMinQuantity) == 0)//当前托盘物料完成
                {
                    btnNext1_Click(null, null);
                    return;
                }
            }
            else//提单
            {
                if ((mm.data[c].quantity - mm.data[c].sumRealQuantity) == 0 && (mm.data[c].minQuantity - mm.data[c].sumRealMinQuantity) == 0)//当前托盘物料完成
                {
                    btnNext1_Click(null, null);
                    return;
                }
            }
            this.txtminqty.Enabled = false;
            if (bst)
            {
                if (st.data[d].orderQuantity != 0 || st.data[d].orderMinQuantity != 0)//本行没有操作完毕，显示
                {
                    showST();
                    this.txtcommonqty.Enabled = true;
                    this.txtcommonqty.Focus();
                    return;
                }
                if (st.data.Count - 1 != d)//不是最后一行，跳到下一个
                {
                    btnnext_Click_1(null, null);
                    this.txtcommonqty.Enabled = true;
                    this.txtcommonqty.Focus();
                    return;
                }
                foreach (Model.SendToItemLists v in st.data)//最后一个循环判断是不是已经全部操作完毕
                {
                    if (v.orderQuantity != 0 || v.orderMinQuantity !=0)
                    {
                        isfinish = false;
                        break;
                    }
                }
                if (!isfinish)//没有完毕，获得数据
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        GetSTList();
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(ex.Message);
                        return;
                    }
                   
                    this.txtcommonqty.Enabled = true;
                    this.txtcommonqty.Focus();
                    return;
                }
                btnNext1_Click(null, null);
                this.txtcommonqty.Enabled = true;
                this.txtcommonqty.Focus();
                return;
            }
            else
            {



                if (ms != null)
                {
                    isfinish = true;

                    foreach (Model.StockOutItems s in ms.data)
                    {
                        if (s.orderMinQuantity != 0 || s.orderQuantity != 0)
                        {
                            isfinish = false;
                            break;
                        }
                    }
                    
                    if (!isfinish)
                    {
                        btnnext_Click_1(null, null);
                        if (mm.data[0].pickType == "1")//按单
                        {
                            this.labqty.Text = (mm.data[c].quantity - mm.data[c].sumRealQuantity).ToString() + mm.data[c].commonUnitName + (mm.data[c].minQuantity - mm.data[c].sumRealMinQuantity).ToString() + mm.data[c].minUnitName;
                        }
                        else
                        {
                            this.labqty.Text = (mm.data[c].quantity).ToString() + mm.data[c].commonUnitName + (mm.data[c].minQuantity).ToString() + mm.data[c].minUnitName;
                        }
                    }
                    else
                    {
                        btnNext1_Click(null, null);
                    }

                }
                else
                {
                    btnNext1_Click(null, null);

                }
                this.txtminqty.SelectAll();
                    //this.txtminqty.Enabled = false;
                    //this.txtcommonqty.Enabled = true;
                    //this.txtcommonqty.Focus();
                
               
            }
            
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Saveso()
        {
            string conn = "";
            conn = @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&trayCode=" + this.txttraycode.Text + "&materialCode=" + mm.data[c].materialCode + "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&updater=" + Comm.usercode + "&id=" + mm.data[c].id + "&fromTrayCode=" + mm.data[c].fromTrayCode + "&toTrayCode=" + mm.data[c].toTrayCode + "&pickType="+mm.data[c].pickType;
            if (ms != null)
            {
                conn += "&stockOutNo=" + ms.data[d].stockOutNo + "&stockOutItemId=" + ms.data[d].stockOutItemId ;
                if (!string.IsNullOrEmpty(ms.data[d].stockOutDetailId))
                {
                    conn += "&stockOutDetailId=" + ms.data[d].stockOutDetailId;
                }
            }
            string x = HttpHelper.HttpPost("stockOutDetailSubmit", conn);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            if (ms != null)//取ID
            {
                Model.MStockOutItems mmm  = (Model.MStockOutItems)JsonConvert.DeserializeObject(x, typeof(Model.MStockOutItems));
                if (mmm == null || mmm.data == null)
                {
                    return;
                }
                ms.data[d].stockOutDetailId = mmm.data.stockOutDetailId;
            }
        }

        void Savest()
        {
            string conn = "";
            conn = @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&materialCode=" + mm.data[c].materialCode + "&quantity=" + commonqty.ToString() + "&minQuantity=" + minqty.ToString() + "&updater=" + Comm.usercode + "&id=" + mm.data[c].id + "&fromTrayCode=" + mm.data[c].fromTrayCode + "&toTrayCode=" + mm.data[c].toTrayCode + "&pickType=" + mm.data[c].pickType + "&sendToCode=" + st.data[d].sendToCode ;
            if (!string.IsNullOrEmpty(st.data[d].sendToDetailId))
            {
                conn += "&sendToDetailId=" + st.data[d].sendToDetailId;
            }
            string x = HttpHelper.HttpPost("sendToDetailSubmit", conn);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            //计算数量
            st.data[d].orderQuantity -= commonqty;
            st.data[d].orderMinQuantity -= minqty;
            Model.SendToOneItem mst = (Model.SendToOneItem)JsonConvert.DeserializeObject(x, typeof(Model.SendToOneItem));
            if (mst == null || mst.data == null)
            {
                return;
            }
          
            st.data[d].sendToDetailId = mst.data.sendToDetailId;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            if (this.txtorderid.Enabled)
                return;
            Model.MShowList mx = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("/getPickOperateList", @"lcCode=" + Comm.lcCode + "&pickNo=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode);
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
            this.txttraycode.Text = "";
           
            this.labcommonUnit.Text = "";
            //this.labcount.Text = "";
            this.labmaterialname.Text = "物料描述";
            this.labminunit.Text = "";
            this.labpdata.Text = "";
            this.labqty.Text = "";
            //this.labstockOutNo.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
            this.txtminqty.Enabled = false;
            //this.labtrayqty.Text = "";
            this.labbatch.Text = "";
            this.labpickType.Text = "";
            quantity = 0;
            minquantity = 0;
        }

        private void frmStockOut_Load(object sender, EventArgs e)
        {
            Clear();
            this.txttraycode.Enabled = false;
            this.txtcommonqty.Enabled = false;
            //this.txtminqty.Enabled = false;
            this.txtorderid.Focus();
            mssrow = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getSecondarySortingInfo", @"sortingType=" + mss.data.sortingType.ToString() + "&lcCode=" + Comm.lcCode + "&pickOperateId="+mss.data.pickOperateSecondarySortingRFDTOS[mssrow].pickOperateId);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                //v = (Model.MstartSecondarySorting)JsonConvert.DeserializeObject(x, typeof(Model.MstartSecondarySorting));
                //if (v == null)
                //{
                //    throw new Exception("数据信息捕捉失败");
                //}
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txttraycode.SelectAll();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.txttraycode.Enabled)
                return;
            if (ms == null || ms.data == null)
                return;
            c++;
            if (ms.data.Count <= c)
                c = 0;
            MyShow();
            this.txtcommonqty.Enabled = true;
            this.txtcommonqty.Focus();
        }

        Model.MultiMaterialList mm = null;
        //Model.MultiMaterialLists mm.data[c] = null;
        Model.MStockOutItem ms = null;
        Model.StockOutItems currentms = null;
        void GetMultiMaterialList()
        {
            string x = HttpHelper.HttpPost("getMultiMaterialList", @"lcCode=" + Comm.lcCode + "&pickNo=" + this.txtorderid.Text + "&whId=" + Comm.warehousecode + "&toTrayCode="+this.txttraycode.Text);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
            mm = (Model.MultiMaterialList)JsonConvert.DeserializeObject(x, typeof(Model.MultiMaterialList));
            if (mm == null)
            {
                throw new Exception("数据信息捕捉失败");
            }
            if (mm.data.Count == 0)
            {
                throw new Exception("该单据已经操作完成");
            }
            if (bst)//发送方
            {
                for (int i = mm.data.Count - 1; i >= 0; i--)
                {
                    if (mm.data[i].quantity - mm.data[i].outletQuantity <= 0 && mm.data[i].minQuantity - mm.data[i].outletMinQuantity <= 0)
                    {
                        mm.data.Remove(mm.data[i]);
                        //studentList.RemoveAt(i);
                    }
                }
            }
            else
            {
                for (int i = mm.data.Count - 1; i >= 0; i--)
                {
                    if (mm.data[i].quantity - mm.data[i].sumRealQuantity <= 0 && mm.data[i].minQuantity - mm.data[i].sumRealMinQuantity <= 0)
                    {
                        mm.data.Remove(mm.data[i]);
                        //studentList.RemoveAt(i);
                    }
                }
            }
            if (mm.data.Count == 0)
            {
                Clear();
                this.labsoqty.Text = "";
                this.labstockoutno.Text = "";
                this.txttraycode.Text = "";
                this.txtorderid.Enabled = true;
                this.txtorderid.Focus();
                throw new Exception("当前托盘的物料已分拣完成！");
            }
            c = 0;
            GetSOIList();
            //checkMul();
            MyShow();
        }

        void checkMul()
        {
            if (mm.data.Count == c)
            {
                GetMultiMaterialList();
                return;

            }
            
            GetSOIList();

            MyShow();
        }

        void GetSOIList()
        {
            if (bst)
            {
                GetSTList();
            }
            else
            {
                if (mm.data[c].pickType == "1")
                {
                    string x = HttpHelper.HttpPost("getStockOutItemList", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&id=" + mm.data[c].id);
                    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                    if (msg == null)
                        throw new Exception("错误信息捕捉失败");
                    if (!msg.success)
                        throw new Exception(msg.msg);
                    ms = (Model.MStockOutItem)JsonConvert.DeserializeObject(x, typeof(Model.MStockOutItem));
                    if (ms == null || ms.data == null)
                    {
                        throw new Exception("数据信息捕捉失败");
                    }
                    if (ms.data.Count == 0)
                    {
                        throw new Exception("该单据1已经操作完成");
                    }
                    d = 0;
                    checkStockOut();
                }
            }
        }

        Model.SendToItemList st = null;
        void GetSTList()
        {

            string x = HttpHelper.HttpPost("getSendToItemList", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&id=" + mm.data[c].id);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                st = (Model.SendToItemList)JsonConvert.DeserializeObject(x, typeof(Model.SendToItemList));
                if (st == null || st.data == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (st.data.Count == 0)
                {
                    throw new Exception("该单据2已经操作完成");
                }
                d = 0;
                //checkStockOut();
                showST();
            
        }

        void showST()
        {
            if (st.data.Count == d)
            {
                string x = HttpHelper.HttpPost("getSendToItemList", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&id=" + mm.data[c].id);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                st = (Model.SendToItemList)JsonConvert.DeserializeObject(x, typeof(Model.SendToItemList));
                if (st == null || st.data == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (st.data.Count == 0)
                {
                    throw new Exception("该单据2已经操作完成");
                }
                d = 0;

            }
            //this.labstockoutno.Location = new System.Drawing.Point(3, 198);
            //this.labstockoutno.Size = new System.Drawing.Size(220, 16);
            this.labstockoutno.Location = new System.Drawing.Point(3, 174);
            this.labstockoutno.Size = new System.Drawing.Size(220, 40);
            this.labstockoutno.Text = "送达方   " +st.data[d].sendToName;
            this.labsoqty.Text = "当前单据操作 " + (st.data[d].orderQuantity).ToString() + mm.data[c].commonUnitName + (st.data[d].orderMinQuantity).ToString() + mm.data[c].minUnitName;
        }

        int d = 0;
        void checkStockOut()
        {
            //int mi = -2;
            if (ms.data.Count == d)
            {
                string x = HttpHelper.HttpPost("getStockOutItemList", @"pickNo=" + this.txtorderid.Text + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&id=" + mm.data[c].id);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                ms = (Model.MStockOutItem)JsonConvert.DeserializeObject(x, typeof(Model.MStockOutItem));
                if (ms == null || ms.data == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (ms.data.Count == 0)
                {
                    throw new Exception("该单据1已经操作完成");
                }
                d = 0;

            }
            this.labstockoutno.Location = new System.Drawing.Point(3, 198);
            this.labstockoutno.Size = new System.Drawing.Size(220, 16);
            this.labstockoutno.Text = "提单号    " + ms.data[d].blNo;
            this.labsoqty.Text = "当前单据操作:" + (ms.data[d].orderQuantity).ToString() + mm.data[c].commonUnitName + (ms.data[d].orderMinQuantity).ToString() + mm.data[c].minUnitName;
                   
        }

        void MyShow()
        {
            //if (mm.data[c]!=null)
            this.labmaterialname.Text = "物料描述  "+mm.data[c].materialName;
            this.labpdata.Text = mm.data[c].pDate;
            this.labbatch.Text = mm.data[c].batchNo;
            //this.labcount.Text = "一共" + ms.data.Count.ToString() + "单";
            //this.labqty.Text = (ms.data[c].orderQuantity-ms.data[c].sumRealMinQuantity).ToString() + ms.data[c].commonUnitName + (ms.data[c].orderMinQuantity-ms.data[c].sumRealMinQuantity).ToString() + ms.data[c].minUnitName;
            if (bst)
            {
                this.labqty.Text = (mm.data[c].quantity - mm.data[c].outletQuantity).ToString() + mm.data[c].commonUnitName + (mm.data[c].minQuantity - mm.data[c].outletMinQuantity).ToString() + mm.data[c].minUnitName;
            }
            else if (mm.data[0].pickType == "1")//按单
            {
                this.labqty.Text = (mm.data[c].quantity - mm.data[c].sumRealQuantity).ToString() + mm.data[c].commonUnitName + (mm.data[c].minQuantity - mm.data[c].sumRealMinQuantity).ToString() + mm.data[c].minUnitName;
            }
            else
            {
                this.labqty.Text = (mm.data[c].quantity).ToString() + mm.data[c].commonUnitName + (mm.data[c].minQuantity).ToString() + mm.data[c].minUnitName;
            }
            //this.labstockOutNo.Text = ms.data[c].stockOutNo;
            this.labcommonUnit.Text = mm.data[c].commonUnitName;
            this.labminunit.Text = mm.data[c].minUnitName;
            if (mm.data[c].pickType == "1")
            {
                this.labpickType.Text = "合并";
            }
            else if (mm.data[c].pickType == "0")
            {
                this.labpickType.Text = "按单";
            }
            else
            {
                this.labpickType.Text = "手工";
            }
            //this.txtcommonqty.Text = mm.data[c].quantity.ToString();
            //this.txtminqty.Text = mm.data[c].minQuantity.ToString();
            //this.txtminqty.Enabled = true;

            this.txtminqty.Text = "";
            this.txtcommonqty.Text = "";

            this.txtminqty.Enabled = false;
            
        }

        private void btnnext_Click_1(object sender, EventArgs e)
        {
            if (this.txttraycode.Enabled || this.txtorderid.Enabled)
                return;
            try
            {
                if (bst)
                {
                    if (st != null)
                    {
                        d++;
                        showST();
                    }
                }
                else
                {
                    if (ms != null)
                    {
                        d++;
                        checkStockOut();
                    }
                }
                //else if (mm != null)
                //{
                //    c++;
                //    checkMul();
                //}
                this.txtcommonqty.Enabled = true;
                this.txtcommonqty.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
          
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            if (this.txttraycode.Enabled || this.txtorderid.Enabled)
                return;
            this.labsoqty.Text = "";
            this.labstockoutno.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (mm != null || st!=null)
                {
                    c++;
                    checkMul();
                }
                Cursor.Current = Cursors.Default;
                this.txtcommonqty.Enabled = true;

                this.txtcommonqty.Focus();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            bst = !bst;
            if (bst)
            {
                this.btnchange.Text = "提单";
            }
            else
            {
                this.btnchange.Text = "送达";
            }
            if (this.txttraycode.Enabled || this.txtorderid.Enabled)
                return;
            if (bst)//发送方
            {
                for (int i = mm.data.Count - 1; i >= 0; i--)
                {
                    if (mm.data[i].quantity - mm.data[i].outletQuantity <= 0 && mm.data[i].minQuantity - mm.data[i].outletMinQuantity <= 0)
                    {
                        mm.data.Remove(mm.data[i]);
                        //studentList.RemoveAt(i);
                    }
                }
            }
            else
            {
                for (int i = mm.data.Count - 1; i >= 0; i--)
                {
                    if (mm.data[i].quantity - mm.data[i].sumRealQuantity <= 0 && mm.data[i].minQuantity - mm.data[i].sumRealMinQuantity <= 0)
                    {
                        mm.data.Remove(mm.data[i]);
                        //studentList.RemoveAt(i);
                    }
                }
            }
            if (mm.data.Count == 0 || c>=mm.data.Count)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    GetMultiMaterialList();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }
                
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetSOIList();

                MyShow();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

       
    }
}