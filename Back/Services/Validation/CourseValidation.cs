using Back.Data.DTOs;
using FluentValidation;

namespace Back.Services.Validation
{
    public class CourseValidation : AbstractValidator<CourseCreateDto>
    {
        public CourseValidation()
        {
            RuleFor(c => c.Title).Length(2, 100);
            RuleFor(c => c.Desctiption).Length(2, 300);
        }
    }
}
