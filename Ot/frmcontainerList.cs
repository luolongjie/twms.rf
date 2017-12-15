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
    public partial class frmcontainerList : Form
    {
        public frmcontainerList()
        {
            InitializeComponent();
        }

      


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Model.MContainer mm = null;
        private void frmcontainerList_Load(object sender, EventArgs e)
        {
            string txt = "";
            int i = 0;
            int row = 0;
            this.labtraycode.Text = "移入托盘码 "+mm.data.toTrayCode;
            foreach (Model.pickOperateDTOSs v in mm.data.pickOperateDTOS)
            {
              
                i++;
                string currenttxt=i+" "+v.materialCode+ ","+v.batchNo+","+v.materialName+","+v.fromSlName+"\r\n";
                txt += currenttxt;
                Graphics vGraphics = CreateGraphics();
                //int mlen = 0;
                //for (int mi = 0; mi < currenttxt.Length; mi++)
                //{
                //    SizeF vSizeF = vGraphics.MeasureString(currenttxt[mi].ToString(), Font);
                //    int dStrLength = Convert.ToInt32(Math.Ceiling(vSizeF.Width));
                //    if (dStrLength + mlen > 210)
                //    {
                //        row++;
                //        mlen = 0;
                //    }
                //    else
                //    {
                //        mlen += dStrLength;
                //    }
                //}
                //row++;
                SizeF vSizeF = vGraphics.MeasureString(currenttxt, Font);
                int dStrLength = Convert.ToInt32(Math.Ceiling(vSizeF.Width));
                row += (int)(Math.Ceiling(((double)dStrLength / 210)));
               
            }
            this.lblinfo.Size = new System.Drawing.Size(210, row * 15+15);
            this.lblinfo.Text = txt;
        }

    }
}