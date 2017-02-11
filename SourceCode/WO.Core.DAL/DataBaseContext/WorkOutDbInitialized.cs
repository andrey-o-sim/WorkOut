using System;
using System.Collections.Generic;
using System.Data.Entity;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext
{
    public class WorkOutDbInitialized : DropCreateDatabaseAlways<WorkOutContext>
    {
        protected override void Seed(WorkOutContext context)
        {
            var trainingTypes = new List<TrainingType>
            {
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "Base"
                },
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "CrossFit"
                },
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "Elements"
                },
            };

            context.TrainingTypes.AddRange(trainingTypes);
            context.SaveChanges();
        }
    }
}
