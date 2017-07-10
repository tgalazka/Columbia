using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTRServices.Utils;
using System.Collections.Generic;

namespace BtrServicesUnitTest.Utils
{
    [TestClass]
    public class HttpUtilsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void QSIntValue_WithNullQueryString_ThrowsNullException()
        {
            IEnumerable<KeyValuePair<string, string>> qs = null;
            string key = null;
            HttpUtils.QSIntValue(qs, key);
        }

        [TestMethod]
        public void QSIntValue_WithEmptyQueryString_ThrowException()
        {
            IEnumerable<KeyValuePair<string, string>> qs = new Dictionary<string, string>();
            string key = null;

            try
            {
                HttpUtils.QSIntValue(qs, key);
                Assert.Fail();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Key () is null could not be parsed.");
            }
        }

        [TestMethod]
        public void QSIntValue_WithNullKey_ThrowsException()
        {
            IEnumerable<KeyValuePair<string, string>> qs = new Dictionary<string, string> { { "foo", "bar" } };
            string key = null;

            try
            {
                HttpUtils.QSIntValue(qs, key);
                Assert.Fail();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Key () is null could not be parsed.");
            }
        }

        [TestMethod]
        public void QSIntValue_WithAbsentKey_ThrowsException()
        {
            IEnumerable<KeyValuePair<string, string>> qs = new Dictionary<string, string> { { "foo", "bar" } };
            string key = "baz";

            try
            {
                HttpUtils.QSIntValue(qs, key);
                Assert.Fail();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Key (baz) is null could not be parsed.");
            }
        }

        [TestMethod]
        public void QSIntValue_WithNonIntegerValue_ThrowsException()
        {
            IEnumerable<KeyValuePair<string, string>> qs = new Dictionary<string, string> { { "foo", "bar" } };
            string key = "foo";

            try
            {
                HttpUtils.QSIntValue(qs, key);
                Assert.Fail();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Invalid value for key (foo) could not be parsed.");
            }
        }

        [TestMethod]
        public void QSIntValue_WithIntegerValue_ReturnsValue()
        {
            IEnumerable<KeyValuePair<string, string>> qs = new Dictionary<string, string> { { "foo", "0" } };
            string key = "foo";
            int expected = 0;

            int result = HttpUtils.QSIntValue(qs, key);
            Assert.AreEqual(expected, result);
        }
    }
}