using Lab07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07.Services
{
    public class ComputerServiceImpl : IComputerService
    {
        private readonly ApplicationContext _context;

        public ComputerServiceImpl(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Computer computer)
        {
            _context.Computers.Add(computer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldComputer = _context.Computers.Find(id);
            _context.Computers.Remove(oldComputer);
            _context.SaveChanges();
        }

        public void Edit(Computer computer)
        {
            _context.Update(computer);
            _context.SaveChanges();
        }

        public Computer GetComputer(int id)
        {
            return _context.Computers.Find(id);
        }

        public List<Computer> GetComputers()
        {
            return _context.Computers.ToList();
        }

        public List<Computer> GetComputers(string computerName)
        {
            var computers = _context.Computers
                .Where(m => m.ComputerName.Contains(computerName))
                .ToList();

            return computers;
        }
    }
}
