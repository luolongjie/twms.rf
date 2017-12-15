using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class Mmaterialcode
    {
        private List<Mmaterialcodebody> _data;
        public List<Mmaterialcodebody> data
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
    public class Mmaterialcodebody
    {
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

        private string _commonUnit;
        public string commonUnit
        {
            get
            {
                return _commonUnit;
            }
            set
            {
                _commonUnit = value;
            }
        }

        private string _minUnit;
        public string minUnit
        {
            get
            {
                return _minUnit;
            }
            set
            {
                _minUnit = value;
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

           
    }
}
