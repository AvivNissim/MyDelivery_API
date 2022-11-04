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
    public class AddressesController : ApiController
    {
        private readonly AddressBAL _bl = new AddressBAL();

        // GET: Addresses
        [Route("api/Addresses/All")]
        public IHttpActionResult Get()
        {
            return Ok(_bl.GetAllAddressesFromDb());
        }


        // GET: Addresses/Address_Code
        [Route("api/Addresses/{Address_Code:int}")]
        public IHttpActionResult Get(int Address_Code)
        {
            try
            {
                List<Address> temp = _bl.GetSingleAddressFromDb(Address_Code);
                if (temp == null)
                    return Content(HttpStatusCode.NotFound, $"The address with Address Code = {Address_Code} Not Found");
                else
                    return Ok(temp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST
        public IHttpActionResult Post([FromBody] Address address)
        {
            try
            {
                _bl.AddNewAddressToDb(address);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + address.Address_Code), address);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        // PUT
        [Route("api/Addresses/{Address_Code:int}")]
        public IHttpActionResult Put(int Address_Code, [FromBody] Address address)
        {
            try
            {
                _bl.UpdateAddressFromDb(Address_Code, address);
                return Ok("Address Update Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //DELETE
        [Route("api/Addresses/{Address_Code:int}")]
        public IHttpActionResult Delete(int Address_Code)
        {
            try
            {
                _bl.DeleteAddressFromDb(Address_Code);
                return Ok("Address Deleted Successfully");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
