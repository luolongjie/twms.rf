using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MBalanceBarcode
    {
        private List<BalanceBarcodes> _data;
        public List<BalanceBarcodes> data
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
    public class BalanceBarcodes
    {
        private string _materialCode;
        public string materialCode
        {
            get
            {
                return _materialCode;
            }
            set
            {
                _materialCode = value;
            }
        }

        private string _materialName;
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                _materialName = value;
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

        private string _pDate;
        public string pDate
        {
            get
            {
                return _pDate;
            }
            set
            {
                _pDate = value;
            }
        }

        private string _pdateString;
        public string pdateString
        {
            get
            {
                return _pdateString;
            }
            set
            {
                _pdateString = value;
            }
        }
    }
}
