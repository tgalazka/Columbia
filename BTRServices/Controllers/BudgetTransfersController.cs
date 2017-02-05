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
using BTRServices;

namespace BTRServices.Controllers
{
    public class BudgetTransfersController : ApiController
    {
        private BTRDbContext db = new BTRDbContext();

        // GET: api/BudgetTransfers
        public IQueryable<BudgetTransfer> GetBudgetTransfers()
        {
            //db.BudgetTransfers.Select()
            IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();
            
            string select = queryString.Where(nv => nv.Key == "select").Select(nv => nv.Value).FirstOrDefault();
            string filter = queryString.Where(nv => nv.Key == "filter").Select(nv => nv.Value).FirstOrDefault();
            string orderby = queryString.Where(nv => nv.Key == "orderby").Select(nv => nv.Value).FirstOrDefault();

            if (select != null)
            {

            }

            if (filter != null)
            {

            }

            if (orderby != null)
            {

            }
            var results = from transfers in db.BudgetTransfers select transfers;
            return results;
        }

        // GET: api/BudgetTransfers/5
        [ResponseType(typeof(BudgetTransfer))]
        public IHttpActionResult GetBudgetTransfer(int id)
        {
            BudgetTransfer budgetTransfer = db.BudgetTransfers.Find(id);
            if (budgetTransfer == null)
            {
                return NotFound();
            }

            return Ok(budgetTransfer);
        }

        // PUT: api/BudgetTransfers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBudgetTransfer(int id, BudgetTransfer budgetTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != budgetTransfer.transfer_id)
            {
                return BadRequest();
            }

            db.Entry(budgetTransfer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetTransferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BudgetTransfers
        [ResponseType(typeof(BudgetTransfer))]
        public IHttpActionResult PostBudgetTransfer(BudgetTransfer budgetTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BudgetTransfers.Add(budgetTransfer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = budgetTransfer.transfer_id }, budgetTransfer);
        }

        // DELETE: api/BudgetTransfers/5
        [ResponseType(typeof(BudgetTransfer))]
        public IHttpActionResult DeleteBudgetTransfer(int id)
        {
            BudgetTransfer budgetTransfer = db.BudgetTransfers.Find(id);
            if (budgetTransfer == null)
            {
                return NotFound();
            }

            db.BudgetTransfers.Remove(budgetTransfer);
            db.SaveChanges();

            return Ok(budgetTransfer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BudgetTransferExists(int id)
        {
            return db.BudgetTransfers.Count(e => e.transfer_id == id) > 0;
        }
    }
}