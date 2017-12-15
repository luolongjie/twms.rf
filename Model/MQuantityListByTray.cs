using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MQuantityListByTray
    {
        private List<QuantityListByTrays> _data;
        public List<QuantityListByTrays> data
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
    public class QuantityListByTrays
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

        private int? _checkQuantity;
        public int? checkQuantity
        {
            get
            {
                return _checkQuantity;
            }
            set
            {
                _checkQuantity = value;
            }
        }

        private int? _checkMinQuantity;
        public int? checkMinQuantity
        {
            get
            {
                return _checkMinQuantity;
            }
            set
            {
                _checkMinQuantity = value;
            }
        }

        private string _fromTrayCode;
        public string fromTrayCode
        {
            get
            {
                return _fromTrayCode;
            }
            set
            {
                _fromTrayCode = value;
            }
        }

        private string _toTrayCode;
        public string toTrayCode
        {
            get
            {
                return _toTrayCode;
            }
            set
            {
                _toTrayCode = value;
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

        private string _pDate;
        public string pDate
        {
            get
            {
                return _pDate;
            }
            set
            {
                _pDate = value;
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

        private string _id;
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _scan;
        public string scan
        {
            get
            {
                return _scan;
            }
            set
            {
                _scan = value;
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

        private string _slId;
        public string slId
        {
            get
            {
                return _slId;
            }
            set
            {
                _slId = value;
            }
        }
    }
}
