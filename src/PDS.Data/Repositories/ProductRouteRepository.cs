using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using PDS.Data.Context;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class ProductRouteRepository: IProductRouteRepository
	{
        private readonly DataContext _context;
        public ProductRouteRepository(DataContext context)
		{
            _context = context;
        }

        public bool Delete(int id)
        {
            var item = _context.ProductRoutes.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;
            else
            {
                _context.ProductRoutes.Remove(item);
                return true;
            }
        }

        public Task<List<ProductRoute>> GetAllAsync()
        {
            return _context.ProductRoutes.ToListAsync();
        }

        public Task<ProductRoute?> GetByIdAsync(long id)
        {
            return _context.ProductRoutes
                .Include(i => i.Product)
                    .ThenInclude(i => i.AgriculturalProducer)
                .Include(i => i.Route).
                SingleOrDefaultAsync(i => i.Id == id);
        }

        public Task<ProductRoute?> GetByProductAndRouteIdAsync(long productId, long routeId)
        {
            return _context.ProductRoutes.SingleOrDefaultAsync(i => i.ProductId == productId && i.RouteId == routeId);
        }

        public Task<List<ProductRoute>> GetAllByCepAsync(string cep)
        {
            return _context.ProductRoutes
                .Include(i => i.Route)
                .Include(i => i.Product)
                    .ThenInclude(i => i.AgriculturalProducer)
                    .ThenInclude(i => i.Media)
                .Join(_context.Routes, pr => pr.RouteId, r => r.Id, (pr, r) => new { ProductRoute = pr, Route = r })
                .Where(i => i.Route.Cep == cep)
                .Select(i => i.ProductRoute)
                .ToListAsync();
        }

        public Task<List<ProductRoute>> GetAllByAgriculturalProducerAsync(long agriculturalProducerId)
        {
            return _context.ProductRoutes
                .Include(i => i.Route)
                .Include(i => i.Product)
                    .ThenInclude(i => i.AgriculturalProducer)
                .Join(_context.Routes, pr => pr.RouteId, r => r.Id, (pr, r) => new { ProductRoute = pr, Route = r })
                .Where(i => i.ProductRoute.Product.AgriculturalProducerId == agriculturalProducerId)
                .Select(i => i.ProductRoute)
                .ToListAsync();

        }

        public void Add(ProductRoute t)
        {
            _context.ProductRoutes.Add(t);
        }

        public void Update(ProductRoute t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}

