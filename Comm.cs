using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Rf_Wms
{
    public class Comm
    {
        public static string url = "";
        public static string upd = "";

        public static string lcCode = "";

        public static string userame = "";

        public static string usercode = "";

        public static string version = "";

        public static string warehousecode = "";

        public static string warehousename = "";

        public static bool islog = true;

        public static Model.MbaseIn basein = null;

        public static List<Model.Twarehouse> warehouseList = new List<Rf_Wms.Model.Twarehouse>();
        public static string fun = "";
        public static string par = "";
        public static string retval = "";
        public static string GetMsg()
        {
            return "";
        }

        public static DataTable GetDT(List<Model.material> mlist)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("materialCode");
            dt.Columns.Add("materialName");
            dt.Columns.Add("pdate");
            dt.Columns.Add("batchNo");
            dt.Columns.Add("qty");
            dt.Columns.Add("slName");
            dt.Columns.Add("fromSlIdName");
            dt.Columns.Add("toSlIdName");
            dt.Columns.Add("trayCode");
            dt.Columns.Add("spec");
            DataRow dr;
            foreach (Model.material v in mlist)
            {
                if (v.quantity == v.realQuantity && v.minQuantity == v.realMinquantity)
                    continue;
                dr = dt.NewRow();
                dr["materialCode"] = v.materialCode;
                dr["materialName"] = v.materialName;
                if (!string.IsNullOrEmpty(v.pdate))
                {
                    dr["pdate"] = v.pdate;
                }
                else
                {
                    dr["pdate"] = "";
                }
                if (!string.IsNullOrEmpty(v.batchNo))
                {
                    dr["batchNo"] = v.batchNo;
                }
                else
                {
                    dr["batchNo"] = "";
                }
                dr["slName"] = v.slName;
                int _quantity = v.quantity - v.realQuantity;
                //if (_quantity < 0)
                //    _quantity = 0;
                int _minquantity = v.minQuantity - v.realMinquantity;
                //if (_minquantity < 0)
                //    _minquantity = 0;

                if (_quantity < 0 || _minquantity<0)
                {
                    int imax = _quantity * v.spec + _minquantity;
                    //_quantity = (int)(Math.Ceiling(((double)(imax) / v.spec)));
                    _quantity = imax / v.spec;
                    _minquantity = imax % v.spec;

                }
                dr["qty"] = _quantity.ToString() + v.commonUnitName + _minquantity.ToString() + v.minUnitName;
                dr["fromSlIdName"] = v.fromSlIdName;
                dr["toSlIdName"] = v.toSlIdName;
                dr["trayCode"] = v.trayCode;
                dr["spec"] = v.spec;
                if (string.IsNullOrEmpty(v.pdate))
                {
                    v.pdate = "";
                }
                if (string.IsNullOrEmpty(v.batchNo))
                {
                    v.batchNo = "";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
