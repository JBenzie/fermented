using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fermented.Data;

namespace fermented.Services
{
    public interface IBeerService
    {
        Task<List<Beer>> GetBreweryDBData(string searchTerm = null);
    }
}
