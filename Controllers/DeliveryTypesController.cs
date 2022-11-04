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
    public class DeliveryTypesController : ApiController
    {
        private readonly DeliveryTypeBAL _bl = new DeliveryTypeBAL();

        // GET: DeliveryTypes
        [Route("api/DeliveryTypes/All")]
        public IHttpActionResult Get()
        {
            return Ok(_bl.GetAllDeliveryTypesFromDb());
        }


        // GET: DeliveryTypes/Delivery_Type_Code
        [Route("api/DeliveryTypes/{Delivery_Type_Code:int}")]
        public IHttpActionResult Get(int Delivery_Type_Code)
        {
            try
            {
                List<DeliveryType> temp = _bl.GetSingleDeliveryTypeFromDb(Delivery_Type_Code);
                if (temp == null)
                    return Content(HttpStatusCode.NotFound, $"The delivery type with code = {Delivery_Type_Code} Not Found");
                else
                    return Ok(temp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST
        public IHttpActionResult Post([FromBody] DeliveryType deliveryType)
        {
            try
            {
                //DeliveryType newDeliveryType = new DeliveryType(deliveryType.Delivery_Type_Code, deliveryType.Delivery_Type_Name);
                _bl.AddNewDeliveryTypeToDb(deliveryType);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + deliveryType.Delivery_Type_Code), deliveryType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
