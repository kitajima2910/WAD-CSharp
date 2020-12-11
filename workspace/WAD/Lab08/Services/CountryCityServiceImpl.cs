using Lab08.Models;
using Lab08.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Services
{
    public class CountryCityServiceImpl : ICountryCityServices
    {
        private readonly ApplicationContext context;

        public CountryCityServiceImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public List<CountryCity> GetCountryCities()
        {
            return context.Country
                .Join(context.City,
                    country => country.idCode,
                    city => city.idCode,
                    (country, city) => new CountryCity
                    {
                        Country = country,
                        City = city
                    }
                ).ToList();
        }

        public List<CountryCity> GetCountryCities(string keyword)
        {
            return context.Country.Where(m => m.idCode.Contains(keyword))
                .Join(context.City,
                    country => country.idCode,
                    city => city.idCode,
                    (country, city) => new CountryCity
                    {
                        Country = country,
                        City = city
                    }
                ).ToList();
        }
    }
}
