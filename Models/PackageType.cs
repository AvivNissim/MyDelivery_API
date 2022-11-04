using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.Models
{
    public class PackageType
    {
        public int Package_Type_Code { get; set; }
        public string Package_Type_Name { get; set; }
        public override string ToString()
        {
            return $"Type Code: {Package_Type_Code}, {Package_Type_Name}";
        }
    }
}