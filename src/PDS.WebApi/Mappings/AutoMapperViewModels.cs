using System;
using AutoMapper;
using PDS.Domain.Entities;
using PDS.WebApi.DTO;
using PDS.WebApi.ViewModels;
using PDS.WebApi.ViewModels.User;

namespace PDS.WebApi.Mappings
{
	public class AutoMapperViewModels : Profile
    {
		public AutoMapperViewModels()
		{

            CreateMap<Address, AddressViewModel>().PreserveReferences().MaxDepth(0);

            CreateMap<AgriculturalProducer, AgriculturalProducerViewModel>().PreserveReferences().MaxDepth(0);

            CreateMap<Client, ClientViewModel>().PreserveReferences().MaxDepth(0);

            CreateMap<Order, OrderViewModel>().PreserveReferences().MaxDepth(0);

            CreateMap<OrderSplitted, OrderSplittedViewModel>().PreserveReferences().MaxDepth(0);

            CreateMap<Product, ProductViewModel>().PreserveReferences().MaxDepth(0);

            CreateMap<ProductRoute, ProductRouteViewModel>().PreserveReferences().MaxDepth(0);

            CreateMap<Domain.Entities.Route, RouteViewModel>().PreserveReferences().MaxDepth(0);

        }
	}
}

