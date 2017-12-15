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
    public partial class frmNStockOutMaterial : Form
    {
        public frmNStockOutMaterial()
        {
            InitializeComponent();
        }

        Model.Mmaterialcodebody materialbody = null;
        Model.Mmaterialcode m = null;
        Model.pickOperateSecondarySortingRFDTOSs pickdetails = null;
        public Model.MstartSecondarySorting mss;
        Model.Mmsg msg = null;
        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar != 13)
                return;
            if (string.IsNullOrEmpty(this.txtbarcode.Text))
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
                this.txtbarcode.SelectAll();
                MessageBox.Show(ex.Message);
                return;

            }
            for (int i = m.data.Count - 1; i >= 0; i--)
            {
                bool ih = false;
                foreach (Model.pickOperateSecondarySortingRFDTOSs v in mss.data.pickOperateSecondarySortingRFDTOS)
                {
                    if (v.materialCode== m.data[i].code)
                    {
                        ih = true;
                        break;
                    }
                }
                if (!ih)
                {
                    m.data.RemoveAt(i);
                }
            }
            if (m.data.Count > 1)
            {
                Ot.frmMaterial frm = new Rf_Wms.Ot.frmMaterial();
                frm.m = m;
                frm.ShowDialog();
                if (frm.mbody != null)
                {
                    materialbody = frm.mbody;
                }
                else
                {
                    //MessageBox.Show("请选择商品");
                    this.txtbarcode.Focus();
                    this.txtbarcode.SelectAll();
                    return;
                }
            }
            else if (m.data.Count == 0)
            {
                MessageBox.Show("单据中不存在该条码的信息");
                this.txtbarcode.Text = "";
                return;
            }
            else
            {
                materialbody = m.data[0];
            }
            foreach (Model.pickOperateSecondarySortingRFDTOSs v in mss.data.pickOperateSecondarySortingRFDTOS)
            {
                if (v.materialCode == materialbody.code)
                {
                    pickdetails = v;
                    break;
                }
            }
            ShowTxt();
            this.txtcommonqty.Enabled = true;
            this.txtbarcode.Enabled = false;
            this.txtcommonqty.Focus();
        }

        void ShowTxt()
        {
            this.lblpickno.Text = mss.data.pickNo;
            this.lbltraycode.Text = mss.data.trayCode;
            this.labmaterialname.Text = pickdetails.materialCode + " " + pickdetails.materialName;
            //this.labpdata.Text = pickdetails.pDate;
            //this.labbatch.Text = pickdetails.batchNo;
            this.labcommonUnit.Text = pickdetails.commonUnitName;
            this.labminunit.Text = pickdetails.minUnitName;
            this.labqty.Text = pickdetails.pickQuantity + pickdetails.commonUnitName + pickdetails.pickMinQuantity + pickdetails.minUnitName;
            this.labcheckqty.Text = pickdetails.checkQuantity + pickdetails.commonUnitName + pickdetails.checkMinQuantity + pickdetails.minUnitName;
            
        
        }

        void Clear()
        {
            this.lblpickno.Text = "";
            this.lbltraycode.Text = "";
            this.labmaterialname.Text = "";
            this.labcommonUnit.Text = "";
            this.labminunit.Text = "";
            this.labqty.Text = "";
            this.labcheckqty.Text = "";
            this.txtcommonqty.Text = "";
            this.txtminqty.Text = "";
        }

        private void frmNStockOutMaterial_Load(object sender, EventArgs e)
        {
            Clear();
            this.txtbarcode.Focus();
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

        int commonqty = 0;
        int minqty = 0;
        private void txtcommonqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                Clear();
                this.txtcommonqty.Enabled = false;
                this.txtbarcode.Enabled = true;
                this.txtbarcode.Focus();
                this.txtbarcode.SelectAll();
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
            int mq = pickdetails.pickQuantity;
            
            if (mq < commonqty)
            {
                MessageBox.Show("不能超托盘量复核");
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
                this.txtcommonqty.SelectAll();
                return;
            }
            int mq = pickdetails.pickMinQuantity;
         
            if (mq < minqty)
            {
                MessageBox.Show("不能超托盘量复核");
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
            pickdetails.checkQuantity = commonqty;
            pickdetails.checkMinQuantity = minqty;
            bool bo = true;
            foreach (Model.pickOperateSecondarySortingRFDTOSs v in mss.data.pickOperateSecondarySortingRFDTOS)
            {
                if (v.checkQuantity != v.pickQuantity || v.pickMinQuantity != v.checkMinQuantity)
                {
                    bo = false;
                    break;
                }
            }
            if (bo)
            {
                this.Close();
                return;
            }
            Clear();
            this.txtbarcode.Text = "";
            this.txtbarcode.Enabled = true;
            this.txtbarcode.Focus();
            this.txtbarcode.SelectAll();
        }

        void Save()
        {
            string conn = @"pickNo=" + mss.data.pickNo + "&lcCode=" + Comm.lcCode + "&checkQuantity=" + commonqty.ToString() + "&checkMinQuantity=" + minqty.ToString() + "&updater=" + Comm.usercode + "&trayCode=" + mss.data.trayCode + "&sortingType=" + mss.data.sortingType + "&pickType=" + mss.data.pickType + "&checkType=" + mss.data.checkType + "&materialCode="+pickdetails.materialCode;
           

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

        private void btnData_Click(object sender, EventArgs e)
        {
            //if (this.txtorderid.Enabled)
            //    return;
            //Model.MShowList mx = null;
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    string x = HttpHelper.HttpPost("/getPickOperateList", @"lcCode=" + Comm.lcCode + "&pickNo=" + mss.data.pickNo + "&whId=" + Comm.warehousecode);
            //    msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //    if (msg == null)
            //        throw new Exception("错误信息捕捉失败");
            //    if (!msg.success)
            //        throw new Exception(msg.msg);
            //    mx = (Model.MShowList)JsonConvert.DeserializeObject(x, typeof(Model.MShowList));
            //    if (mx == null)
            //    {
            //        throw new Exception("数据信息捕捉失败");
            //    }
            //    if (mx.data.Count == 0)
            //    {
            //        throw new Exception("该单据已经操作完成");
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor.Current = Cursors.Default;
            //    MessageBox.Show(ex.Message);
            //    return;

            //}
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
            dt.Columns.Add("checkqty");
            DataRow dr;
            //foreach (Model.material v in mx.data)
            foreach (Model.pickOperateSecondarySortingRFDTOSs v in mss.data.pickOperateSecondarySortingRFDTOS)
            {
                //if (v.quantity == v.realQuantity && v.minQuantity == v.realMinquantity)
                //    continue;
                dr = dt.NewRow();
                dr["materialCode"] = v.materialCode;
                dr["materialName"] = v.materialName;

                dr["pdate"] = "";


                dr["batchNo"] = "";
                
                dr["slName"] = "";
                int _quantity = v.pickQuantity;
                if (_quantity < 0)
                    _quantity = 0;
                int _minquantity = v.pickMinQuantity;
                if (_minquantity < 0)
                    _minquantity = 0;
                dr["qty"] = _quantity.ToString() + v.commonUnitName + _minquantity.ToString() + v.minUnitName;
                dr["checkqty"] = v.checkQuantity + v.commonUnitName + v.checkMinQuantity.ToString() + v.minUnitName;
                dr["fromSlIdName"] = "";
                dr["toSlIdName"] = "";
                dr["trayCode"] = "";
                
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
       
    }
}