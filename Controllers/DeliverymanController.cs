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
    public class DeliverymanController : ApiController
    {
        private readonly DeliverymanBAL _bl = new DeliverymanBAL();

        [HttpPost]
        [Route("api/deliveryman/login")]
        public IHttpActionResult Login([FromBody] Deliveryman deliveryman)
        {
            try
            {
                return Ok(_bl.LoginDeliveryman(deliveryman.Email, deliveryman.Password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/deliveryman/register")]
        public IHttpActionResult Register([FromBody] Deliveryman deliveryman)
        {
            try
            {
                List<Deliveryman> deliverymanList = _bl.Register(deliveryman);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + deliverymanList[0].Id_Num), deliverymanList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/deliveryman/edit")]
        public IHttpActionResult Update([FromBody] Deliveryman deliveryman)
        {
            try
            {
                _bl.UpdateDetails(deliveryman);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + deliveryman.Id_Num), deliveryman);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
