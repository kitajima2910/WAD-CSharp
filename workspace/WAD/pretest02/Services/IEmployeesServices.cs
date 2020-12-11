using pretest02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pretest02.Services
{
    public interface IEmployeesServices
    {
        List<Employees> GetEmployees();
        Employees GetEmployee(int empID);
        void Update(Employees employees);
    }
}
