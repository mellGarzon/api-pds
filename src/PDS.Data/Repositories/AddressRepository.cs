using System;
using Microsoft.EntityFrameworkCore;
using PDS.Data.Context;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class AddressRepository: IAddressRepository
	{

        private readonly DataContext _context;

		public AddressRepository(DataContext context)
		{
            _context = context;

        }

        public bool Delete(int id)
        {
            var item = _context.Adresses.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;
            else
            {
                _context.Adresses.Remove(item);
                return true;
            }
        }

        public Task<List<Address>> GetAllAsync()
        {
            return _context.Adresses.ToListAsync();
        }

        public Task<Address?> GetByIdAsync(long id)
        {
            return _context.Adresses.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Add(Address t)
        {
            _context.Adresses.Add(t);
        }

        public void Update(Address t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }

        public Task<Address?> GetByClientIdAsync(long clientId)
        {
            return _context.Adresses.SingleOrDefaultAsync(i => i.ClientId == clientId);
        }
    }
}

