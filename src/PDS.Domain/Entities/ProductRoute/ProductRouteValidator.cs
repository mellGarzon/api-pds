using System;
using FluentValidation;

namespace PDS.Domain.Entities
{
	public class ProductRouteValidator : AbstractValidator<ProductRoute>
    {
		public ProductRouteValidator()
		{
            RuleFor(i => i.ProductId)
              .NotNull();

            RuleFor(i => i.RouteId)
              .NotNull();
        }
	}
}

