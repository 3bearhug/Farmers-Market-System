using MySql.Data.MySqlClient;
using System.Data;

namespace FarmersAPIRest.Models
{
    public class Applications
    {
        /*
         * This class will hold all the CRUD related operations we are going to apply in the database/remote server.
         * 
         * this will generate the requests, get the Response and then send that response back to the controller whenever called 
         */

        //1)Insertion/ Add student Operation 
        public Response AddProduct(MySqlConnection con, products productToAdd)
        {
            Response response = new Response();

            try
            {
                /*
                 * In each of the methods under Application section/class, we are going to send the product value from the controller page and then going to add those
                 * product information in the server/database.To do that we need to connection string of the remote database as well as the product information itself. 
                 */

                //generate query
                string Query = "Insert into products (ProductName, ProductID, AmountKG, PricePerKG) values (@ProductName, @ProductID, @AmountKG, @PricePerKG)";

                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductName", productToAdd.ProductName);
                cmd.Parameters.AddWithValue("@ProductID", productToAdd.ProductID);
                cmd.Parameters.AddWithValue("@AmountKG", productToAdd.AmountKG);
                cmd.Parameters.AddWithValue("@PricePerKG", productToAdd.PricePerKG);
                con.Open();

                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    response.statusCode = 200;
                    response.message = "product is added successfully";
                    response.product = productToAdd;
                    response.productList = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.message = "product is not added";
                    response.product = null;
                    response.productList = null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public Response GetAllProducts(MySqlConnection con)
        {
            Response response = new Response();
            try
            {
                //generate query
                string Query = "select * from products";
                MySqlDataAdapter da = new MySqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                List<products> _productList = new List<products>();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        products product = new products(); // for each of the product individually

                        // Check if the values are null and handle accordingly.
                        if (dt.Rows[i]["ProductName"] != DBNull.Value)
                        {
                            product.ProductName = (string)dt.Rows[i]["ProductName"];
                        }
                        else
                        {
                            product.ProductName = string.Empty;
                        }

                        if (dt.Rows[i]["ProductID"] != DBNull.Value)
                        {
                            product.ProductID = (int)dt.Rows[i]["ProductID"];
                        }

                        if (dt.Rows[i]["AmountKG"] != DBNull.Value)
                        {
                            product.AmountKG = (int)dt.Rows[i]["AmountKG"];
                        }

                        if (dt.Rows[i]["PricePerKG"] != DBNull.Value)
                        {
                            product.PricePerKG = (decimal)dt.Rows[i]["PricePerKG"];
                        }

                        _productList.Add(product); // add product to the list 
                    }
                }

                if (_productList.Count > 0) // retrieved the info from table 
                {
                    response.statusCode = 200;
                    response.message = "products are retrieved successfully";
                    response.product = null;
                    response.productList = _productList;
                }
                else
                {
                    response.statusCode = 100;
                    response.message = "products are not retrieved";
                    response.product = null;
                    response.productList = null;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public Response GetProductById(MySqlConnection con, int id)
        {
            Response response = new Response();
            try
            {
                // perform query
                string Query = "select * from products where ProductID = @ProductID";
                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductID", id);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);// datatable will get the structure/entries of the datatable over here 
                products product = new products();//this will create instance for only one product 
                if (dt.Rows.Count > 0)// means i get at least one match, which is required 
                {
                    product.ProductName = (string)dt.Rows[0]["ProductName"];
                    product.ProductID = (int)dt.Rows[0]["ProductID"];
                    product.AmountKG = (int)dt.Rows[0]["AmountKG"];
                    product.PricePerKG = (decimal)dt.Rows[0]["PricePerKG"];

                    //create the response for server

                    response.statusCode = 200;
                    response.message = "Product found and retrieved";
                    response.product = product;
                    response.productList = null;
                }
                else
                {
                    product = null;
                    response.statusCode = 100;
                    response.message = "product is not retrieved...might not present in database";
                    response.product = null;
                    response.productList = null;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }
        public Response UpdateProduct(MySqlConnection con, products product, int id)
        {
            Response response = new Response();

            try
            {
                con.Open();
                string Query = "update products set ProductName = @ProductName, AmountKG = @AmountKG, PricePerKG = @PricePerKG where ProductID = @Id";

                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@AmountKG", product.AmountKG);
                cmd.Parameters.AddWithValue("@PricePerKG", product.PricePerKG);
                cmd.Parameters.AddWithValue("@Id", id);

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    response.statusCode = 200;
                    response.message = "Product is updated ";
                    response.product = product;
                    response.productList = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.message = "product is not updated";
                    response.product = null;
                    response.productList = null;
                }
            }
            catch (MySqlException ex)
            {
                response.statusCode = 500;
                response.message = ex.Message;
                response.product = null;
                response.productList = null;
            }

            return response;
        }

        public Response DeleteProductById(MySqlConnection con, int id)
        {
            Response response = new Response();

            try
            {
                con.Open();
                string Query = "delete from products where ProductID = @Id";

                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    response.statusCode = 200;
                    response.message = "Product is deleted ";
                    response.product = null;
                    response.productList = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.message = "product is not deleted";
                    response.product = null;
                    response.productList = null;
                }

                }
            catch (MySqlException ex)
                {
                    response.statusCode = 500;
                    response.message = "Error " + ex.Message;
                }
                return response;
            }

        public Response GetProductByName(MySqlConnection con, string productName)
        {
            Response response = new Response();

            try
            {
                con.Open();
                string getProductQuery = "select * from products where ProductName = @Name";

                MySqlCommand cmd = new MySqlCommand(getProductQuery, con);
                cmd.Parameters.AddWithValue("@Name", productName);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0]["ProductName"].ToString();
                    int amountkg = (int)dt.Rows[0]["AmountKG"];
                    decimal priceperkg = (decimal)dt.Rows[0]["PricePerKG"];

                    response.statusCode = 200;
                    response.message = "Product successfully fetched.";
                    response.product = new products { ProductName = name, AmountKG = amountkg, PricePerKG = priceperkg };
                }
                else
                {
                    response.statusCode = 404;
                    response.message = "Product not found.";
                    response.product = null;
                }

                con.Close();
            }
            catch (MySqlException ex)
            {
                response.statusCode = 500;
                response.message = "Error " + ex.Message;
            }

            return response;
        }


        public Response AfterSales(MySqlConnection con, string productName, int amountPurchased)
        {
            Response response = new Response();

            try
            {
                con.Open();
                string Query = "select * from products where ProductName = @Name";

                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Name", productName);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int currentAmount = (int)dt.Rows[0]["amountkg"];

                    if (currentAmount < amountPurchased)
                    {
                        response.statusCode = 100;
                        response.message = "no product available";
                        response.product = null;
                        response.productList = null;

                        return response;
                    }

                    int newAmount = currentAmount - amountPurchased;

                    string updateProductQuery = "update products set amountkg = @AmountKG where ProductName = @Name";
                    MySqlCommand updateProductCmd = new MySqlCommand(updateProductQuery, con);
                    updateProductCmd.Parameters.AddWithValue("@AmountKG", newAmount);
                    updateProductCmd.Parameters.AddWithValue("@Name", productName);
                    int i = updateProductCmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        int id = (int)dt.Rows[0]["ProductID"];
                        decimal pricePerKg = (decimal)dt.Rows[0]["PricePerKG"];
                        Console.WriteLine($"Price per Kg: {pricePerKg}");  // so prini price per Kg
                        Console.WriteLine($"Amount Purchased: {amountPurchased}"); // amount purchased
                        decimal totalAmount = pricePerKg * amountPurchased;
                        Console.WriteLine($"Total Amount: {totalAmount}"); // give you total amount
                        response.statusCode = 200;
                        response.message = "Product successfully purchased.";
                        response.product = new products { ProductID = id, AmountKG = newAmount, ProductName = productName, PricePerKG = pricePerKg };
                        response.productList = null;
                        response.TotalAmount = totalAmount;
                    }

                    else
                    {
                        response.statusCode = 100;
                        response.message = "Product purchase failed.";
                        response.product = null;
                        response.productList = null;
                    }
                }
                else
                {
                    response.statusCode = 100;
                    response.message = "Product not found.";
                    response.product = null;
                    response.productList = null;
                }

                con.Close();
            }
            catch (MySqlException ex)
            {
                response.statusCode = 500;
                response.message = "Error " + ex.Message;
            }

            return response;
        }


    }
}