using System;
namespace PDS.Domain.Entities
{
	public class Client: User
	{
        public List<Address> Adresses { get; set; }
        public List<OrderSplitted> OrdersSplitted { get; set; }
    }
}

