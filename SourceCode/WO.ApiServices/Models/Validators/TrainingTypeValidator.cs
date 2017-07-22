using FluentValidation;

namespace WO.ApiServices.Models.Validators
{
    public class TrainingTypeValidator : AbstractValidator<TrainingType>
    {
        public TrainingTypeValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(tt => tt.TypeTraining.Trim()).NotNull().NotEmpty();
        }
    }
}