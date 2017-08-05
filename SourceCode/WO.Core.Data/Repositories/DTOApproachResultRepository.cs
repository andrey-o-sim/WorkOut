using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Repositories
{
    public class DTOApproachResultRepository : DTORepository<ApproachResult, ApproachResultDTO>, IRepositoryDTO<ApproachResultDTO>
    {
        private IRepository<SetTarget> _setTargetRepository;
        private IRepository<Approach> _approachRepository;
        public DTOApproachResultRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetGenericRepository<ApproachResult>();
            _setTargetRepository = unitOfWork.GetGenericRepository<SetTarget>();
            _approachRepository = unitOfWork.GetGenericRepository<Approach>();
        }

        public override int Create(ApproachResultDTO aproachResultDTO)
        {
            var approachResult = _mapper.Map<ApproachResult>(aproachResultDTO);
            approachResult.CreatedDate = DateTime.Now;
            approachResult.ModifiedDate = DateTime.Now;

            SetSubItems(approachResult, aproachResultDTO);

            _repository.Create(approachResult);
            _unitOfWork.Commit();

            return approachResult.Id;
        }

        public override void Update(ApproachResultDTO approachResultDTO)
        {
            var approachResultForUpdate = _repository.Get(approachResultDTO.Id);
            _mapper.Map<ApproachResultDTO, ApproachResult>(approachResultDTO, approachResultForUpdate);
            approachResultForUpdate.ModifiedDate = DateTime.Now;

            SetSubItems(approachResultForUpdate, approachResultDTO);

            _repository.Update(approachResultForUpdate);
            _unitOfWork.Commit();
        }

        private void SetSubItems(ApproachResult aproachResult, ApproachResultDTO aproachResultDTO)
        {
            var setTargetId = aproachResultDTO.SetTarget != null
                ? aproachResultDTO.SetTarget.Id
                : aproachResultDTO.SetTargetId;

            aproachResult.SetTarget = setTargetId.HasValue
                ? _setTargetRepository.Get(setTargetId.Value)
                : new SetTarget();

            var approachId = aproachResultDTO.Approach != null
                ? aproachResultDTO.Approach.Id
                : aproachResultDTO.ApproachId;

            aproachResult.Approach = approachId.HasValue
                ? _approachRepository.Get(approachId.Value)
                : new Approach();
        }
    }
}
