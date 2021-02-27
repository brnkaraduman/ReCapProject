using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidatior : AbstractValidator<Color>
    {
        public ColorValidatior()
        {
            //  rules for colors
        }
    }
}