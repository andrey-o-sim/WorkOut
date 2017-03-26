﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.DAL.Model
{
    public class TrainingType : BaseModel
    {
        [Required]
        public string TypeTraining { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Training> Trainings { get; set; }
    }
}
