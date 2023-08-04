using NUnit.Framework;
using System.Net.Http;
using Newtonsoft.Json;
using FarmersAPIRest.Models;
using System.Threading.Tasks;
using System.Text;

namespace UpdateTestRESTAPI
{
    public class UpdateRESTAPITest
    {
        private HttpClient restClient;// for sending http request and receiving http response that identified by a uri
        private string URI = "https://localhost:7159/api/Product/UpdateProduct";

        [SetUp]
        public void Setup()
        {
            restClient = new HttpClient();// create an instance 
        }

        [Test]
        public async Task TestUpdateProductAPI()
        {
            products updatedProduct = new products
            {
                ProductName = "UpdatedRESTAPI",//change to UpdatedRESTAPI from UpdatedUnit
                ProductID = 2295484,
                AmountKG = 120,//change to 120 from 100
                PricePerKG = 12 // change to 12 from 15
            };

            var json = new StringContent(JsonConvert.SerializeObject(updatedProduct), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await restClient.PutAsync($"{URI}/{updatedProduct.ProductID}", json);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}