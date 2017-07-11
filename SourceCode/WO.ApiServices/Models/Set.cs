using FluentValidation.Attributes;
using System.Collections.Generic;
using WO.ApiServices.Models.Helper;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(SetValidator))]
    public class Set : BaseModel
    {
        public Set()
        {
            Exercises = new List<Exercise>();
            Approaches = new List<Approach>();
        }

        public TimeWO PlannedTime { get; set; }
        public TimeWO TimeForRest { get; set; }
        public TimeWO SpentTime { get; set; }
        public int CountApproaches { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Approach> Approaches { get; set; }

        public Training Training { get; set; }
        public int? TrainingId { get; set; }
    }
}