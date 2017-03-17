using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Repositories
{
    public class DTOSetRepository : DTORepository<Set, SetDTO>, IRepositoryDTO<SetDTO>
    {
        IRepository<Approach> _approachRepository;
        IRepository<Exercise> _exerciseRepository;

        public DTOSetRepository(IRepository<Set> setRepository,
            IRepository<Approach> approachRepository,
            IRepository<Exercise> exerciseRepository)
            : base(setRepository)
        {
            _approachRepository = approachRepository;
            _exerciseRepository = exerciseRepository;
        }

        public override int Create(SetDTO setDto)
        {
            var set = _mapper.Map<Set>(setDto);
            set.CreatedDate = DateTime.Now;
            set.ModifiedDate = DateTime.Now;

            foreach (Exercise exercise in set.Exercises)
            {
                _repository.AttachToContext<Exercise>(exercise, EntityState.Unchanged);
            }

            foreach (Approach approach in set.Approaches)
            {
                approach.CreatedDate = DateTime.Now;
                approach.ModifiedDate = DateTime.Now;
            }

            return _repository.Create(set);
        }

        public override void Update(SetDTO setDto)
        {
            var setForUpdate = _repository.Get(setDto.Id);
            _mapper.Map<SetDTO, Set>(setDto, setForUpdate);

            setForUpdate.ModifiedDate = DateTime.Now;

            var setExercises = setForUpdate.Exercises;
            setForUpdate.Exercises = new List<Exercise>();
            foreach (Exercise exercise in setExercises)
            {
                var exerciseForUpdate = _exerciseRepository.Get(exercise.Id);
                if (exerciseForUpdate.Sets.Any(s => s.Id == setForUpdate.Id) == false)
                {
                    exerciseForUpdate.Sets.Add(setForUpdate);
                }
                setForUpdate.Exercises.Add(exerciseForUpdate);
            }

            var setApproaches = setForUpdate.Approaches;
            setForUpdate.Approaches = new List<Approach>();
            foreach (Approach approach in setApproaches)
            {
                var approachForUpdate = _approachRepository.Get(approach.Id);
                setForUpdate.Approaches.Add(approachForUpdate);
            }

            _repository.Update(setForUpdate);
        }
    }
}
