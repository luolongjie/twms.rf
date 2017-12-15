using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MbaseIn
    {
        private MbaseIns _data;
        public MbaseIns data
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
    public class MbaseIns
    {
        private List<transferMaterialSurface> _transferMaterialSurfaces;
        public List<transferMaterialSurface> transferMaterialSurfaces
        {
            get
            {
                return _transferMaterialSurfaces;
            }
            set
            {
                _transferMaterialSurfaces = value;
            }
        }

        private List<stockInMaterialSurface> _stockInMaterialSurfaces;
        public List<stockInMaterialSurface> stockInMaterialSurfaces
        {
            get
            {
                return _stockInMaterialSurfaces;
            }
            set
            {
                _stockInMaterialSurfaces = value;
            }
        }

        private List<normalStockInType> _normalStockInTypes;
        public List<normalStockInType> normalStockInTypes
        {
            get
            {
                return _normalStockInTypes;
            }
            set
            {
                _normalStockInTypes = value;
            }
        }

        private List<unNormalStockInType> _unNormalStockInTypes;
        public List<unNormalStockInType> unNormalStockInTypes
        {
            get
            {
                return _unNormalStockInTypes;
            }
            set
            {
                _unNormalStockInTypes = value;
            }
        }

        private List<materialCondition> _materialConditions;
        public List<materialCondition> materialConditions
        {
            get
            {
                return _materialConditions;
            }
            set
            {
                _materialConditions = value;
            }
        }

        private List<orderBusinessType> _orderBusinessTypes;
        public List<orderBusinessType> orderBusinessTypes
        {
            get
            {
                return _orderBusinessTypes;
            }
            set
            {
                _orderBusinessTypes = value;
            }
        }

        private List<transportMethod> _transportMethods;
        public List<transportMethod> transportMethods
        {
            get
            {
                return _transportMethods;
            }
            set
            {
                _transportMethods = value;
            }
        }
    }
    [Serializable]
    public class stockInMaterialSurface
    {
        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }

    [Serializable]
    public class transferMaterialSurface
    {
        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }

    [Serializable]
    public class normalStockInType
    {
        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }

    [Serializable]
    public class unNormalStockInType
    {
        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }

    [Serializable]
    public class materialCondition
    {
        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }

    [Serializable]
    public class orderBusinessType
    {
        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }

    [Serializable]
    public class transportMethod
    {
        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _des;
        public string des
        {
            get
            {
                return _des;
            }
            set
            {
                _des = value;
            }
        }
    }
}
