using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class McheckResult
    {
        private checkResult _data;
        public checkResult data
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
    public class checkResult
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

        private string _fromSlName;
        public string fromSlName
        {
            get
            {
                return _fromSlName;
            }
            set
            {
                _fromSlName = value;
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

        private bool _blind;
        public bool blind
        {
            get
            {
                return _blind;
            }
            set
            {
                _blind = value;
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
