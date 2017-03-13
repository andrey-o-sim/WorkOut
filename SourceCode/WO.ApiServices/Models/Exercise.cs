using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models
{
    public class Exercise : BaseModel
    {
        public Exercise()
        {
            Sets = new List<Set>();
        }

        public string Name { get; set; }

        public ICollection<Set> Sets { get; set; }
    }
}