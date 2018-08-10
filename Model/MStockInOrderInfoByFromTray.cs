using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MStockInOrderInfoByFromTray
    {
        private StockInOrderInfoByFromTrays _data;
        public StockInOrderInfoByFromTrays data
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
    public class StockInOrderInfoByFromTrays
    {
        private bool _merge;
        public bool merge
        {
            get
            {
                return _merge;
            }
            set
            {
                _merge = value;
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

        private string _oid;
        public string oid
        {
            get
            {
                return _oid;
            }
            set
            {
                _oid = value;
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

        private string _commonUnit;
        public string commonUnit
        {
            get
            {
                return _commonUnit;
            }
            set
            {
                _commonUnit = value;
            }
        }

        private string _minUnit;
        public string minUnit
        {
            get
            {
                return _minUnit;
            }
            set
            {
                _minUnit = value;
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

        private string _shipperCodeName;
        public string shipperCodeName
        {
            get
            {
                return _shipperCodeName;
            }
            set
            {
                _shipperCodeName = value;
            }
        }



        private string _unit;
        public string unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
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

        private string _materialStatusStr;
        public string materialStatusStr
        {
            get
            {
                return _materialStatusStr;
            }
            set
            {
                _materialStatusStr = value;
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

        private int _slId;
        public int slId
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

        private string _slIdName;
        public string slIdName
        {
            get
            {
                return _slIdName;
            }
            set
            {
                _slIdName = value;
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
    }
}
