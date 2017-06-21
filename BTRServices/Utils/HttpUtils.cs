using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTRServices.Utils
{
    public class HttpUtils
    {
        private HttpUtils()
        {

        }
        public static int QSIntValue(IEnumerable<KeyValuePair<string, string>> queryString, string key)
        {
            string sValue = queryString.Where(nv => nv.Key == key).Select(nv => nv.Value).FirstOrDefault();
            if (sValue == null)
            {
                throw new Exception("Key ("+key+") is null could not be parsed.");
            }
            int value;
            if (Int32.TryParse(sValue, out value))
            {
                return value;
            }
            throw new Exception("Invalid value for key (" + key + ") could not be parsed.");
        }

        public static Guid QSGuidValue(IEnumerable<KeyValuePair<string, string>> queryString, string key)
        {
            string sValue = queryString.Where(nv => nv.Key == key).Select(nv => nv.Value).FirstOrDefault();
            if (sValue == null)
            {
                throw new Exception("Key (" + key + ") is null could not be parsed.");
            }
            Guid value;
            if (Guid.TryParse(sValue, out value))
            {
                return value;
            }
            throw new Exception("Invalid value for key (" + key + ") could not be parsed.");
        }
    }
}