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
    public partial class frmBalMaterial : Form
    {
        public frmBalMaterial()
        {
            InitializeComponent();
        }

        public Model.MBalanceBarcode mb = null;
        public Model.BalanceBarcodes mbs = null;
        DataTable dt = null;
        private void frmBalMaterial_Load(object sender, EventArgs e)
        {
           
            
            dt = new DataTable();
            dt.Columns.Add("materialName");
            dt.Columns.Add("spec");
            foreach (Model.BalanceBarcodes v in mb.data)
            {
                DataRow dr = dt.NewRow();
                dr["materialName"] = v.materialName;
                dr["spec"] = v.spec;
                dt.Rows.Add(dr);
            }
            this.dataGrid1.DataSource = dt;
            Bind();
            frmList.SizeColumnsToContent(this.dataGrid1, -1);//yy
        }

        void Bind()
        {
            dataGrid1.TableStyles.Clear();
            DataGridTableStyle dts = new DataGridTableStyle();

            dts.MappingName = dt.TableName;

            DataGridTextBoxColumn dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "物料名称";
            dtbc.MappingName = "materialName";
            dtbc.Width = 120;
            dts.GridColumnStyles.Add(dtbc);

            dtbc = new DataGridTextBoxColumn();
            dtbc.HeaderText = "规格";
            dtbc.MappingName = "spec";
            dtbc.Width = 110;
            dts.GridColumnStyles.Add(dtbc);



            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(dts);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int _int;
            _int = dataGrid1.CurrentCell.RowNumber;

            if (_int < 0)
                return;
            if (mb != null)
            {
                if (_int > mb.data.Count)
                    return;
                mbs = mb.data[_int];
            }
            this.Close();
        }
       
    }
}