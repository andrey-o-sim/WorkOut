using FluentValidation.Attributes;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(ApproachResultValidator))]
    public class ApproachResult : BaseModel
    {
        public int MadeNumberOfTimes { get; set; }
        public string Description { get; set; }

        public int? SetTargetId { get; set; }
        public SetTarget SetTarget { get; set; }
        public int? ApproachId { get; set; }
        public Approach Approach { get; set; }
    }
}