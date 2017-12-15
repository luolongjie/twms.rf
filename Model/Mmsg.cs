using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class Mmsg
    {
        private string _msg;
        public string msg
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
            }
        }

        private bool _success;
        public bool success
        {
            get
            {
                return _success;
            }
            set
            {
                _success = value;
            }
        }

       
    }
}
