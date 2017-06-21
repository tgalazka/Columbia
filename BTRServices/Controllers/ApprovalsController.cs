using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BTRServices.DAL;
using BTRServices.Models;
using Swashbuckle.Swagger.Annotations;
using BTRServices.Repository;
using BTRServices.Model;
using System.Web.Script.Serialization;

namespace BTRServices.Controllers
{
    public class ApprovalsController : ApiController
    {
        [HttpPut]
        [ActionName("Init")]
        [SwaggerOperation("Init")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Init(int btr_key, int transfer_activity_id, int approval_level)
        {
            try
            {

                /*if (pIndexKey == null)
                {
                    return BadRequest((new Error(1, "index key is not valid or blank", "AccountsByIndexKey")).ToString());
                }*/

                Dictionary<string, string> test = new Dictionary<string, string>();
                test.Add("kcooper", "kcooper");
                test.Add("acooper", "kcooper");
                test.Add("bcooper", "kcooper");
                return Ok(test);
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "Init").ToString()));
            }
        }

        [HttpPut]
        [ActionName("Initialize")]
        [SwaggerOperation("Initialize")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Initialize(int btr_key, int transfer_activity_id, int approval_level)
        {
            try
            {

                /*if (pIndexKey == null)
                {
                    return BadRequest((new Error(1, "index key is not valid or blank", "AccountsByIndexKey")).ToString());
                }*/

                Dictionary<string, string> test = new Dictionary<string, string>();
                test.Add("kcooper", "kcooper");
                test.Add("acooper", "kcooper");
                test.Add("bcooper", "kcooper");
                return Ok(test);
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "Init").ToString()));
            }
        }


        [HttpGet]
        [ActionName("Initialize")]
        [SwaggerOperation("Initialize")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Test()
        {
            try
            {

                /*if (pIndexKey == null)
                {
                    return BadRequest((new Error(1, "index key is not valid or blank", "AccountsByIndexKey")).ToString());
                }*/

                Dictionary<string, string> test = new Dictionary<string, string>();
                test.Add("kcooper", "kcooper");
                test.Add("acooper", "kcooper");
                test.Add("bcooper", "kcooper");
                return Ok(test);
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "Init").ToString()));
            }
        }

    }
}
