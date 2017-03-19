using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.ApiServices.Models.Helper;

namespace WO.ApiServices.Models
{
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
    }
}