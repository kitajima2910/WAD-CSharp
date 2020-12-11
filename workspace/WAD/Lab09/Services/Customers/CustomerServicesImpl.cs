using Lab09.Models;
using Lab09.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab09.Services.Customers
{
    public class CustomerServicesImpl : ICustomerServices
    {
        private readonly ApplicationContext context;

        public CustomerServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public void Create(Customer customer)
        {
            var oldCustomer = context.Customers.SingleOrDefault(c => c.customerid.Equals(customer.customerid));

            if(oldCustomer == null)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }
    }
}
