namespace WO.Core.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using WO.Core.DAL.DataBaseContext;
    using WO.Core.DAL.Model;


    internal sealed class WoDbConfiguration : DbMigrationsConfiguration<WorkOutContext>
    {
        private WorkOutContext _context;

        public WoDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WorkOutContext context)
        {
            _context = context;

            InitialTrainingTypes();
            InitialExercises();

            context.SaveChanges();
        }

        private void InitialTrainingTypes()
        {
            var trainingTypes = new List<TrainingType>
            {
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "����"
                },
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "�������"
                },
                new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "��������"
                },
                 new TrainingType
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "�������"
                }
            };

            foreach (var trainingType in trainingTypes)
            {
                _context.TrainingTypes.AddOrUpdate(t => t.TypeTraining, trainingType);
            }
        }

        private void InitialExercises()
        {
            var exercises = new List<Exercise>
            {
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="������������"
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="��������� �� �������"
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="��������� �� ����"
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="�����������"
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="��������������"
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="������"
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="����������"
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="�����"
                },
                new Exercise
                {
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Name="������ ����"
                }
            };

            foreach (var exercise in exercises)
            {
                _context.Exercises.AddOrUpdate(ex => ex.Name, exercise);
            }
        }
    }
}
