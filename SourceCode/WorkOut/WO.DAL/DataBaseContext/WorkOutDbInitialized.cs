using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.DAL.DataBaseContext
{
    public class WorkOutDbInitialized : DropCreateDatabaseIfModelChanges<WorkOutContext>
    {
        protected override void Seed(WorkOutContext context)
        {
            //добавить дефолтные тыпы тренировок
        }
    }
}
