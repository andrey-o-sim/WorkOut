using System;
using FluentValidation.Attributes;
using System.Collections.Generic;
using WO.ApiServices.Models.Helper;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(SetValidator))]
    public class Set : BaseModel
    {
        public TimeWO PlannedTime { get; set; } = new TimeWO();
        public TimeWO TimeForRest { get; set; } = new TimeWO();
        public TimeWO SpentTime { get; set; } = new TimeWO();
        public int CountApproaches { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }

        public int? TrainingId { get; set; }
        public Training Training { get; set; }

        public ICollection<Approach> Approaches { get; set; } = new List<Approach>();

        public ICollection<SetTarget> SetTargets { get; set; } = new List<SetTarget>();
    }
}