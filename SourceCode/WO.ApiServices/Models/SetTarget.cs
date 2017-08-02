using System.Collections.Generic;
using FluentValidation.Attributes;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(SetTargetValidator))]
    public class SetTarget : BaseModel
    {
        public int PlainNumberOfTimes { get; set; }
        public string Description { get; set; }

        public int? ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int? SetId { get; set; }
        public Set Set { get; set; }

        public ICollection<ApproachResult> ApproachResults { get; set; } = new List<ApproachResult>();
    }
}