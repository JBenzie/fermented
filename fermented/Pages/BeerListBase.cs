using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using fermented.Services;
using fermented.Data;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace fermented.Pages
{
    public class BeerListBase:ComponentBase
    {
        [Inject]
        public IBeerService BeerService { get; set; }

        public Root results { get; set; }
        public IEnumerable<OpenBeerDB_Model> results_csv { get; set; }

        public List<Beer> Beers { get; set; }

        public string searchTerm { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Beers = (await BeerService.GetBreweryDBData(searchTerm));

            //using (var reader = new StreamReader("wwwroot\\Assets\\beers.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    results_csv = (csv.GetRecords<OpenBeerDB_Model>()).ToList();
            //}

            //if (results_csv != null)
            //{
            //    foreach (var x in results_csv)
            //    {
            //        Beers.Add(new Beer
            //        {
            //            name = x.name,
            //            desc = x.descript,
            //            abv = x.abv,
            //            src = "CSV"
            //        });
            //    }
            //}

            //Beers.Distinct().OrderBy(x => x.name);
        }

        protected async Task OnSearchAsync()
        {
            Beers = (await BeerService.GetBreweryDBData(searchTerm));

            //using (var reader = new StreamReader("wwwroot\\Assets\\beers.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    var temp_csv = (csv.GetRecords<OpenBeerDB_Model>()).ToList();
            //    results_csv = temp_csv.Where(x => x.name.ToLower().Contains(searchTerm));
            //}

            //if (results_csv != null)
            //{
            //    foreach (var x in results_csv)
            //    {
            //        Beers.Add(new Beer
            //        {
            //            name = x.name,
            //            desc = x.descript,
            //            abv = x.abv,
            //            src = "CSV"
            //        });
            //    }
            //}

            //Beers.Distinct().OrderBy(x => x.name);
            
        }

    }
}
