using NUnit.Framework;
using System.Net.Http;
using Newtonsoft.Json;
using FarmersAPIRest.Models;
using System.Threading.Tasks;
using System.Text;

namespace DeleteTestRESTAPI
{
    public class DeleteRestAPI
    {

        private HttpClient restClient;// for sending http request and receiving http response that identified by a uri
        private string URI = "https://localhost:7159/api/Product/DeleteProductById";

        [SetUp]
        public void Setup()
        {
            restClient = new HttpClient();// create an instance 
        }

        [Test]
        public async Task TestDeleteProductRESTAPI()
        {
            //Arrange
            int productId = 2295486;

            // Act
            var response = await restClient.DeleteAsync($"{URI}/{productId}");

            // Assert
            Assert.IsTrue(response.IsSuccessStatusCode, "Product is not deleted");
        }
    }
}