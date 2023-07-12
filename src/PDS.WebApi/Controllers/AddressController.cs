using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDS.Data.Repositories;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;
using PDS.WebApi.ViewModels;

namespace PDS.WebApi.Controllers
{
    [Authorize]
    [ApiController]
	[Route("api/[controller]")]
	public class AddressController: ControllerBase
	{

		private readonly IAddressRepository _addressRepository;
		private readonly IUnitOfWork _unitOfWork;
		private IClientRepository _clientRepository;


        public AddressController(
			IAddressRepository addressRepository,
			IUnitOfWork unitOfWork,
			IClientRepository clientRepository

        )
		{

			_unitOfWork = unitOfWork;
            _addressRepository = addressRepository;
			_clientRepository = clientRepository;

        }

		[HttpPost]
		public async Task<IActionResult> AddAsync(AddressViewModel item)
		{

			try
			{
                var client = await _clientRepository.GetByIdAsync(item.ClientId);

                if (client == null)
                    return NotFound("Cliente não foi encontrado");


                var address = new Address()
                {

                    Cep = item.Cep,
                    City = item.City,
                    Completion = item.Completion,
                    Neighborhood = item.Neighborhood,
                    Number = item.Number,
                    Reference = item.Reference,
                    StreetName = item.StreetName,
                    Uf = item.Uf,
                    ClientId = item.ClientId
                };

                _addressRepository.Add(address);

                await _unitOfWork.CommitAsync();

                return Ok();

            } catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }

	}
}

