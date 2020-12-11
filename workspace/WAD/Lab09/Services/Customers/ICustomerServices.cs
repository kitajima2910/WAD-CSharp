using Lab09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab09.Services.Customers
{
    public interface ICustomerServices
    {
        List<Customer> GetCustomers();
        void Create(Customer customer);
    }
}
