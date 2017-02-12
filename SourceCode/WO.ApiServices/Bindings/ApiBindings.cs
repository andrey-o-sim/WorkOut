using Ninject.Modules;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Services;
using WO.Core.BLL.Services.GenericDataServices;

namespace WO.ApiServices.Bindings
{
    public class ApiBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<TrainingTypeDTO>>().To<TrainingTypeService>();
            Bind<IService<ApproachDTO>>().To<ApproachService>();
            Bind<IService<SetDTO>>().To<SetService>();
            Bind<IService<TrainingDTO>>().To<TrainingService>();
            Bind<IService<ExerciseDTO>>().To<ExerciseService>();
        }
    }
}