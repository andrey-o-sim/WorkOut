using System.Data.Entity.ModelConfiguration;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext.Configurations
{
    class ApproachResultConfiguration : EntityTypeConfiguration<ApproachResult>
    {
        public ApproachResultConfiguration()
        {
            ToTable("ApproachResults");

            HasRequired<SetTarget>(ar => ar.SetTarget)
                .WithMany(s => s.ApproachResults)
                .HasForeignKey(a => new { a.SetTargetId })
                .WillCascadeOnDelete(true);

            HasRequired<Approach>(ar => ar.Approach)
                .WithMany(a => a.ApproachResults)
                .HasForeignKey(ar => new { ar.ApproachId })
                .WillCascadeOnDelete(true);
        }
    }
}
