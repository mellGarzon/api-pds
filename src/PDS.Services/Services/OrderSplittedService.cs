using System;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Service.Services
{
	public class OrderSplittedService: IOrderSplittedService
	{
		private readonly IOrderSplittedRepository _orderSplittedRepository;

		public OrderSplittedService(
			IOrderSplittedRepository orderSplittedRepository,
            IUnitOfWork unitOfWork
        )
		{
			_orderSplittedRepository = orderSplittedRepository;

        }
	}
}

