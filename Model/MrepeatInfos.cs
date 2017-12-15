using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MrepeatInfos
    {
        private repeatInfo _data;
        public repeatInfo data
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
    public class repeatInfo
    {
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

        private string _commonUnitName;
        public string commonUnitName
        {
            get
            {
                return _commonUnitName;
            }
            set
            {
                _commonUnitName = value;
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

      

        private string _slName;
        public string slName
        {
            get
            {
                return _slName;
            }
            set
            {
                _slName = value;
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

        private string _inDate;
        public string inDate
        {
            get
            {
                return _inDate;
            }
            set
            {
                _inDate = value;
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
       

        private int _orderItemId;
        public int orderItemId
        {
            get
            {
                return _orderItemId;
            }
            set
            {
                _orderItemId = value;
            }
        }

        private int _nextItemId;
        public int nextItemId
        {
            get
            {
                return _nextItemId;
            }
            set
            {
                _nextItemId = value;
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

        private List<repeatTraycode> _trayRepeats;
        public List<repeatTraycode> trayRepeats
        {
            get
            {
                return _trayRepeats;
            }
            set
            {
                _trayRepeats = value;
            }
        }
        
    }

    [Serializable]
    public class repeatTraycode
    {
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

        private bool _ischecked;
        public bool ischecked
        {
            get
            {
                return _ischecked;
            }
            set
            {
                _ischecked = value;
            }
        }
    }
}
