using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MultiMaterialList
    {
        private List<MultiMaterialLists> _data;
        public List<MultiMaterialLists> data
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

    public class MultiMaterialLists
    {
        private string _pickType;
         public string pickType
        {
            get
            {
                return _pickType;
            }
            set
            {
                _pickType = value;
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

        private int _orderQuantity;
        public int orderQuantity
        {
            get
            {
                return _orderQuantity;
            }
            set
            {
                _orderQuantity = value;
            }
        }

        private int _orderMinQuantity;
        public int orderMinQuantity
        {
            get
            {
                return _orderMinQuantity;
            }
            set
            {
                _orderMinQuantity = value;
            }
        }

        private int _outletQuantity;
        public int outletQuantity
        {
            get
            {
                return _outletQuantity;
            }
            set
            {
                _outletQuantity = value;
            }
        }

        private int _outletMinQuantity;
        public int outletMinQuantity
        {
            get
            {
                return _outletMinQuantity;
            }
            set
            {
                _outletMinQuantity = value;
            }
        }

        private int _sumRealQuantity;
        public int sumRealQuantity
        {
            get
            {
                return _sumRealQuantity;
            }
            set
            {
                _sumRealQuantity = value;
            }
        }

        private int _sumRealMinQuantity;
        public int sumRealMinQuantity
        {
            get
            {
                return _sumRealMinQuantity;
            }
            set
            {
                _sumRealMinQuantity = value;
            }
        }

        private int _spec;
        public int spec
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

        private string _stockOutItemId;
        public string stockOutItemId
        {
            get
            {
                return _stockOutItemId;
            }
            set
            {
                _stockOutItemId = value;
            }
        }
    }
}
