using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Net.Http;

namespace Win8UnitTest
{
    [TestClass]
	public class HttpMethodTests
    {
        [TestMethod]
        public void MethodsTest()
        {
			Assert.AreEqual(HttpMethod.Delete.Method, "DELETE");
			Assert.AreEqual(HttpMethod.Get.Method, "GET");
			Assert.AreEqual(HttpMethod.Head.Method, "HEAD");
			Assert.AreEqual(HttpMethod.Options.Method, "OPTIONS");
			Assert.AreEqual(HttpMethod.Post.Method, "POST");
			Assert.AreEqual(HttpMethod.Put.Method, "PUT");
			Assert.AreEqual(HttpMethod.Trace.Method, "TRACE");
		}

		[TestMethod]
		public void EqualsTest()
		{
			Assert.IsTrue(HttpMethod.Get.Equals(new HttpMethod("GET")));
		}

		[TestMethod]
		public void ToStringTest()
		{
			Assert.AreEqual(HttpMethod.Get.ToString(), "GET");
		}
	}
}
