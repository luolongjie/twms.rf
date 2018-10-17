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
    }
}
