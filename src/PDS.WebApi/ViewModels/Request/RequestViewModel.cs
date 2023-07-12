using System;
namespace PDS.WebApi.ViewModels
{
	public class RequestViewModel
	{
        public DateTime TimeToAnswer { get; set; }

        public bool Response { get; set; }

        public long? OrderId { get; set; }
    }
}

