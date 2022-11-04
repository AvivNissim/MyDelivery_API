using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.Models
{
    public class Address
    {
        public int Address_Code { get; set; }
        public string Address_Name { get; set; }
        public int City_Code { get; set; }
        public override string ToString()
        {
            return $"#{Address_Code} \nName:{Address_Name}\nCity:{City_Code}";
        }
    }
}