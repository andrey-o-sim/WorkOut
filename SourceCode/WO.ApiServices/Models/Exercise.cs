using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models
{
    public class Exercise : BaseModel
    {
        public string Name { get; set; }

        public Set Set { get; set; }
        public int? SetId { get; set; }
    }
}