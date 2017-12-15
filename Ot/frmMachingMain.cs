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
    public partial class frmMachingMain : Form
    {
        public frmMachingMain()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Out.frmMachiningOut frm = new Rf_Wms.Out.frmMachiningOut();
            frm.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            In.frmMachiningIn frm = new Rf_Wms.In.frmMachiningIn();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}