using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class Mreplenish
    {
        private replenishs _data;
        public replenishs data
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
    public class replenishs
    {
        private string _assistance;
        public string assistance
        {
            get
            {
                return _assistance;
            }
            set
            {
                _assistance = value;
            }
        }

        private string _assistanceName;
        public string assistanceName
        {
            get
            {
                return _assistanceName;
            }
            set
            {
                _assistanceName = value;
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

        private string _fromSlIdName;
        public string fromSlIdName
        {
            get
            {
                return _fromSlIdName;
            }
            set
            {
                _fromSlIdName = value;
            }
        }

        private string _toSlIdName;
        public string toSlIdName
        {
            get
            {
                return _toSlIdName;
            }
            set
            {
                _toSlIdName = value;
            }
        }

        private int _recommendId;
         public int recommendId
        {
            get
            {
                return _recommendId;
            }
            set
            {
                _recommendId = value;
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

        private int _fromSlId;
        public int fromSlId
        {
            get
            {
                return _fromSlId;
            }
            set
            {
                _fromSlId = value;
            }
        }

        private int _toSlId;
        public int toSlId
        {
            get
            {
                return _toSlId;
            }
            set
            {
                _toSlId = value;
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
    }
}