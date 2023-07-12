using System;
using Microsoft.EntityFrameworkCore;
using PDS.Data.Context;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class ClientRepository: IClientRepository
	{
        private readonly DataContext _context;

		public ClientRepository(DataContext context)
		{
            _context = context;

        }

        public bool Delete(int id)
        {
            var item = _context.Clients.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;
            else
            {
                _context.Clients.Remove(item);
                return true;
            }
        }

        public Task<List<Client>> GetAllAsync()
        {
            return _context.Clients.ToListAsync();
        }

        public Task<Client?> GetByIdAsync(long id)
        {
            return _context.Clients.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Add(Client t)
        {
            _context.Clients.Add(t);
        }

        public void Update(Client t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }

        public Task<Client?> GetByEmail(string email)
        {
            return _context.Clients.SingleOrDefaultAsync(i => i.Email == email);
        }
    }
}

