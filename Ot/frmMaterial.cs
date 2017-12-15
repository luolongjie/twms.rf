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
    public partial class frmMaterial : Form
    {
        public frmMaterial()
        {
            InitializeComponent();
        }
        public Model.Mmaterialcode m;
        public Model.Mmaterialcodebody mbody = null;

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
                mbody = m.data[_int];
            }
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Bind()
        {
            dataGrid1.TableStyles.Clear();
            DataGridTableStyle dts = new DataGridTableStyle();

            dts.MappingName = dt.TableName;

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

        DataTable dt = null;
        private void frmMaterial_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("code");
            dt.Columns.Add("name");
            foreach (Model.Mmaterialcodebody v in m.data)
            {
                DataRow dr = dt.NewRow();
                dr["code"] = v.code;
                dr["name"] = v.name;
                dt.Rows.Add(dr);
            }
            this.dataGrid1.DataSource = dt;
            Bind();
            frmList.SizeColumnsToContent(this.dataGrid1, -1);//yy
        }
    }
}