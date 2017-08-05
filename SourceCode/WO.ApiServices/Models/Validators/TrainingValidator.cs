using FluentValidation;
using System.Linq;

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

            RuleFor(tr => tr.Sets)
                .NotNull()
                .Must(sets => sets.Any())
                .WithMessage("Please, provide at least one 'Set'");
        }
    }
}