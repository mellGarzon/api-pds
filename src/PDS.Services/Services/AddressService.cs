using System;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Service.Services
{
	public class AddressService: IAddressService
	{
		private readonly IAddressRepository _addressRepository;

		public AddressService(
			IAddressRepository addressRepository,
            IUnitOfWork unitOfWork
		)
		{
			_addressRepository = addressRepository;

        }
	}
}

