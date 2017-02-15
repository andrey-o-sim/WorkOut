using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.ApiServices.Configs;
using WO.ApiServices.Controllers.GenericData;
using WO.ApiServices.Models;
using WO.ApiServices.Tests.DTORepositories;
using WO.ApiServices.Tests.Services;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;

namespace WO.ApiServices.Tests.Controllers
{
    [TestClass]
    public class TestTrainingTypeController
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var trainingTypes = GetTrainingTypeCollection();
            var repository = new TestDTORepository<TrainingTypeDTO>(trainingTypes);
            var service = new TestTrainingTypeService(repository);
            var trainingTypeController = new TrainingTypeController(service);

            // Act
            var result = trainingTypeController.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<TrainingType>));
            Assert.AreEqual(trainingTypes.Count, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            int searchId = 2;
            // Arrange
            var trainingTypes = GetTrainingTypeCollection();
            var repository = new TestDTORepository<TrainingTypeDTO>(trainingTypes);
            var service = new TestTrainingTypeService(repository);
            var trainingTypeController = new TrainingTypeController(service);

            // Act
            var result = trainingTypeController.Get(2);

            // Assert
            var testTrainingType = trainingTypes.Where(tt => tt.Id == searchId).First();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TrainingType));
            Assert.AreEqual(testTrainingType.TypeTraining, result.TypeTraining);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var trainingTypes = GetTrainingTypeCollection();
            var repository = new TestDTORepository<TrainingTypeDTO>(trainingTypes);
            var service = new TestTrainingTypeService(repository);
            var trainingTypeController = new TrainingTypeController(service);

            var newTrainingType = new TrainingType
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Description = string.Empty,
                TypeTraining = "Test Training Type"
            };

            // Act
            var result = trainingTypeController.Create(newTrainingType);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
        }

        [TestMethod]
        public void Update()
        {
            // Arrange
            var trainingTypes = GetTrainingTypeCollection();
            var repository = new TestDTORepository<TrainingTypeDTO>(trainingTypes);
            var service = new TestTrainingTypeService(repository);
            var trainingTypeController = new TrainingTypeController(service);

            var updateTrainingType = new TrainingType
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Description = string.Empty,
                TypeTraining = "Test CrossFit",
                Id = 2
            };

            // Act
            var result = trainingTypeController.Update(2, updateTrainingType);
            var resultUpdatedTrainingType = trainingTypeController.Get(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);

            Assert.AreEqual(resultUpdatedTrainingType.TypeTraining, updateTrainingType.TypeTraining);
        }

        [TestMethod]
        public void Remove()
        {
            var idForRemove = 2;
            // Arrange
            var trainingTypes = GetTrainingTypeCollection();
            var repository = new TestDTORepository<TrainingTypeDTO>(trainingTypes);
            var service = new TestTrainingTypeService(repository);
            var trainingTypeController = new TrainingTypeController(service);

            // Act
            var result = trainingTypeController.Delete(idForRemove);
            var resultTrainingTypes = trainingTypeController.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.IsTrue(result.Succeed);
            Assert.IsFalse(resultTrainingTypes.Any(tt => tt.Id == idForRemove));
        }

        private List<TrainingTypeDTO> GetTrainingTypeCollection()
        {
            var trainingTypes = new List<TrainingTypeDTO>
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

            return trainingTypes;
        }
    }
}
