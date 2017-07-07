using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTRServices.Utils.HTTP
{
    /// <summary>
    /// Utility class for manipulating a query string from an HTTP request.
    /// </summary>
    public class QueryString
    {
        private QueryString() { }

        /// <summary>
        /// Retrieves the value of the first matching key in the supplied query string, or NULL. 
        /// </summary>
        /// <param name="qs">Request query string parameters, if any.</param>
        /// <param name="key">Target key for value retrieval.</param>
        /// <returns>String value of first matching key, or NULL.</returns>
        public static string GetValue(IEnumerable<KeyValuePair<string, string>> qs, string key)
        {
            return (qs == null || key == null || !qs.Any()) ?
                null :
                qs
                .Where(pair => key.Equals(pair.Key))
                .Select(pair => pair.Value)
                .FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the integer (32) value of the first matching key in the supplied query string, or NULL. 
        /// </summary>
        /// <param name="qs">Request query string parameters, if any.</param>
        /// <param name="key">Target key for integer value retrieval.</param>
        /// <returns>Integer value of first matching key, or NULL.</returns>
        public static Nullable<int> GetIntValue(IEnumerable<KeyValuePair<string, string>> qs, string key)
        {
            string val = GetValue(qs, key);
            int value;
            return Int32.TryParse(val, out value) ? value : new Nullable<int>();
        }

        /// <summary>
        /// Retrieves the Guid value of the first matching key in the supplied query string, or Guid.Empty. 
        /// </summary>
        /// <param name="qs">Request query string parameters, if any.</param>
        /// <param name="key">Target key for integer value retrieval.</param>
        /// <returns>Guid value of first matching key, or Guid.Empty.</returns>
        public static Guid GetGuidValue(IEnumerable<KeyValuePair<string, string>> qs, string key)
        {
            string val = GetValue(qs, key);
            Guid value;
            Guid.TryParse(val, out value);
            return value;
        }
    }
}