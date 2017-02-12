using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.DAL.Model
{
    public class Approach : BaseModel
    {
        //Добавить правила на ввод только чисел, знака тире и точки
        public string PlanTimeForRest { get; set; }
        public string SpentTimeForRest { get; set; }

        public virtual Set Set { get; set; }
        public int? SetId { get; set; }
    }
}
