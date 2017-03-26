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
        public Exercise()
        {
            Sets = new List<Set>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Set> Sets { get; set; }
    }
}
