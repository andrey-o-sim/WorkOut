using System.Data.Entity.ModelConfiguration;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.DataBaseContext.Configurations
{
    class SetTargetConfiguration : EntityTypeConfiguration<SetTarget>
    {
        public SetTargetConfiguration()
        {
            ToTable("SetTargets");

            Property(s => s.SetId).IsRequired();
            Property(s => s.ExerciseId).IsRequired();
            Property(s => s.PlainNumberOfTimes).IsRequired();
        }
    }
}
