using BTRServices.DAL;
using BTRServices.Models;
using BTRServices.Models.Banner;
using BTRServices.Repository.Banner;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Web.Http;

namespace BTRServices.Controllers.Banner
{
    public class EmployeeController : ApiController
    {
        HrDbContext dbCxt = new HrDbContext();

        [HttpGet]
        [ActionName("Item")]
        [SwaggerOperation("Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetItem(string uni)
        {
            try
            {
                EmployeeRepository dbData = new EmployeeRepository(dbCxt);
                Models.Banner.EmployeeDTO data = dbData.GetItem(uni);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
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
        /*
        [HttpPut]
        [ActionName("Item")]
        [SwaggerOperation("Update Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult UpdateItem(EmployeeDTO record)
        {
            try
            {
                EmployeeRepository dbData = new EmployeeRepository(dbCxt);

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
        public IHttpActionResult CreateItem(EmployeeDTO record)
        {
            try
            {
                EmployeeRepository dbData = new EmployeeRepository(dbCxt);

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
        */
    }
}
