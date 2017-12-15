using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MStockOutItem
    {
        private List<StockOutItems> _data;
        public List<StockOutItems> data
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

    public class MStockOutItems
    {
        private StockOutItems _data;
        public StockOutItems data
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
    public class StockOutItems
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

        private string _stockOutDetailId;
        public string stockOutDetailId
        {
            get
            {
                return _stockOutDetailId;
            }
            set
            {
                _stockOutDetailId = value;
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

        private string _demandTypeName;
        public string demandTypeName
        {
            get
            {
                return _demandTypeName;
            }
            set
            {
                _demandTypeName = value;
            }
        }

        private string _demand;
        public string demand
        {
            get
            {
                return _demand;
            }
            set
            {
                _demand = value;
            }
        }

        private string _valid;
        public string valid
        {
            get
            {
                return _valid;
            }
            set
            {
                _valid = value;
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
    }
}
