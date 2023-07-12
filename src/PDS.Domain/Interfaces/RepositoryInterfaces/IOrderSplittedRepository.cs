using System;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces.RepositoryInterfaces;

namespace PDS.Domain.Interfaces
{
	public interface IOrderSplittedRepository: IBaseRepository<OrderSplitted>
	{
        Task<List<OrderSplitted>> GetAllByClientWithPendingRequestsAsync(long clientId);
        Task<List<OrderSplitted>> GetAllByClientWithNoPendingRequestsAsync(long clientId);
        Task<List<OrderSplitted>> GetAllByAgriculturalProducerIdWithNoPendingRequestsAsync(long agriculturalProducerId);
        Task<List<OrderSplitted>> GetAllByAgriculturalProducerWithPendingRequestsAsync(long agriculturalProducerId);
    }
}