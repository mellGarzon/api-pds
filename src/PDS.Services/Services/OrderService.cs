using System;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Service.Services
{
	public class OrderService: IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(
			IOrderRepository orderRepository,
            IUnitOfWork unitOfWork
        )
		{
			_orderRepository = orderRepository;

        }
	}
}

