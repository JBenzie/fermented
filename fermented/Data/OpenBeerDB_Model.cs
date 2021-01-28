using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace fermented.Data
{
    public class OpenBeerDB_Model
    {
        public string id { get; set; }
        public string brewery_id { get; set; }
        public string name { get; set; }
        public string cat_id { get; set; }
        public string style_id { get; set; }
        public string abv { get; set; }
        public string ibu { get; set; }
        public string srm { get; set; }
        public string upc { get; set; }
        public string filepath { get; set; }
        public string descript { get; set; }
        public string last_mod { get; set; }

    }

    public class OpenBeerDBCsv_Map : ClassMap<OpenBeerDB_Model>
    {
        public OpenBeerDBCsv_Map()
        {
            Map(l => l.id).Name("id");
            Map(l => l.brewery_id).Name("brewery_id");
            Map(l => l.name).Name("name");
            Map(l => l.cat_id).Name("cat_id");
            Map(l => l.style_id).Name("style_id");
            Map(l => l.abv).Name("abv");
            Map(l => l.ibu).Name("ibu");
            Map(l => l.srm).Name("srm");
            Map(l => l.upc).Name("upc");
            Map(l => l.filepath).Name("filepath");
            Map(l => l.descript).Name("descript");
            Map(l => l.last_mod).Name("last_mod");
        }
    }
}
