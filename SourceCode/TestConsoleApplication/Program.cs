using System;
using System.Collections.Generic;
using System.Linq;
using WO.Core.BLL.DTO;
using WO.Core.DAL.DataBaseContext;
using WO.Core.DAL.Model;
using WO.Core.DAL.Repositories;
using WO.Core.Data.Repositories;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkOutContext context = new WorkOutContext("WorkOutDbConnection");
            WorkOutContext context1 = new WorkOutContext("WorkOutDbConnection");

            Repository<Set> repSet = new Repository<Set>(context);
            Repository<Exercise> repExercise = new Repository<Exercise>(context);
            Repository<Approach> repApproach = new Repository<Approach>(context);
            Repository<Training> repTraining = new Repository<Training>(context);

            //var set = context.Sets.FirstOrDefault();

            TrainingType trainingType1 = context.TrainingTypes.FirstOrDefault<TrainingType>();
            var training = context.Trainings.Where(tr => tr.Id == 1).FirstOrDefault();

            //set.Training = training;
            //context.SaveChanges();

            ExerciseDTO firstEx = new ExerciseDTO
            {
                Name = "Test",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };



            SetDTO set1 = new SetDTO
            {
                TimeForRest = 10,
                PlannedTime = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            DTOSetRepository dtoSetRepository = new DTOSetRepository(repSet, repApproach, repExercise, repTraining);
            DTORepository<Approach, ApproachDTO> dtoApproachRepository = new DTORepository<Approach, ApproachDTO>(repApproach);
            DTORepository<Exercise, ExerciseDTO> dtoExcerciseRepository = new DTORepository<Exercise, ExerciseDTO>(repExercise);

            firstEx.Id = dtoExcerciseRepository.Create(firstEx);
            firstEx.CreatedDate = DateTime.Now;
            firstEx.ModifiedDate = DateTime.Now;

            set1.Exercises.Add(firstEx);
            dtoSetRepository.Create(set1);

            string settttt = "Set";
            var exer = context.Exercises.Include(settttt).Where(item => item.Id == 1).FirstOrDefault();



            ApproachDTO approachDTO = new ApproachDTO
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                PlannedTimeForRest = 10,
                SpentTimeForRest = 12
            };



            var approaches = dtoApproachRepository.GetAll();

            //context1.Exercises.Attach(ex);
            //var contextChanges = context1.ChangeTracker.Entries().ToList();
            //repSet.Create(set1);


            //Exercise firstEx = new Exercise
            //{
            //    Name = "Test",
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now
            //};

            //Approach firstApproach = new Approach
            //{
            //    PlannedTimeForRest = 0,
            //    SpentTimeForRest = 0,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now
            //};

            //repApproach.Create(firstApproach);

            //Set set = new Set
            //{
            //    TimeForRest = 10,
            //    PlannedTime = 0,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now
            //};

            //set.Approaches.Add(firstApproach);
            //set.Exercises.Add(firstEx);

            //repSet.Create(set);



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
