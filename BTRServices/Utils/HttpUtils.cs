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

        /// <summary>
        /// Examines an HTTP query string map of key-value pairs for the supplied key.<br />
        /// If the key is found, it attempts to parse the value into an integer.
        /// </summary>
        /// <param name="queryString">Here is the query string.</param>
        /// <param name="key">The case-sensitive target key in the query string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If the supplied query string collection is null.</exception>
        /// <exception cref="Exception">If the supplied key is not present in the query string.</exception>
        /// <exception cref="Exception">If the value for the supplied key could not be parsed into an integer.</exception>
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