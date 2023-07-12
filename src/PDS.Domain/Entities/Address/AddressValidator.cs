using System;
using FluentValidation;

namespace PDS.Domain.Entities
{
	public class AddressValidator : AbstractValidator<Address>
    {
		public AddressValidator()
		{

            RuleFor(i => i.StreetName)
                .NotNull();

            RuleFor(i => i.Uf)
                .NotNull();

            RuleFor(i => i.Completion)
                .NotNull();

            RuleFor(i => i.Cep)
                .NotNull();

            RuleFor(i => i.City)
               .NotNull();

            RuleFor(i => i.Number)
               .NotNull();

            RuleFor(i => i.ClientId)
               .NotNull();

            RuleFor(i => i.Neighborhood)
              .NotNull();

           
        }
	}
}

