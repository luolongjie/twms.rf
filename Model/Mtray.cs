using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class Mtray
    {
        private tray _data;
        public tray data
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
    public class tray
    {
        private string _trayCode;
        public string trayCode
        {
            get
            {
                return _trayCode;
            }
            set
            {
                _trayCode = value;
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

        private string _qtStatus;
         public string qtStatus
        {
            get
            {
                return _qtStatus;
            }
            set
            {
                _qtStatus = value;
            }
        }
        
    }
}
