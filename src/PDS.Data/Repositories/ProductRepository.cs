using System;
using Microsoft.EntityFrameworkCore;
using PDS.Data.Context;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class ProductRepository: IProductRepository
	{
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
		{
            _context = context;
        }

        public bool Delete(int id)
        {
            var item = _context.Products.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;
            else
            {
                _context.Products.Remove(item);
                return true;
            }
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _context.Products.ToListAsync();
        }

        public Task<List<Product>> GetAllByAsync()
        {
            return _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _context.Products.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Add(Product t)
        {
            _context.Products.Add(t);
        }

        public void Update(Product t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}

