using System;
using FluentValidation;

namespace PDS.Domain.Entities
{
	public class RouteValidator : AbstractValidator<Route>
    {
		public RouteValidator()
		{
            RuleFor(i => i.Name)
            .NotNull();

            RuleFor(i => i.DeliveryDate)
           .NotNull();

            RuleFor(i => i.City)
          .NotNull();

            RuleFor(i => i.Cep)
          .NotNull();

            RuleFor(i => i.Uf)
          .NotNull();

            RuleFor(i => i.AgriculturalProducerId)
          .NotNull();

        }
	}
}

