using MyDelivery_API.DALProj;
using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.BALProj
{
    public class DeliveryBAL
    {
        private readonly DeliveryData _data = new DeliveryData();

        public List<Delivery> GetAllDeliveriesFromDb()
        {
            return _data.GetDeliveries();
        }

        public List<Delivery> GetAllUserDeliveries(int User_Id)
        {
            return _data.GetDeliveries(User_Id);
        }

        public List<Delivery> AddNewDeliveryToDb(Delivery delivery)
        {
            return _data.AddDelivery(delivery);
        }

        public List<Delivery> GetActiveUserDeliveries(int User_Id)
        {
            return _data.GetActiveDeliveries(User_Id);
        }

        public List<Delivery> GetCloseUserDeliveries(int User_Id)
        {
            return _data.GetCloseDeliveries(User_Id);
        }
    }
}