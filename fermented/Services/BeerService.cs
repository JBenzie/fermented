using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CsvHelper;
using fermented.Data;
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

        public async Task<List<Beer>> GetBreweryDBData(string searchTerm)
        {
            string url;
            List<Beer> Beers = new List<Beer>();
            IEnumerable<OpenBeerDB_Model> results_csv = null;
            if(searchTerm == null)
            {
                url = "beers/?key=bc89972830c7ba3bb8d065585964191a";
            } else
            {
                url = "search?q=" + searchTerm + "&type=beer&key=bc89972830c7ba3bb8d065585964191a";
            }
            
            var content = await httpClient.GetStringAsync(url);
            Console.WriteLine("content: " + content);

            var temp = JsonConvert.DeserializeObject<Root>(content);

            foreach (var x in temp.data)
            {
                Beers.Add(new Beer
                {
                    name = x.nameDisplay,
                    desc = x.description,
                    abv = x.abv,
                    src = "Web API"
                });
            }

            using (var reader = new StreamReader("wwwroot\\Assets\\beers.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var temp_csv = (csv.GetRecords<OpenBeerDB_Model>());
                if (searchTerm != null)
                {
                    results_csv = temp_csv.Where(x => x.name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }
                else
                {
                    results_csv = temp_csv.ToList();
                }
            }

            if (results_csv != null)
            {
                foreach (var x in results_csv)
                {
                    Beers.Add(new Beer
                    {
                        name = x.name,
                        desc = x.descript,
                        abv = x.abv,
                        src = "CSV"
                    });
                }
            }
            if (searchTerm != null || searchTerm != "" || searchTerm != " ")
            {
                Beers.Where(x => x.name.ToLower().Contains(searchTerm.ToLower()));
            }
            Beers.Distinct().OrderBy(x => x.name);

            return Beers;
        }
    }
}
