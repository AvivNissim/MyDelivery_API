using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.Models
{
    public class DeliverymanInDelivery
    {
        public string Id_Num { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public int User_Id { get; set; }
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }
        public string User_Phone { get; set; }
        public int Delivery_Id { get; set; }
        public string Delivery_Date { get; set; }
        public string From_City { get; set; }
        public string From_Address { get; set; }
        public string To_City { get; set; }
        public string To_Address { get; set; }
        public int Package_Type_Code { get; set; }
        public string Package_Type_Name { get; set; }
        public bool Is_Finished { get; set; }
        public string Delivery_Comment { get; set; }
        public int Price { get; set; }

    }
}