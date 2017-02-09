using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;

namespace WO.ApiServices.App_Start
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<TrainingType, TrainingTypeDTO>();
                  cfg.CreateMap<TrainingTypeDTO, TrainingType>();
              });
        }
    }
}