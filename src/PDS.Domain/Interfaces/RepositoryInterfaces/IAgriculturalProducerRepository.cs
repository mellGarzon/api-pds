using System;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces.RepositoryInterfaces;

namespace PDS.Domain.Interfaces
{
	public interface IAgriculturalProducerRepository : IBaseRepository<AgriculturalProducer>
    {
        Task<AgriculturalProducer?> GetByEmail(string email);
    }
}

