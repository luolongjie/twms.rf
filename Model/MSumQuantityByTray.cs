using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MSumQuantityByTray
    {
        private MSumQuantityByTrays _data;
        public MSumQuantityByTrays data
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
    public class MSumQuantityByTrays
    {
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
    }

}
