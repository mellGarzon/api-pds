using System;
using AutoMapper;
using PDS.WebApi.DTO;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
	public class AutoMapperDTOs : Profile
    {
		public AutoMapperDTOs()
		{

            CreateMap<Address, AddressDTO>().PreserveReferences().MaxDepth(0);

            CreateMap<AgriculturalProducer, AgriculturalProducerDTO>().PreserveReferences().MaxDepth(0);

            CreateMap<Client, ClientDTO>().PreserveReferences().MaxDepth(0);

            CreateMap<Order, OrderDTO>().PreserveReferences().MaxDepth(0);

            CreateMap<OrderSplitted, OrderSplittedDTO>().PreserveReferences().MaxDepth(0);

            CreateMap<Product, ProductDTO>().PreserveReferences().MaxDepth(0);

            CreateMap<ProductRoute, ProductRouteDTO>().PreserveReferences().MaxDepth(0);

            CreateMap<Domain.Entities.Route, RouteDTO>().PreserveReferences().MaxDepth(0);

        }
	}
}

