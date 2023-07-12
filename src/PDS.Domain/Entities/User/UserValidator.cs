using System;
using FluentValidation;

namespace PDS.Domain.Entities
{
	public class UserValidator: AbstractValidator<User>
	{
		public UserValidator()
		{
        }
        
	}
}

