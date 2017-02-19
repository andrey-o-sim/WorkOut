using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WO.ApiServices.Controllers.GenericData;
using WO.ApiServices.Models;
using WO.Core.BLL;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Tests.Controllers
{
    [TestClass]
    public class TestTrainingTypeController
    {
        private Mock<IService<TrainingTypeDTO>> _mock;
        private TrainingTypeController _trainingTypeController;
        private List<TrainingTypeDTO> _trainingTypes;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IService<TrainingTypeDTO>>();
            _trainingTypeController = new TrainingTypeController(_mock.Object);

            _trainingTypes = new List<TrainingTypeDTO>
            {
                new TrainingTypeDTO
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "Base",
                   Id = 1
                },
                new TrainingTypeDTO
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "CrossFit",
                   Id = 2
                },
                new TrainingTypeDTO
                {
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Description = string.Empty,
                   TypeTraining = "Elements",
                   Id = 3
                },
            };
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var searchTrainingTypeId = 2;
            _mock.Setup(s => s.Get(It.IsAny<int>())).Returns<int>(searchId =>
           {
               return _trainingTypes.Where(tr => tr.Id == searchId).FirstOrDefault();
           });

            // Act
            var result = _trainingTypeController.Get(searchTrainingTypeId);

            // Assert
            var testTrainingType = _trainingTypes.Where(tt => tt.Id == searchTrainingTypeId).First();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TrainingType));
            Assert.AreEqual(testTrainingType.TypeTraining, result.TypeTraining);
        }

        [TestMethod]
        public void GetAll()
        {
            // Arrange
            _mock.Setup(s => s.GetAll()).Returns(_trainingTypes);

            // Act
            var result = _trainingTypeController.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<TrainingType>));
            Assert.AreEqual(_trainingTypes.Count, result.Count());
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var countTrainingTypes = _trainingTypes.Count;
            var newTrainingType = new TrainingType
            {
                Description = string.Empty,
                TypeTraining = "Test Training Type"
            };

            _mock.Setup(s => s.Create(It.IsAny<TrainingTypeDTO>())).Returns<TrainingTypeDTO>(newItem =>
           {
               newItem.Id = _trainingTypes.Count + 1;
               newItem.CreatedDate = DateTime.Now;
               newItem.ModifiedDate = DateTime.Now;

               _trainingTypes.Add(newItem);

               return new OperationResult
               {
                   ResultItemId = newItem.Id,
                   Succeed = true
               };
           });

            // Act
            var result = _trainingTypeController.Create(newTrainingType);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(countTrainingTypes + 1, _trainingTypes.Count);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
        }

        [TestMethod]
        public void Update()
        {
            // Arrange
            var updateTrainingType = new TrainingType
            {
                Id = 2,
                Description = string.Empty,
                TypeTraining = "Test CrossFit"
            };

            _mock.Setup(s => s.Update(It.IsAny<TrainingTypeDTO>())).Returns<TrainingTypeDTO>(updateValue =>
             {
                 updateValue.ModifiedDate = DateTime.Now;
                 var trainingTypeIndex = _trainingTypes.FindIndex(tt => tt.Id == updateValue.Id);
                 _trainingTypes[trainingTypeIndex] = updateValue;

                 return new OperationResult
                 {
                     ResultItemId = updateValue.Id,
                     Succeed = true
                 };
             });

            // Act
            var result = _trainingTypeController.Update(updateTrainingType.Id, updateTrainingType);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);

            Assert.AreEqual(_trainingTypes.Find(tt => tt.Id == updateTrainingType.Id).TypeTraining, updateTrainingType.TypeTraining);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var idForRemove = 2;
            var currentItemsCount = _trainingTypes.Count;

            _mock.Setup(s => s.Delete(idForRemove)).Returns<int>(id =>
           {
               var itemForRemove = _trainingTypes.Where(tt => tt.Id == id).FirstOrDefault();
               _trainingTypes.Remove(itemForRemove);

               return new OperationResult { ResultItemId = id, Succeed = true };
           });

            // Act
            var result = _trainingTypeController.Delete(idForRemove);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(_trainingTypes.Count, currentItemsCount - 1);
            Assert.IsTrue(result.Succeed);
            Assert.IsFalse(_trainingTypes.Any(tt => tt.Id == idForRemove));
        }
    }
}
