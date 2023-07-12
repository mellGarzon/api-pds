using System;
namespace PDS.WebApi.DTO
{
	public class OrderDTO
	{
        public int Amount { get; set; }

        public double Price { get; set; }

        public long? ProductRouteId { get; set; }

        public DateTime TimeToAnswer { get; set; }

        public bool Response { get; set; }

    }
}

