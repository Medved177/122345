using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Server.Data;

namespace Server.Application.Validators
{
    public class EducationValidator : AbstractValidator<DbEducation>
    {
        public EducationValidator()
        {
            RuleFor(reg => reg.University).NotEmpty();
            RuleFor(reg => reg.Specialty).NotEmpty();
            RuleFor(reg => reg.Employee).NotEmpty();
        }
    }
}
