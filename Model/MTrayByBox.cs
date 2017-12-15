using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MTrayByBox
    {
        private TrayBox _data;
        public TrayBox data
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
    public class TrayBox
    {
        private string _boxcode;
        public string boxcode
        {
            get
            {
                return _boxcode;
            }
            set
            {
                _boxcode = value;
            }
        }


        private string _materialCode;
        public string materialCode
        {
            get
            {
                return _materialCode;
            }
            set
            {
                _materialCode = value;
            }
        }

        private string _materialName;
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                _materialName = value;
            }
        }

        private string _barCode;
        public string barCode
        {
            get
            {
                return _barCode;
            }
            set
            {
                _barCode = value;
            }
        }

       

        private string _batchNo;
        public string batchNo
        {
            get
            {
                return _batchNo;
            }
            set
            {
                _batchNo = value;
            }
        }





        private int _quantity;
        public int quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        private int _minQuantity;
        public int minQuantity
        {
            get
            {
                return _minQuantity;
            }
            set
            {
                _minQuantity = value;
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

        private string _pdate;
        public string pdate
        {
            get
            {
                return _pdate;
            }
            set
            {
                _pdate = value;
            }
        }

        private string _spec;
        public string spec
        {
            get
            {
                return _spec;
            }
            set
            {
                _spec = value;
            }
        }

        private string _trayCode;
        public string trayCode
        {
            get
            {
                return _trayCode;
            }
            set
            {
                _trayCode = value;
            }
        }

        private string _materialStatus;
        public string materialStatus
        {
            get
            {
                return _materialStatus;
            }
            set
            {
                _materialStatus = value;
            }
        }

        private string _shipperCode;
        public string shipperCode
        {
            get
            {
                return _shipperCode;
            }
            set
            {
                _shipperCode = value;
            }
        }
    }
}
