﻿using AutoMapper;
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
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore());

                cfg.CreateMap<Training, TrainingDTO>();
                cfg.CreateMap<TrainingDTO, Training>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore());

                cfg.CreateMap<Set, SetDTO>();
                cfg.CreateMap<SetDTO, Set>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore());

                cfg.CreateMap<Exercise, ExerciseDTO>()
                .ForMember(dto => dto.Sets, dl => dl.Ignore());
                cfg.CreateMap<ExerciseDTO, Exercise>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore());

                cfg.CreateMap<Approach, ApproachDTO>()
                .ForMember(dto => dto.Set, dl => dl.Ignore());
                cfg.CreateMap<ApproachDTO, Approach>()
                .ForMember(dto => dto.CreatedDate, dl => dl.Ignore())
                .ForMember(dto => dto.ModifiedDate, dl => dl.Ignore());
            });
        }
    }
}
