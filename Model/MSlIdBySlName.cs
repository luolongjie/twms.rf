using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MSlIdBySlName
    {
         private SlIdBySlNames _data;
        public SlIdBySlNames data
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
    public class SlIdBySlNames
    {
        private int _slId;
        public int slId
        {
            get
            {
                return _slId;
            }
            set
            {
                _slId = value;
            }
        }
    }
}
