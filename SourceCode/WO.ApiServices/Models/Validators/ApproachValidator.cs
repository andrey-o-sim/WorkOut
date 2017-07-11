using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.ApiServices.Models.Helper;

namespace WO.ApiServices.Models.Validators
{
    public class ApproachValidator : AbstractValidator<Approach>
    {
        public ApproachValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(ap => ap.PlannedTimeForRest)
                .NotNull()
                .Must(time => time.Hours > 0 || time.Minutes > 0 || time.Seconds > 0)
                .WithMessage("Please provide 'Time For Rest'");
        }
    }
}