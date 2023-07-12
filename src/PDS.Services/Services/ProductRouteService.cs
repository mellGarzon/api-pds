using System;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Service.Services
{
	public class ProductRouteService: IProductRouteService
	{
		private readonly IProductRouteRepository _productRouteRepository;

		public ProductRouteService(
            IProductRouteRepository productRouteRepository,
            IUnitOfWork unitOfWork
        )
		{
			_productRouteRepository = productRouteRepository;

        }
	}
}

