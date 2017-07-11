using FluentValidation.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(TrainingTypeValidator))]
    public class TrainingType : BaseModel
    {
        public string TypeTraining { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Training> Trainings { get; set; }
    }
}