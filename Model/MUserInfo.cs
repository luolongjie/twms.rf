using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class MUserInfo
    {
        private MUser _data;
        public MUser data
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
    public class MUser
    {
        private string _userCode;
        public string userCode
        {
            get
            {
                return _userCode;
            }
            set
            {
                _userCode = value;
            }
        }

        private string _userName;
        public string userName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
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
