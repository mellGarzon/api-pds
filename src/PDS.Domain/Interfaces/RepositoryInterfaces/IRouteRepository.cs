using System;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces.RepositoryInterfaces;

namespace PDS.Domain.Interfaces
{
	public interface IRouteRepository : IBaseRepository<Route>
    {
        Task<List<Route>> GetAllByAgriculturalProducerAsync(long producerId);

    }
}

