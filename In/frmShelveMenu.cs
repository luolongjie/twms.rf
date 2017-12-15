using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rf_Wms.In
{
    public partial class frmShelveMenu : Form
    {
        public frmShelveMenu()
        {
            InitializeComponent();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            //frmrefundshelveOne frm = new frmrefundshelveOne();
            frmshelve frm = new frmshelve();
            frm.ShowDialog();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            frmrefundshelve frm = new frmrefundshelve();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmrefundshelveOne frm = new frmrefundshelveOne();
            frm.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //frmrefundshelveOne frm = new frmrefundshelveOne();
            frmshelve frm = new frmshelve();
            frm.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmrefundshelveOne frm = new frmrefundshelveOne();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmrefundshelve frm = new frmrefundshelve();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
    }
}