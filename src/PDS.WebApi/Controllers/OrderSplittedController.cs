using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDS.Data.Repositories;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;
using PDS.WebApi.DTO;
using PDS.WebApi.ViewModels;

namespace PDS.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderSplittedController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderSplittedRepository _orderSplittedRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRouteRepository _productRouteRepository;
        private readonly IMapper _mapper;

        public OrderSplittedController
        (
            IUnitOfWork unitOfWork,
            IOrderSplittedRepository orderSplittedRepository,
            IOrderRepository orderRepository,
            IProductRouteRepository productRouteRepository,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _orderSplittedRepository = orderSplittedRepository;
            _orderRepository = orderRepository;
            _productRouteRepository = productRouteRepository;
            _mapper = mapper;
        }


        [HttpGet("noPendingRequests/client/{clientId}")]
        public async Task<IActionResult> GetAllByClientWithNoPendingRequestsAsync(long clientId)
        {
            try
            {
                var orderSplitted = await _orderSplittedRepository.GetAllByClientWithNoPendingRequestsAsync(clientId);

                var orderSplittedDTO = _mapper.Map<List<OrderSplittedDTO>>(orderSplitted);

                return Ok(orderSplittedDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("pendingRequests/client/{clientId}")]
        public async Task<IActionResult> GetAllByClientWithPendingRequestsAsync(long clientId)
        {
            try
            {
                var orderSplitted = await _orderSplittedRepository.GetAllByClientWithPendingRequestsAsync(clientId);

                var orderSplittedDTO = _mapper.Map<List<OrderSplittedDTO>>(orderSplitted);

                return Ok(orderSplittedDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("noPendingRequests/agriculturalProducer/{agriculturalProducerId}")]
        public async Task<IActionResult> GetAllByAgriculturalProducerIdWithNoPendingRequestsAsync(long agriculturalProducerId)
        {
            try
            {
                var orderSplitted = await _orderSplittedRepository.GetAllByAgriculturalProducerIdWithNoPendingRequestsAsync(agriculturalProducerId);
                var orderSplittedDTO = _mapper.Map<List<OrderSplittedDTO>>(orderSplitted);

                return Ok(orderSplittedDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("pendingRequests/agriculturalProducer/{agriculturalProducerId}")]
        public async Task<IActionResult> GetAllByAgriculturalProducerWithPendingRequestsAsync(long agriculturalProducerId)
        {
            try
            {
                var orderSplitted = await _orderSplittedRepository.GetAllByAgriculturalProducerWithPendingRequestsAsync(agriculturalProducerId);
                var orderSplittedDTO = _mapper.Map<List<OrderSplittedDTO>>(orderSplitted);

                return Ok(orderSplittedDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPost]
		public async Task<IActionResult> AddAsync(OrderSplittedViewModel item)
		{

			try
			{

                //criando uma OrderSplitted
                var orderSplitted = new OrderSplitted()
                {
                    ClientId = item.ClientId,
                    AgriculturalProducerId = item.AgriculturalProducerId
                };
                
                _orderSplittedRepository.Add(orderSplitted);
                await _unitOfWork.CommitAsync();

                foreach (var order in item.Orders)
                {

                    //criando varias order
                    var orderOfOrderSplitted = new Order()
                    {
                        Amount = order.Amount,
                        ProductRouteId = order.ProductRouteId,
                        OrderSplittedId = orderSplitted.Id,
                        Response = order.Response,
                        TimeToAnswer = order.TimeToAnswer
                    };

                    _orderRepository.Add(orderOfOrderSplitted);
                    await _unitOfWork.CommitAsync();
                }

                await _unitOfWork.CommitAsync();

                return Ok();

            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}

