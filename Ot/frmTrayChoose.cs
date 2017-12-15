using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rf_Wms.Ot
{
    public partial class frmTrayChoose : Form
    {
        public frmTrayChoose()
        {
            InitializeComponent();
        }

        public List<Model.recommends> srecommendList;
        bool ischeck = false;
        public int slid ;
        public string slname = "";
        private void dataGrid1_Click(object sender, EventArgs e)
        {
            int _int;
            _int = dataGrid1.CurrentCell.RowNumber;

            if (_int < 0)
                return;
            //if (m != null)
            //{
            //    if (_int > m.data.Count)
            //        return;
            //    //customer = m.data[_int];
            //    this.txtorderid.Text = m.data[_int].code;
           
                ischeck = true;
            //}
        }

        int _int;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ischeck)
            {
                MessageBox.Show("请先选择货位");
                return;
            }
            //int _int;
            _int = dataGrid1.CurrentCell.RowNumber;

            if (_int < 0)
                return;
            slid = srecommendList[_int].id;
            slname = srecommendList[_int].name;
            //if (m != null)
            //{
            //    if (_int > m.data.Count)
            //        return;
            //    //customer = m.data[_int];
               

            //}
            this.Close();
        }

        void Bind()
        {
            dataGrid1.TableStyles.Clear();
            DataGridTableStyle dts = new DataGridTableStyle();

            dts.MappingName = dt.TableName;

            DataGridTextBoxColumn dtbc = new DataGridTextBoxColumn();
            //dtbc.HeaderText = "编码";
            //dtbc.MappingName = "id";
            //dtbc.Width = 120;
            //dts.GridColumnStyles.Add(dtbc);

            dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "名称";
            dtbc.MappingName = "name";
            dtbc.Width = 110;
            dts.GridColumnStyles.Add(dtbc);

            dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "批次";
            dtbc.MappingName = "batch";
            dtbc.Width = 110;
            dts.GridColumnStyles.Add(dtbc);

            dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "生产日期";
            dtbc.MappingName = "pdate";
            dtbc.Width = 110;
            dts.GridColumnStyles.Add(dtbc);

            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(dts);

        }

        DataTable dt = null;
        private void frmTrayChoose_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("pdate");
            dt.Columns.Add("batch");
            dt.Columns.Add("name");
            foreach (Model.recommends v in srecommendList)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = v.id;
                dr["pdate"] = v.pdate;
                dr["batch"] = v.batch;
                dr["name"] = v.name;
                dt.Rows.Add(dr);
            }
            this.dataGrid1.DataSource = dt;
            dt.TableName = "dt";
            Bind();
            frmList.SizeColumnsToContent(this.dataGrid1, -1);//yy
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}