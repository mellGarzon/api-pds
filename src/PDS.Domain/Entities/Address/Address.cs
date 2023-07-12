using System;
namespace PDS.Domain.Entities
{
    public class Address: BaseEntity
    {
        public string StreetName { get; set; }

        public int Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string Cep { get; set; }

        public string Uf { get; set; }

        public string Completion { get; set; }

        public string Reference { get; set; }

        public Client Client { get; set; }

        public long ClientId { get; set; }
    }
}