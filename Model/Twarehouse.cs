using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class Twarehouse
    {
        private string _whId;
        public string whCode
        {
            get
            {
                return _whId;
            }
            set
            {
                _whId = value;
            }
        }

        private string _whName;
        public string whName
        {
            get
            {
                return _whName;
            }
            set
            {
                _whName = value;
            }
        }
    }
}
