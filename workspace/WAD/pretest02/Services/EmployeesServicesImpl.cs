using pretest02.Models;
using pretest02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pretest02.Services
{
    public class EmployeesServicesImpl : IEmployeesServices
    {

        private readonly ApplicationContext context;

        public EmployeesServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public Employees GetEmployee(int empID)
        {
            return context.Employees.Find(empID);
        }

        public List<Employees> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public void Update(Employees employees)
        {
            context.Update(employees);
            context.SaveChanges();
        }
    }
}
