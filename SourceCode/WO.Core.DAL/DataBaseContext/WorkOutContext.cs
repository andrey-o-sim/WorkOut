using System;
using System.Data.Entity;
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
            modelBuilder.Entity<Approach>()
                .HasOptional<Set>(a => a.Set)
                .WithMany(s => s.Approaches)
                .HasForeignKey(a => new { a.SetId })
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Set>()
                .HasOptional<Training>(s => s.Training)
                .WithMany(t => t.Sets)
                .HasForeignKey(t => new { t.TrainingId })
                .WillCascadeOnDelete(true);
        }

        public int Commit()
        {
            return base.SaveChanges();
        }
    }
}
