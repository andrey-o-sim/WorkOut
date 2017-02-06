using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models
{
    public class Set : BaseModel
    {
        public DateTime? TimeForRest { get; set; }
        public int CountApproaches { get; set; }
        public DateTime? PlainTime { get; set; }
        public DateTime? SummaryTime { get; set; }
        public int CountMadeApproaches { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<Approach> Approaches { get; set; }
        public Set()
        {
            Exercises = new List<Exercise>();
            Approaches = new List<Approach>();
        }
    }
}