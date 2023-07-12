using System;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces.RepositoryInterfaces;

namespace PDS.Domain.Interfaces
{
	public interface IClientRepository : IBaseRepository<Client>
    {
        Task<Client?> GetByEmail(string email);
    }
}

