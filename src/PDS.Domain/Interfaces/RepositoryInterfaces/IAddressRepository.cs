using System;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces.RepositoryInterfaces;

namespace PDS.Domain.Interfaces
{
	public interface IAddressRepository: IBaseRepository<Address>
	{
        Task<Address?> GetByClientIdAsync(long clientId);

    }
}

