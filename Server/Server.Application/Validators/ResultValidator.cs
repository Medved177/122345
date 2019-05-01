using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Server.Data;

namespace Server.Application.Validators
{
    public class ResultValidator : AbstractValidator<DbResult>
    {
        public ResultValidator()
        {
            RuleFor(reg => reg.Result1).NotEmpty();
            RuleFor(reg => reg.Vacancy).NotEmpty();
            RuleFor(reg => reg.Employee).NotEmpty();
        }
    }
}
