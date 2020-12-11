using Lab08.Models;
using Lab08.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Services
{
    public class CityServicesImpl : ICityServices
    {
        private readonly ApplicationContext context;

        public CityServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }


        public void CreateCity(City city)
        {
            context.City.Add(city);
            context.SaveChanges();
        }

        public List<City> GetCities()
        {
            return context.City.ToList();
        }
    }
}
