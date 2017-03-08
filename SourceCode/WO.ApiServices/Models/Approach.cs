using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.ApiServices.Models.Helper;

namespace WO.ApiServices.Models
{
    public class Approach : BaseModel
    {
        public TimeWO PlannedTimeForRest { get; set; }
        public TimeWO SpentTimeForRest { get; set; }
        public Set Set { get; set; }
        public int? SetId { get; set; }
    }
}