using System;
using FluentValidation;

namespace PDS.Domain.Entities
{
	public class OrderSplittedValidator : AbstractValidator<OrderSplitted>
    {
		public OrderSplittedValidator()
		{
            RuleFor(i => i.ClientId)
               .NotNull();

            RuleFor(i => i.AgriculturalProducerId)
               .NotNull();
        }
	}
}

