using FluentValidation.Attributes;
using System.Collections.Generic;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(ExerciseValidator))]
    public class Exercise : BaseModel
    {
        public string Name { get; set; }

        public ICollection<TrainingType> TrainingTypes { get; set; } = new List<TrainingType>();
        public ICollection<Set> Sets { get; set; } = new List<Set>();
    }
}