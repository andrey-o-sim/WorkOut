using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.ApiServices.Models.Helper;

namespace WO.ApiServices.Models
{
    public class Set : BaseModel
    {
        //Use Time object
        public TimeWO TimeForRest { get; set; }
        //Use Time object
        public TimeWO PlainTime { get; set; }
        //Use Time object
        public TimeWO SummaryTime { get; set; }
        public int CountApproaches { get; set; }
        public int CountMadeApproaches { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<Approach> Approaches { get; set; }

        public Training Training { get; set; }
        public Set()
        {
            Exercises = new List<Exercise>();
            Approaches = new List<Approach>();
        }
    }
}