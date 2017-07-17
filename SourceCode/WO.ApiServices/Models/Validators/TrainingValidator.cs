using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models.Validators
{
    public class TrainingValidator : AbstractValidator<Training>
    {
        public TrainingValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(tr => tr.MainTrainingPurpose)
                .NotEmpty()
                .WithMessage("Please, provide 'Main Training Purpose'");

            RuleFor(tr => tr.TrainingType)
                .NotNull()
                .Must(tt => tt.Id > 0)
                .WithMessage("Please, provide 'Training Type'");

            //Return when "Move Edit Form to New"
            //RuleFor(tr => tr.Sets)
            //    .NotNull()
            //    .Must(sets => sets.Count() > 0)
            //    .WithMessage("Please, provide at least one 'Set'");

            //RuleFor(tr => tr)
            //    .Must(tr => tr.StartDateTime < tr.EndDateTime)
            //    .WithMessage("'End Training' must be later than 'Start Training'");
        }
    }
}