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
    public partial class frmBalBlnoSearch : Form
    {
        public frmBalBlnoSearch()
        {
            InitializeComponent();
        }

        public string tcod = "";
        public string materialCode = "";
        Model.Mmsg msg = null;
        private void frmBalBlnoSearch_Load(object sender, EventArgs e)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                string con = @"&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&materialCode=" + materialCode + "&tcod=" + tcod;
                //outletcode
                string x = HttpHelper.HttpPost("", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.MoutletInfo m = (Model.MoutletInfo)JsonConvert.DeserializeObject(x, typeof(Model.MoutletInfo));
                
                this.cbooutlet.DataSource = m.data;
                this.cbooutlet.ValueMember = "outletCode";
                this.cbooutlet.DisplayMember = "outletName";
                this.cbooutlet.SelectedItem = 1;

                con = @"&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&materialCode=" + materialCode + "&tcod=" + tcod;
                //outletcode
                x = HttpHelper.HttpPost("", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.MbalPickno mp = (Model.MbalPickno)JsonConvert.DeserializeObject(x, typeof(Model.MbalPickno));
                dataGrid2.TableStyles.Clear();
                DataGridTableStyle dts = new DataGridTableStyle();

                dts.MappingName = mp.data.GetType().Name;

                DataGridTextBoxColumn dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "拣货单号";
                dtbc.MappingName = "pickNo";
                dtbc.Width = 240;
                dts.GridColumnStyles.Add(dtbc);

                dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "备注";
                dtbc.MappingName = "des";
                dtbc.Width = 240;
                dts.GridColumnStyles.Add(dtbc);

                dataGrid2.TableStyles.Clear();
                dataGrid2.TableStyles.Add(dts);
                this.dataGrid2.DataSource = mp.data;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
        }

        Model.MbalBlno mbl = null;
        private void cbooutlet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                string con = @"&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode + "&materialCode=" + materialCode + "&tcod=" + tcod + "&outletCode="+this.cbooutlet.SelectedValue.ToString();
                //outletcode
                string x = HttpHelper.HttpPost("", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mbl = (Model.MbalBlno)JsonConvert.DeserializeObject(x, typeof(Model.MbalBlno));
                Cursor.Current = Cursors.Default;
                dataGrid1.TableStyles.Clear();
                DataGridTableStyle dts = new DataGridTableStyle();

                dts.MappingName = mbl.data.GetType().Name;

                DataGridTextBoxColumn dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "提单号";
                dtbc.MappingName = "blNo";
                dtbc.Width = 240;
                dts.GridColumnStyles.Add(dtbc);

                dataGrid1.TableStyles.Clear();
                dataGrid1.TableStyles.Add(dts);
                this.dataGrid1.DataSource = mbl.data;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);

                return;
            }
        }

        public string blNo = "";
        private void btnOK_Click(object sender, EventArgs e)
        {
            int _int;
            _int = dataGrid1.CurrentCell.RowNumber;

            if (_int < 0)
                return;
            if (mbl != null)
            {
                if (_int > mbl.data.Count)
                    return;
                blNo = mbl.data[_int].blNo;
            }
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}