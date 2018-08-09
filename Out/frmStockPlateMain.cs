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
    public partial class frmStockPlateMain : Form
    {
        public frmStockPlateMain()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Out.frmStockUp frm = new Rf_Wms.Out.frmStockUp();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Out.frmUsePlate frm = new Rf_Wms.Out.frmUsePlate();
            frm.ShowDialog();
        }

      
        
    }
}