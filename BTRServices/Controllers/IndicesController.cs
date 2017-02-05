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
using System.Linq.Dynamic;
using BTRServices.Repository;
using Swashbuckle.Swagger.Annotations;

namespace BTRServices.Controllers
{
    public class IndicesController : ApiController
    {
        BTRDbContext dbCxt = new BTRDbContext();
        // GET: api/Indices
        [HttpGet]
        [ActionName("IndicesByOwner")]
        [SwaggerOperation("IndicesByOwner")]
        public IHttpActionResult IndicesByOwner()
        {
            IndexRepository dbData = new IndexRepository(dbCxt);
            IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

            string pUniValue = queryString.Where(nv => nv.Key == "uni").Select(nv => nv.Value).FirstOrDefault();
            if (pUniValue == null)
            {
                return NotFound();
            }

            // string orderby = queryString.Where(nv => nv.Key == "orderby").Select(nv => nv.Value).FirstOrDefault();
            return Ok(dbData.GetIndices_ByOwner(pUniValue));
        }

        [HttpGet]
        [ActionName("IndicesOwnedByDept")]
        [SwaggerOperation("IndicesOwnedByDept")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult IndicesOwnedByDept()
        {
            IndexRepository dbData = new IndexRepository(dbCxt);
            IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

            string pUniValue = queryString.Where(nv => nv.Key == "uni").Select(nv => nv.Value).FirstOrDefault();
            string DeptValue = queryString.Where(nv => nv.Key == "dept_key").Select(nv => nv.Value).FirstOrDefault();

            if ((pUniValue == null) || (DeptValue == null))
            {
                return NotFound();
            }

            int pDeptKey;
            if (!Int32.TryParse(DeptValue, out pDeptKey))
            {
                // the try parse didn't work return an error code
                BadRequest("Could not parse dept key");
            }
            // string orderby = queryString.Where(nv => nv.Key == "orderby").Select(nv => nv.Value).FirstOrDefault();
            return Ok(dbData.GetIndicesOwned_ByDept(pUniValue, pDeptKey));
        }

        [HttpGet]
        [ActionName("IndicesByDept")]
        [SwaggerOperation("IndicesByDept")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult IndicesByDept()
        {
            IndexRepository dbData = new IndexRepository(dbCxt);
            IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

            string DeptValue = queryString.Where(nv => nv.Key == "dept_key").Select(nv => nv.Value).FirstOrDefault();
            //if pDeptKey is null then return all records

            if (String.IsNullOrEmpty(DeptValue))
            {
                return Ok(dbData.GetIndices());
            }
            int pDeptKey;
            
            Int32.TryParse(DeptValue, out pDeptKey);
            return Ok(dbData.GetIndices_ByDept(pDeptKey));
        }
        // GET: api/Indices/5
        [ResponseType(typeof(Indices))]
        public IHttpActionResult GetIndices(int id)
        {
            Indices indices = dbCxt.Indices.Find(id);
            if (indices == null)
            {
                return NotFound();
            }

            return Ok(indices);
        }

        // PUT: api/Indices/5
        [ActionName("PostValues")]
        [SwaggerOperation("PostValues")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpPost]

        public IHttpActionResult PutIndices(int id, Indices indices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != indices.index_key)
            {
                return BadRequest();
            }

            dbCxt.Entry(indices).State = EntityState.Modified;

            try
            {
                dbCxt.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndicesExists(id))
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

        // POST: api/Indices
        [ResponseType(typeof(Indices))]
        public IHttpActionResult PostIndices(Indices indices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbCxt.Indices.Add(indices);

            try
            {
                dbCxt.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IndicesExists(indices.index_key))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = indices.index_key }, indices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbCxt.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IndicesExists(int id)
        {
            return dbCxt.Indices.Count(e => e.index_key == id) > 0;
        }
    }
}