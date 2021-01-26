using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fermented.Services;
using fermented.Data;

namespace fermented.Pages
{
    public class BeerListBase:ComponentBase
    {
        [Inject]
        public IBeerService BeerService { get; set; }

        public Root results { get; set; }

        public string searchTerm { get; set; }

        protected override async Task OnInitializedAsync()
        {
            results = (await BeerService.GetBeers(searchTerm));
        }

        protected async Task OnSearchAsync()
        {
            results = (await BeerService.GetBeers(searchTerm));
        }
    }
}
