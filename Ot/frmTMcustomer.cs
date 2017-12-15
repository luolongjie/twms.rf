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
    public partial class frmTMcustomer : Form
    {
        public frmTMcustomer()
        {
            InitializeComponent();
        }

        private void frmTMcustomer_Load(object sender, EventArgs e)
        {
            Model.Mmsg msg = null;

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
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtorderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            this.txtorderid.Text = this.txtorderid.Text.ToUpper();
            customer = m.data.Find(delegate(Model.MgetCustomersByLcCodeBody v) { return v.code == this.txtorderid.Text; });
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
                MessageBox.Show("没有改货主编号");
                this.txtorderid.SelectAll();
                return;
            }
        }

        Model.Mmsg msg = null;
        Model.MgetCustomersByLcCode m = null;
       
        public Model.MgetCustomersByLcCodeBody customer = null;
        public string ccode = "";
        void getNewOrder(string shippercode)
        {

            string x = HttpHelper.HttpPost("createNoOrderTransfer", @"shipperCode=" + shippercode + "&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&updater=" + Comm.usercode);
            msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
            if (msg == null)
                throw new Exception("错误信息捕捉失败");
            if (!msg.success)
                throw new Exception(msg.msg);
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
    }
}