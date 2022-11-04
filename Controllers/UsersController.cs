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
    public class UsersController : ApiController
    {
        private readonly UserBAL _bl = new UserBAL();

        [HttpPost]
        [Route("api/users/login")]
        public IHttpActionResult Login([FromBody] User user)
        {
            try
            {
                return Ok(_bl.Login(user.Email, user.Password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/users/register")]
        public IHttpActionResult Register([FromBody] User user)
        {
            try
            {
                List<User> users = _bl.Register(user);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + users[0].Id), users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT
        [Route("api/users/edit")]
        public IHttpActionResult Put([FromBody] User user)
        {
            try
            {
                _bl.UpdateDetails(user);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + user.Id), user);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
