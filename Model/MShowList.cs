using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    

    [Serializable]
    public class MShowList
    {
        private List<material> _data;
        public List<material> data
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
    public class material
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

        private int _surplusQuantity;
        public int surplusQuantity
        {
            get
            {
                return _surplusQuantity;
            }
            set
            {
                _surplusQuantity = value;
            }
        }



        private int _surplusMinQuantity;
        public int surplusMinQuantity
        {
            get
            {
                return _surplusMinQuantity;
            }
            set
            {
                _surplusMinQuantity = value;
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

        private int _realQuantity;
        public int realQuantity
        {
            get
            {
                return _realQuantity;
            }
            set
            {
                _realQuantity = value;
            }
        }

        private int _realMinquantity;
        public int realMinquantity
        {
            get
            {
                return _realMinquantity;
            }
            set
            {
                _realMinquantity = value;
            }
        }

        private int _recommendSlId;
        public int recommendSlId
        {
            get
            {
                return _recommendSlId;
            }
            set
            {
                _recommendSlId = value;
            }
        }

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
