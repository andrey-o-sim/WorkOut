using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.DAL.Model
{
    public class Exercise : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public virtual Set Set { get; set; }
        public int? SetId { get; set; }
    }
}
