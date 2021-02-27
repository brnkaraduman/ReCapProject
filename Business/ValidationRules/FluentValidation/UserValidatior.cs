using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidatior : AbstractValidator<User>
    {
        public UserValidatior()
        {
            //  rules for users
        }
    }
}