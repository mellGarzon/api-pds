using System;
using PDS.Domain.Entities;
using PDS.WebApi.DTO;

namespace PDS.WebApi.ViewModels
{
	public class OrderViewModel
	{
        public int Amount { get; set; }

        public double Total { get; set; }

        public long ProductRouteId { get; set; }

        public long? OrderSplittedId { get; set; }

        public long RequestId { get; set; }

        public DateTime TimeToAnswer { get; set; }

        public bool Response { get; set; }
    }
}

