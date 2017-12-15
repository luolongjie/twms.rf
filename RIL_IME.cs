using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsCE.Forms;
namespace Rf_Wms
{
    class RIL_IME
    {//显示输入面板
        static public InputPanel m_InputPanel = new InputPanel();

        public static void ShowIME(string name)
        {
            foreach (InputMethod m in m_InputPanel.InputMethods)
            {
                if (m.Name == name)
                {
                    m_InputPanel.CurrentInputMethod = m;
                    break;
                }
            }
            if (m_InputPanel.Enabled)
            {
                m_InputPanel.Enabled = false;
            }
            else
            {
                m_InputPanel.Enabled = true;
            }
        }



        public static void HideIME()
        {
            m_InputPanel.Enabled = false;
        }
    }

}
