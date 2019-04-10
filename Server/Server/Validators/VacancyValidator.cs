using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Server.Data;

namespace Server.Validators
{
    public class VacancyValidator : AbstractValidator<DbVacancy>
    {
        public VacancyValidator()
        {
            RuleFor(reg => reg.Name).NotEmpty();
            RuleFor(reg => reg.Salary).NotEmpty();
            RuleFor(reg => reg.Task).NotEmpty();
        }
    }
}
