using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDS.Data.Repositories;
using PDS.Domain.Constants;
using PDS.Domain.Entities;
using PDS.Domain.Enum;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;
using PDS.Services.Services;
using PDS.WebApi.DTO;
using PDS.WebApi.ViewModels;

namespace PDS.WebApi.Controllers
{
	[ApiController]
	[Authorize]
    [Route("api/[controller]")]
    public class ProductController: ControllerBase
	{
		private readonly IProductRepository _productRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IAgriculturalProducerRepository _agriculturalProducerRepository;
		private readonly IClientRepository _clientRepository;
		private readonly ITokenService _tokenService;
        private readonly IAddressRepository _addressRepository;
		private readonly IProductRouteRepository _productRouteRepository;
		private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;


        public ProductController(
			IProductRepository productRepository,
			IUnitOfWork unitOfWork,
			IAgriculturalProducerRepository agriculturalProducerRepository,
			IClientRepository clientRepository,
			ITokenService tokenService,
			IAddressRepository addressRepository,
			IProductRouteRepository productRouteRepository,
			IRouteRepository routeRepository,
            IMapper mapper
        )
		{
			_clientRepository = clientRepository;
            _agriculturalProducerRepository = agriculturalProducerRepository;
            _productRepository = productRepository;
			_unitOfWork = unitOfWork;
			_tokenService = tokenService;
			_addressRepository = addressRepository;
			_productRouteRepository = productRouteRepository;
			_routeRepository = routeRepository;
            _mapper = mapper;

        }

		[HttpGet("{productId}/{routeId}")]
        public async Task<IActionResult> GetOneByAsync(long productId, long routeId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                return NotFound("Produto não encontrado");
            }

            var agriculturalProducer = await _agriculturalProducerRepository.GetByIdAsync(product.AgriculturalProducerId);
            if(agriculturalProducer == null)
            {
                return NotFound("Produtor agrícola não foi encontrado");
            }

            var productRoute = await _productRouteRepository.GetByProductAndRouteIdAsync(productId, routeId);
            if (productRoute == null)
            {
                return NotFound("Rota e produto não foram encontradas");
            }

            var route = await _routeRepository.GetByIdAsync(productRoute.RouteId);
            if (route == null)
            {
                return NotFound("Rota não encontrada");
            }

            var result = new {
                Name = product.Name,
                Amount = product.Amount,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                AgriculturalProducer = new {
                    Name = agriculturalProducer.Name,
                    ImageUrl = agriculturalProducer.ImageUrl
                },
                Route =  new
                {
                    Name = route.Name,
                    City = route.City,
                    DeliveryDate = route.DeliveryDate,
                } 
            };
            return Ok(result);

        }


//TENHO QUE PEGAR PELO PRODUCT_ROUTE E NAO PELO PRODUCT

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ProductViewModel item)
		{

			var agriculturalProducer = await _agriculturalProducerRepository.GetByIdAsync(item.AgriculturalProducerId);
			if(agriculturalProducer == null)
                return NotFound("Produtor agrícola não encontrado");

            try
			{
                var product = new Product
                {

                    Name = item.Name,
                    Price = item.Price,
                    Amount = item.Amount,
                    Description = item.Description,
                    AgriculturalProducerId = item.AgriculturalProducerId,
                    ImageUrl = item.ImageUrl

                };

                _productRepository.Add(product);
                await _unitOfWork.CommitAsync();

				return Ok();

            } catch(Exception e)
			{
				throw new Exception(e.ToString());
			}

        }

    }
}

