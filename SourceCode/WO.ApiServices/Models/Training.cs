using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(TrainingValidator))]
    public class Training : BaseModel
    {
        public virtual TrainingType TrainingType { get; set; }
        public int? TrainingTypeId { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public DateTime? TrainingDate { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string MainTrainingPurpose { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
    }
}