using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.ApiServices.Models.Helper;

namespace WO.ApiServices.Models
{
    public class Approach: BaseModel
    {
        //Use Time object
        public TimeWO PlanTimeForRest { get; set; }
        //Use Time object
        public TimeWO SpentTimeForRest { get; set; }

        public Set Set { get; set; }
        public int? SetId { get; set; }
    }
}