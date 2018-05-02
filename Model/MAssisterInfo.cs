using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MAssisterInfo
    {
        private Assisters _data;
        public Assisters data
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
    public class Assisters
    {
        private string _companyCode;
        public string companyCode
        {
            get
            {
                return _companyCode;
            }
            set
            {
                _companyCode = value;
            }
        }

        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
