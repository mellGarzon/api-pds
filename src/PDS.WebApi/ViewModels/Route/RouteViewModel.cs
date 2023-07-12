using System;
namespace PDS.WebApi.ViewModels
{
	public class RouteViewModel
	{
        public string Name { get; set; }

        public string Uf { get; set; }

        public string City { get; set; }

        public string Cep { get; set; }

        public string DeliveryDate { get; set; }

        public long? AgriculturalProducerId { get; set; }

    }
}

