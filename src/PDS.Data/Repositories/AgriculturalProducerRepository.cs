using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PDS.Data.Context;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class AgriculturalProducerRepository: IAgriculturalProducerRepository
	{
        private readonly DataContext _context;

		public AgriculturalProducerRepository(DataContext context)
		{
            _context = context;

        }

        public bool Delete(int id)
        {
            var item = _context.AgriculturalProducers.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;
            else
            {
                _context.AgriculturalProducers.Remove(item);
                return true;
            }
        }

        public Task<List<AgriculturalProducer>> GetAllAsync()
        {
            return _context.AgriculturalProducers.ToListAsync();
        }

        public Task<AgriculturalProducer?> GetByIdAsync(long id)
        {
            return _context.AgriculturalProducers.SingleOrDefaultAsync(i => i.Id == id);
        }

        public Task<AgriculturalProducer?> GetByEmail(string email)
        {
            return _context.AgriculturalProducers.SingleOrDefaultAsync(i => i.Email == email);
        }

        public void Add(AgriculturalProducer t)
        {
            _context.AgriculturalProducers.Add(t);
        }

        public void Update(AgriculturalProducer t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}

