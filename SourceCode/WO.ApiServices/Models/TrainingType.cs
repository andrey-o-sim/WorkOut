using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models
{
    public class TrainingType : BaseModel
    {
        public string TypeTraining { get; set; }
        public string Description { get; set; }

        public Training Training { get; set; }
        public int? TrainingId { get; set; }
    }
}