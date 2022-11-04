using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.Models
{
    public class Deliveryman
    {
        public string Id_Num { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Driving_License { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"ID: {Id_Num}\n" +
                $"Name: {First_Name} {Last_Name}\n" +
                $"Phone: {Phone_Number}\n" +
                $"Driving Licensie: {Driving_License}";
        }
    }
}