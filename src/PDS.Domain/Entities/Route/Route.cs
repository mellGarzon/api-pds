using System;
namespace PDS.Domain.Entities
{
	public class Route: BaseEntity
	{

        public string Name { get; set; }

        public string Uf { get; set; }

		public string City { get; set; }

		public string Cep { get; set; }

        public DateTime DeliveryDate { get; set; }

		public long? AgriculturalProducerId { get; set; }

        public AgriculturalProducer AgriculturalProducer { get; set; }

        public List<ProductRoute> ProductRoutes { get; set; }



    }
}

