using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rf_Wms.Out
{
    public partial class frmStockOutMenu : Form
    {
        public frmStockOutMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            frmStockOut frm = new frmStockOut();
            frm.ShowDialog();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            frmStockOutCheck frm = new frmStockOutCheck();
            frm.ShowDialog();
        }

       
    }
}