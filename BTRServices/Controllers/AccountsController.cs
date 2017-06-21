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
    public class AccountsController : ApiController
    {
        BtrDbContext dbCxt = new BtrDbContext();

        [HttpGet]
        [ActionName("AccountsByIndexKey")]
        [SwaggerOperation("AccountsByIndexKey")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetAccountsByIndexKey()
        {
            try
            {
                AccountRepository dbData = new AccountRepository(dbCxt);
                IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                string pIndexKey = queryString.Where(nv => nv.Key == "index_key").Select(nv => nv.Value).FirstOrDefault();
                if (pIndexKey.EndsWith("/")) pIndexKey = pIndexKey.Remove(pIndexKey.IndexOf("/"));
                if (pIndexKey == null)
                {
                    return BadRequest((new Error(1, "index key is not valid or blank", "AccountsByIndexKey")).ToString());
                }

                int iIndexKey;
                if (!Int32.TryParse(pIndexKey, out iIndexKey))
                {
                    return BadRequest((new Error(2, "index key could not be parsed", "AccountsByIndexKey").ToString()));
                }
                return Ok(dbData.GetAccountsByIndex(iIndexKey));
            }
            catch (Exception exError)
            {
                if (exError.InnerException != null)
                {
                    return BadRequest((new Error(0, exError.InnerException.ToString(), "AccountsByIndexKey").ToString()));
                }
                return BadRequest((new Error(0, exError.Message, "AccountsByIndexKey").ToString()));
            }
        }

        [HttpGet]
        [ActionName("AccountBalance")]
        [SwaggerOperation("AccountBalance")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAccountBalance()
        {
            try
            {
                AccountRepository dbData = new AccountRepository(dbCxt);
                IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                string pKey = queryString.Where(nv => nv.Key == "account_key").Select(nv => nv.Value).FirstOrDefault();
                if (pKey == null)
                {
                    return BadRequest((new Error(2, "index key could not be parsed", "GetAccountBalance").ToString()));
                }

                int iKey;
                if (!Int32.TryParse(pKey, out iKey))
                {
                    // the try parse didn't work return an error code
                    return BadRequest((new Error(2, "index key could not be parsed", "GetAccountBalance").ToString()));
                }
                return Ok(dbData.GetAccountBalance(iKey));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetAccountBalance").ToString()));
            }

            
        }

        [HttpGet]
        [ActionName("AccountBalances")]
        [SwaggerOperation("AccountBalances")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAccountBalances()
        {
            try
            {
                AccountRepository dbData = new AccountRepository(dbCxt);
                IEnumerable<KeyValuePair<string, string>> queryString = Request.GetQueryNameValuePairs();

                string pKeys = queryString.Where(nv => nv.Key == "index_keys").Select(nv => nv.Value).FirstOrDefault();
                if (pKeys == null)
                {
                    return NotFound();
                }

                int[] iKeys = null;
                try
                {
                    iKeys = Array.ConvertAll(pKeys.Split(','), int.Parse);
                }
                catch (Exception exParse)
                {
                    // the try parse didn't work return an error code
                    return BadRequest((new Error(2, exParse.Message, "GetAccountBalances").ToString()));
                }
                return Ok(dbData.GetAccountBalances(iKeys));
            }
            catch (Exception exError)
            {
                return BadRequest((new Error(0, exError.Message, "GetAccountBalances").ToString()));
            }
        }
    }
}
