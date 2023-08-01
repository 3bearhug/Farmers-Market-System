using FamersWPF.Models;
using FarmersWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FamersWPF
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        HttpClient httpClient = new HttpClient();// this will help to configure the HTTP connection for the REMOTE rest APIs
        public Sales()
        {
            /*
             * configrure WPF Application to ensure proper connection 
            */

            //step 1 - setup the base address for the REST APIs
            httpClient.BaseAddress = new Uri("https://localhost:7159/api/Product");

            //step 2 - configure the packets header , firstly, need to clear the present packer header 
            httpClient.DefaultRequestHeaders.Accept.Clear();

            //step 3 - Add customized header information - sending request to server/response in json format, so configure at the beginning
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            InitializeComponent();
        }        private void adminbutton_Click(object sender, RoutedEventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Close();
        }

        private async void showme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string productName = Name.Text;
                int amountPurchased = int.Parse(amountTextBox.Text);

                HttpResponseMessage serverResSales = await httpClient.PostAsJsonAsync($"Product/AfterSales/{productName}/{amountPurchased}", new { });

                if (!serverResSales.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error when calling the AfterSales API. Status code: {serverResSales.StatusCode}, Reason: {serverResSales.ReasonPhrase}");
                    return;
                }

                var salesResponseContent = await serverResSales.Content.ReadAsStringAsync();
                Response salesResponseObject = JsonConvert.DeserializeObject<Response>(salesResponseContent);

                if (salesResponseObject == null)
                {
                    MessageBox.Show("Error when parsing the sales response.");
                    return;
                }

                if (salesResponseObject.TotalAmount == 0)
                {
                    MessageBox.Show("TotalAmount from AfterSales response is zero.");
                    return;
                }

                // update saleTexBox if total amount is not 0 
                salesTextBox.Text = salesResponseObject.TotalAmount.ToString();

                string response = await httpClient.GetStringAsync("Product/GetAllProducts");
                Response responseObject = JsonConvert.DeserializeObject<Response>(response);

                ProductList.ItemsSource = responseObject.productList;
                DataContext = this;

                MessageBox.Show("Inventory has been updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Name.Text = "";
            amountTextBox.Text = "";
            salesTextBox.Text = "";
        }


    }
}
