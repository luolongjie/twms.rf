using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class locationStockList
    {
        private List<locationStockLists> _data;
        public List<locationStockLists> data
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
    public class locationStockLists
    {
        private int _canUseMinTotalQuantity;
        public int canUseMinTotalQuantity
        {
            get
            {
                return _canUseMinTotalQuantity;
            }
            set
            {
                _canUseMinTotalQuantity = value;
            }
        }

        private int _canUseTotalQuantity;
        public int canUseTotalQuantity
        {
            get
            {
                return _canUseTotalQuantity;
            }
            set
            {
                _canUseTotalQuantity = value;
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

        private string _materialCodeName;
        public string materialCodeName
        {
            get
            {
                return _materialCodeName;
            }
            set
            {
                _materialCodeName = value;
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


         private string _pdateStr;
            public string pdateStr
        {
            get
            {
                return _pdateStr;
            }
            set
            {
                _pdateStr = value;
            }
        }

            private string _inDateStr;
            public string inDateStr
            {
                get
                {
                    return _inDateStr;
                }
                set
                {
                    _inDateStr = value;
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

        private int _id;
        public int id
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

        private int _minTotalQuantity;
        public int minTotalQuantity
        {
            get
            {
                return _minTotalQuantity;
            }
            set
            {
                _minTotalQuantity = value;
            }
        }

        private int _totalQuantity;
        public int totalQuantity
        {
            get
            {
                return _totalQuantity;
            }
            set
            {
                _totalQuantity = value;
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
    }
}
