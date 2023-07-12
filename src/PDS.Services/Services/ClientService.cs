using System;
using System.Text;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Service.Services
{
	public class ClientService: IClientService
	{
		private readonly IClientRepository _clientRepository;

		public ClientService(
			IClientRepository clientRepository,
            IUnitOfWork unitOfWork
        )
		{
			_clientRepository = clientRepository;

        }

        public void registerAsync(Client client)
        {
			_clientRepository.Add(client);
        }
    }
}

