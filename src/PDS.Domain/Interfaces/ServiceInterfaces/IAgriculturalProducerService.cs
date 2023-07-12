using System;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces.Base;
using PDS.Domain.Interfaces.RepositoryInterfaces;

namespace PDS.Domain.Interfaces.ServiceInterfaces
{
	public interface IAgriculturalProducerService : IBaseService
    {
        void registerAsync(AgriculturalProducer agriculturalProducer);
    }
}

