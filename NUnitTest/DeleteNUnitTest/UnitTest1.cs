using NUnit.Framework;
using FarmersAPIRest;
using MySql.Data.MySqlClient;
using FarmersAPIRest.Models;

namespace DeleteNUnitTest
{
    public class DeleteProductTest
    {

        private string server = "localhost";
        private string database = "farmersmarket";
        private string uid = "root";
        private string password = "root12345!";
        private string connectionString;
        private MySqlConnection con;
        private Applications apps;

        [SetUp]
        public void Setup()
        {
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            con = new MySqlConnection(connectionString);
            apps = new Applications();
        }

        private bool IsProductExists(int ProductID)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string Query = "select * from products where ProductID = @ProductID";
                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                con.Open();
                var reader = cmd.ExecuteReader();
                var exists = reader.HasRows;
                return exists;
            }
        }

        [Test]
        public void DeleteProductVerificationTest()
        {
            //A - Arrange
            int ProductID = 2295485;

            //A - Act
            Assert.IsTrue(IsProductExists(ProductID), "Product does not exist before deletion");
            Response response;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                response = apps.DeleteProductById(con, ProductID);
            }

            //A - Assert
            Assert.AreEqual(200, response.statusCode);
            Assert.AreEqual("Product is deleted", response.message.Trim());
            Assert.IsFalse(IsProductExists(ProductID), "Product still exists after deletion");
        }
    }
}