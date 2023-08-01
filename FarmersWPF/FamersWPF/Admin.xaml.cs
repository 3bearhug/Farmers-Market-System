using FarmersWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;


namespace FamersWPF
{
    /*
     * before using RESTAPI, configuration rest API connection with the present WPF allication is needed
     * 
     * RESTAPIs are connected with the remote server with http communication protocol.
     * So, to communicate with restAPI, configure Http Communication as well.
     */

    public partial class Admin : Window
    {
        HttpClient httpClient = new HttpClient();// this will help to configure the HTTP connection for the REMOTE rest APIs
        public Admin()
        {
            /*
             * configrure WPF Application to ensure proper connection 
             */

            //step 1 - setup the base address for the REST APIs
            httpClient.BaseAddress = new Uri("https://localhost:7159/api/Product/");

            //step 2 - configure the packets header , firstly, need to clear the present packer header 
            httpClient.DefaultRequestHeaders.Accept.Clear();

            //step 3 - Add customized header information - sending request to server/response in json format, so configure at the beginning
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            InitializeComponent();
        }

        private async void addbutton_Click(object sender, RoutedEventArgs e)
        {
            // send product info/structure that getting from front end
            products product = new products(); // same as table name??
            product.ProductName = namebox.Text;
            product.ProductID = int.Parse(idbox.Text);
            product.AmountKG = int.Parse(amountbox.Text);
            product.PricePerKG = decimal.Parse(pricebox.Text);

            //pass product instance to the remote server using restAPIs that created. Call restAPI, pass product instance. 
            HttpResponseMessage serverRes = await httpClient.PostAsJsonAsync("AddProduct", product);

            // then decrypt the response message 

            if (serverRes.IsSuccessStatusCode)
            {
                var responseContent = await serverRes.Content.ReadAsStringAsync(); // Read content as string

                Response responseObject = JsonConvert.DeserializeObject<Response>(responseContent); // Deserialize the string content

                if (responseObject != null)
                {
                    responselabel.Visibility = Visibility.Visible;
                    responselabel.Content = "Status Code: " + responseObject.statusCode + " Message: " + responseObject.message;
                }
                else
                {
                    responselabel.Visibility = Visibility.Visible;
                    responselabel.Content = "Error when parsing the response.";
                }
            }
            else
            {
                responselabel.Visibility = Visibility.Visible;
                responselabel.Content = "Error when calling the API.";
            }
        }

        private async void searchbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string response = await httpClient.GetStringAsync("GetProductById/" + label55.Text);
                Response responseObject = JsonConvert.DeserializeObject<Response>(response);

                responselabel.Visibility = Visibility.Visible;
                responselabel.Content = responseObject.statusCode + " " + responseObject.message;

                if (responseObject.product != null)  // Add null checking here
                {
                    namebox.Text = responseObject.product.ProductName;
                    idbox.Text = responseObject.product.ProductID.ToString(); // Converting integer to string
                    amountbox.Text = responseObject.product.AmountKG.ToString(); // Converting integer to string
                    pricebox.Text = responseObject.product.PricePerKG.ToString(); // Converting integer to string
                }
                else
                {
                    MessageBox.Show("No product data returned from API.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error whencalling the API: " + ex.Message);
            }
        }

        private void clearbutton_Click(object sender, RoutedEventArgs e)
        {
            namebox.Text = "";
            idbox.Text = "";
            amountbox.Text = "";
            pricebox.Text = "";
            responselabel.Content = "";
            label55.Text = "";
        }

        private async void showallbutton_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.GetStringAsync("GetAllProducts");

            Response responseObject = JsonConvert.DeserializeObject<Response>(response);

            responselabel.Visibility = Visibility.Visible;
            responselabel.Content = responseObject.statusCode + " " + responseObject.message;

            if (responseObject.productList != null)  // Add null checking here
            {
                showallgrid.ItemsSource = responseObject.productList;
            }
            else
            {
                MessageBox.Show("No product data returned from API.");
            }
        }

        private async void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            products product = new products();
            product.ProductName = namebox.Text;
            product.ProductID = int.Parse(idbox.Text);
            product.AmountKG = int.Parse(amountbox.Text);
            product.PricePerKG = decimal.Parse(pricebox.Text);

            var response = await httpClient.PutAsJsonAsync($"UpdateProduct/{product.ProductID}", product);

            MessageBox.Show(response.StatusCode.ToString());
        }

        private async void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.DeleteAsync($"DeleteProductById/{label55.Text}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully deleted the product.");
            }
            else
            {
                MessageBox.Show("Failed to delete the product.");
            }
        }

        private void salesbutton_Click(object sender, RoutedEventArgs e)
        {
            Sales sl = new Sales();
            sl.Show();
            this.Close();
        }
    }
}

