using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WO.ApiServices.Controllers;
using WO.ApiServices.Models;
using WO.Core.BLL;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Tests.Controllers
{
    [TestClass]
    public class TestExerciseController
    {
        private Mock<IService<ExerciseDTO>> _mock;
        private ExerciseController _exerciseController;
        private List<ExerciseDTO> _exercises;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IService<ExerciseDTO>>();
            _exerciseController = new ExerciseController(_mock.Object);

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
            var result = _exerciseController.Get(searchId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, searchId);
            Assert.IsInstanceOfType(result, typeof(Exercise));
        }

        [TestMethod]
        public void GetAll()
        {
            //Arrange
            _mock.Setup(s => s.GetAll()).Returns(_exercises);

            //Act
            var result = _exerciseController.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Exercise>));
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            var newExercise = new Exercise
            {
                Name = "Push-ups"
            };

            _mock.Setup(s => s.Create(It.IsAny<ExerciseDTO>())).Returns<ExerciseDTO>(newValue =>
             {
                 newValue.Id = _exercises.Count + 1;
                 newValue.CreatedDate = DateTime.Now;
                 newValue.ModifiedDate = DateTime.Now;

                 _exercises.Add(newValue);

                 return new OperationResult
                 {
                     Succeed = true,
                     ResultItemId = newValue.Id
                 };
             });

            //Act
            var result = _exerciseController.Create(newExercise);

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
            var exerciseForUpdate = new Exercise
            {
                Id = 3,
                Name = "Squats",
            };

            _mock.Setup(s => s.Update(It.IsAny<ExerciseDTO>())).Returns<ExerciseDTO>(updateValue =>
             {
                 updateValue.ModifiedDate = DateTime.Now;
                 var indexForUpdate = _exercises.FindIndex(ex => ex.Id == updateValue.Id);
                 _exercises[indexForUpdate] = updateValue;

                 return new OperationResult
                 {
                     Succeed = true,
                     ResultItemId = updateValue.Id
                 };
             });

            //Act
            var result = _exerciseController.Update(exerciseForUpdate.Id, exerciseForUpdate);

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
            _mock.Setup(s => s.Delete(It.IsAny<int>())).Returns<int>(id =>
             {
                 var removeExercise = _exercises.Find(ex => ex.Id == id);
                 _exercises.Remove(removeExercise);

                 return new OperationResult
                 {
                     Succeed = true,
                     ResultItemId = id
                 };
             });

            //Act
            var result = _exerciseController.Delete(idForRemove);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
            Assert.IsFalse(_exercises.Any(ex => ex.Id == result.ResultItemId));
        }
    }
}
