using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyDelivery_API.DALProj
{
    public class DeliveryTypeData
    {
        private DbServices _db = DbServices.GetDbServices();

        public List<DeliveryType> GetDeliveryTypes(int Delivery_Type_Code = 0)
        {
            string sql = "Select * From DeliveryTypes";
            if (Delivery_Type_Code != 0)
                sql += $"Where Delivery_Type_Code = {Delivery_Type_Code}";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<DeliveryType>(dt);
        }

        public void AddDeliveryType(DeliveryType deliveryType)
        {
            string sql = $@"Insert Into DeliveryTypes(Delivery_Type_Code, Delivery_Type_Name)
                            Valuse({deliveryType.Delivery_Type_Code}, N'{deliveryType.Delivery_Type_Name}'";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }

        public void UpdateDeliveryType(int Delivery_Type_Code, DeliveryType deliveryType)
        {
            string sql = $@"Update DeliveryTypes Set [Delivery_Type_Code] = {deliveryType.Delivery_Type_Code},
                                [Delivery_Type_Name] = N'{deliveryType.Delivery_Type_Name}'
                                Where [Delivery_Type_Code] = {Delivery_Type_Code}";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }

        public void DeleteDeliveryType(int Delivery_Type_Code)
        {
            string sql = $@"Delete From DeliveryTypes Where [Delivery_Type_Code] = {Delivery_Type_Code}";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }
    }
}