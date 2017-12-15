using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rf_Wms.CK
{
    public partial class frmCheckMenu : Form
    {
        public frmCheckMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            CK.frmCheckVoByOrder frm = new frmCheckVoByOrder();
            frm.ShowDialog();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            CK.frmCheckVoSecond frm = new frmCheckVoSecond();
            frm.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            CK.frmCheckVoByOrder frm = new frmCheckVoByOrder();
            frm.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            CK.frmCheckVoSecond frm = new frmCheckVoSecond();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}