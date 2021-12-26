using ECommerce.Context;
using ECommerce.Entities;
using ECommerce.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Implementations.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Order Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            return _context.Orders.Find(id);
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }
    }
}
