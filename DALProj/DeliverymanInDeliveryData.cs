using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyDelivery_API.DALProj
{
    public class DeliverymanInDeliveryData
    {
        private readonly DbServices _db = DbServices.GetDbServices();

        public List<DeliverymanInDelivery> WaitingDeliveries()
        {
            string sql = $"Select * From WaitingOrdersView Where Is_Finished = 0";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<DeliverymanInDelivery>(dt);
        }

        public List<DeliverymanInDelivery> MyOpenDeliveries(string Id_Num)
        {
            string sql = $"Select * From DeliverymanInDeliveriesView Where Id_Num = '{Id_Num}' And Is_Finished = 0";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<DeliverymanInDelivery>(dt);
        }

        public List<DeliverymanInDelivery> MyClosedDeliveries(string Id_Num)
        {
            string sql = $"Select * From DeliverymanInDeliveriesView Where Id_Num = '{Id_Num}' And Is_Finished = 1";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<DeliverymanInDelivery>(dt);
        }

        public List<DeliverymanInDelivery> AddDeliverymanToDelivery(string Id_num, int User_Id, int Delivery_Id)
        {
            string sql = $"Exec InsertDeliverymanToDelivery '{Id_num}', {User_Id}, {Delivery_Id}";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<DeliverymanInDelivery>(dt);
        }
    }
}