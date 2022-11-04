using MyDelivery_API.DALProj;
using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.BALProj
{
    public class UserBAL
    {
        private readonly UserData _data = new UserData();

        public List<User> Register(User user)
        {
           return _data.AddUser(user);
        }

        public List<User> Login(string email, string password)
        {
            return _data.CheckUser(email, password);
        }

        public void UpdateDetails(User user)
        {
            _data.UpdateUser(user);
        }
    }
}