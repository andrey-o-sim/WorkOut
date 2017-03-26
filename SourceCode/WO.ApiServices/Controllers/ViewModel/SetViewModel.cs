using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;

namespace WO.ApiServices.Controllers.ViewModel
{
    public class SetViewModel
    {
        public void GetFullSetData(Set setDTO)
        {
            GenerateApproaches(setDTO);
        }

        private void GenerateApproaches(Set setDTO)
        {
            var countCreateApproaches = setDTO.CountApproaches;

            for (int i = 0; i < countCreateApproaches; i++)
            {
                var approach = new Approach
                {
                    PlannedTimeForRest = setDTO.TimeForRest
                };

                setDTO.Approaches.Add(approach);
            }
        }
    }
}