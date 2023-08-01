namespace FarmersWPF.Models
{
    public class products
    {
        // database information in mySQL 

        /*
         * this class holds all the entries in my datase, hols all the columns present in the remote data server 
         */
        public string ProductName { get; set; } 
        public int ProductID { get; set; }
        public int AmountKG { get; set; }
        public decimal PricePerKG {  get; set; }

        public decimal TotalAmount { get; set; }

    }
}
