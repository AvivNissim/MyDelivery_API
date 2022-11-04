using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.Models
{
    public class Delivery
    {
        public int Delivery_Id { get; set; }
        public int User_Id { get; set; }
        public string Delivery_Date { get; set; }
        public string From_City { get; set; }
        public string To_City { get; set; }
        public string From_Address { get; set; }
        public string To_Address { get; set; }
        public int Package_Type_Code { get; set; }
        public string Delivery_Comment { get; set; }
        public bool Is_Finished { get; set; }
        public int Price { get; set; }
        public string Package_Type_Name { get; set; }
        public override string ToString()
        {
            return $"#{Delivery_Id} Date: {Delivery_Date}\n" +
                $"From: {From_City}, {From_Address}\n" +
                $"To: {To_City}, {To_Address}\n" +
                $"Delivery: {Package_Type_Code}\n" +
                $"Comment: {Delivery_Comment}";
        }
    }
}