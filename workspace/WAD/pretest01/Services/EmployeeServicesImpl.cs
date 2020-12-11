using pretest01.Models;
using pretest01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pretest01.Services
{
    public class EmployeeServicesImpl : IEmployeeServices
    {
        private readonly ApplicationContext context;
        
        public EmployeeServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public void Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Delete(int empID)
        {
            var employee = context.Employees.Find(empID);
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public Employee GetEmployee(int empID)
        {
            return context.Employees.Find(empID);
        }

        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }
    }
}
