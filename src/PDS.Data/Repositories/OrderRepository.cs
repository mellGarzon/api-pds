using System;
using Microsoft.EntityFrameworkCore;
using PDS.Data.Context;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class OrderRepository: IOrderRepository
	{
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
		{
            _context = context;
        }

        public bool Delete(int id)
        {
            var item = _context.Orders.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;
            else
            {
                _context.Orders.Remove(item);
                return true;
            }
        }

        public Task<List<Order>> GetAllAsync()
        {
            return _context.Orders.ToListAsync();
        }

        public Task<Order?> GetByIdAsync(long id)
        {
            return _context.Orders.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Add(Order t)
        {
            _context.Orders.Add(t);
        }

        public void Update(Order t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}

