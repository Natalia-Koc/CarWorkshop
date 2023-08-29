using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkShop;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator(ICarWorkshopRepository carWorkshopRepository)
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(25);

            RuleFor(a => a.Description)
                .NotEmpty();

            RuleFor(b => b.PhoneNumber)
                .Length(9);
        }
    }
}
