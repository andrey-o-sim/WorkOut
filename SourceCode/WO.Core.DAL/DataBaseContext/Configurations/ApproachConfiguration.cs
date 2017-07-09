using System.Data.Entity.ModelConfiguration;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext.Configurations
{
    class ApproachConfiguration : EntityTypeConfiguration<Approach>
    {
        public ApproachConfiguration()
        {
            ToTable("Approaches");
            Property(ap => ap.PlannedTimeForRest).IsRequired();

            HasOptional<Set>(a => a.Set)
                .WithMany(s => s.Approaches)
                .HasForeignKey(a => new { a.SetId })
                .WillCascadeOnDelete(true);
        }
    }
}
