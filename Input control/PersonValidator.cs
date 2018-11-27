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
            RuleFor(person => person.FirstName).NotEmpty().WithMessage("First name input is empty");
            RuleFor(person => person.LastName).NotEmpty().WithMessage("Last name input is empty");
            RuleFor(person => person.Date).NotEmpty().WithMessage("Date input is empty");
            RuleFor(person => person.LastName).NotEqual(person => person.FirstName).WithMessage("Last name can not be same as first name");
            RuleFor(person => person.Date).LessThan(DateTime.Now).WithMessage("Invalid date");
        }
    }
}
