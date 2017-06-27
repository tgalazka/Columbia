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
using Swashbuckle.Swagger.Annotations;
using BTRServices.Models;
using BTRServices.Repository;
using BTRServices.Utils;

namespace BTRServices.Controllers
{
    public class TransferActivityController : ApiController
    {
        private BtrDbContext db = new BtrDbContext();

        [HttpGet]
        [ActionName("ItemsByBtrId")]
        [SwaggerOperation("ItemsByBtrId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]

        public IHttpActionResult ItemsByBtrId(int btr_key)
        {
            try
            {
                TransferActivityRepository ta = new TransferActivityRepository(db);
                return Ok(ta.ItemsByBtrId(btr_key));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetItem").ToString()));
            }
        }


        // GET: api/TransferActivity
        [HttpGet]
        [ActionName("Items")]
        [SwaggerOperation("Items")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]

        public IHttpActionResult Items()
        {
            try
            {
                TransferActivityRepository ta = new TransferActivityRepository(db);
                return Ok(ta.Items());
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetItems").ToString()));
            }
        }

        [HttpGet]
        [ActionName("Item")]
        [SwaggerOperation("Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]

        public IHttpActionResult Item(int transfer_activity_key)
        {
            try
            {
                TransferActivityRepository ta = new TransferActivityRepository(db);
                return Ok(ta.Item(transfer_activity_key));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetItem").ToString()));
            }
        }


        // PUT: api/TransferActivity/5
        [HttpPut]
        [ActionName("Item")]
        [SwaggerOperation("Update Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [ResponseType(typeof(void))]
        public IHttpActionResult Item(int id, TransferActivityDTO transfer_activity)
        {
            try
            {
                TransferActivityRepository ta = new TransferActivityRepository(db);
                ta.Update(transfer_activity);

                return Ok();
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "Update Item").ToString()));
            }
        }

        // POST: api/TransferActivity
        [HttpPost]
        [ActionName("Item")]
        [SwaggerOperation("Create Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult CreateItem(TransferActivityDTO transfer_activity)
        {
            try
            {
                TransferActivityRepository ta = new TransferActivityRepository(db);
                return Ok(ta.Create(transfer_activity));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "Create Item").ToString()));
            }
        }

        // POST: api/TransferActivity
        [HttpPost]
        [ActionName("BatchSave")]
        [SwaggerOperation("BatchSave")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult BatchSave(TransferActivityBatchDTO[] transferactivities)
        {
            TransferActivityRepository ta = new TransferActivityRepository(db);

            foreach (TransferActivityBatchDTO taItem in transferactivities)
            {
                switch (taItem.action.ToUpper())
                {
                    case "CREATE":
                        ta.Create(taItem.transfer_activity);
                        break;
                    case "UPDATE":
                        ta.Update(taItem.transfer_activity);
                        break;
                    case "DELETE":
                        ta.Delete(taItem.transfer_activity.transfer_activity_key);
                        break;
                }
            }

            return Ok();
        }

        // DELETE: api/TransferActivity/5
        [HttpDelete]
        [ActionName("Item")]
        [SwaggerOperation("Item")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult DeleteItem(int transfer_activity_key)
        {
            try
            {
                TransferActivityRepository ta = new TransferActivityRepository(db);
                ta.Delete(transfer_activity_key);
                return Ok();
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "Delete Item").ToString()));
            }
        }


        [HttpGet]
        [ActionName("UserAssignedApprovals")]
        [SwaggerOperation("UserAssignedApprovals")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult UserAssignedApprovals(int transfer_activity_key, int uni_key)
        {
            try
            {

                TransferActivityRepository ta = new TransferActivityRepository(db);

                return Ok(ta.GetUserAssignedApprovals(transfer_activity_key,uni_key));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "InitializeApprovals").ToString()));
            }
        }


        [HttpGet]
        [ActionName("ApprovalLevels")]
        [SwaggerOperation("ApprovalLevels")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetApprovalLevels()
        {
            try
            {
                IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                int transfer_activity_key = HttpUtils.QSIntValue(queryString, "transfer_activity_key");

                TransferActivityRepository ta = new TransferActivityRepository(db);
                
                return Ok(ta.GetApprovalLevels(transfer_activity_key));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "InitializeApprovals").ToString()));
            }
        }

        [HttpGet]
        [ActionName("CurrentApprovalLevel")]
        [SwaggerOperation("CurrentApprovalLevel")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetCurrentApprovalLevel(int transfer_activity_key)
        {
            try
            {
                //IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                //int transfer_activity_key = HttpUtils.QSIntValue(queryString, "transfer_activity_key");

                TransferActivityRepository ta = new TransferActivityRepository(db);

                return Ok(ta.GetCurrentApprovalLevel(transfer_activity_key));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetCurrentApprovalLevel").ToString()));
            }
        }

        // POST: TransferActivity

        [ActionName("InitializeApprovals")]
        [SwaggerOperation("InitializeApprovals")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpPost]
        public IHttpActionResult InitializeApprovals()
        {
            try
            {
                IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                int btr_key = HttpUtils.QSIntValue(queryString, "btr_key");
                int approval_level = HttpUtils.QSIntValue(queryString, "approval_level");

                TransferActivityRepository ta = new TransferActivityRepository(db);
                ta.SetApprovalLevels(btr_key,approval_level);
                
                return Ok();
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "InitializeApprovals").ToString()));
            }
        }

        [ActionName("SetApproval")]
        [SwaggerOperation("SetApproval")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpPost]
        public IHttpActionResult SetApproval(int transfer_activity_key, int approval_level)
        {
            try
            {
                TransferActivityRepository ta = new TransferActivityRepository(db);
                ta.SetApprovalLevel(transfer_activity_key, approval_level);

                return Ok();
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "SetApprovals").ToString()));
            }
        }


        [ActionName("SetApprovals")]
        [SwaggerOperation("SetApprovals")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpPost]
        public IHttpActionResult SetApprovals(int btr_key, int approval_level)
        {
            try
            {
                TransferActivityRepository ta = new TransferActivityRepository(db);
                ta.SetApprovalLevels(btr_key, approval_level);

                return Ok();
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "SetApprovals").ToString()));
            }
        }

        [ActionName("AssignReviewers")]
        [SwaggerOperation("AssignReviewers")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpPost]
        public IHttpActionResult AssignReviewers()
        {
            try
            {
                IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                int transfer_activity_key = HttpUtils.QSIntValue(queryString, "transfer_activity_key");
                int approval_level = HttpUtils.QSIntValue(queryString, "approval_level");
                Guid workflow_guid = HttpUtils.QSGuidValue(queryString, "workflow_guid");

                TransferActivityRepository ta = new TransferActivityRepository(db);

                return Ok(ta.AssignReviewers(transfer_activity_key,approval_level,workflow_guid));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetCurrentApprovalLevel").ToString()));
            }
        }

        private bool transfer_activityExists(int id)
        {
            return db.transfer_activity.Count(e => e.transfer_activity_key == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}