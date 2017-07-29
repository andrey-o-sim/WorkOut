using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models.Validators
{
    public class ExerciseValidator : AbstractValidator<Exercise>
    {
        public ExerciseValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(ex => ex.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please provide 'Exercise Name'");

            RuleFor(ex => ex.TrainingTypes)
                .NotNull()
                .Must(s => s.Count > 0);
        }
    }
}