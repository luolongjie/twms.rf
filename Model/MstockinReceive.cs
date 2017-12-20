using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MstockinReceive
    {
        private stockinreceivedata _data;
        public stockinreceivedata data
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
    public class stockinreceivedata
    {
        private materials _material;
        public materials material
        {
            get
            {
                return _material;
            }
            set
            {
                _material = value;
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

        private string _recommendSlName;
        public string recommendSlName
        {
            get
            {
                return _recommendSlName;
            }
            set
            {
                _recommendSlName = value;
            }
        }
        
    }


    [Serializable]
    public class materials
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

        private string _spec;
        public string spec
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
    }
}
