using System;
namespace PDS.Domain.Interfaces
{
	public interface IUnitOfWork
	{
        Task CommitAsync();

        IAddressRepository AddressRepository { get; }

        IAgriculturalProducerRepository AgriculturalProducerRepository { get; }

        IClientRepository ClientRepository { get; }

        IOrderRepository OrderRepository { get; }

        IOrderSplittedRepository OrderSplittedRepository { get; }

        IProductRepository ProductRepository { get; }

        IProductRouteRepository ProductRouteRepository { get; }

        IRouteRepository RouteRepository { get; }
    }
}

