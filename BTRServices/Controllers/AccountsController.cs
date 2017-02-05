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
    public class AccountsController : ApiController
    {
        BTRDbContext dbCxt = new BTRDbContext();

        [HttpGet]
        [ActionName("AccountsByIndexKey")]
        [SwaggerOperation("AccountsByIndexKey")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetAccountsByIndexKey()
        {
            AccountRepository dbData = new AccountRepository(dbCxt);
            IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

            string pIndexKey = queryString.Where(nv => nv.Key == "index_key").Select(nv => nv.Value).FirstOrDefault();
            if (pIndexKey == null)
            {
                return NotFound();
            }

            int iIndexKey;
            if (!Int32.TryParse(pIndexKey, out iIndexKey))
            {
                // the try parse didn't work return an error code
                BadRequest("Could not parse index_key");
            }
            return Ok(dbData.GetAccountsByIndex(iIndexKey));
        }

        [HttpGet]
        [ActionName("AccountBalance")]
        [SwaggerOperation("AccountBalance")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetAccountBalance()
        {
            AccountRepository dbData = new AccountRepository(dbCxt);
            IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

            string pKey = queryString.Where(nv => nv.Key == "account_key").Select(nv => nv.Value).FirstOrDefault();
            if (pKey == null)
            {
                return NotFound();
            }

            int iKey;
            if (!Int32.TryParse(pKey, out iKey))
            {
                // the try parse didn't work return an error code
                BadRequest("Could not parse account_key");
            }
            return Ok(dbData.GetAccountBalance(iKey));
        }

        [HttpGet]
        [ActionName("AccountBalances")]
        [SwaggerOperation("AccountBalances")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetAccountBalances()
        {
            AccountRepository dbData = new AccountRepository(dbCxt);
            IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

            string pKeys = queryString.Where(nv => nv.Key == "index_keys").Select(nv => nv.Value).FirstOrDefault();
            if (pKeys == null)
            {
                return NotFound();
            }

            int[] iKeys= null;
            try
            {
                iKeys = Array.ConvertAll(pKeys.Split(','), int.Parse);
            }
            catch(Exception exParse)
            {
                // the try parse didn't work return an error code
                BadRequest("Could not parse index_keys - " + exParse.Message);
            }
            return Ok(dbData.GetAccountBalances(iKeys));
        }

    }
}
