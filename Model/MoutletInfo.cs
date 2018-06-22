using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MoutletInfo
    {
        private List<outletInfos> _data;
        public List<outletInfos> data
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
    public class outletInfos
    {
        private string _outletCode;
        public string outletCode
        {
            get
            {
                return _outletCode;
            }
            set
            {
                _outletCode = value;
            }
        }

        private string _outletName;
        public string outletName
        {
            get
            {
                return _outletName;
            }
            set
            {
                _outletName = value;
            }
        }

       
    }
}
