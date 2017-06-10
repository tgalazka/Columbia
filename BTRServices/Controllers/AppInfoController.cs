using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTRServices.Repository;
using Swashbuckle.Swagger.Annotations;


namespace BTRServices.Controllers
{
    public class AppInfoController : ApiController
    {
        // GET: AppInfo

        [HttpGet]
        [ActionName("Version")]
        [SwaggerOperation("AccountBalances")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetVersion()
        {
            return Ok("1.0.0.0");
        }

    }
}