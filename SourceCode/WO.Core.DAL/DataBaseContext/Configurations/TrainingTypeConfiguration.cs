using System.Data.Entity.ModelConfiguration;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext.Configurations
{
    class TrainingTypeConfiguration : EntityTypeConfiguration<TrainingType>
    {
        public TrainingTypeConfiguration()
        {
            ToTable("TrainingTypes");
            Property(tt => tt.TypeTraining).IsRequired();
        }
    }
}
