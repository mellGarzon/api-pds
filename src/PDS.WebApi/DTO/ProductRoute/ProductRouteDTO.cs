using System;
using PDS.Domain.Entities;

namespace PDS.WebApi.DTO
{
	public class ProductRouteDTO
	{
        public long Id { get; set; }
        public ProductDTO Product { get; set; }
        public long ProductId { get; set; }
 
    }
}

