using FluentValidation;

namespace WO.ApiServices.Models.Validators
{
    public class SetValidator : AbstractValidator<Set>
    {
        public SetValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(set => set.TimeForRest)
                .NotNull()
                .Must(time => time.Hours > 0 || time.Minutes > 0 || time.Seconds > 0)
                .WithMessage("Please provide 'Time For Rest'");

            RuleFor(set => set.Exercises)
                .NotNull()
                .Must(exs => exs.Count > 0)
                .WithMessage("Please, provide at least one 'Exercise'");

            RuleFor(set => set)
                .Must(set => set.Approaches.Count > 0 || set.CountApproaches > 0)
                .WithMessage(set =>
                {
                    var resultMessage = set.Id > 0
                    ? "Please, provide at least one 'Approach'"
                    : "Please, provide approach count";

                    return resultMessage;
                });
        }
    }
}