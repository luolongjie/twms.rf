using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class Mccode
    {
        private string _data;
        public string data
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
}
