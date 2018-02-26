using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MAssisterByOperation
    {
        private List<Assisters> _data;
        public List<Assisters> data
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
