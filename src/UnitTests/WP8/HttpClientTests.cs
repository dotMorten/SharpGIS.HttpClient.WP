using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Win8UnitTest
{
    [TestClass]
	public class HttpClientTests
    {
        [TestMethod]
		public async Task GetAsyncTest1()
        {
			HttpClient client = new HttpClient();
			var response = await client.GetAsync("http://www.microsoft.com");
			Assert.IsTrue(response.IsSuccessStatusCode);
			Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
		}

		[TestMethod]
		public async Task GetAsyncTest_Compressed()
		{
			HttpClient client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = System.Net.DecompressionMethods.GZip });
			var response = await client.GetAsync("http://www.microsoft.com");
			Assert.IsTrue(response.IsSuccessStatusCode);
			Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
		}
		[TestMethod]
		public async Task GetAsyncTest_POST()
		{
			byte[] bytes = Encoding.UTF8.GetBytes("Foo");
			System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
			StreamContent streamContent = new StreamContent(ms);
			HttpClient client = new HttpClient();
			var response = await client.PostAsync("http://www.microsoft.com", streamContent);
			Assert.IsFalse(response.IsSuccessStatusCode);
			Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.MethodNotAllowed);
		}
		[TestMethod]
		public async Task GetAsyncTest_POST2()
		{
			byte[] bytes = Encoding.UTF8.GetBytes("Where=1%3D1");
			System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
			StreamContent streamContent = new StreamContent(ms);
			HttpClient client = new HttpClient();
			var response = await client.PostAsync("http://sampleserver3.arcgisonline.com/ArcGIS/rest/services/Fire/Sheep/FeatureServer/0/query?f=pjson", streamContent);
			string result = await response.Content.ReadAsStringAsync();
			Assert.IsFalse(response.IsSuccessStatusCode);
			Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
		}
		
	}
}
