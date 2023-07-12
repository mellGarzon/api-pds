using System;
using System.Net.Sockets;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDS.Data.Repositories;
using PDS.Domain.Entities;
using PDS.Domain.Enum;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;
using PDS.Service.Services;
using PDS.Services.Services;
using PDS.WebApi.ViewModels.User;

namespace PDS.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAgriculturalProducerRepository _agriculturalProducerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public AuthController(
            IClientRepository clientRepository,
            IAgriculturalProducerRepository agriculturalProducerRepository,
            IUnitOfWork unitOfWork,
            ITokenService tokenService
            )
        {
            _unitOfWork = unitOfWork;
            _agriculturalProducerRepository = agriculturalProducerRepository;
            _clientRepository = clientRepository;
            _tokenService = tokenService;


        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync(UserViewModel user)
        {
            if (user == null)
                return BadRequest("Dados inválidos");

            try

            {
                var client = await _clientRepository.GetByEmail(user.Email);
                var agriculturalProducer = await _agriculturalProducerRepository.GetByEmail(user.Email);
            

                if (client != null)
                {
                    bool passwordIsValid = AuthService.VerifyPasswordHash(user.Password, client.PasswordHash, client.PasswordSalt);

                    if (passwordIsValid)
                    {
                       
                        var token = _tokenService.CreateToken(client.Id, RoleEnum.CLIENT.ToString());


                        return Ok(token);
                    }
                }

                if (agriculturalProducer != null)
                {

                    bool passwordIsValid = AuthService.VerifyPasswordHash(user.Password, agriculturalProducer.PasswordHash, agriculturalProducer.PasswordSalt);
                    if (passwordIsValid)
                    {
                        var token = _tokenService.CreateToken(agriculturalProducer.Id, RoleEnum.AGRICULTURAL_PRODUCER.ToString());
                        return Ok(token);
                    }
                }

                return BadRequest("Usuário não foi encontrado");

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }



    }

