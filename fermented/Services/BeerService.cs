using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using fermented.Data;
using fermented.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace fermented.Services
{
    public class BeerService : IBeerService
    {
        private readonly HttpClient httpClient;

        public BeerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Root> GetBeers(string searchTerm)
        {
            string url;
            if(searchTerm == null)
            {
                url = "beers/?key=bc89972830c7ba3bb8d065585964191a";
            } else
            {
                url = "search?q=" + searchTerm + "&type=beer&key=bc89972830c7ba3bb8d065585964191a";
            }
            
            var content = await httpClient.GetStringAsync(url);
            Console.WriteLine("content: " + content);
            return JsonConvert.DeserializeObject<Root>(content);
        }
    }
}
