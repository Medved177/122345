using FluentValidation;
using Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Server.Validators
{
    public class EmployeeValidator : AbstractValidator <DbEmployee>
    {
        public EmployeeValidator ()
        {
            RuleFor(reg => reg.Family).NotEmpty();
            RuleFor(reg => reg.Name).NotEmpty();
            RuleFor(reg => reg.Email).NotEmpty().EmailAddress();
        }
    }
}
