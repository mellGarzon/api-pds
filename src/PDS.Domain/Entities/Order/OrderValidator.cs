using System;
using FluentValidation;

namespace PDS.Domain.Entities
{
	public class OrderValidator : AbstractValidator<Order>
    {
		public OrderValidator()
		{
            RuleFor(i => i.Amount)
                .NotNull();

            RuleFor(i => i.Price)
                .NotNull();

            RuleFor(i => i.ProductRouteId)
                .NotNull();

        }
    }
}

