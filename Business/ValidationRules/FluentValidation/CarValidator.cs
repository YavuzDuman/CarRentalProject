﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.CarName).NotEmpty();
			RuleFor(c => c.BrandId).NotEmpty();
			RuleFor(c => c.ModelYear).MinimumLength(1900);
		}
	}
}
