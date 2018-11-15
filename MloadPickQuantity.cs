using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MloadPickQuantity
    {
        private loadPickQuantitys _data;
        public loadPickQuantitys data
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
    public class loadPickQuantitys
    {
        

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
    }
}
