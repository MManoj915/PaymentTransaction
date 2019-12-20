using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace PaymentTransaction.Models
{
    public class Api_Helper
    {

        public static List<T> GetDataFromApi<T>(string ApiPath, string urlAction)
        {
            List<T> returnValue =
                 default(List<T>);


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiPath);

                client.DefaultRequestHeaders.Clear();

                // added by karthik
                // To maintaining the http client request timeout with timespan  
                client.Timeout = new TimeSpan(0, 1, 0, 0, 0); // 

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var Res = client.GetAsync(urlAction).Result;

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {

                    returnValue = JsonConvert.DeserializeObject<List<T>>(((HttpResponseMessage)Res).Content.ReadAsStringAsync().Result);

                }


            }
            return returnValue;
        }


        public static string SaveProduct(string ApiPath, string urlAction, object Obj)
        {
            string data = "S";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiPath);
                client.DefaultRequestHeaders.Accept.Clear();

                // added by karthik
                // To maintaining the http client request timeout with timespan  
                client.Timeout = new TimeSpan(0, 1, 0, 0, 0); // 


                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(Obj), Encoding.UTF8, "application/json");
                // HTTP POST
                HttpResponseMessage response = client.PostAsync(urlAction, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    data = response.Content.ReadAsStringAsync().Result;
                    //  product = JsonConvert.DeserializeObject<Product>(data);
                }
                else
                {
                    data = "Error While Inserting Data !.";
                }
            }
            return data;
        }





        public static DataTable GetDataTable(string ApiPath, string urlAction)
        {
            DataTable returnValue = new DataTable();

            Type valueType = typeof(object);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiPath);

                client.DefaultRequestHeaders.Clear();

                // added by karthik
                // To maintaining the http client request timeout with timespan  
                client.Timeout = new TimeSpan(0, 1, 0, 0, 0); // 


                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var Res = client.GetAsync(urlAction).Result;

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {

                    //  var restult= Res.Content.ReadAsStringAsync().Result;
                    returnValue = JsonConvert.DeserializeObject<DataTable>(((HttpResponseMessage)Res).Content.ReadAsStringAsync().Result);



                }


            }
            return returnValue;
        }



    }
}