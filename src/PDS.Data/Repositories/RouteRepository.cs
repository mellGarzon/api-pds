using System;
using Microsoft.EntityFrameworkCore;
using PDS.Data.Context;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class RouteRepository: IRouteRepository
	{
        private readonly DataContext _context;
        public RouteRepository(DataContext context)
		{
            _context = context;
        }

        public bool Delete(int id)
        {
            var item = _context.Routes.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;
            else
            {
                _context.Routes.Remove(item);
                return true;
            }
        }

        public Task<List<Route>> GetAllAsync()
        {
            return _context.Routes.ToListAsync();
        }

        public Task<Route?> GetByIdAsync(long id)
        {
            return _context.Routes.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Add(Route t)
        {
            _context.Routes.Add(t);
        }

        public void Update(Route t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }

        public Task<List<Route>> GetAllByAgriculturalProducerAsync(long producerId)
        {
            return _context.Routes.Where(p => p.Id == producerId).ToListAsync();
        }
    }
}

