using System;
namespace PDS.WebApi.ViewModels
{
	public class AddressViewModel
	{
        public string StreetName { get; set; }

        public int Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string Cep { get; set; }

        public string Uf { get; set; }

        public string Completion { get; set; }

        public string Reference { get; set; }

        public long ClientId { get; set; }
    }
}

