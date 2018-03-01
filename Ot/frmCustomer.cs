using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Rf_Wms.Ot
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        Control co = null;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Model.MgetCustomersByLcCode m = null;
        public bool isRed=false;
        public Model.MgetCustomersByLcCodeBody customer = null;
        public string ccode = "";
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            Model.Mmsg msg = null;
            co = txtorderid;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getCustomersByLcCode", @"lcCode=" + Comm.lcCode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                m = (Model.MgetCustomersByLcCode)JsonConvert.DeserializeObject(x, typeof(Model.MgetCustomersByLcCode));
                if (m == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                if (m.data.Count == 0)
                {
                    throw new Exception("该账户对应的物流中心下没有仓库,请找相关人员调整");
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
               
            }
            this.dataGrid1.DataSource = m.data;
            Bind();
            #region 测试
           
            #endregion

            if (!isRed)
            {
                this.cmbordertype.DataSource = Comm.basein.data.normalStockInTypes;
            }
            else
            {
                this.cmbordertype.DataSource = Comm.basein.data.unNormalStockInTypes;
            }
            this.cmbordertype.DisplayMember = "description";
            this.cmbordertype.ValueMember = "code";

            this.cmbbusinessType.DataSource = Comm.basein.data.transportMethods;
            this.cmbbusinessType.DisplayMember = "des";
            this.cmbbusinessType.ValueMember = "code";
            //this.cmbbusinessType.SelectedIndex = 1;

            this.cmbordertype.Focus();
            this.cmbbusinessType.Enabled = false;
            this.txtorderid.Enabled = false;
            //this.btnOK.Enabled = false;
        }

        void Bind()
        {
            dataGrid1.TableStyles.Clear();
            DataGridTableStyle dts = new DataGridTableStyle();

            dts.MappingName = m.data.GetType().Name;

            DataGridTextBoxColumn dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "编码";
            dtbc.MappingName = "code";
            dtbc.Width = 120;
            dts.GridColumnStyles.Add(dtbc);

            dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "名称";
            dtbc.MappingName = "name";
            dtbc.Width = 110;
            dts.GridColumnStyles.Add(dtbc);

          

            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(dts);
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ischeck)
                return;
            int _int;
            _int = dataGrid1.CurrentCell.RowNumber;

            if (_int < 0)
                return;
            if (m != null)
            {
                if (_int > m.data.Count)
                    return;
                customer = m.data[_int];
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    getNewOrder(customer.code);
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
            this.Close();
           
        }

        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.txtorder.Enabled = true;
                this.txtorder.SelectAll();
                this.txtorder.Focus();
            }
            if (e.KeyChar != 13)
                return;
            this.txtorderid.Text = this.txtorderid.Text.ToUpper();
            if (this.txtorderid.Text == "")
            {
                MessageBox.Show("请输入货主号");
                return;
            }
            customer=m.data.Find(delegate(Model.MgetCustomersByLcCodeBody v) { return v.code == this.txtorderid.Text; });
            if (customer != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    getNewOrder(customer.code);
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    return;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("没有该货主编号");
                this.txtorderid.SelectAll();
                return;
            }
        }

        private void cmbordertype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (this.cmbordertype.Text == "")
            {
                MessageBox.Show("请选择业务类型");
                return;
            }
            //this.btnOK.Enabled = true;
            //this.cmbordertype.Enabled = false;
            //this.txtorderid.Enabled = true;
            //this.txtorder.Focus();
            this.cmbordertype.Enabled = false;
            this.cmbbusinessType.Enabled = true;
            this.cmbbusinessType.Focus();
        }

        private void cmbbusinessType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.cmbordertype.Enabled = true;
                this.cmbordertype.Focus();
                this.cmbbusinessType.Enabled = false;
            }
            if (e.KeyChar != 13)
                return;
            this.cmbbusinessType.Enabled = false;
            //this.btnOK.Enabled = true;
            this.cmbordertype.Enabled = false;
            this.txtorderid.Enabled = true;
            this.txtorder.Focus();
        }

        Model.Mmsg msg = null;
        void getNewOrder(string shippercode)
        {
            string con=@"shipperCode=" + shippercode + "&lcCode=" + Comm.lcCode + "&orderType=" + this.cmbordertype.SelectedValue.ToString() + "&whId=" + Comm.warehousecode + "&updater=" + Comm.usercode + "&oid=" + this.txtorder.Text;
             if (this.cmbbusinessType.Text != "")
            {
                con += "&transportMethods=" + this.cmbbusinessType.SelectedValue.ToString();
            }
            string x = HttpHelper.HttpPost("createStockInNoOrder", con);
           
            //msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            //if (msg == null)
            //    throw new Exception("错误信息捕捉失败");
            //if (!msg.success)
            //    throw new Exception(msg.msg);
            Model.Mccode m = (Model.Mccode)JsonConvert.DeserializeObject(x, typeof(Model.Mccode));
            if (m == null)
            {
                throw new Exception("数据信息捕捉失败");
            }
            if (m.data == "")
            {
                throw new Exception("没有该对应的单据");
            }

            ccode = m.data;

        }

        bool ischeck = false;
        private void dataGrid1_Click(object sender, EventArgs e)
        {
            int _int;
            _int = dataGrid1.CurrentCell.RowNumber;

            if (_int < 0)
                return;
            if (m != null)
            {
                if (_int > m.data.Count)
                    return;
                //customer = m.data[_int];
                this.txtorderid.Text = m.data[_int].code;
                ischeck = true;
            }
        }

        private void btnkeybord_Click(object sender, EventArgs e)
        {
            //RIL_IME.ShowIME("键盘");
            RIL_IME.ShowIME("Letter Recognizer");
            //foreach (Control v in this.Controls)
            //{
            //    if (v is TextBox)
            //    {
            //        if (v.Enabled)
            //            v.Focus();
            //    }
            //}
            co.Focus();
            (co as TextBox).SelectionStart = (co as TextBox).Text.Length;
        }

        private void txtorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                //this.cmbordertype.Enabled = true;
                //this.cmbordertype.Focus();
                this.cmbbusinessType.Enabled = true;
                this.cmbbusinessType.Focus();
            }
            if (e.KeyChar != 13)
                return;
            txtorderid.Enabled = true;
            this.txtorderid.Focus();
        }

        private void txtorder_GotFocus(object sender, EventArgs e)
        {
            co = txtorder;
        }

        private void txtorderid_GotFocus(object sender, EventArgs e)
        {
            co = txtorderid;
        }

        
    }
}