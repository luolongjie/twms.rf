﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Rf_Wms.Ot;
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
                this.cbooutlet.SelectedIndexChanged -= new System.EventHandler(this.cbooutlet_SelectedIndexChanged);
                Cursor.Current = Cursors.WaitCursor;
                string con = @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&materialCode=" + materialCode + "&tcod=" + tcod;
                //outletcode
                string x = HttpHelper.HttpPost("loadOutletList", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.MoutletInfo m = (Model.MoutletInfo)JsonConvert.DeserializeObject(x, typeof(Model.MoutletInfo));
                Model.outletInfos ois=new Rf_Wms.Model.outletInfos();
                ois.outletName="请选择";
                ois.outletCode = "0";
                m.data.Insert(0, ois);
                this.cbooutlet.DataSource = m.data;
                this.cbooutlet.ValueMember = "outletCode";
                this.cbooutlet.DisplayMember = "outletName";
                //this.cbooutlet.SelectedItem = 1;
                //cbooutlet.Items.Insert(0, "请选择");
                cbooutlet.SelectedItem = 0;

                con = @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&materialCode=" + materialCode + "&tcod=" + tcod;
                //outletcode
                x = HttpHelper.HttpPost("loadPickOrderList", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Model.MbalPickno mp = (Model.MbalPickno)JsonConvert.DeserializeObject(x, typeof(Model.MbalPickno));
                dataGrid2.TableStyles.Clear();
                DataTable dt = new DataTable();
                dt.Columns.Add("pickNo");
                dt.Columns.Add("des");
                foreach (Model.balPicknos v in mp.data)
                {
                    DataRow dr = dt.NewRow();
                    dr["pickNo"] = v.pickNo;
                    dr["des"] = v.des;
                    dt.Rows.Add(dr);
                }
                DataGridTableStyle dts = new DataGridTableStyle();

                //dts.MappingName = mp.data.GetType().Name;

                DataGridTextBoxColumn dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "拣货单号";
                dtbc.MappingName = "pickNo";
                dtbc.Width = 140;
                dts.GridColumnStyles.Add(dtbc);

                dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "备注";
                dtbc.MappingName = "des";
                dtbc.Width = 240;
                dts.GridColumnStyles.Add(dtbc);

                dataGrid2.TableStyles.Clear();
                dataGrid2.TableStyles.Add(dts);
                //this.dataGrid2.DataSource = mp.data;
                this.dataGrid2.DataSource = dt;
                frmList.SizeColumnsToContent(this.dataGrid2, -1);//yy
                Cursor.Current = Cursors.Default;
                this.cbooutlet.SelectedIndexChanged += new System.EventHandler(this.cbooutlet_SelectedIndexChanged);
                cbooutlet_SelectedIndexChanged(null, null);
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
           
        }

        public string blNo = "";
        private void btnOK_Click(object sender, EventArgs e)
        {
            //int _int;
            //_int = dataGrid1.CurrentCell.RowNumber;

            //if (_int < 0)
            //    return;
            if (!ischeck)
            {
                MessageBox.Show("请选择一条记录");
                return;
            }
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

        private void cbooutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.cbooutlet.Text == "请选择" && cbooutlet.Items.Count != 1)
            //    return;
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                string con = @"lcCode=" + Comm.lcCode + "&whCode=" + Comm.warehousecode + "&materialCode=" + materialCode + "&tcod=" + tcod;
                if (this.cbooutlet.Text != "请选择")
                {
                    con += "&outletCode=" + this.cbooutlet.SelectedValue.ToString();
                }
                else
                {
                    con += "&outletCode=";
                }
                //outletcode
                string x = HttpHelper.HttpPost("loadBlnoList", con);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                mbl = (Model.MbalBlno)JsonConvert.DeserializeObject(x, typeof(Model.MbalBlno));
                Cursor.Current = Cursors.Default;
                if (mbl.data.Count == 1 && this.cbooutlet.Text == "请选择")
                {
                    blNo = mbl.data[0].blNo;

                    this.Close();
                    return;
                }
                if (mbl.data.Count == 1)
                {
                    ischeck = true;
                    _int = 0;
                }
                else
                {
                    ischeck = false;
                }
                dataGrid1.TableStyles.Clear();
                DataGridTableStyle dts = new DataGridTableStyle();

                dts.MappingName = mbl.data.GetType().Name;

                DataGridTextBoxColumn dtbc = new DataGridTextBoxColumn();
                dtbc.HeaderText = "提单号";
                dtbc.MappingName = "blNo";
                dtbc.Width = 190;
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

        bool ischeck = false;
        int _int;
        private void dataGrid1_Click(object sender, EventArgs e)
        {
            //int _int;
            _int = dataGrid1.CurrentCell.RowNumber;

            if (_int < 0)
                return;

            //if (_int > m.data.Count)
            //    return;
            ischeck = true;
        }

       
    }
}