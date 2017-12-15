using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class Mlogin
    {
        private MloginBody _data;
        public MloginBody data
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
    public class MloginBody
    {
        private string _lcCode;
        public string lcCode
        {
            get
            {
                return _lcCode;
            }
            set
            {
                _lcCode = value;
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

        private List<Twarehouse> _warehourseList;
        public List<Twarehouse> warehourseList
        {
            get
            {
                return _warehourseList;
            }
            set
            {
                _warehourseList = value;
            }
        }

    }
}
