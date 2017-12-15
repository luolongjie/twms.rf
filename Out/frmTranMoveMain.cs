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
    public partial class frmTranMoveMain : Form
    {
        public frmTranMoveMain()
        {
            InitializeComponent();
        }



        private void btnF_Click_1(object sender, EventArgs e)
        {
            frmTranMove frm = new frmTranMove();
            frm.ShowDialog();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            frmDirTranMove frm = new frmDirTranMove();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            frmTranMove frm = new frmTranMove();
            frm.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmDirTranMove frm = new frmDirTranMove();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}