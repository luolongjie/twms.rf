using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MstartSecondarySorting
    {
        private MstartSecondarySortings _data;
        public MstartSecondarySortings data
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
    public class MstartSecondarySortings
    {
        private string _pickNo;
        public string pickNo
        {
            get
            {
                return _pickNo;
            }
            set
            {
                _pickNo = value;
            }
        }

        private int? _pickType;
        public int? pickType
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

        private int? _checkType;
        public int? checkType
        {
            get
            {
                return _checkType;
            }
            set
            {
                _checkType = value;
            }
        }
        

        private int? _sortingType;
        public int? sortingType
        {
            get
            {
                return _sortingType;
            }
            set
            {
                _sortingType = value;
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

        private int _trayPickQuantity;
        public int trayPickQuantity
        {
            get
            {
                return _trayPickQuantity;
            }
            set
            {
                _trayPickQuantity = value;
            }
        }

        private int _trayPickMinQuantity;
        public int trayPickMinQuantity
        {
            get
            {
                return _trayPickMinQuantity;
            }
            set
            {
                _trayPickMinQuantity = value;
            }
        }

        private int _trayCheckQuantity;
        public int trayCheckQuantity
        {
            get
            {
                return _trayCheckQuantity;
            }
            set
            {
                _trayCheckQuantity = value;
            }
        }

        private int _trayCheckMinQuantity;
        public int trayCheckMinQuantity
        {
            get
            {
                return _trayCheckMinQuantity;
            }
            set
            {
                _trayCheckMinQuantity = value;
            }
        }

        private List<pickOperateSecondarySortingRFDTOSs> _pickOperateSecondarySortingRFDTOS;
        public List<pickOperateSecondarySortingRFDTOSs> pickOperateSecondarySortingRFDTOS
        {
            get
            {
                return _pickOperateSecondarySortingRFDTOS;
            }
            set
            {
                _pickOperateSecondarySortingRFDTOS = value;
            }
        }
    }

    [Serializable]
    public class pickOperateSecondarySortingRFDTOSs
    {
        private string _pickOperateId;
        public string pickOperateId
        {
            get
            {
                return _pickOperateId;
            }
            set
            {
                _pickOperateId = value;
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

        private int _pickQuantity;
        public int pickQuantity
        {
            get
            {
                return _pickQuantity;
            }
            set
            {
                _pickQuantity = value;
            }
        }

        private int _pickMinQuantity;
        public int pickMinQuantity
        {
            get
            {
                return _pickMinQuantity;
            }
            set
            {
                _pickMinQuantity = value;
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

        private bool _ischeck;
        public bool ischeck
        {
            get
            {
                return _ischeck;
            }
            set
            {
                _ischeck = value;
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

        private int _pickOrderQuantity;
        public int pickOrderQuantity
        {
            get
            {
                return _pickOrderQuantity;
            }
            set
            {
                _pickOrderQuantity = value;
            }
        }

        private int _pickOrderMinQuantity;
        public int pickOrderMinQuantity
        {
            get
            {
                return _pickOrderMinQuantity;
            }
            set
            {
                _pickOrderMinQuantity = value;
            }
        }

      
    }
}
