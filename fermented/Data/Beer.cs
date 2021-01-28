using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fermented.Data;

namespace fermented.Data
{
    public class Beer
    {
        public string name { get; set; }
        public string abv { get; set; }
        public string desc { get; set; }
        public string src { get; set; }

        //public Root Root { get; set; } // BreweryDB Model - Web api data
        //public IEnumerable<OpenBeerDB_Model> OpenBeerDBs { get; set; } // Open Beer Database Model - csv import

    }
}
