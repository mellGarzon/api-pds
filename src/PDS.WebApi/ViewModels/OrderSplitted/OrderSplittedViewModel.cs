using System;
using PDS.Domain.Entities;

namespace PDS.WebApi.ViewModels
{
	public class OrderSplittedViewModel
	{
        public long ClientId { get; set; }

        public long AgriculturalProducerId { get; set; }

        public List<OrderViewModel> Orders { get; set; }
    }
}

