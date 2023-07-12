using System;
namespace PDS.Domain.Entities
{
	public class OrderSplitted: BaseEntity
	{

		public Client Client { get; set; }
        public long ClientId { get; set; }

        public AgriculturalProducer AgriculturalProducer { get; set; }
        public long AgriculturalProducerId { get; set; }

        public List<Order> Orders { get; set; }
    }
}

