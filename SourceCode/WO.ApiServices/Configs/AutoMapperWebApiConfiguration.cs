using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.ApiServices.Models;
using WO.ApiServices.Models.Helper;
using WO.Core.BLL.DTO;

namespace WO.ApiServices.Configs
{
    public static class AutoMapperWebApiConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        public static MapperConfiguration MapperConfiguration
        {
            get
            {
                if (_mapperConfiguration == null)
                {
                    RegisterMappings();
                }
                return _mapperConfiguration;
            }
        }

        public static void RegisterMappings()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<TrainingType, TrainingTypeDTO>();
                  cfg.CreateMap<TrainingTypeDTO, TrainingType>();

                  cfg.CreateMap<Training, TrainingDTO>();
                  cfg.CreateMap<TrainingDTO, Training>();

                  cfg.CreateMap<Exercise, ExerciseDTO>();
                  cfg.CreateMap<ExerciseDTO, Exercise>();

                  cfg.CreateMap<Set, SetDTO>()
                    .ForMember(dest => dest.PlainTime,
                             opt => opt.MapFrom(src => TimeWoOperations.FromTimeWoToSeconds(src.PlainTime)))
                    .ForMember(dest => dest.SummaryTime,
                             opt => opt.MapFrom(src => TimeWoOperations.FromTimeWoToSeconds(src.SummaryTime)))
                    .ForMember(dest => dest.TimeForRest,
                             opt => opt.MapFrom(src => TimeWoOperations.FromTimeWoToSeconds(src.TimeForRest)));

                  cfg.CreateMap<SetDTO, Set>()
                  .ForMember(dest => dest.PlainTime,
                             opt => opt.MapFrom(src => TimeWoOperations.FromSecondsToTimeWo(src.PlainTime)))
                  .ForMember(dest => dest.SummaryTime,
                             opt => opt.MapFrom(src => TimeWoOperations.FromSecondsToTimeWo(src.SummaryTime)))
                  .ForMember(dest => dest.TimeForRest,
                             opt => opt.MapFrom(src => TimeWoOperations.FromSecondsToTimeWo(src.TimeForRest)));

                  cfg.CreateMap<Approach, ApproachDTO>()
                  .ForMember(dest => dest.PlanTimeForRest,
                             opt => opt.MapFrom(src => TimeWoOperations.FromTimeWoToSeconds(src.PlanTimeForRest)))
                  .ForMember(dest => dest.SpentTimeForRest,
                             opt => opt.MapFrom(src => TimeWoOperations.FromTimeWoToSeconds(src.SpentTimeForRest)));

                  cfg.CreateMap<ApproachDTO, Approach>()
                  .ForMember(dest => dest.PlanTimeForRest,
                             opt => opt.MapFrom(src => TimeWoOperations.FromSecondsToTimeWo(src.PlanTimeForRest)))
                  .ForMember(dest => dest.SpentTimeForRest,
                             opt => opt.MapFrom(src => TimeWoOperations.FromSecondsToTimeWo(src.SpentTimeForRest)));
              });
        }
    }
}