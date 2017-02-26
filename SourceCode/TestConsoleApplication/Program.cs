using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.DAL.DataBaseContext;
using WO.Core.DAL.Model;
using WO.Core.DAL.Repositories;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkOutContext context = new WorkOutContext("WorkOutDbConnection");
            Repository<TrainingType> rep = new Repository<TrainingType>(context);

            var tt = new TrainingType
            {
                Description = "test 4",
                TypeTraining = "TT 4",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var result = rep.Create(tt);
        }
    }
}
