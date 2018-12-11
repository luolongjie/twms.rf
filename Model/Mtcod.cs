using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class Mtcod
    {
        private tcods _data;
        public tcods data
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
    public class tcods
    {
        private string _trainFrequency;
        public string trainFrequency
        {
            get
            {
                return _trainFrequency;
            }
            set
            {
                _trainFrequency = value;
            }
        }

        private string _unitName;
        public string unitName
        {
            get
            {
                return _unitName;
            }
            set
            {
                _unitName = value;
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

        private string _platePlan;
        public string platePlan
        {
            get
            {
                return _platePlan;
            }
            set
            {
                _platePlan = value;
            }
        }

        private string _driver;
        public string driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }

        private int _blNum;
        public int blNum
        {
            get
            {
                return _blNum;
            }
            set
            {
                _blNum = value;
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

        private int _realMinQuantity;
        public int realMinQuantity
        {
            get
            {
                return _realMinQuantity;
            }
            set
            {
                _realMinQuantity = value;
            }
        }

        private int _loadQuantity;
        public int loadQuantity
        {
            get
            {
                return _loadQuantity;
            }
            set
            {
                _loadQuantity = value;
            }
        }

        private int _loadMinQuantity;
        public int loadMinQuantity
        {
            get
            {
                return _loadMinQuantity;
            }
            set
            {
                _loadMinQuantity = value;
            }
        }

        private int _dispatchQuantity;
        public int dispatchQuantity
        {
            get
            {
                return _dispatchQuantity;
            }
            set
            {
                _dispatchQuantity = value;
            }
        }

        private int _dispatchMinQuantity;
        public int dispatchMinQuantity
        {
            get
            {
                return _dispatchMinQuantity;
            }
            set
            {
                _dispatchMinQuantity = value;
            }
        }
    }
}
