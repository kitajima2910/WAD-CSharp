﻿using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Services
{
    public interface ICityServices
    {
        List<City> GetCities();
        void CreateCity(City city);
    }
}
