using System;
using FluentValidation;

namespace PDS.Domain.Entities
{
	public class ProductValidator : AbstractValidator<Product>
    {
		public ProductValidator()
		{
            RuleFor(i => i.AgriculturalProducerId)
               .NotNull();

            RuleFor(i => i.Amount)
               .NotNull();

            RuleFor(i => i.Description)
               .NotNull();

            RuleFor(i => i.ImageUrl)
               .NotNull();

            RuleFor(i => i.Name)
               .NotNull();

            RuleFor(i => i.Price)
               .NotNull();

        }
	}
}

