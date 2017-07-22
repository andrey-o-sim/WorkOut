using FluentValidation.Attributes;
using System.Collections.Generic;
using WO.ApiServices.Models.Validators;

namespace WO.ApiServices.Models
{
    [Validator(typeof(ExerciseValidator))]
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