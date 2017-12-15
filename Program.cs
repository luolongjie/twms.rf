using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rf_Wms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new frmLogin());
            //Application.Run(new Out.frmPackingUp());
        }
    }
}