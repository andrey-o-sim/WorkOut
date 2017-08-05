using Ninject.Modules;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Services;
using WO.Core.BLL.Services;
using WO.Core.BLL.Services.GenericDataServices;
using WO.LoggerFactory;

namespace WO.ApiServices.Bindings
{
    public class ApiBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggerFactory>().To<LoggerFactory.LoggerFactory>();

            Bind<IService<TrainingTypeDTO>>().To<TrainingTypeService>();
            Bind<IApproachService>().To<ApproachService>();
            Bind<IService<SetDTO>>().To<SetService>();
            Bind<IService<TrainingDTO>>().To<TrainingService>();
            Bind<IExerciseService>().To<ExerciseService>();
            Bind<IService<SetTargetDTO>>().To<SetTargetService>();
            Bind<IService<ApproachResultDTO>>().To<ApproachResultService>();

            Bind<IService<LogEntryDTO>>().To<LogEntryService>();
        }
    }
}