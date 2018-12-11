using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MUsePlate
    {
        private List<useplates> _data;
        public List<useplates> data
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
    public class useplates
    {
        private string _plateNo;
        public string plateNo
        {
            get
            {
                return _plateNo;
            }
            set
            {
                _plateNo = value;
            }
        }

        private string _tcod;
        public string tcod
        {
            get
            {
                return _tcod;
            }
            set
            {
                _tcod = value;
            }
        }
    }
}
