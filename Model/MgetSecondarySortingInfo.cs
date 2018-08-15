using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    [Serializable]
    public class MgetSecondarySortingInfo
    {
        private List<SecondarySortingInfos> _data;
        public List<SecondarySortingInfos> data
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
    public class SecondarySortingInfos
    {
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

        private string _stockOutNo;
        public string stockOutNo
        {
            get
            {
                return _stockOutNo;
            }
            set
            {
                _stockOutNo = value;
            }
        }

        private string _stockOutItemId;
        public string stockOutItemId
        {
            get
            {
                return _stockOutItemId;
            }
            set
            {
                _stockOutItemId = value;
            }
        }

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

         private int _trainFrequency;
         public int trainFrequency
         {
             get
             {
                 return _trainFrequency;
             }
             set
             {
                 _trainFrequency = value;
             }
         }

         private string _platePlan;
         public string platePlan
         {
             get
             {
                 return _platePlan;
             }
             set
             {
                 _platePlan = value;
             }
         }

         private int _pickQuantity;
         public int pickQuantity
         {
             get
             {
                 return _pickQuantity;
             }
             set
             {
                 _pickQuantity = value;
             }
         }

         private int _pickMinQuantity;
         public int pickMinQuantity
         {
             get
             {
                 return _pickMinQuantity;
             }
             set
             {
                 _pickMinQuantity = value;
             }
         }

         private string _sendToCode;
         public string sendToCode
         {
             get
             {
                 return _sendToCode;
             }
             set
             {
                 _sendToCode = value;
             }
         }

         private string _sendToName;
         public string sendToName
         {
             get
             {
                 return _sendToName;
             }
             set
             {
                 _sendToName = value;
             }
         }
    }
}
