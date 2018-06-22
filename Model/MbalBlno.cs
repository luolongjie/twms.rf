using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MbalBlno
    {
        private List<balBlnos> _data;
        public List<balBlnos> data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }

    [Serializable]
    public class balBlnos
    {
        private string _stockOutNo;
        public string stockOutNo
        {
            get
            {
                return _stockOutNo;
            }
            set
            {
                _stockOutNo = value;
            }
        }

        private string _blNo;
        public string blNo
        {
            get
            {
                return _blNo;
            }
            set
            {
                _blNo = value;
            }
        }

        private int _realQuantity;
        public int realQuantity
        {
            get
            {
                return _realQuantity;
            }
            set
            {
                _realQuantity = value;
            }
        }

        private int _realMinquantity;
        public int realMinquantity
        {
            get
            {
                return _realMinquantity;
            }
            set
            {
                _realMinquantity = value;
            }
        }
    }
}
