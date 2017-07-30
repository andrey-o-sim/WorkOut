using FluentValidation.Attributes;
using WO.ApiServices.Models.Helper;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(ApproachValidator))]
    public class Approach : BaseModel
    {
        public TimeWO PlannedTimeForRest { get; set; } = new TimeWO();
        public TimeWO SpentTimeForRest { get; set; } = new TimeWO();
        public bool Started { get; set; }
        public bool Finished { get; set; }

        public Set Set { get; set; }
        public int? SetId { get; set; }
    }
}