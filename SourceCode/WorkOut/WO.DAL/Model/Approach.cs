using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.DAL.Model
{
    public class Approach : BaseModel
    {
        public DateTime? PlanTimeForRest { get; set; }
        public DateTime? SpentTimeForRest { get; set; }

        public virtual Set Set { get; set; }
        public int? SetId { get; set; }
    }
}
