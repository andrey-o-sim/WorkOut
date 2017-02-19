using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Tests.Services
{
    [TestClass]
    public class TestApproachService
    {
        private Mock<IRepositoryDTO<ApproachDTO>> _mock;
        private ApproachService _approachService;
        private List<ApproachDTO> _approaches;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IRepositoryDTO<ApproachDTO>>();
            _approachService = new ApproachService(_mock.Object);

            _approaches = new List<ApproachDTO>
            {
                new ApproachDTO
                {
                    Id=1,
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    PlanTimeForRest=5,
                    SpentTimeForRest=5
                },
                new ApproachDTO
                {
                    Id=2,
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    PlanTimeForRest=10,
                    SpentTimeForRest=9
                },
                new ApproachDTO
                {
                    Id=3,
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    PlanTimeForRest=15,
                    SpentTimeForRest=14
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
                return _approaches.Where(approach => approach.Id == id).FirstOrDefault();
            });

            // Act
            var result = _approachService.Get(searchId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ApproachDTO));
            Assert.AreEqual(result.Id, searchId);
        }

        [TestMethod]
        public void GetAll()
        {
            // Arrange
            _mock.Setup(s => s.GetAll()).Returns(_approaches);

            // Act
            var result = _approachService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ApproachDTO>));
            Assert.AreEqual(_approaches.Count, result.Count());
        }

        [TestMethod]
        public void Find()
        {
            //Arrange
            var searchApproachId = 1;
            _mock.Setup(s => s.Find(It.IsAny<Func<ApproachDTO, bool>>())).Returns<Func<ApproachDTO, bool>>(predicate =>
            {
                return _approaches.Where(predicate).FirstOrDefault();
            });

            //Act
            var result = _approachService.Find(approach => approach.Id == searchApproachId);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ApproachDTO));
            Assert.AreEqual(result.Id, searchApproachId);
        }

        [TestMethod]
        public void FindMany()
        {
            //Arrange
            _mock.Setup(s => s.FindMany(It.IsAny<Func<ApproachDTO, bool>>())).Returns<Func<ApproachDTO, bool>>(predicate =>
            {
                return _approaches.Where(predicate).ToList();
            });

            //Act
            var result = _approachService.FindMany(approach => approach.Id > 0);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ApproachDTO>));
            Assert.AreEqual(result.Count(), _approaches.Count);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var countApproaches = _approaches.Count;

            var approach = new ApproachDTO
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                PlanTimeForRest = 100,
                SpentTimeForRest = 150
            };

            _mock.Setup(s => s.Create(It.IsAny<ApproachDTO>())).Returns<ApproachDTO>(newItem =>
            {
                newItem.Id = _approaches.Count + 1;
                newItem.CreatedDate = DateTime.Now;
                newItem.ModifiedDate = DateTime.Now;

                _approaches.Add(newItem);

                return newItem.Id;
            });

            // Act
            var result = _approachService.Create(approach);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(countApproaches + 1, _approaches.Count);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
        }

        [TestMethod]
        public void Update()
        {
            // Arrange
            var updateApproach = new ApproachDTO
            {
                Id = 2,
                PlanTimeForRest = 150,
                SpentTimeForRest = 110
            };

            _mock.Setup(s => s.Update(It.IsAny<ApproachDTO>())).Callback<ApproachDTO>(updateValue =>
            {
                updateValue.ModifiedDate = DateTime.Now;
                var approachIndex = _approaches.FindIndex(approach => approach.Id == updateValue.Id);
                _approaches[approachIndex] = updateValue;
            });

            // Act
            var result = _approachService.Update(updateApproach);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var idForRemove = 2;
            var currentItemsCount = _approaches.Count;

            _mock.Setup(s => s.Delete(idForRemove)).Callback<int>(id =>
            {
                var itemForRemove = _approaches.Where(approach => approach.Id == id).FirstOrDefault();
                _approaches.Remove(itemForRemove);
            });

            // Act
            var result = _approachService.Delete(idForRemove);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(_approaches.Count, currentItemsCount - 1);
            Assert.IsTrue(result.Succeed);
            Assert.IsFalse(_approaches.Any(approach => approach.Id == idForRemove));
        }
    }
}
