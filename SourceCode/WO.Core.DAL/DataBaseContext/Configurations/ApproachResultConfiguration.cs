using System.Data.Entity.ModelConfiguration;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext.Configurations
{
    class ApproachResultConfiguration : EntityTypeConfiguration<ApproachResult>
    {
        public ApproachResultConfiguration()
        {
            ToTable("ApproachResults");

            Property(a => a.ExerciseId).IsRequired();
            Property(a => a.SetTargetId).IsRequired();
            Property(a => a.ApproachId).IsRequired();

            HasOptional<SetTarget>(a => a.SetTarget)
                .WithMany(s => s.ApproachResults)
                .HasForeignKey(a => new { a.SetTargetId })
                .WillCascadeOnDelete(true);
        }
    }
}
