using System.Data.Entity.ModelConfiguration;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext.Configurations
{
    class SetTargetConfiguration : EntityTypeConfiguration<SetTarget>
    {
        public SetTargetConfiguration()
        {
            ToTable("SetTargets");

            Property(s => s.PlainNumberOfTimes).IsRequired();

            HasRequired<Set>(st => st.Set)
                .WithMany(s => s.SetTargets)
                .HasForeignKey(st => new { st.SetId })
                .WillCascadeOnDelete(false);

            HasRequired<Exercise>(st => st.Exercise)
               .WithMany(s => s.SetTargets)
               .HasForeignKey(st => new { st.ExerciseId })
               .WillCascadeOnDelete(true);
        }
    }
}
