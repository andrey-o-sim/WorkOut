using AutoMapper;
using System;
using System.Collections.Generic;
using WO.Core.BLL.DTO;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Configs
{
    public static class AutoMapperDataConfiguration
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
                cfg.CreateMap<TrainingType, TrainingTypeDTO>()
                .ForMember(dto => dto.Trainings, dl => dl.Ignore());

                cfg.CreateMap<TrainingTypeDTO, TrainingType>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore())
                .ForMember(dto => dto.Trainings, dl => dl.Ignore());


                cfg.CreateMap<Training, TrainingDTO>();

                cfg.CreateMap<TrainingDTO, Training>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore())
                .ForMember(dto => dto.TrainingType, dl => dl.Ignore())
                .ForMember(dto => dto.Sets, dl => dl.Ignore());


                cfg.CreateMap<Set, SetDTO>()
                .ForMember(dto => dto.Training, dl => dl.Ignore());

                cfg.CreateMap<SetDTO, Set>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore())
                .ForMember(dto => dto.Approaches, dl => dl.Ignore())
                .ForMember(dto => dto.Training, dl => dl.Ignore())
                .ForMember(dto => dto.SetTargets, dl => dl.Ignore());


                cfg.CreateMap<Exercise, ExerciseDTO>()
                .ForMember(dl => dl.SetTargets, dl => dl.Ignore());

                cfg.CreateMap<ExerciseDTO, Exercise>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore())
                .ForMember(dto => dto.SetTargets, dto => dto.Ignore())
                .ForMember(dto => dto.TrainingTypes, dto => dto.Ignore());


                cfg.CreateMap<Approach, ApproachDTO>()
                .ForMember(dto => dto.Set, dl => dl.Ignore());

                cfg.CreateMap<ApproachDTO, Approach>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore())
                .ForMember(dto => dto.Set, dl => dl.Ignore());

                cfg.CreateMap<SetTarget, SetTargetDTO>()
                .ForMember(dto => dto.Set, dl => dl.Ignore());

                cfg.CreateMap<SetTargetDTO, SetTarget>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore());

                cfg.CreateMap<ApproachResult, ApproachResultDTO>()
                .ForMember(dto => dto.Approach, dl => dl.Ignore())
                .ForMember(dto => dto.SetTarget, dl => dl.Ignore());

                cfg.CreateMap<ApproachResultDTO, ApproachResult>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore());

                cfg.CreateMap<LogEntry, LogEntryDTO>();

                cfg.CreateMap<LogEntryDTO, LogEntry>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore());
            });
        }
    }
}
