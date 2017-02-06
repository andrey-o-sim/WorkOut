using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models
{
    public class Training : BaseModel
    {
        public IEnumerable<TrainingType> TrainingTypes { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string MainTrainingPurpose { get; set; }
        public string Description { get; set; }
    }
}