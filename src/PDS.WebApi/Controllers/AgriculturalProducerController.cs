using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDS.Data.Repositories;
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
    public class AgriculturalProducerController: ControllerBase
    {
        private readonly IAgriculturalProducerRepository _agriculturalProducerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public AgriculturalProducerController(
            IAgriculturalProducerRepository agriculturalProducerRepository,
            IUnitOfWork unitOfWork
        )
        {
            _agriculturalProducerRepository = agriculturalProducerRepository;
            _unitOfWork = unitOfWork;

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AgriculturalProducerViewModel item)
        {
            try

            {
                if (item == null)
                    return BadRequest("Dados inválidos");

                var oldAgriculturalProducer = await _agriculturalProducerRepository.GetByEmail(item.Email);

                if(oldAgriculturalProducer != null) {
                    return BadRequest("Essa conta já existe");
                }

                var passwordData = AuthService.CreatePasswordHash(item.Password);
                

                var agriculturalProducer = new AgriculturalProducer
                {

                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    PasswordHash = passwordData.hash,
                    PasswordSalt = passwordData.salt,
                    Phone = item.Phone,
                    Email = item.Email,
                    Role = RoleEnum.AGRICULTURAL_PRODUCER,
                    MediaId = item.MediaId
                };

                _agriculturalProducerRepository.Add(agriculturalProducer);
                await _unitOfWork.CommitAsync();

                return Ok();

            } catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }
    

    }
}

