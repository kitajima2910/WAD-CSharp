using Lab09.Models;
using Lab09.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab09.Services.Orders
{
    public class OrderServicesImpl : IOrderServices
    {
        private readonly ApplicationContext context;

        public OrderServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public void Create(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            return context.Orders.ToList();
        }
    }
}
