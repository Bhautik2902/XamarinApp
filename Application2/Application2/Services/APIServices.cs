using Application2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Application2.Services
{
    class APIServices
    {
        static string BaseUrl = "https://crudcrud.com/api/e1a6be7a56b64f3392beaf1c8950a2de"; 

        static HttpClient client;

        static APIServices()
        {
            try
            {
                client = new HttpClient();
               /* {
                    BaseAddress = new Uri(BaseUrl)
                };*/
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
        }

        public static IEnumerable<Contact> GetAllRecords()
        {
            Uri uri = new Uri("https://crudcrud.com/api/80f8fb64a6c34f138c2aa28c3c4d043b/unicorns");
            var json = client.GetAsync(uri).Result;
            string tokenresponse = json.StatusCode.ToString();
            string clientresult = json.Content.ReadAsStringAsync().Result;

            return new List<Contact>();
        }

        

    }
}
