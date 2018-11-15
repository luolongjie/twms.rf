using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MbalPdate
    {
        private List<balPdates> _data;
        public List<balPdates> data
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

    public class balPdates
    {
        private string _pDate;
        public string pDate
        {
            get
            {
                return _pDate;
            }
            set
            {
                _pDate = value;
            }
        }

        private string _pdateString;
        public string pdateString
        {
            get
            {
                return _pdateString;
            }
            set
            {
                _pdateString = value;
            }
        }
    }
}
