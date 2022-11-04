using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.Models
{
    public class City
    {
        public int City_Code { get; set; }
        public string City_Name { get; set; }
        public override string ToString()
        {
            return $"City #{City_Code}, Name: {City_Name}";
        }
    }
}