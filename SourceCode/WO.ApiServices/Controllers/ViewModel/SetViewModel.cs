using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.Core.BLL.DTO;

namespace WO.ApiServices.Controllers.ViewModel
{
    public class SetViewModel
    {
        public void GetFullSetData(SetDTO setDTO)
        {
            GenerateApproaches(setDTO);
        }

        private void GenerateApproaches(SetDTO setDTO)
        {
            var countCreateApproaches = setDTO.CountApproaches;

            for (int i = 0; i < countCreateApproaches; i++)
            {
                var approach = new ApproachDTO
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    PlannedTimeForRest = setDTO.TimeForRest
                };

                setDTO.Approaches.Add(approach);
            }
        }
    }
}