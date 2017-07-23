using System.Collections.Generic;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.BLL.Interfaces.Services;

namespace WO.Core.BLL.Services
{
    public class ApproachService : GenericService<ApproachDTO>, IApproachService
    {
        public ApproachService(IRepositoryDTO<ApproachDTO> repository)
            : base(repository)
        {
        }

        public ICollection<ApproachDTO> GenerateApproachesForSet(SetDTO setDTO)
        {
            var approachesForGeneration = GenerateApproaches(setDTO);

            var result = _repository.CreateMany(approachesForGeneration);
            return result;
        }

        private List<ApproachDTO> GenerateApproaches(SetDTO setDTO)
        {
            var countCreateApproaches = setDTO.CountApproaches;
            var approaches = new List<ApproachDTO>();
            for (int i = 0; i < countCreateApproaches; i++)
            {
                var approach = new ApproachDTO
                {
                    PlannedTimeForRest = setDTO.TimeForRest
                };

                if(setDTO.Id > 0)
                {
                    approach.SetId = setDTO.Id;
                }

                approaches.Add(approach);
            }

            return approaches;
        }
    }
}
