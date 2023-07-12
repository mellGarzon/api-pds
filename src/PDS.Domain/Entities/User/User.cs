using System;
using PDS.Domain.Enum;

namespace PDS.Domain.Entities
{
	public class User : BaseEntity
    {

        public string Name { get; set; }

		public string Email { get; set; }

		public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public string Phone { get; set; }

		public string ImageUrl { get; set; }

		public RoleEnum Role { get; set; }

        public Media Media { get; set; }
        public long MediaId { get; set; }
    }
}

