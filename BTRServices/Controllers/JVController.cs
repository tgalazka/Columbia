using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTRServices.Repository;
using Swashbuckle.Swagger.Annotations;
using BTRServices.Models;
using BTRServices.DAL;

namespace BTRServices.Controllers
{
    public class JVController : ApiController
    {
        BtrDbContext dbCxt = new BtrDbContext();

        [HttpPost]
        [ActionName("Create")]
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult CreateJV(int btr_key)
        {
            try
            {
                JvRepository dbData = new JvRepository(dbCxt);
                dbData.CreateJV(btr_key);
                return Ok();
            }
            catch (Exception exError)
            {
                if (exError.InnerException != null)
                {
                    return BadRequest((new Error(0, exError.InnerException.ToString(), "CreateJV").ToString()));
                }
                return BadRequest((new Error(0, exError.Message, "CreateJV").ToString()));
            }
        }
        [HttpGet]
        [ActionName("Status")]
        [SwaggerOperation("Status")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetStatus(int btr_key)
        {
            try
            {
                JvRepository dbData = new JvRepository(dbCxt);
                dbData.GetStatus(btr_key);
                return Ok();
            }
            catch (Exception exError)
            {
                if (exError.InnerException != null)
                {
                    return BadRequest((new Error(0, exError.InnerException.ToString(), "CreateJV").ToString()));
                }
                return BadRequest((new Error(0, exError.Message, "CreateJV").ToString()));
            }
        }

    }
}
