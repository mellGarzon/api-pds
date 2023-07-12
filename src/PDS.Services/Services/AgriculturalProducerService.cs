using System;
using System.Runtime.CompilerServices;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Service.Services
{
	public class AgriculturalProducerService: IAgriculturalProducerService
	{
		private readonly IAgriculturalProducerRepository _agriculturalProducerRepository;

		public AgriculturalProducerService(
            IAgriculturalProducerRepository agriculturalProducerRepository,
            IUnitOfWork unitOfWork
        )
		{
			_agriculturalProducerRepository = agriculturalProducerRepository;

        }

        public void registerAsync(AgriculturalProducer agriculturalProducer)
        {

            _agriculturalProducerRepository.Add(agriculturalProducer);
        }

    }
}

