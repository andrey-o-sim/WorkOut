using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext
{
    public class WorkOutContext : DbContext
    {
        static WorkOutContext()
        {
            Database.SetInitializer<WorkOutContext>(new WorkOutDbInitialized());
        }
        public WorkOutContext(string connectionString) 
            : base(connectionString)
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Approach> Approachs { get; set; }

    }
}
