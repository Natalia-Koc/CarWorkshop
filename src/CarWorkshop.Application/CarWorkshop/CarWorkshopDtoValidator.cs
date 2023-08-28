using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDtoValidator : AbstractValidator<CarWorkshopDto>
    {
        public CarWorkshopDtoValidator(ICarWorkshopRepository carWorkshopRepository)
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(25)
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = carWorkshopRepository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} is not unique name for car workshop");
                    }
                });

            RuleFor(a => a.Description)
                .NotEmpty();

            RuleFor(b => b.PhoneNumber)
                .Length(9);
        }
    }
}
