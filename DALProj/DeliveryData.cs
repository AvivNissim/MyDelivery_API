using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyDelivery_API.DALProj
{
    public class DeliveryData
    {
        private readonly DbServices _db = DbServices.GetDbServices();

        public List<Delivery> GetDeliveries(int User_Id = 0)
        {
            string sql = "Select * From DeliveryView ";
            if (User_Id != 0)
                sql += $"Where User_Id = {User_Id}";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<Delivery>(dt);
        }

        public List<Delivery> AddDelivery(Delivery delivery)
        {
            string sql = $"Exec InsertDelivery '{delivery.Delivery_Date}',N'{delivery.From_City}',N'{delivery.To_City}'," +
                $"N'{delivery.From_Address}',N'{delivery.To_Address}'," +
                $"{delivery.Package_Type_Code},N'{delivery.Package_Type_Name}',N'{delivery.Delivery_Comment}'," +
                $"{delivery.User_Id},{delivery.Is_Finished},{delivery.Price}";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<Delivery>(dt);
        }

        public List<Delivery> GetActiveDeliveries(int User_Id = 0)
        {
            string sql = "Select * From DeliveryView Where Is_Finished = 0";
            if (User_Id != 0)
                sql += $"And User_Id = {User_Id}";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<Delivery>(dt);
        }

        public List<Delivery> GetCloseDeliveries(int User_Id = 0)
        {
            string sql = "Select * From DeliveryView Where Is_Finished = 1";
            if (User_Id != 0)
                sql += $"And User_Id = {User_Id}";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<Delivery>(dt);
        }
    }
}