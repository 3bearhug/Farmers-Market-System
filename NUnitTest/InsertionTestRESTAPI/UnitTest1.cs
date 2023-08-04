using NUnit.Framework;
using System.Net.Http;
using Newtonsoft.Json;
using FarmersAPIRest.Models;
using System.Threading.Tasks;
using System.Text;

namespace InsertionTestRESTAPI
{
    public class AddRESTAPITest
    {
        private HttpClient restClient;// for sending http request and receiving http response that identified by a uri
        private string URI = "https://localhost:7159/api/Product/AddProduct"; 

        [SetUp]
        public void Setup()
        {
            restClient = new HttpClient();// create an instance 
        }

        [Test]
        public async Task TestAddProductAPI()//asyn: runs asynchronously
        {
            products newProduct = new products
            {
                ProductName = "RESTFRUIT",
                ProductID = 22954877,
                AmountKG = 100,
                PricePerKG = 10
            };

            var json = new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await restClient.PostAsync(URI, json);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

    }
}