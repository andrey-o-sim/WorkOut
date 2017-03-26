using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models
{
    public class Training : BaseModel
    {
        public virtual TrainingType TrainingType { get; set; }
        public int? TrainingTypeId { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string MainTrainingPurpose { get; set; }
        public string Description { get; set; }
    }
}