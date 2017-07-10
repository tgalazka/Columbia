using BTRServices.DAL;
using BTRServices.Models;
using BTRServices.Repository;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTRServices.Controllers
{
    public class UserController : ApiController
    {
        private BtrDbContext db = new BtrDbContext();

        // GET: api/Btr
        [HttpGet]
        [ActionName("ByUni")]
        [SwaggerOperation("ByUni")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]

        public IHttpActionResult ByUni(string uni)
        {
            try
            {
                UserRepository user = new UserRepository(db);
                return Ok(user.ByUni(uni));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "ByUni").ToString()));
            }
        }

        // GET: api/User
        [HttpGet]
        [ActionName("ByEmail")]
        [SwaggerOperation("ByEmail")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]

        public IHttpActionResult ByEmail(string email)
        {
            try
            {
                UserRepository user = new UserRepository(db);
                return Ok(user.ByEmail(email));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "ByEmail").ToString()));
            }
        }

    }
}
