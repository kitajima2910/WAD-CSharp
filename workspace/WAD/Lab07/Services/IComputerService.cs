using Lab07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07.Services
{
    public interface IComputerService
    {
        List<Computer> GetComputers();
        List<Computer> GetComputers(string computerName);
        Computer GetComputer(int id);
        void Create(Computer computer);
        void Edit(Computer computer);
        void Delete(int id);
    }
}
