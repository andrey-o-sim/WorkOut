using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.BLL.Services.GenericDataServices;

namespace WO.ApiServices.Tests.Services
{
    [TestClass]
    public class TestTrainingTypeService
    {
        private Mock<IRepositoryDTO<TrainingTypeDTO>> _mock;
        private TrainingTypeService _trainingTypeService;
        private List<TrainingTypeDTO> _trainingTypes;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IRepositoryDTO<TrainingTypeDTO>>();
            _trainingTypeService = new TrainingTypeService(_mock.Object);

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
            var searchId = 2;
            _mock.Setup(s => s.Get(It.IsAny<int>())).Returns<int>(id =>
           {
               return _trainingTypes.Where(tr => tr.Id == id).FirstOrDefault();
           });

            // Act
            var result = _trainingTypeService.Get(searchId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TrainingTypeDTO));
            Assert.AreEqual(_trainingTypes.Find(tt => tt.Id == searchId).TypeTraining, result.TypeTraining);
        }

        [TestMethod]
        public void GetAll()
        {
            // Arrange
            _mock.Setup(s => s.GetAll()).Returns(_trainingTypes);

            // Act
            var result = _trainingTypeService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<TrainingTypeDTO>));
            Assert.AreEqual(_trainingTypes.Count, result.Count());
        }

        //[TestMethod]
        //public void Find()
        //{
        //    //Arrange
        //    var searchTrainingType = "Base";
        //    _mock.Setup(s => s.Find(It.IsAny<Func<TrainingTypeDTO, bool>>())).Returns<Func<TrainingTypeDTO, bool>>(predicate =>
        //      {
        //          return _trainingTypes.Where(predicate).FirstOrDefault();
        //      });

        //    //Act
        //    var result = _trainingTypeService.Find(tt => tt.TypeTraining == searchTrainingType);

        //    //Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOfType(result, typeof(TrainingTypeDTO));
        //    Assert.AreEqual(result.TypeTraining, searchTrainingType);
        //}

        //[TestMethod]
        //public void FindMany()
        //{
        //    //Arrange
        //    _mock.Setup(s => s.FindMany(It.IsAny<Func<TrainingTypeDTO, bool>>())).Returns<Func<TrainingTypeDTO, bool>>(predicate =>
        //   {
        //       return _trainingTypes.Where(predicate).ToList();
        //   });

        //    //Act
        //    var result = _trainingTypeService.FindMany(tt => tt.Id > 0);

        //    //Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOfType(result, typeof(IEnumerable<TrainingTypeDTO>));
        //    Assert.AreEqual(result.Count(), _trainingTypes.Count);
        //}

        [TestMethod]
        public void Create()
        {
            // Arrange
            var countTrainingTypes = _trainingTypes.Count;
            var newTrainingType = new TrainingTypeDTO
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

               return newItem.Id;
           });

            // Act
            var result = _trainingTypeService.Create(newTrainingType);

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
            var updateTrainingType = new TrainingTypeDTO
            {
                Description = string.Empty,
                TypeTraining = "Test CrossFit",
                Id = 2
            };

            _mock.Setup(s => s.Update(It.IsAny<TrainingTypeDTO>())).Callback<TrainingTypeDTO>(updateValue =>
           {
               updateValue.ModifiedDate = DateTime.Now;
               var trainingTypeIndex = _trainingTypes.FindIndex(tt => tt.Id == updateValue.Id);
               _trainingTypes[trainingTypeIndex] = updateValue;
           });

            // Act
            var result = _trainingTypeService.Update(updateTrainingType);

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

            _mock.Setup(s => s.Delete(idForRemove)).Callback<int>(id =>
           {
               var itemForRemove = _trainingTypes.Where(tt => tt.Id == id).FirstOrDefault();
               _trainingTypes.Remove(itemForRemove);
           });

            // Act
            var result = _trainingTypeService.Delete(idForRemove);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(_trainingTypes.Count, currentItemsCount - 1);
            Assert.IsTrue(result.Succeed);
            Assert.IsFalse(_trainingTypes.Any(tt => tt.Id == idForRemove));
        }
    }
}
