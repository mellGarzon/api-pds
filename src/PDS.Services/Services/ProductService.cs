using System;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Service.Services
{
	public class ProductService: IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork
        )
		{
			_productRepository = productRepository;

        }
	}
}

