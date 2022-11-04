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
    public class CitiesController : ApiController
    {
        private readonly CityBAL _bl = new CityBAL();

        // GET: Cities
        [Route("api/Cities/All")]
        public IHttpActionResult Get()
        {
            return Ok(_bl.GetAllCitiesFromDb());
        }

        // GET: Cities/City_Code
        [Route("api/Cities/{City_Code:int}")]
        public IHttpActionResult Get(int City_Code)
        {
            try
            {
                List<City> temp = _bl.GetSingleCityFromDb(City_Code);
                if (temp == null)
                    return Content(HttpStatusCode.NotFound, $"The city with City Code = {City_Code} Not Found");
                else
                    return Ok(temp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST
        public IHttpActionResult Post([FromBody] City city)
        {
            try
            {
                _bl.AddNewCityToDb(city);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + city.City_Code), city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT
        [Route("api/Cities/{City_Code:int}")]
        public IHttpActionResult Put(int City_Code, [FromBody] City city)
        {
            try
            {
                _bl.UpdateCityFromDb(City_Code, city);
                return Ok("City Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE
        [Route("api/Cities/{City_Code:int}")]
        public IHttpActionResult Delete(int City_Code)
        {
            try
            {
                _bl.DeleteCityFromDb(City_Code);
                return Ok("City Deleted Successfully");
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
    }
}
