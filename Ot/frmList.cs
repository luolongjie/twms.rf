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
    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public string txtname = "";
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
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["trayCode"].ToString()))
                {
                    dtbc = new DataGridTextBoxColumn();
                    dtbc.HeaderText = "托盘";
                    dtbc.MappingName = "trayCode";
                    dtbc.Width = 80;
                    dts.GridColumnStyles.Add(dtbc);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["slName"].ToString()))
                {
                    dtbc = new DataGridTextBoxColumn();
                    dtbc.HeaderText = "库位";
                    dtbc.MappingName = "slName";//YY
                    //dtbc.MappingName = "slId";
                    dtbc.Width = 60;
                    dts.GridColumnStyles.Add(dtbc);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["fromSlIdName"].ToString()))
                {
                    dtbc = new DataGridTextBoxColumn();
                    dtbc.HeaderText = "移出库位";
                    dtbc.MappingName = "fromSlIdName";
                    dtbc.Width = 60;
                    dts.GridColumnStyles.Add(dtbc);
                }


                dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "名称";
                dtbc.MappingName = "materialName";
                dtbc.Width = 110;
                dts.GridColumnStyles.Add(dtbc);


                dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "数量";
                dtbc.MappingName = "qty";
                dtbc.Width = 80;
                dts.GridColumnStyles.Add(dtbc);

                if (dt.Columns.Contains("checkqty"))
                {
                    dtbc = new DataGridTextBoxColumn();
                    dtbc.HeaderText = "复核数量";
                    dtbc.MappingName = "checkqty";
                    dtbc.Width = 80;
                    dts.GridColumnStyles.Add(dtbc);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["pdate"].ToString()) || "待收货列表" == txtname)
                {
                    dtbc = new DataGridTextBoxColumn();
                    dtbc.HeaderText = "生产日期";
                    dtbc.MappingName = "pdate";
                    dtbc.Width = 80;
                    dts.GridColumnStyles.Add(dtbc);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["batchNo"].ToString()) || "待收货列表" == txtname)
                {
                    dtbc = new DataGridTextBoxColumn();
                    dtbc.HeaderText = "批次";
                    dtbc.MappingName = "batchNo";
                    dtbc.Width = 60;
                    dts.GridColumnStyles.Add(dtbc);
                }

                if (dt.Columns.Contains("inDate"))
                {
                    dtbc = new DataGridTextBoxColumn();
                    dtbc.HeaderText = "入库日期";
                    dtbc.MappingName = "inDate";
                    dtbc.Width = 60;
                    dts.GridColumnStyles.Add(dtbc);
                }

                if (dt.Columns.Contains("spec"))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["spec"].ToString()) && dt.Rows[0]["spec"].ToString() != "0")
                    {
                        dtbc = new DataGridTextBoxColumn();
                        dtbc.HeaderText = "规格";
                        dtbc.MappingName = "spec";
                        dtbc.Width = 60;
                        dts.GridColumnStyles.Add(dtbc);
                    }
                }


                dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "编码";
                dtbc.MappingName = "materialCode";
                dtbc.Width = 120;
                dts.GridColumnStyles.Add(dtbc);
            }
            else
            {
                dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "编码";
                dtbc.MappingName = "materialCode";
                dtbc.Width = 80;
                dts.GridColumnStyles.Add(dtbc);

                dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "批次";
                dtbc.MappingName = "batchNo";
                dtbc.Width = 80;
                dts.GridColumnStyles.Add(dtbc);
            }

            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(dts);
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtname))
            {
                this.Text = txtname;
            }
            this.dataGrid1.DataSource = dt;
            Bind();
            SizeColumnsToContent(this.dataGrid1,-1);//yy
        }

        public static void SizeColumnsToContent(DataGrid dataGrid, int nRowsToScan)
        {
            Graphics Graphics = dataGrid.CreateGraphics();

            try
            {
                DataTable dataTable = (DataTable)dataGrid.DataSource;

                if (-1 == nRowsToScan)
                {
                    nRowsToScan = dataTable.Rows.Count;
                }
                else
                {
                    nRowsToScan = System.Math.Min(nRowsToScan, dataTable.Rows.Count);
                }

                DataGridTextBoxColumn columnStyle;
                int iWidth;



                for (int iCurrCol = 0; iCurrCol < dataTable.Columns.Count; iCurrCol++)
                {
                    DataColumn dataColumn = dataTable.Columns[iCurrCol];
                    if (dataGrid.TableStyles[0].GridColumnStyles[dataColumn.ColumnName] == null)
                    {
                        continue;
                    }
                    if (dataGrid.TableStyles[0].GridColumnStyles[dataColumn.ColumnName].Width == -1)
                    {
                        continue;
                    }

                    columnStyle = new DataGridTextBoxColumn();

                    columnStyle.HeaderText = dataGrid.TableStyles[0].GridColumnStyles[dataColumn.ColumnName].HeaderText;
                    columnStyle.MappingName = dataColumn.ColumnName;

                    iWidth = (int)(Graphics.MeasureString(columnStyle.HeaderText, dataGrid.Font).Width);

                    DataRow dataRow;
                    for (int iRow = 0; iRow < nRowsToScan; iRow++)
                    {
                        dataRow = dataTable.Rows[iRow];

                        if (null != dataRow[dataColumn.ColumnName])
                        {
                            int iColWidth = (int)(Graphics.MeasureString(dataRow.ItemArray[iCurrCol].ToString(), dataGrid.Font).Width);
                            int iColHight = (int)(Graphics.MeasureString(dataRow.ItemArray[iCurrCol].ToString(), dataGrid.Font).Height);
                            iWidth = (int)System.Math.Max(iWidth, iColWidth);
                            columnStyle.Width = iWidth;

                        }
                    }
                    if (columnStyle.Width == -1)
                    {
                        continue;
                    }
                    dataGrid.TableStyles[0].GridColumnStyles[dataColumn.ColumnName].Width = iWidth + 4;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Graphics.Dispose();
            }
        }
    }
}