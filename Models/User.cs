using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Phone_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City_Name { get; set; }
        public string Address_Name { get; set; }
        public override string ToString()
        {
            return $"#{Id}, Name: {First_Name} {Last_Name}\n" +
                $"Mail: {Email}, City: {City_Name}, Address: {Address_Name}";
        }
    }
}