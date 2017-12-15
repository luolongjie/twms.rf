using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rf_Wms
{
    public partial class frmMenuPic : Form
    {
        public frmMenuPic()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            In.frmreceipting frm = new Rf_Wms.In.frmreceipting();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            In.frmreceipting frm = new Rf_Wms.In.frmreceipting();
            frm.isRed = true;
            frm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            In.frmshelve frm = new Rf_Wms.In.frmshelve();
            frm.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Out.frmPackingUp frm = new Rf_Wms.Out.frmPackingUp();
            frm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Out.frmStockOut frm = new Rf_Wms.Out.frmStockOut();
            frm.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Out.frmTranMoveMain frm = new Rf_Wms.Out.frmTranMoveMain();
            frm.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Out.frmMachiningOut frm = new Rf_Wms.Out.frmMachiningOut();
            frm.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            In.frmMachiningIn frm = new Rf_Wms.In.frmMachiningIn();
            frm.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Out.frmreplenish frm = new Rf_Wms.Out.frmreplenish();
            frm.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            CK.frmCheckMenu frm = new Rf_Wms.CK.frmCheckMenu();
            frm.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Ot.frmWarehouse frm = new Rf_Wms.Ot.frmWarehouse();
            frm.ShowDialog();
            this.labwarehousename.Text = Comm.warehousename;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            string filePath = System.IO.Path.GetDirectoryName
              (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (filePath.Substring(0, 6) == @"file:\")
            {
                filePath = filePath.Substring(6);
            }
            filePath = System.IO.Path.Combine(filePath, "1.txt");
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine("方法名: " + Comm.fun);
                sw.WriteLine("参数: " + Comm.par);
                sw.WriteLine("返回值: " + Comm.retval);
                sw.Close();
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMenuPic_Load(object sender, EventArgs e)
        {
            this.Text = Comm.userame;
            this.labwarehousename.Text = "当前仓库 " + Comm.warehousename;
        }

        private void frmMenuPic_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Ot.frmTray frm = new Rf_Wms.Ot.frmTray();
            frm.ShowDialog();
            this.labwarehousename.Text = Comm.warehousename;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            frmMain o = new frmMain();
            o.ShowDialog();
        }
    }
}