using System;
using Microsoft.AspNetCore.Mvc;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Service.Services
{
	public class RouteService: IRouteService
	{
		private readonly IRouteRepository _routeRepository;

		public RouteService(
			IRouteRepository routeRepository,
            IUnitOfWork unitOfWork
        )
		{
			_routeRepository = routeRepository;

        }
	}
}

