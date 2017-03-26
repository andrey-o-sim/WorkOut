using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Tests.Services
{
    [TestClass]
    public class TestExerciseService
    {
        private Mock<IExerciseRepositoryDTO> _mock;
        private ExerciseService _exerciseService;
        private List<ExerciseDTO> _exercises;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IExerciseRepositoryDTO>();
            _exerciseService = new ExerciseService(_mock.Object);

            _exercises = new List<ExerciseDTO>
            {
                new ExerciseDTO
                {
                    Id = 1,
                    Name = "Tightening",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new ExerciseDTO
                {
                    Id = 2,
                    Name = "Dips",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new ExerciseDTO
                {
                    Id = 3,
                    Name = "Curl up",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            };
        }

        [TestMethod]
        public void GetById()
        {
            //Arrange
            var searchId = 2;
            _mock.Setup(s => s.Get(It.IsAny<int>())).Returns<int>(id =>
           {
               return _exercises.Find(ex => ex.Id == id);
           });

            //Act
            var result = _exerciseService.Get(searchId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, searchId);
            Assert.IsInstanceOfType(result, typeof(ExerciseDTO));
        }

        [TestMethod]
        public void GetAll()
        {
            //Arrange
            _mock.Setup(s => s.GetAll()).Returns(_exercises);

            //Act
            var result = _exerciseService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ExerciseDTO>));
        }

        //[TestMethod]
        //public void Find()
        //{
        //    //Arrange
        //    var searchExerciseId = 1;
        //    _mock.Setup(s => s.Find(It.IsAny<Func<ExerciseDTO, bool>>())).Returns<Func<ExerciseDTO, bool>>(predicate =>
        //   {
        //       return _exercises.Where(predicate).FirstOrDefault();
        //   });

        //    //Act
        //    var result = _exerciseService.Find(exercise => exercise.Id == searchExerciseId);

        //    //Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOfType(result, typeof(ExerciseDTO));
        //    Assert.AreEqual(result.Id, searchExerciseId);
        //}

        //[TestMethod]
        //public void FindMany()
        //{
        //    //Arrange
        //    _mock.Setup(s => s.FindMany(It.IsAny<Func<ExerciseDTO, bool>>())).Returns<Func<ExerciseDTO, bool>>(predicate =>
        //   {
        //       return _exercises.Where(predicate).ToList();
        //   });

        //    //Act
        //    var result = _exerciseService.FindMany(exercise => exercise.Id > 0);

        //    //Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOfType(result, typeof(IEnumerable<ExerciseDTO>));
        //    Assert.AreEqual(result.Count(), _exercises.Count);
        //}

        [TestMethod]
        public void Create()
        {
            //Arrange
            var newExercise = new ExerciseDTO
            {
                Name = "Push-ups"
            };

            _mock.Setup(s => s.Create(It.IsAny<ExerciseDTO>())).Returns<ExerciseDTO>(newValue =>
           {
               newValue.Id = _exercises.Count + 1;
               newValue.CreatedDate = DateTime.Now;
               newValue.ModifiedDate = DateTime.Now;

               _exercises.Add(newValue);

               return newValue.Id;
           });

            //Act
            var result = _exerciseService.Create(newExercise);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
            Assert.AreEqual(_exercises.Find(ex => ex.Id == result.ResultItemId).Name, newExercise.Name);
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            var exerciseForUpdate = new ExerciseDTO
            {
                Id = 3,
                Name = "Squats",
            };

            _mock.Setup(s => s.Update(It.IsAny<ExerciseDTO>())).Callback<ExerciseDTO>(updateValue =>
           {
               updateValue.ModifiedDate = DateTime.Now;
               var indexForUpdate = _exercises.FindIndex(ex => ex.Id == updateValue.Id);
               _exercises[indexForUpdate] = updateValue;
           });

            //Act
            var result = _exerciseService.Update(exerciseForUpdate);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
            Assert.AreEqual(_exercises.Find(ex => ex.Id == result.ResultItemId).Name, exerciseForUpdate.Name);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            var idForRemove = 1;
            _mock.Setup(s => s.Delete(It.IsAny<int>())).Callback<int>(id =>
           {
               var removeExercise = _exercises.Find(ex => ex.Id == id);
               _exercises.Remove(removeExercise);
           });

            //Act
            var result = _exerciseService.Delete(idForRemove);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
            Assert.IsFalse(_exercises.Any(ex => ex.Id == result.ResultItemId));
        }
    }
}
