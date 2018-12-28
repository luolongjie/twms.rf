using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class PickRrList
    {
        private List<PickRrLists> _data;
        public List<PickRrLists> data
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
    public class PickRrLists
    {
        private string _rrId;
        public string rrId
        {
            get
            {
                return _rrId;
            }
            set
            {
                _rrId = value;
            }
        }

        private string _rrName;
        public string rrName
        {
            get
            {
                return _rrName;
            }
            set
            {
                _rrName = value;
            }
        }

        private string _sortFlg;
        public string sortFlg
        {
            get
            {
                return _sortFlg;
            }
            set
            {
                _sortFlg = value;
            }
        }

        private string _assistanceName;
         public string assistanceName
        {
            get
            {
                return _assistanceName;
            }
            set
            {
                _assistanceName = value;
            }
        }

        
    }
}
