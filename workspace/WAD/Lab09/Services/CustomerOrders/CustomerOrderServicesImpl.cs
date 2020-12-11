using Lab09.Models;
using Lab09.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab09.Services.CustomerOrders
{
    public class CustomerOrderServicesImpl : ICustomerOrderServices
    {
        private readonly ApplicationContext context;

        public CustomerOrderServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public List<CustomerOrder> GetCustomerOrders()
        {
            return context.CustomerOrders.ToList();
        }
    }
}
