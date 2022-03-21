using Back.Data.Models.Entities;
using Back.DTOs;
using FluentValidation;

namespace Back.Services.Validation
{
    public class UserValidator : AbstractValidator<RegistrationDto>
    // валідатор не працює при  User коли передаэмо RegistrationDto в методі POST
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).Length(2, 20);
            RuleFor(x => x.LastName).Length(2, 20);
            RuleFor(x => x.Email).EmailAddress().Length(3, 50);
            RuleFor(x => x.Age).InclusiveBetween(14, 99);
        }
    }
}