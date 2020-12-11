using pretest01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pretest01.Services
{
    public interface IEmployeeServices
    {
        List<Employee> GetEmployees();
        void Create(Employee employee);
        Employee GetEmployee(int empID);
        void Delete(int empID);
    }
}
