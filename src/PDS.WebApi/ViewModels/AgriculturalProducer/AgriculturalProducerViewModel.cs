using System;
using PDS.Domain.Enum;

namespace PDS.WebApi.ViewModels
{
	public class AgriculturalProducerViewModel: BaseViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string ImageUrl { get; set; }

        public long MediaId { get; set; }
    }
}

