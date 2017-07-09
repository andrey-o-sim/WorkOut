using System.Data.Entity.ModelConfiguration;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext.Configurations
{
    class SetConfiguration : EntityTypeConfiguration<Set>
    {
        public SetConfiguration()
        {
            ToTable("Sets");
            Property(s => s.TimeForRest).IsRequired();

            HasOptional<Training>(s => s.Training)
                .WithMany(t => t.Sets)
                .HasForeignKey(t => new { t.TrainingId })
                .WillCascadeOnDelete(true);
        }
    }
}
