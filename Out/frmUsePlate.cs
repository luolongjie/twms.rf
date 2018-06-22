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
    public partial class frmUsePlate : Form
    {
        public frmUsePlate()
        {
            InitializeComponent();
        }

        bool ischeck = false;
        private void dataGrid1_Click(object sender, EventArgs e)
        {
            int _int;
            _int = dataGrid1.CurrentCell.RowNumber;

            if (_int < 0)
                return;

            //if (_int > m.data.Count)
            //    return;
            ischeck = true;
            
        }

        Model.Mmsg msg = null;
        Model.MUsePlate m = null;
        private void frmUsePlate_Load(object sender, EventArgs e)
        {
            Init();
        }

        void Init()
        {
            m = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string con = @"&lcCode=" + Comm.lcCode + "&whId=" + Comm.warehousecode;
                string x = HttpHelper.HttpPost("", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                m = (Model.MUsePlate)JsonConvert.DeserializeObject(x, typeof(Model.MUsePlate));
                if (m == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                //if (m.data == "")
                //{
                //    throw new Exception("没有车辆信息");
                //}
                Cursor.Current = Cursors.Default;
                this.dataGrid1.DataSource = m.data;
                Bind();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void Bind()
        {
            dataGrid1.TableStyles.Clear();
            DataGridTableStyle dts = new DataGridTableStyle();

            dts.MappingName = m.data.GetType().Name;

            DataGridTextBoxColumn dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "车辆";
            dtbc.MappingName = "plateNo";
            dtbc.Width = 120;
            dts.GridColumnStyles.Add(dtbc);

            dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "运单号";
            dtbc.MappingName = "tcod";
            dtbc.Width = 110;
            dts.GridColumnStyles.Add(dtbc);



            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(dts);

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
            //co.Focus();
            //(co as TextBox).SelectionStart = (co as TextBox).Text.Length;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

     
    }
}