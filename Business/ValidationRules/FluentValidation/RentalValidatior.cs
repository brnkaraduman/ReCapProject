using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidatior : AbstractValidator<Rental>
    {
        public RentalValidatior()
        {
            //  rules for rentals
        }
    }
}