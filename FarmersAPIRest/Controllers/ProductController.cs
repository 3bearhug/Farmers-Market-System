using FarmersAPIRest.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace FarmersAPIRest.Controllers
{
    //give route of the APIs, then pass the controller 
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        //Constructor 
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //create a controller/method
        //1. ADD/POST
        [HttpPost]
        [Route("AddProduct")] // go to applications class
        public Response AddProduct(products product)
        {
            //create database connection 
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            //"productConnection" should be matched one from appsettings.json
            Response response = new Response();
            //call the application interface 
            Applications app = new Applications();
            response = app.AddProduct(con, product); //pass connection and product object
            return response;
        }

        //2. READ/GET
        [HttpGet]
        [Route("GetAllProducts")]
        public Response GetProduct()// get all so no parameters needed
        {
            Response response = new Response();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Applications app = new Applications();
            response = app.GetAllProducts(con);
            return response;
        }

        //3. GET with productID only
        [HttpGet]
        [Route("GetProductById/{id}")] // in this way, sending one parameter/info to remote server, here pass ID
        
        public Response GetProductById(int id)
        {
            Response response = new Response();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Applications app = new Applications();
            response = app.GetProductById(con, id);
            return response;

        }

        //4. PUT-UPDATE table 
        [HttpPut]
        [Route("UpdateProduct/{id}")]

        public Response UpdateProduct(products product, int id) 
        {
            Response response = new Response();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Applications app = new Applications();
            response = app.UpdateProduct(con, product, id);
            return response;
        }

        //5. DELETE
        [HttpDelete]
        [Route("DeleteProductById/{id}")]
        public Response DeleteProduct( int id)
        {
            Response response = new Response();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Applications app = new Applications();
            response = app.DeleteProductById(con, id);
            return response;
        }


        [HttpPost]
        [Route("GetProductByName")]
        public Response GetProductByName([FromBody] products product)
        {
            Response response = new Response();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Applications app = new Applications();
            response = app.GetProductByName(con, product.ProductName);
            return response;
        }



        [HttpPost]
        [Route("AfterSales/{name}/{amount}")]
        public Response AfterSales(string name, int amount)
        {
            Response response = new Response();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Applications app = new Applications();
            response = app.AfterSales(con, name, amount);
            return response;
        }


    }
}
