using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MCVreason
    {
        private string _des;
        public string des
        {
            get
            {
                return _des;
            }
            set
            {
                _des = value;
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
    }
}
