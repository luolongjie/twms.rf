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
    public partial class frmTrayMenu : Form
    {
        public frmTrayMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            Ot.frmTray frm = new Rf_Wms.Ot.frmTray();
            frm.ShowDialog();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            Ot.frmSLSearch frm = new Rf_Wms.Ot.frmSLSearch();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ot.frmGetTray frm = new Rf_Wms.Ot.frmGetTray();
            frm.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Ot.frmTray frm = new Rf_Wms.Ot.frmTray();
            frm.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Ot.frmSLSearch frm = new Rf_Wms.Ot.frmSLSearch();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ot.frmGetTray frm = new Rf_Wms.Ot.frmGetTray();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Ot.frmMaterialInfo frm = new Rf_Wms.Ot.frmMaterialInfo();
            frm.ShowDialog();
            //frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ot.frmcontainer frm = new Rf_Wms.Ot.frmcontainer();
            frm.ShowDialog();
        }

       

      
    }
}