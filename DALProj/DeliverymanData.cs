using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyDelivery_API.DALProj
{
    public class DeliverymanData
    {
        private readonly DbServices _db = DbServices.GetDbServices();

        public List<Deliveryman> AddDeliveryman(Deliveryman deliveryman) // Register
        {
            string sql = $"Exec Add_New_Deliveryman '{deliveryman.Id_Num}', N'{deliveryman.First_Name}'," +
                $"N'{deliveryman.Last_Name}','{deliveryman.Phone_Number}','{deliveryman.Driving_License}'," +
                $"'{deliveryman.Email}', '{deliveryman.Password}'";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<Deliveryman>(dt);
        }

        public List<Deliveryman> CheckDeliveryman(string email, string password) // Login
        {
            try
            {
                string sql = $"Select * from dbo.LoginDeliveryman('{email}', '{password}')";
                SqlCommand cmd = _db.CreateCommand(sql);
                DataTable dt = _db.Select(cmd);
                return _db.ConvertDataTable<Deliveryman>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDeliveryman(Deliveryman deliveryman) // Update Deliveryman
        {
            string sql = $"Exec Update_Deliveryman_Details N'{deliveryman.First_Name}',N'{deliveryman.Last_Name}'," +
                $"'{deliveryman.Phone_Number}','{deliveryman.Email}'," +
                $"'{deliveryman.Password}',{deliveryman.Id_Num}";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }
    }
}