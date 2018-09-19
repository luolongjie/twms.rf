using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MgetMaterialsByBar
    {
        private List<MaterialsByBars> _data;
        public List<MaterialsByBars> data
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
    public class MaterialsByBars
    {
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

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

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

        private int _plateY;
        public int plateY
        {
            get
            {
                return _plateY;
            }
            set
            {
                _plateY = value;
            }
        }

        private int _plateX;
        public int plateX
        {
            get
            {
                return _plateX;
            }
            set
            {
                _plateX = value;
            }
        }

        private int _plateCount;
        public int plateCount
        {
            get
            {
                return _plateCount;
            }
            set
            {
                _plateCount = value;
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
    }
}
