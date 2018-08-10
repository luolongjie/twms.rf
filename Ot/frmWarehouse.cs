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
    public partial class frmWarehouse : Form
    {
        public frmWarehouse()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWarehouse_Load(object sender, EventArgs e)
        {
            this.cmbwarehouse.DataSource = Comm.warehouseList;
            this.cmbwarehouse.DisplayMember = "name";
            this.cmbwarehouse.ValueMember = "whCode";
            this.cmbwarehouse.Text = Comm.warehousename;
        }

        private void cmbwarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            Comm.warehousecode = this.cmbwarehouse.SelectedValue.ToString();
            Comm.warehousename = this.cmbwarehouse.Text;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Comm.warehousecode = this.cmbwarehouse.SelectedValue.ToString();
            Comm.warehousename = this.cmbwarehouse.Text;
            this.Close();
        }

        
    }
}