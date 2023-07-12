using System;
namespace PDS.Domain.Entities
{
	public class AgriculturalProducer: User
	{

		public List<Route> Routes { get; set; }

		public List<Product> Products { get; set; }

		public List<OrderSplitted> OrdersSplitted { get; set; }
}
}

