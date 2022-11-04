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
    public class DeliveriesController : ApiController
    {
        private readonly DeliveryBAL _bl = new DeliveryBAL();


        // GET: Deliveries/User_Id
        [HttpGet]
        [Route("api/deliveries/user/{User_Id:int}")]
        public IHttpActionResult GetAll(int User_Id)
        {
            try
            {
                List<Delivery> temp = _bl.GetAllUserDeliveries(User_Id);
                if (temp == null)
                    return Content(HttpStatusCode.NotFound, $"No have deliveries...");
                else
                    return Ok(temp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: Deliveries/User_Id
        [HttpGet]
        [Route("api/deliveries/active/user/{User_Id:int}")]
        public IHttpActionResult GetActive(int User_Id)
        {
            try
            {
                List<Delivery> temp = _bl.GetActiveUserDeliveries(User_Id);
                if (temp == null)
                    return Content(HttpStatusCode.NotFound, $"No active deliveries...");
                else
                    return Ok(temp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: Deliveries/User_Id
        [HttpGet]
        [Route("api/deliveries/close/user/{User_Id:int}")]
        public IHttpActionResult GetClose(int User_Id)
        {
            try
            {
                List<Delivery> temp = _bl.GetCloseUserDeliveries(User_Id);
                if (temp == null)
                    return Content(HttpStatusCode.NotFound, $"No close deliveries...");
                else
                    return Ok(temp);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST
        [Route("api/deliveries/add")]
        public IHttpActionResult Post([FromBody] Delivery delivery)
        {
            try
            {
                List<Delivery> deliveries = _bl.AddNewDeliveryToDb(delivery);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + deliveries[0].Delivery_Id), deliveries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
