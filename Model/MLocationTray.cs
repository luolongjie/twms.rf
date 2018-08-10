using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MLocationTray
    {
        private List<LocationTrays> _data;
        public List<LocationTrays> data
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
    public class LocationTrays
    {
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

        private string _shipperName;
        public string shipperName
        {
            get
            {
                return _shipperName;
            }
            set
            {
                _shipperName = value;
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

       

        private string _qt;
          public string qt
        {
            get
            {
                return _qt;
            }
            set
            {
                _qt = value;
            }
        }
        

        private string _condition;
        public string condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
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
