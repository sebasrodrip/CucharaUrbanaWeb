using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using Frontend.Helpers.Interfaces;

namespace Frontend.Helpers.Implementations
{

    public class ServiceRepository : IServiceRepository
    {
        public HttpClient Client { get; set; }

        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5246"); //Agregar ApiKey cuando esté implementado

        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }



    }
}
