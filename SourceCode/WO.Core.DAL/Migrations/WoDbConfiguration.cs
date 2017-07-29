namespace WO.Core.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WO.Core.DAL.DataBaseContext;
    using WO.Core.DAL.Model;


    internal sealed class WoDbConfiguration : DbMigrationsConfiguration<WorkOutContext>
    {
        private WorkOutContext _context;

        private const string BASE_TRAINING_TYPE = "База";
        private const string CROSSFIT_TRAINING_TYPE = "Кросфит";
        private const string ELEMENTS_TRAINING_TYPE = "Элементы";
        private const string STATIC_TRAINING_TYPE = "Статика";

        public WoDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WorkOutContext context)
        {
            _context = context;

            var trainingTypes = InitialTrainingTypes();
            context.SaveChanges();

            InitialExercises(trainingTypes);
            context.SaveChanges();
        }

        private List<TrainingType> InitialTrainingTypes()
        {
            var trainingTypes = new List<TrainingType>
            {
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = BASE_TRAINING_TYPE
                },
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = CROSSFIT_TRAINING_TYPE
                },
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = ELEMENTS_TRAINING_TYPE
                },
                 new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = STATIC_TRAINING_TYPE
                }
            };

            foreach (var trainingType in trainingTypes)
            {
                _context.TrainingTypes.AddOrUpdate(t => t.TypeTraining, trainingType);
            }

            return trainingTypes;
        }

        private void InitialExercises(List<TrainingType> trainingTypes)
        {

            var exercises = new List<Exercise>
            {
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Подтягивание",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE || tt.TypeTraining==STATIC_TRAINING_TYPE).ToList()
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Отжимание на Брусьях",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE || tt.TypeTraining==STATIC_TRAINING_TYPE).ToList()
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Отжимание от пола",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE).ToList()
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Скручивание",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE).ToList()
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Гиперэкстензия",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE).ToList()
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Планка",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE || tt.TypeTraining==STATIC_TRAINING_TYPE).ToList()
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Приседание",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE).ToList()
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Берпи",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE).ToList()
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="Подьем гири",
                    TrainingTypes=trainingTypes.Where(tt=>tt.TypeTraining==BASE_TRAINING_TYPE || tt.TypeTraining==CROSSFIT_TRAINING_TYPE).ToList()
                }
            };

            foreach (var exercise in exercises)
            {
                _context.Exercises.AddOrUpdate(ex => ex.Name, exercise);
            }
        }
    }
}
