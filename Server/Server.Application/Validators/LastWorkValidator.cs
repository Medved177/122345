using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Server.Data;

namespace Server.Application.Validators
{
    public class LastWorkValidator : AbstractValidator<DbLastWork>
    {
        public LastWorkValidator()
        {
            RuleFor(reg => reg.Employee).NotEmpty();
        }
    }
}
