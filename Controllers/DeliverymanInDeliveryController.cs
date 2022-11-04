using MyDelivery_API.BALProj;
using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyDelivery_API.Controllers
{
    public class DeliverymanInDeliveryController : ApiController
    {
        private readonly DeliverymanInDeliveryBAL _bl = new DeliverymanInDeliveryBAL();


        [HttpGet, Route("api/DeliverymanInDelivery/AllWaitingDeliveries")]
        public IHttpActionResult AllWaitingDeliveries()
        {
            try
            {
                return Ok(_bl.AllWaitingDeliveries());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet, Route("api/DeliverymanInDelivery/Open/{Id_Num}")]
        public IHttpActionResult AllMyOpenDeliveries(string Id_Num)
        {
            try
            {
                return Ok(_bl.AllMyOpenDeliveries(Id_Num));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet, Route("api/DeliverymanInDelivery/Close/{Id_Num}")]
        public IHttpActionResult AllMyClosedDeliveries(string Id_Num)
        {
            try
            {
                return Ok(_bl.AllMyClosedDeliveries(Id_Num));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost, Route("api/DeliverymanInDelivery/Asign")]
        public IHttpActionResult AsignDeliverymanToDelivery([FromBody] DeliverymanInDelivery deliverymanInDelivery)
        {
            try
            {
                List<DeliverymanInDelivery> inDeliveries = _bl.AsignToDelivery(deliverymanInDelivery.Id_Num,
                    deliverymanInDelivery.User_Id,deliverymanInDelivery.Delivery_Id);
                return Created(new Uri(Request.RequestUri.AbsoluteUri), inDeliveries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
