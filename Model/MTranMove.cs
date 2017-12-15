using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
   public class MTranMove
    {
        private TranMoves _data;
        public TranMoves data
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
    public class TranMoves
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

        private string _toSlName;
        public string toSlName
        {
            get
            {
                return _toSlName;
            }
            set
            {
                _toSlName = value;
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

        private int _materialStatusCode;
        public int materialStatusCode
        {
            get
            {
                return _materialStatusCode;
            }
            set
            {
                _materialStatusCode = value;
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
        

        private string _materialStatusName;
        public string materialStatusName
        {
            get
            {
                return _materialStatusName;
            }
            set
            {
                _materialStatusName = value;
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
    }
}
