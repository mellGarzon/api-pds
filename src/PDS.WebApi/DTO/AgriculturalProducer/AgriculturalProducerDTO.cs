using System;
using PDS.Domain.Entities;

namespace PDS.WebApi.DTO
{
	public class AgriculturalProducerDTO
	{
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Media Media { get; set; }
    }
}

