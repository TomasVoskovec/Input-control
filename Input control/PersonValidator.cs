using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Input_control
{
    class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(isEmpty => isEmpty.FirstName).NotEmpty().WithMessage("First name input is empty");
            RuleFor(isEmpty => isEmpty.LastName).NotEmpty().WithMessage("Last name input is empty");
            RuleFor(isEmpty => isEmpty.Date).NotEmpty().WithMessage("Date input is empty");
        }
    }
}
