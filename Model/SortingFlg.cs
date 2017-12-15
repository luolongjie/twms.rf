using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class SortingFlg
    {
        private SortingFlgs _data;
        public SortingFlgs data
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
    public class SortingFlgs
    {
        private bool _sortingFlg;
        public bool sortingFlg
        {
            get
            {
                return _sortingFlg;
            }
            set
            {
                _sortingFlg = value;
            }
        }
    }
}
