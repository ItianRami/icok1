using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace icok1.Test.Integration
{
    public class ApiProductTest
    {
        [TestCase("Get", "api/v1/product")]
        [TestCase("Get", "api/v1/product/1")]
        [Ignore("Need to fix jwt setting value and handle 401 error")]
        public async Task GetAllproductTestAsync(string method, string URL)
        {
            using var client = new TestClientProvider().Client;
            var request = new HttpRequestMessage(new HttpMethod(method), URL);
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}