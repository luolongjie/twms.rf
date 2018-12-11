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

        private int _dispatchQuantity;
        public int dispatchQuantity
        {
            get
            {
                return _dispatchQuantity;
            }
            set
            {
                _dispatchQuantity = value;
            }
        }

        private int _dispatchMinQuantity;
        public int dispatchMinQuantity
        {
            get
            {
                return _dispatchMinQuantity;
            }
            set
            {
                _dispatchMinQuantity = value;
            }
        }

        private string _outletCode;
        public string outletCode
        {
            get
            {
                return _outletCode;
            }
            set
            {
                _outletCode = value;
            }
        }

        private string _unitName;
        public string unitName
        {
            get
            {
                return _unitName;
            }
            set
            {
                _unitName = value;
            }
        }

        private string _minUnitName;
        public string minUnitName
        {
            get
            {
                return _minUnitName;
            }
            set
            {
                _minUnitName = value;
            }
        }
    }
}
