using System;
using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
	public class RouteController: ControllerBase
	{

		private readonly IRouteRepository _routeRepository;
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAgriculturalProducerRepository _agriculturalProducerRepository;
        private readonly IMapper _mapper;

        public RouteController
        (
            IRouteRepository routeRepository,
            IUnitOfWork unitOfWork,
            IAgriculturalProducerRepository agriculturalProducerRepository,
            IMapper mapper
        )
		{
			_routeRepository = routeRepository;
			_unitOfWork = unitOfWork;
            _agriculturalProducerRepository = agriculturalProducerRepository;
            _mapper = mapper;

        }

        
        [HttpGet]
        public async Task<IActionResult> GetByAgriculturalProducerAsync()
        {

            var routes = await _routeRepository.GetAllAsync();
    
            return Ok(routes);

        }

        //[Authorize(Roles = RoleConstants.AGRICULTURAL_PRODUCER)]
        [HttpGet("agriculturalProducer/{id}")]
        public async Task<IActionResult> GetByAgriculturalProducerAsync(long id)
        {
            try
            {
                //ROTA NAO RETORNANDO COMO DEVERIA
                var routes = await _routeRepository.GetAllByAgriculturalProducerAsync(id);
                var routesDTO = _mapper.Map<List<RouteDTO>>(routes);
                return Ok(routesDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = RoleConstants.AGRICULTURAL_PRODUCER)]
        [HttpPost]
		public async Task<IActionResult> AddAsync(RouteViewModel item)
		{
            DateTime deliveryDate;

            try
            {

                deliveryDate = DateTime.ParseExact(item.DeliveryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            }
            catch (FormatException)
            {
                return BadRequest("A data está em um formato inválido");
            }

            try
			{
                var agriculturalProducer = await _agriculturalProducerRepository.GetByIdAsync((long)item.AgriculturalProducerId);
                if (agriculturalProducer == null)
                    NotFound("Produto agrícola não encontrado");

                var route = new Domain.Entities.Route()
                {
                    Cep = item.Cep,
                    City = item.City,
                    DeliveryDate = deliveryDate,
                    Name = item.Name,
                    Uf = item.Uf,
                    AgriculturalProducerId = item.AgriculturalProducerId
                };

				_routeRepository.Add(route);
                await _unitOfWork.CommitAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
	}
}

