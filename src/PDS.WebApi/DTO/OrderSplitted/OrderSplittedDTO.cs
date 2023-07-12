using System;
using PDS.Domain.Entities;

namespace PDS.WebApi.DTO
{
	public class OrderSplittedDTO
	{
        public ClientDTO Client { get; set; }
        public long ClientId { get; set; }

        public List<OrderDTO> Orders { get; set; }

    }
}

