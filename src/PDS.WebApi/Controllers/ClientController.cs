using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDS.Domain.Entities;
using PDS.Domain.Enum;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;
using PDS.Services.Services;
using PDS.WebApi.ViewModels;

namespace PDS.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController: ControllerBase
	{

		private readonly IClientRepository _clientRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ClientController(
			IClientRepository clientRepository,
			IUnitOfWork unitOfWork
		)
		{
			_clientRepository = clientRepository;
			_unitOfWork = unitOfWork;

        }

        [AllowAnonymous]
		[HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ClientViewModel item)
		{

			try
			{
                if (item == null)
                    return BadRequest("Dados inválidos");

                var passwordData = AuthService.CreatePasswordHash(item.Password);

                var client = new Client()
                {

                    Name = item.Name,
                    Email = item.Email,
                    PasswordHash = passwordData.hash,
                    Phone = item.Phone,
                    PasswordSalt = passwordData.salt,
                    ImageUrl = item.ImageUrl,
                    Role = RoleEnum.CLIENT,
                    MediaId = item.MediaId

                };

                _clientRepository.Add(client);

				await _unitOfWork.CommitAsync();

				return Ok();

            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }



	}
}

