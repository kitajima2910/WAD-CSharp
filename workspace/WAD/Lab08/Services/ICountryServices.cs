using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Services
{
    public interface ICountryServices
    {
        List<Country> GetCountries();
        void CreateCountry(Country country);
    }
}
