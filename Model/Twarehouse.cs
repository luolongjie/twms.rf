using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class Twarehouse
    {
        private string _whId;
        public string whId
        {
            get
            {
                return _whId;
            }
            set
            {
                _whId = value;
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
