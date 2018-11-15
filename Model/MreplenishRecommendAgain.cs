using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    
    [Serializable]
    public class MreplenishRecommendAgain
    {
        private replenishRecommendAgains _data;
        public replenishRecommendAgains data
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
    public class replenishRecommendAgains
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

        private int _recommendId;
        public int recommendId
        {
            get
            {
                return _recommendId;
            }
            set
            {
                _recommendId = value;
            }
        }
    }
}
