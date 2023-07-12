using System;
namespace PDS.WebApi.DTO
{
	public class RequestDTO
	{
        public DateTime TimeToAnswer { get; set; }

        public bool Response { get; set; }

        public long? OrderId { get; set; }
    }
}

