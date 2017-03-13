using System;
using System.Collections.Generic;
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

            Repository<Set> repSet = new Repository<Set>(context);
            Repository<Exercise> repExercise = new Repository<Exercise>(context);
            Repository<Approach> repApproach = new Repository<Approach>(context);

            Exercise firstEx = new Exercise
            {
                Name = "Test",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            Approach firstApproach = new Approach
            {
                PlannedTimeForRest = 0,
                SpentTimeForRest = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            repExercise.Create(firstEx);
            repApproach.Create(firstApproach);

            Set set = new Set
            {
                TimeForRest=10,
                PlannedTime = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            set.Approaches.Add(firstApproach);
            set.Exercises.Add(firstEx);

            repSet.Create(set);



            Repository<TrainingType> rep = new Repository<TrainingType>(context);
            //var test = rep.Get(1);

            TrainingType test1 = new TrainingType
            {
                Id = 1,
                TypeTraining = "Op",
                Description = "aaa",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            foreach (var changeTrack in context.ChangeTracker.Entries())
            {
                Console.WriteLine(changeTrack.Entity);
            }

            context.Set<TrainingType>().Attach(test1);

            foreach (var changeTrack in context.ChangeTracker.Entries())
            {
                Console.WriteLine(changeTrack.Entity);
            }
            rep.Update(test1);

            var tt = new TrainingType
            {
                Description = "test 4",
                TypeTraining = "TT 4",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            rep.Create(tt);

            Repository<TrainingType> rep1 = new Repository<TrainingType>(context);

            var trainingType = rep1.Get(tt.Id);
            trainingType.TypeTraining = "fwefwef";
            trainingType.Trainings = new List<Training>();
            rep1.Update(tt);


        }
    }
}
