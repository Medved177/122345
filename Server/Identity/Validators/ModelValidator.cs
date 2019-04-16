using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Identity.Models;

namespace Identity.Validators
{
    public class ModelValidator : AbstractValidator<ModelUser>
    {
        public ModelValidator()
        {
            RuleFor(reg=> reg.Login).NotEmpty();
            RuleFor(reg => reg.Password).NotEmpty();
            RuleFor(reg => reg.PasswordConfirm).NotEmpty();
            RuleFor(reg => reg.Email).NotEmpty().EmailAddress();
        }
    }
}
