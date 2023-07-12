using System;
using PDS.Domain.Entities;
using PDS.Domain.Interfaces.Base;

namespace PDS.Domain.Interfaces.ServiceInterfaces
{
	public interface IClientService : IBaseService
    {
        public void registerAsync(Client client);
    }
}

