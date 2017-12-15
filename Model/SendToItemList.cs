using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Rf_Wms.Model
{
    public class SendToItemList
    {
        private List<SendToItemLists> _data;
        public List<SendToItemLists> data
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

    public class SendToOneItem
    {
        private SendToItemLists _data;
        public SendToItemLists data
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

    public class SendToItemLists
    {
        private string _materialCode;
        public string materialCode
        {
            get
            {
                return _materialCode;
            }
            set
            {
                _materialCode = value;
            }
        }

        private string _materialName;
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                _materialName = value;
            }
        }

        private string _commonUnitName;
        public string commonUnitName
        {
            get
            {
                return _commonUnitName;
            }
            set
            {
                _commonUnitName = value;
            }
        }

        private string _minUnitName;
        public string minUnitName
        {
            get
            {
                return _minUnitName;
            }
            set
            {
                _minUnitName = value;
            }
        }

       



        private int _quantity;
        public int quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        private int _minQuantity;
        public int minQuantity
        {
            get
            {
                return _minQuantity;
            }
            set
            {
                _minQuantity = value;
            }
        }

        private int _orderQuantity;
        public int orderQuantity
        {
            get
            {
                return _orderQuantity;
            }
            set
            {
                _orderQuantity = value;
            }
        }

        private int _orderMinQuantity;
        public int orderMinQuantity
        {
            get
            {
                return _orderMinQuantity;
            }
            set
            {
                _orderMinQuantity = value;
            }
        }



        private string _sendToDetailId;
        public string sendToDetailId
        {
            get
            {
                return _sendToDetailId;
            }
            set
            {
                _sendToDetailId = value;
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

        private string _outletAddress;
        public string outletAddress
        {
            get
            {
                return _outletAddress;
            }
            set
            {
                _outletAddress = value;
            }
        }

        private string _id;
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }
}
