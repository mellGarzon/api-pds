using System;
using PDS.Domain.Entities;

namespace PDS.WebApi.DTO
{
	public class RouteDTO
	{
        public string Name { get; set; }

        public string Uf { get; set; }

        public string City { get; set; }

        public string Cep { get; set; }

        public DateTime DeliveryDate { get; set; }

        public List<ProductRoute> ProductRoutes { get; set; }


    }
}

