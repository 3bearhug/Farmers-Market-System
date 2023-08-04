using NUnit.Framework;
using FarmersAPIRest;
using MySql.Data.MySqlClient;
using FarmersAPIRest.Models;

namespace UpdateNunitTest
{
    public class UpdateProductTest
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

        private products GetProduct(MySqlConnection con, int ProductID)
        {
            products product = new products();
            string Query = "select * from products where ProductID = @ProductID";

            MySqlCommand cmd = new MySqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            con.Open();

            using (MySqlDataReader dt = cmd.ExecuteReader())
            {
                while (dt.Read())
                {
                    product.ProductName = dt[0].ToString();
                    product.ProductID = int.Parse(dt[1].ToString());
                    product.AmountKG = int.Parse(dt[2].ToString());
                    product.PricePerKG = decimal.Parse(dt[3].ToString());
                }
            }
            con.Close();

            return product;
        }

        [Test]
        public void UpdatingProductVerificationTest()
        {
            //A - Arrange
            products product = new products
            {
                ProductName = "apple",// update from apple to apple1
                ProductID = 124567,
                AmountKG = 100,
                PricePerKG = 15 // from 10 to 15 
            };

            //A - Act
            Response response = apps.UpdateProduct(con, product, product.ProductID);

            //A - Assert
            Assert.AreEqual(200, response.statusCode);
            Assert.AreEqual("Product is updated ", response.message);
            Assert.IsNotNull(response.product);

            products getP = GetProduct(con, product.ProductID);
            Assert.AreEqual(product.ProductName, getP.ProductName);
            Assert.AreEqual(product.ProductID, getP.ProductID);
            Assert.AreEqual(product.AmountKG, getP.AmountKG);
            Assert.AreEqual(product.PricePerKG, getP.PricePerKG);
        }
    }
}
