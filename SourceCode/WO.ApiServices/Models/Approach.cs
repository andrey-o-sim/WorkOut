using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models
{
    public class Approach: BaseModel
    {
        public DateTime? PlanTimeForRest { get; set; }
        public DateTime? SpentTimeForRest { get; set; }

        public Set Set { get; set; }
        public int? SetId { get; set; }
    }
}