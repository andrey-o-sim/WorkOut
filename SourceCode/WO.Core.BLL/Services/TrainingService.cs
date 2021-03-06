﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;

namespace WO.Core.BLL.Services
{
    public class TrainingService : GenericService<TrainingDTO>
    {
        public TrainingService(IRepositoryDTO<TrainingDTO> repository)
            : base(repository)
        {
        }
    }
}
