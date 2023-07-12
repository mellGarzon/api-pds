using System;
namespace PDS.Domain.Entities
{
	public class ProductRoute: BaseEntity
	{
		public Product Product { get; set; }
		public long ProductId { get; set; }
		public Route Route { get; set; }
        public long RouteId { get; set; }

		public List<Order> Orders { get; set; }
    }
}

