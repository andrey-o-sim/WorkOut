using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;
using WO.Core.DAL.DataBaseContext;
using WO.Core.DAL.Repositories;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.BLL.DTO;
using WO.Core.Data.Repositories;

namespace WO.Core.Data.Bindings
{
    public class DataBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<TrainingType>>().To<Repository<TrainingType>>().WithConstructorArgument("dbContext", new WorkOutContext("WorkOutDbConnection"));
            Bind<IRepositoryDTO<TrainingTypeDTO>>().To<DTORepository<TrainingType, TrainingTypeDTO>>();
        }
    }
}
