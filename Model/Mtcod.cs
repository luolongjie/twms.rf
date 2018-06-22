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
    }
}
