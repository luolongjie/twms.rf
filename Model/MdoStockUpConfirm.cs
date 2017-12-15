using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MdoStockUpConfirm
    {
        private MdoStockUpConfirms _data;
        public MdoStockUpConfirms data
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
    public class MdoStockUpConfirms
    {
        private string _stockUpConfirmMsg;
        public string stockUpConfirmMsg
        {
            get
            {
                return _stockUpConfirmMsg;
            }
            set
            {
                _stockUpConfirmMsg = value;
            }
        }

        private int _pickQuantity;
        public int pickQuantity
        {
            get
            {
                return _pickQuantity;
            }
            set
            {
                _pickQuantity = value;
            }
        }

        private int _pickMinQuantity;
        public int pickMinQuantity
        {
            get
            {
                return _pickMinQuantity;
            }
            set
            {
                _pickMinQuantity = value;
            }
        }

        private int _checkQuantity;
        public int checkQuantity
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

        private int _checkMinQuantity;
        public int checkMinQuantity
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

        private int _checkOrderQuantity;
        public int checkOrderQuantity
        {
            get
            {
                return _checkOrderQuantity;
            }
            set
            {
                _checkOrderQuantity = value;
            }
        }

        private int _checkOrderMinQuantity;
        public int checkOrderMinQuantity
        {
            get
            {
                return _checkOrderMinQuantity;
            }
            set
            {
                _checkOrderMinQuantity = value;
            }
        }
    }
}
