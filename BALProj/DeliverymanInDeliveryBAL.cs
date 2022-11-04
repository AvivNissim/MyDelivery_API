using MyDelivery_API.DALProj;
using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.BALProj
{
    public class DeliverymanInDeliveryBAL
    {
        private readonly DeliverymanInDeliveryData _data = new DeliverymanInDeliveryData();

        public List<DeliverymanInDelivery> AllWaitingDeliveries()
        {
            return _data.WaitingDeliveries();
        }

        public List<DeliverymanInDelivery> AllMyOpenDeliveries(string Id_Num)
        {
            return _data.MyOpenDeliveries(Id_Num);
        }

        public List<DeliverymanInDelivery> AllMyClosedDeliveries(string Id_Num)
        {
            return _data.MyClosedDeliveries(Id_Num);
        }

        public List<DeliverymanInDelivery> AsignToDelivery(string Id_Num, int User_Id, int Delivery_Id)
        {
            return _data.AddDeliverymanToDelivery(Id_Num, User_Id, Delivery_Id);
        }
    }
}