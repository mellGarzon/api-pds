using System;
using PDS.Domain.Entities;

namespace PDS.WebApi.ViewModels
{
	public class ProductViewModel
	{
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public long AgriculturalProducerId { get; set; }
    }
}

