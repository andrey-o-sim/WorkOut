using System.Data.Entity.ModelConfiguration;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext.Configurations
{
    class TrainingConfiguration : EntityTypeConfiguration<Training>
    {
        public TrainingConfiguration()
        {
            ToTable("Trainings");
            Property(t => t.TrainingTypeId).IsRequired();
            Property(t => t.MainTrainingPurpose).IsRequired();
        }
    }
}
