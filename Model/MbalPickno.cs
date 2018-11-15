using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MbalPickno
    {
        private List<balPicknos> _data;
        public List<balPicknos> data
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
    public class balPicknos
    {
        private string _pickNo;
        public string pickNo
        {
            get
            {
                return _pickNo;
            }
            set
            {
                _pickNo = value;
            }
        }

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


    }
}
