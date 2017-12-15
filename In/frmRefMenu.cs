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
    public partial class frmRefMenu : Form
    {
        public frmRefMenu()
        {
            InitializeComponent();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            In.frmreceipting frm = new Rf_Wms.In.frmreceipting();
            frm.isRed = true;
            frm.ShowDialog();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            In.frmrefund frm = new frmrefund();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmbalance frm = new frmbalance();
            frm.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            In.frmreceipting frm = new Rf_Wms.In.frmreceipting();
            frm.isRed = true;
            frm.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            In.frmrefund frm = new frmrefund();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmbalance frm = new frmbalance();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       
    }
}