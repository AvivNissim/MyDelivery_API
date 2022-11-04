using MyDelivery_API.DALProj;
using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.BALProj
{
    public class DeliverymanBAL
    {
        private readonly DeliverymanData _data = new DeliverymanData();

        public List<Deliveryman> Register(Deliveryman deliveryman)
        {
            return _data.AddDeliveryman(deliveryman);
        }

        public List<Deliveryman> LoginDeliveryman(string email, string password)
        {
            return _data.CheckDeliveryman(email, password);
        }

        public void UpdateDetails(Deliveryman deliveryman)
        {
            _data.UpdateDeliveryman(deliveryman);
        }
    }
}