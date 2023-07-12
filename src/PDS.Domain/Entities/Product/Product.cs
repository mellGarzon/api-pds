using System;
namespace PDS.Domain.Entities
{
	public class Product: BaseEntity
	{
		public string Name { get; set; }
		public double Price { get; set; }
		public int Amount { get; set; }
		public string Description { get; set; }
        public string ImageUrl { get; set; }

		public Media Media { get; set; }
        public long MediaId { get; set; }

        public AgriculturalProducer AgriculturalProducer { get; set; }
        public long AgriculturalProducerId { get; set; }

        public List<ProductRoute> ProductRoutes { get; set; }
    }
}

