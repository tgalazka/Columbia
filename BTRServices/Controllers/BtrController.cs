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
    public class BtrController : ApiController
    {
        private BtrDbContext db = new BtrDbContext();

        // GET: api/Btr
        [HttpGet]
        [ActionName("Items")]
        [SwaggerOperation("Items")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]

        public IHttpActionResult GetItems()
        {
            try
            {
                BTRRepository btr = new BTRRepository(db);
                return Ok(btr.Items());
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetbudgetTransferRequests").ToString()));
            }
        }

        [HttpGet]
        [ActionName("ItemsByUni")]
        [SwaggerOperation("ItemsByUni")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]

        public IHttpActionResult GetItemsByUni(int requestor_uni_key)
        {
            try
            {
                BTRRepository btr = new BTRRepository(db);
                return Ok(btr.ByUni(requestor_uni_key));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetItemsByUni").ToString()));
            }
        }

        // GET: api/Btr/Item/5
        [HttpGet]
        [ActionName("Item")]
        [SwaggerOperation("Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Item(int btr_key)
        {
            try
            {
                BTRRepository btr = new BTRRepository(db);
                BtrDTO record = btr.Item(btr_key);
               

                if (record == null)
                {
                    return NotFound();
                }
                return Ok(record);
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetbudgetTransferRequestById").ToString()));
            }
        }

        // PUT: api/Btr/5
        [HttpPut]
        [ActionName("Update")]
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [ResponseType(typeof(void))]
        public IHttpActionResult Update(BtrDTO budgetTransferRequest)
        {
            try
            {
                BTRRepository btr = new BTRRepository(db);
                BtrDTO record = btr.Update(budgetTransferRequest);
                return Ok(record);
            }
            catch (Exception exError)
            {
                string errMessage = exError.Message;
                if (exError.InnerException != null)
                {
                    errMessage = exError.InnerException.Message;
                }
                return BadRequest((new Error(0, errMessage, "Update.BTR").ToString()));
            }
        }

        // POST: api/Btr
        [HttpPost]
        [ActionName("Create")]
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]

        [ResponseType(typeof(BtrDTO))]
        public IHttpActionResult Create(BtrDTO budgetTransferRequest)
        {
            try
            {
                BTRRepository btr = new BTRRepository(db);
                BtrDTO createdRec = btr.Create(budgetTransferRequest);
                return Ok(createdRec);
            }
            catch (Exception exError)
            {
                string errMessage = exError.Message;
                if (exError.InnerException != null)
                {
                    errMessage = exError.InnerException.Message;
                }
                return BadRequest((new Error(0, errMessage, "CreatebudgetTransferRequest").ToString()));
            }
        }

        // DELETE: api/Btr/5
        [HttpDelete]
        [ActionName("Delete")]
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]

        [ResponseType(typeof(budget_transfer_request))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                budget_transfer_request budgetTransferRequest = db.budget_transfer_request.Find(id);
                if (budgetTransferRequest == null)
                {
                    return NotFound();
                }

                db.budget_transfer_request.Remove(budgetTransferRequest);
                db.SaveChanges();
                return Ok(budgetTransferRequest);

            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "PutbudgetTransferRequest").ToString()));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool budgetTransferRequestExists(int id)
        {
            return db.budget_transfer_request.Count(e => e.btr_key == id) > 0;
        }
    }
}