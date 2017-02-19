using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WO.ApiServices.Controllers;
using WO.ApiServices.Models;
using WO.Core.BLL;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Tests.Controllers
{
    [TestClass]
    public class TestTrainingController
    {
        private Mock<IService<TrainingDTO>> _mock;
        private TrainingController _trainingController;
        private List<TrainingDTO> _trainings;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IService<TrainingDTO>>();
            _trainingController = new TrainingController(_mock.Object);

            _trainings = new List<TrainingDTO>
            {
                new TrainingDTO
                {
                   Id = 1,
                   MainTrainingPurpose="The main purpose is 1...",
                   Description="Desc 1",
                   StartDateTime=DateTime.Now,
                   EndDateTime=DateTime.Now.AddHours(2),
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now
                },
                new TrainingDTO
                {
                   Id = 2,
                   MainTrainingPurpose="The main purpose is 2...",
                   Description="Desc 2",
                   StartDateTime=DateTime.Now,
                   EndDateTime=DateTime.Now.AddHours(1).AddMinutes(30),
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now
                },
                new TrainingDTO
                {
                   Id = 3,
                   MainTrainingPurpose="The main purpose is 3...",
                   Description="Desc 3",
                   StartDateTime=DateTime.Now,
                   EndDateTime=DateTime.Now.AddHours(1).AddMinutes(40),
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now
                },
            };
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var searchTrainingId = 2;
            _mock.Setup(s => s.Get(It.IsAny<int>())).Returns<int>(searchId =>
            {
                return _trainings.Where(tr => tr.Id == searchId).FirstOrDefault();
            });

            // Act
            var result = _trainingController.Get(searchTrainingId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Training));
            Assert.IsTrue(result.Id > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            // Arrange
            _mock.Setup(s => s.GetAll()).Returns(_trainings);

            // Act
            var result = _trainingController.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Training>));
            Assert.AreEqual(_trainings.Count, result.Count());
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var countTrainings = _trainings.Count;
            var newTraining = new Training
            {
                MainTrainingPurpose = "The main purpose is 4...",
                Description = "Desc 4",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(1).AddMinutes(40),
            };

            _mock.Setup(s => s.Create(It.IsAny<TrainingDTO>())).Returns<TrainingDTO>(newItem =>
            {
                newItem.Id = _trainings.Count + 1;
                newItem.CreatedDate = DateTime.Now;
                newItem.ModifiedDate = DateTime.Now;

                _trainings.Add(newItem);

                return new OperationResult
                {
                    ResultItemId = newItem.Id,
                    Succeed = true
                };
            });

            // Act
            var result = _trainingController.Create(newTraining);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(countTrainings + 1, _trainings.Count);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
        }

        [TestMethod]
        public void Update()
        {
            // Arrange
            var updateTraining = new Training
            {
                Id = 2,
                MainTrainingPurpose = "The main purpose is 5...",
                Description = "Desc 5",
            };

            _mock.Setup(s => s.Update(It.IsAny<TrainingDTO>())).Returns<TrainingDTO>(updateValue =>
            {
                updateValue.ModifiedDate = DateTime.Now;
                var trainingIndex = _trainings.FindIndex(training => training.Id == updateValue.Id);
                _trainings[trainingIndex] = updateValue;

                return new OperationResult
                {
                    ResultItemId = updateValue.Id,
                    Succeed = true
                };
            });

            // Act
            var result = _trainingController.Update(updateTraining.Id, updateTraining);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
            Assert.AreEqual(_trainings.Find(training => training.Id == updateTraining.Id).MainTrainingPurpose, updateTraining.MainTrainingPurpose);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var idForRemove = 2;
            var currentItemsCount = _trainings.Count;

            _mock.Setup(s => s.Delete(idForRemove)).Returns<int>(id =>
            {
                var itemForRemove = _trainings.Where(training => training.Id == id).FirstOrDefault();
                _trainings.Remove(itemForRemove);

                return new OperationResult { ResultItemId = id, Succeed = true };
            });

            // Act
            var result = _trainingController.Delete(idForRemove);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(_trainings.Count, currentItemsCount - 1);
            Assert.IsTrue(result.Succeed);
            Assert.IsFalse(_trainings.Any(training => training.Id == idForRemove));
        }
    }
}
