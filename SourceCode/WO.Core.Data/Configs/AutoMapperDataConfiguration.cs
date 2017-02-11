using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Configs
{
    public static class AutoMapperDataConfiguration
    {
        public static MapperConfiguration MapperConfiguration;
        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrainingType, TrainingTypeDTO>();
                cfg.CreateMap<TrainingTypeDTO, TrainingType>();

                cfg.CreateMap<Training, TrainingDTO>();
                cfg.CreateMap<TrainingDTO, Training>();

                cfg.CreateMap<Set, SetDTO>();
                cfg.CreateMap<SetDTO, Set>();

                cfg.CreateMap<Exercise, ExerciseDTO>();
                cfg.CreateMap<ExerciseDTO, Exercise>();

                cfg.CreateMap<Approach, ApproachDTO>();
                cfg.CreateMap<ApproachDTO, Approach>();
            });
        }
    }
}
