using System;
using Microsoft.EntityFrameworkCore;
using PDS.Data.Context;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class OrderSplittedRepository: IOrderSplittedRepository
	{
        private readonly DataContext _context;

        public OrderSplittedRepository(DataContext context)
		{
            _context = context;
        }

        public bool Delete(int id)
        {
            var item = _context.OrdersSplitted.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;
            else
            {
                _context.OrdersSplitted.Remove(item);
                return true;
            }
        }

        public Task<List<OrderSplitted>> GetAllAsync()
        {
            return _context.OrdersSplitted.ToListAsync();
        }

        //encomendas com solicitacoes pendentes 
        public Task<List<OrderSplitted>> GetAllByClientWithPendingRequestsAsync(long clientId)
        {
            return _context.OrdersSplitted
               .Include(i => i.Orders)
               .Include(i => i.Client)
              .Where(os => os.ClientId == clientId
                       && os.Orders.Any(o => !o.Response))
              .ToListAsync();
        }

        //encomendas sem solicitacoes pendentes
        public Task<List<OrderSplitted>> GetAllByClientWithNoPendingRequestsAsync(long clientId)
        {
            return _context.OrdersSplitted
              .Include(i => i.Orders)
              .Include(i => i.Client)
              .Where(os => os.ClientId == clientId
                       && os.Orders.Any(o => o.Response != false))
              .ToListAsync();
        }

        //encomendas com solicitacoes pendentes 
        public Task<List<OrderSplitted>> GetAllByAgriculturalProducerWithPendingRequestsAsync(long agriculturalProducerId)
        {
            return _context.OrdersSplitted
               .Include(i => i.Orders)
               .Include(i => i.Client)
              .Where(os => os.AgriculturalProducerId == agriculturalProducerId
                       && os.Orders.Any(o => !o.Response))
              .ToListAsync();
        }

        //encomendas sem solicitacoes pendentes
        public Task<List<OrderSplitted>> GetAllByAgriculturalProducerIdWithNoPendingRequestsAsync(long agriculturalProducerId)
        {
            return _context.OrdersSplitted
              .Include(i => i.Orders)
              .Include(i => i.Client)
              .Where(os => os.ClientId == agriculturalProducerId
                       && os.Orders.Any(o => o.Response != false))
              .ToListAsync();
        }

        public Task<OrderSplitted?> GetByIdAsync(long id)
        {
            return _context.OrdersSplitted.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Add(OrderSplitted t)
        {
            _context.OrdersSplitted.Add(t);
        }

        public void Update(OrderSplitted t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}

