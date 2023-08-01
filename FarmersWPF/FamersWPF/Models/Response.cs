using System.Collections.Generic;

namespace FarmersWPF.Models
{
    public class Response
    {
        /* 
         * the purpose of this class is to have a structure of the response we are going to get from the remote server 
         */

        public int statusCode { get; set; }
        public string message { get; set; }

        public products product { get; set; } 
        // hold the information related with four values, this is for single product 

        public List<products> productList { get; set; }
        // this is for multiple products/ a list of products

        public decimal TotalAmount { get; set; }

    }
}
