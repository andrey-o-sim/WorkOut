using Ninject.Modules;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;
using WO.Core.DAL.Repositories;
using WO.Core.Data.Repositories;

namespace WO.Core.Data.Bindings
{
    public class DataBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbFactory>().To<DbFactory>();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepository<TrainingType>>().To<Repository<TrainingType>>();
            Bind<IRepositoryDTO<TrainingTypeDTO>>().To<DTORepository<TrainingType, TrainingTypeDTO>>();

            Bind<IRepository<Approach>>().To<Repository<Approach>>();
            Bind<IRepositoryDTO<ApproachDTO>>().To<DTORepository<Approach, ApproachDTO>>();

            Bind<IRepository<Set>>().To<Repository<Set>>();
            Bind<IRepositoryDTO<SetDTO>>().To<DTOSetRepository>();

            Bind<IRepository<Training>>().To<Repository<Training>>();
            Bind<IRepositoryDTO<TrainingDTO>>().To<DTOTrainingRepository>();

            Bind<IRepository<Exercise>>().To<Repository<Exercise>>();
            Bind<IExerciseRepositoryDTO>().To<DTOExerciseRepository>();

            Bind<IRepository<LogEntry>>().To<Repository<LogEntry>>();
            Bind<IRepositoryDTO<LogEntryDTO>>().To<DTORepository<LogEntry, LogEntryDTO>>();
        }
    }
}
