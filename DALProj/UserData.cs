using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyDelivery_API.DALProj
{
    public class UserData
    {
        private DbServices _db = DbServices.GetDbServices();

        public List<User> AddUser(User user) // Register
        {
            try
            {
                string sql = $"Exec Add_New_User '{user.Phone_Number}',N'{user.First_Name}',N'{user.Last_Name}','{user.Email}'," +
                    $"N'{user.City_Name}',N'{user.Address_Name}',{user.Password}";
                SqlCommand cmd = _db.CreateCommand(sql);
                DataTable dt = _db.Select(cmd);
                return _db.ConvertDataTable<User>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> CheckUser(string email, string password) // Login
        {
            try
            {
                string sql = $"Select * from dbo.LoginUser('{email}', '{password}')";
                SqlCommand cmd = _db.CreateCommand(sql);
                DataTable dt = _db.Select(cmd);
                return _db.ConvertDataTable<User>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(User user) // Update User
        {
            string sql = $"Exec Update_Details N'{user.First_Name}',N'{user.Last_Name}','{user.Phone_Number}'," +
                $"'{user.Email}',N'{user.City_Name}',N'{user.Address_Name}', '{user.Password}', {user.Id}";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }
    }
}