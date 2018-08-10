using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MTrayStockByOrderType
    {
        private TrayStockByOrderTypes _data;
        public TrayStockByOrderTypes data
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
    public class TrayStockByOrderTypes
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

        private bool _batchNoAdjust;
        public bool batchNoAdjust
        {
            get
            {
                return _batchNoAdjust;
            }
            set
            {
                _batchNoAdjust = value;
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

        private bool _cargoTransf;
         public bool cargoTransf
        {
            get
            {
                return _cargoTransf;
            }
            set
            {
                _cargoTransf = value;
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

        private string _status;
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        private int _materialStatus;
        public int materialStatus
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

          private string _qtStatus;
          public string qtStatus
          {
              get
              {
                  return _qtStatus;
              }
              set
              {
                  _qtStatus = value;
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
    }
}
