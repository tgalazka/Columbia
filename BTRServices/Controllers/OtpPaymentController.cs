using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTRServices.DAL;
using BTRServices.Models;
using BTRServices.Model;

namespace BTRServices.Controllers
{
    public class OtpPaymentController : ApiController
    {
        HrDbContext dbCxt = new HrDbContext();

        [HttpGet]
        [ActionName("Item")]
        [SwaggerOperation("Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetItem(int one_time_payment_key)
        {
            try
            {
                OneTimePaymentRepository dbData = new OneTimePaymentRepository(dbCxt);

                return Ok(dbData.GetItem(one_time_payment_key));
            }
            catch (Exception exError)
            {
                if (exError.InnerException != null)
                {
                    return BadRequest((new Error(0, exError.InnerException.ToString(), "GetItem").ToString()));
                }
                return BadRequest((new Error(0, exError.Message, "GetItem").ToString()));
            }
        }

        [HttpPut]
        [ActionName("Item")]
        [SwaggerOperation("Update Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult UpdateItem(OneTimePaymentDTO record)
        {
            try
            {
                OneTimePaymentRepository dbData = new OneTimePaymentRepository(dbCxt);

                return Ok(dbData.UpdateItem(record));
            }
            catch (Exception exError)
            {
                if (exError.InnerException != null)
                {
                    return BadRequest((new Error(0, exError.InnerException.ToString(), "UpdateItem").ToString()));
                }
                return BadRequest((new Error(0, exError.Message, "UpdateItem").ToString()));
            }
        }

        [HttpPost]
        [ActionName("Item")]
        [SwaggerOperation("Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult CreateItem(OneTimePaymentDTO record)
        {
            try
            {
                OneTimePaymentRepository dbData = new OneTimePaymentRepository(dbCxt);

                return Ok(dbData.CreateItem(record));
            }
            catch (Exception exError)
            {
                if (exError.InnerException != null)
                {
                    return BadRequest((new Error(0, exError.InnerException.ToString(), "CreateItem").ToString()));
                }
                return BadRequest((new Error(0, exError.Message, "CreateItem").ToString()));
            }
        }

        [HttpGet]
        [ActionName("Item")]
        [SwaggerOperation("Delete Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult DeleteItem(int one_time_payment_key)
        {
            try
            {
                OneTimePaymentRepository dbData = new OneTimePaymentRepository(dbCxt);
                dbData.DeleteItem(one_time_payment_key);
                return Ok(true);
            }
            catch (Exception exError)
            {
                if (exError.InnerException != null)
                {
                    return BadRequest((new Error(0, exError.InnerException.ToString(), "DeleteItem").ToString()));
                }
                return BadRequest((new Error(0, exError.Message, "DeleteItem").ToString()));
            }
        }
    }
}
