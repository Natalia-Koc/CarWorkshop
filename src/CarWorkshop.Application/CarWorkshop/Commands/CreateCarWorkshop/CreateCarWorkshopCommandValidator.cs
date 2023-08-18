using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkShop;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository carWorkshopRepository)
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
