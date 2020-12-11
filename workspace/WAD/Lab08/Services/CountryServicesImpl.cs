using Lab08.Models;
using Lab08.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Services
{
    public class CountryServicesImpl : ICountryServices
    {
        private readonly ApplicationContext context;

        public CountryServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public void CreateCountry(Country country)
        {
            context.Country.Add(country);
            context.SaveChanges();
        }

        public List<Country> GetCountries()
        {
            return context.Country.ToList();
        }
    }
}
