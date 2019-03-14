using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MstockIn
    {
        private MstockIns _data;
        public MstockIns data
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
    public class MstockIns
    {
        private List<material> _materialList;
        public List<material> materialList
        {
            get
            {
                return _materialList;
            }
            set
            {
                _materialList = value;
            }
        }
        private bool _overchargesFlag;
         public bool overchargesFlag
        {
            get
            {
                return _overchargesFlag;
            }
            set
            {
                _overchargesFlag = value;
            }
        }
        

        private shipper _shipperInfo;
        public shipper shipperInfo
        {
            get
            {
                return _shipperInfo;
            }
            set
            {
                _shipperInfo = value;
            }
        }
    }

   
    

    [Serializable]
    public class shipper
    {
        private string _shipperCode;
        public string shipperCode
        {
            get
            {
                return _shipperCode;
            }
            set
            {
                _shipperCode = value;
            }
        }

        private string _blNo;
         public string blNo
        {
            get
            {
                return _blNo;
            }
            set
            {
                _blNo = value;
            }
        }

        

        private string _shipperName;
        public string shipperName
        {
            get
            {
                return _shipperName;
            }
            set
            {
                _shipperName = value;
            }
        }
    }
}
