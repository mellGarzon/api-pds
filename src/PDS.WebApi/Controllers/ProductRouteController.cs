using System;
using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDS.Data.Repositories;
using PDS.Domain.Constants;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;
using PDS.WebApi.DTO;
using PDS.WebApi.ViewModels;

namespace PDS.WebApi.Controllers
{
    [Authorize]
    [ApiController]
	[Route("api/[controller]")]
	public class ProductRouteController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductRouteRepository _productRouteRepository;
		private readonly IProductRepository _productRepository;
		private readonly IRouteRepository _routeRepository;
		private readonly IMapper _mapper;

		public ProductRouteController
		(
			IUnitOfWork unitOfWork,
			IProductRouteRepository productRouteRepository,
			IProductRepository productRepository,
			IRouteRepository routeRepository,
			IMapper mapper
		)
		{
			_unitOfWork = unitOfWork;
			_productRouteRepository = productRouteRepository;
			_productRepository = productRepository;
			_routeRepository = routeRepository;
			_mapper = mapper;

		}

       
        [Authorize(Roles = RoleConstants.CLIENT)]
        [HttpGet("cep/{cep}")]
		public async Task<IActionResult> GetAllByCepAsync(string cep)
		{
			try
			{
				var productsRoute = await _productRouteRepository.GetAllByCepAsync(cep);
				var productsRouteDTO = _mapper.Map<List<ProductRouteDTO>>(productsRoute);
				return Ok(productsRouteDTO);
			}
			catch (Exception e)
			{
				throw new Exception(e.ToString());
			}
		}

       
        [Authorize(Roles = RoleConstants.AGRICULTURAL_PRODUCER)]
        [HttpGet("agriculturalProducerId/{agriculturalProducerId}")]
        public async Task<IActionResult> GetAllByAgriculturalProducerAsync(long agriculturalProducerId)
        {
            try
            {
                var productsRoute = await _productRouteRepository.GetAllByAgriculturalProducerAsync(agriculturalProducerId);
                var productsRouteDTO = _mapper.Map<List<ProductRouteDTO>>(productsRoute);
                return Ok(productsRouteDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByCepAsync(long id)
        {
            try
            {
                var productsRoute = await _productRouteRepository.GetByIdAsync(id);
                var productsRouteDTO = _mapper.Map<ProductRouteDTO>(productsRoute);
                return Ok(productsRouteDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [Authorize(Roles = RoleConstants.AGRICULTURAL_PRODUCER)]
        [HttpPost]
		public async Task<IActionResult> AddAsync(ProductRouteViewModel item)
		{

			try
			{
                var route = await _routeRepository.GetByIdAsync(item.RouteId);
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (route == null || product == null)
                {
                    throw new Exception("Dados inválidos");
                }


                var productRoute = new ProductRoute
                {
                    ProductId = item.ProductId,
                    RouteId = item.RouteId
                };

                _productRouteRepository.Add(productRoute);
                await _unitOfWork.CommitAsync();

				return Ok();

            } catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

	}
}

