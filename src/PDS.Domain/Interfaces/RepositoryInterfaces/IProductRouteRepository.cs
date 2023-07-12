using System;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces.RepositoryInterfaces;

namespace PDS.Domain.Interfaces
{
	public interface IProductRouteRepository : IBaseRepository<ProductRoute>
    {
        Task<ProductRoute?> GetByProductAndRouteIdAsync(long productId, long routeId);
        Task<List<ProductRoute>> GetAllByCepAsync(string cep);
        Task<List<ProductRoute>> GetAllByAgriculturalProducerAsync(long agriculturalProducerId);

    }
}

