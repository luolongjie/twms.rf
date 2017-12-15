using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MgetMaterial
    {
        private List<MgetMaterialbody> _data;
        public List<MgetMaterialbody> data
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
    public class MgetMaterialbody
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

        private int _itemId;
        public int itemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
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
        
       
    }
}
