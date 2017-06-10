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
using BTRServices.Models;
using BTRServices.DAL;

namespace BTRServices.Controllers
{
    public class IndicesController : ApiController
    {
        BtrDbContext dbCxt = new BtrDbContext();

        // GET: api/Indices
        [HttpGet]
        [ActionName("IndicesByOwner")]
        [SwaggerOperation("IndicesByOwner")]
        public IHttpActionResult IndicesByOwner()
        {
            try
            {
                IndexRepository dbData = new IndexRepository(dbCxt);
                IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                string pUniValue = queryString.Where(nv => nv.Key == "uni").Select(nv => nv.Value).FirstOrDefault();
                if (pUniValue == null)
                {
                    return BadRequest((new Error(1, "Could not parse dept key", "IndicesByOwner").ToString()));
                }

                // string orderby = queryString.Where(nv => nv.Key == "orderby").Select(nv => nv.Value).FirstOrDefault();
                return Ok(dbData.GetIndices_ByOwner(pUniValue));

            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "IndicesByOwner").ToString()));
            }


        }

        [HttpGet]
        [ActionName("IndicesOwnedByDept")]
        [SwaggerOperation("IndicesOwnedByDept")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult IndicesOwnedByDept()
        {
            try
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
                    return BadRequest((new Error(1, "Could not parse dept key", "IndicesByOwner").ToString()));
                }
                // string orderby = queryString.Where(nv => nv.Key == "orderby").Select(nv => nv.Value).FirstOrDefault();
                return Ok(dbData.GetIndicesOwned_ByDept(pUniValue, pDeptKey));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "IndicesByOwner").ToString()));
            }
        }

        [HttpGet]
        [ActionName("IndicesByDept")]
        [SwaggerOperation("IndicesByDept")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Dept()
        {
            try
            {
                IndexRepository dbData = new IndexRepository(dbCxt);
                IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                string DeptValue = queryString.Where(nv => nv.Key == "dept_key").Select(nv => nv.Value).FirstOrDefault();
                //strip off last character if a slash

                //if pDeptKey is null then return all records

                if (String.IsNullOrEmpty(DeptValue))
                {
                    var dataValue = dbData.GetIndices();
                    return Ok(dbData.GetIndices());
                }
                int pDeptKey;

                Int32.TryParse(DeptValue, out pDeptKey);
                return Ok(dbData.GetIndices_ByDept(pDeptKey));

            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "IndicesByOwner").ToString()));
            }
        }

        //[HttpGet]
        //[ActionName("Id")]
        //[SwaggerOperation("Id")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.NotFound)]
        //public IHttpActionResult IndicesById()
        //{
        //    try
        //    {
        //        return Ok(GetDbContext().indices.);
        //    }
        //    catch (Exception exError)
        //    {
        //        return BadRequest((new Error(0, exError.Message, "IndicesById").ToString()));
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbCxt != null) dbCxt.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}