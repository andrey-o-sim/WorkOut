using Ninject.Modules;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.DataBaseContext;
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
            Bind<IRepository<TrainingType>>().To<Repository<TrainingType>>().WithConstructorArgument("dbContext", new WorkOutContext("WorkOutDbConnection"));
            Bind<IRepositoryDTO<TrainingTypeDTO>>().To<DTORepository<TrainingType, TrainingTypeDTO>>();

            Bind<IRepository<Approach>>().To<Repository<Approach>>().WithConstructorArgument("dbContext", new WorkOutContext("WorkOutDbConnection"));
            Bind<IRepositoryDTO<ApproachDTO>>().To<DTORepository<Approach, ApproachDTO>>();

            Bind<IRepository<Set>>().To<Repository<Set>>().WithConstructorArgument("dbContext", new WorkOutContext("WorkOutDbConnection"));
            Bind<IRepositoryDTO<SetDTO>>().To<DTORepository<Set, SetDTO>>();

            Bind<IRepository<Training>>().To<Repository<Training>>().WithConstructorArgument("dbContext", new WorkOutContext("WorkOutDbConnection"));
            Bind<IRepositoryDTO<TrainingDTO>>().To<DTORepository<Training, TrainingDTO>>();

            Bind<IRepository<Exercise>>().To<Repository<Exercise>>().WithConstructorArgument("dbContext", new WorkOutContext("WorkOutDbConnection"));
            Bind<IRepositoryDTO<ExerciseDTO>>().To<DTORepository<Exercise, ExerciseDTO>>();
        }
    }
}
