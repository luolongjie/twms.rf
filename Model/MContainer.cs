using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MContainer
    {
        private MContainers _data;
        public MContainers data
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
    public class MContainers
    {
        private string _combineContent;
        public string combineContent
        {
            get
            {
                return _combineContent;
            }
            set
            {
                _combineContent = value;
            }
        }

        private string _combineTypeName;
        public string combineTypeName
        {
            get
            {
                return _combineTypeName;
            }
            set
            {
                _combineTypeName = value;
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
        

        private string _combineType;
        public string combineType
        {
            get
            {
                return _combineType;
            }
            set
            {
                _combineType = value;
            }
        }

        private string _pickTypeName;
         public string pickTypeName
        {
            get
            {
                return _pickTypeName;
            }
            set
            {
                _pickTypeName = value;
            }
        }

         private string _sortingTypeName;
         public string sortingTypeName
         {
             get
             {
                 return _sortingTypeName;
             }
             set
             {
                 _sortingTypeName = value;
             }
         }
        

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

        private List<pickOperateDTOSs> _pickOperateDTOS;
        public List<pickOperateDTOSs> pickOperateDTOS
        {
            get
            {
                return _pickOperateDTOS;
            }
            set
            {
                _pickOperateDTOS = value;
            }
        }
    }

    [Serializable]
    public class pickOperateDTOSs
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
