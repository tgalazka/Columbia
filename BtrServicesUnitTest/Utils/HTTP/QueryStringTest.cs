using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTRServices.Utils.HTTP;
using System.Collections.Generic;

namespace BtrServicesUnitTest.Utils.HTTP
{
    [TestClass]
    public class QueryStringTest
    {
        [TestMethod]
        public void Utils__HTTP__QueryString___GetValue()
        {
            Assert.IsNull(QueryString.GetValue(null, null), "NULL query string failed to return NULL.");
            Assert.IsNull(QueryString.GetValue(new Dictionary<string, string>(), null), "NULL key failed to return NULL.");
            Assert.IsNull(QueryString.GetValue(new Dictionary<string, string>(), "baz"), "Empty query string failed to return NULL.");
            Assert.IsNull(QueryString.GetValue(new Dictionary<string, string> { { "foo", "bar" } }, "baz"), "Absent key failed to return NULL.");
            Assert.IsNull(QueryString.GetValue(new Dictionary<string, string> { { "foo", "bar" } }, "FOO"), "Case-sensitive absent key failed to return NULL.");
            Assert.AreEqual("bar", QueryString.GetValue(new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("foo", "bar"),
                new KeyValuePair<string, string>("foo", "baz")
            }, "foo"), "Present key failed to return value.");
        }

        [TestMethod]
        public void Utils__HTTP__QueryString___GetIntValue()
        {
            Assert.IsNull(QueryString.GetIntValue(null, null));
            Assert.IsNull(QueryString.GetIntValue(new Dictionary<string, string>(), null));
            Assert.IsNull(QueryString.GetIntValue(new Dictionary<string, string>(), "baz"));
            Assert.IsNull(QueryString.GetIntValue(new Dictionary<string, string> { { "foo", "bar" } }, "baz"));
            Assert.IsNull(QueryString.GetIntValue(new Dictionary<string, string> { { "foo", "bar" } }, "FOO"));
            Assert.IsNull(QueryString.GetIntValue(new Dictionary<string, string> { { "foo", "bar" } }, "foo"));

            Assert.AreEqual(0, QueryString.GetIntValue(new Dictionary<string, string> { { "foo", "0" } }, "foo"));
            Assert.AreEqual(-1, QueryString.GetIntValue(new Dictionary<string, string> { { "foo", "-1" } }, "foo"));
            Assert.AreEqual(100, QueryString.GetIntValue(new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("foo", "100"),
                new KeyValuePair<string, string>("foo", "1")
            }, "foo"), "Failed to retrieve first matching key value.");
        }

        [TestMethod]
        public void Utils__HTTP__QueryString___GetGuidValue()
        {
            Assert.AreEqual(Guid.Empty, QueryString.GetGuidValue(null, null));
            Assert.AreEqual(Guid.Empty, QueryString.GetGuidValue(new Dictionary<string, string>(), null));
            Assert.AreEqual(Guid.Empty, QueryString.GetGuidValue(new Dictionary<string, string>(), "baz"));
            Assert.AreEqual(Guid.Empty, QueryString.GetGuidValue(new Dictionary<string, string> { { "foo", "bar" } }, "baz"));
            Assert.AreEqual(Guid.Empty, QueryString.GetGuidValue(new Dictionary<string, string> { { "foo", "bar" } }, "FOO"));
            Assert.AreEqual(Guid.Empty, QueryString.GetGuidValue(new Dictionary<string, string> { { "foo", "bar" } }, "foo"));

            Guid expected = Guid.Parse("23873223-1f04-4b9b-8919-a6e8579b0525");
            Assert.AreEqual(expected, QueryString.GetGuidValue(new Dictionary<string, string> { { "foo", "23873223-1f04-4b9b-8919-a6e8579b0525" } }, "foo"));
            Assert.AreEqual(expected, QueryString.GetGuidValue(new Dictionary<string, string> { { "foo", "23873223-1F04-4B9B-8919-A6E8579B0525" } }, "foo"));
            Assert.AreEqual(expected, QueryString.GetGuidValue(new Dictionary<string, string> { { "foo", "238732231F044B9B8919A6E8579B0525" } }, "foo"));
            Assert.AreEqual(expected, QueryString.GetGuidValue(new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("foo", "23873223-1f04-4b9b-8919-a6e8579b0525"),
                new KeyValuePair<string, string>("foo", "dc6fb65e-b6e8-423e-a608-a8dd74ed61cd")
            }, "foo"), "Failed to retrieve first matching key value.");
        }
    }
}