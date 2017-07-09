﻿using System;
using System.Data.Entity;
using WO.Core.DAL.DataBaseContext.Configurations;
using WO.Core.DAL.Model;
using WO.LoggerFactory;
using WO.LoggerService;

namespace WO.Core.DAL.DataBaseContext
{
    public class WorkOutContext : DbContext
    {
        private static ILoggerFactory _loggerFactory;
        private static ILoggerService _loggerService;
        static WorkOutContext()
        {
            _loggerFactory = new LoggerFactory.LoggerFactory();
            _loggerService = _loggerFactory.Create<WorkOutContext>();

            Database.SetInitializer<WorkOutContext>(new WorkOutDbInitialized(_loggerFactory));
        }

        public WorkOutContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Approach> Approachs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TrainingTypeConfiguration());
            modelBuilder.Configurations.Add(new ExerciseConfiguration());
            modelBuilder.Configurations.Add(new TrainingConfiguration());
            modelBuilder.Configurations.Add(new ApproachConfiguration());
            modelBuilder.Configurations.Add(new SetConfiguration());
        }

        public int Commit()
        {
            return base.SaveChanges();
        }
    }
}
