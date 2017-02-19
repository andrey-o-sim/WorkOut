using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WO.ApiServices.Controllers;
using WO.ApiServices.Models;
using WO.ApiServices.Models.Helper;
using WO.Core.BLL;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Tests.Controllers
{
    [TestClass]
    public class TestSetController
    {
        private Mock<IService<SetDTO>> _mock;
        private SetController _setController;
        private List<SetDTO> _sets;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IService<SetDTO>>();
            _setController = new SetController(_mock.Object);

            _sets = new List<SetDTO>
            {
                new SetDTO
                {
                   Id = 1,
                   CountApproaches=5,
                   CountMadeApproaches=5,
                   PlainTime=1000,
                   TimeForRest=120,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                },
                new SetDTO
                {
                   Id = 2,
                   CountApproaches=4,
                   CountMadeApproaches=4,
                   PlainTime=500,
                   TimeForRest=60,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                },
                new SetDTO
                {
                   Id = 3,
                   CountApproaches=6,
                   CountMadeApproaches=6,
                   PlainTime=1100,
                   TimeForRest=100,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                },
            };
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var searchSetId = 2;
            _mock.Setup(s => s.Get(It.IsAny<int>())).Returns<int>(searchId =>
            {
                return _sets.Where(tr => tr.Id == searchId).FirstOrDefault();
            });

            // Act
            var result = _setController.Get(searchSetId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Set));
            Assert.IsTrue(result.Id > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            // Arrange
            _mock.Setup(s => s.GetAll()).Returns(_sets);

            // Act
            var result = _setController.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Set>));
            Assert.AreEqual(_sets.Count, result.Count());
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var countSets = _sets.Count;
            var newSet = new Set
            {
                CountApproaches = 7,
                CountMadeApproaches = 7,
                PlainTime = new TimeWO { Hours = 0, Minutes = 30, Seconds = 0 },
                TimeForRest = new TimeWO { Hours = 0, Minutes = 1, Seconds = 50 },
            };

            _mock.Setup(s => s.Create(It.IsAny<SetDTO>())).Returns<SetDTO>(newItem =>
            {
                newItem.Id = _sets.Count + 1;
                newItem.CreatedDate = DateTime.Now;
                newItem.ModifiedDate = DateTime.Now;

                _sets.Add(newItem);

                return new OperationResult
                {
                    ResultItemId = newItem.Id,
                    Succeed = true
                };
            });

            // Act
            var result = _setController.Create(newSet);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(countSets + 1, _sets.Count);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
        }

        [TestMethod]
        public void Update()
        {
            // Arrange
            var updateSet = new Set
            {
                Id = 2,
                SummaryTime = new TimeWO { Hours = 0, Minutes = 5, Seconds = 55 }
            };

            _mock.Setup(s => s.Update(It.IsAny<SetDTO>())).Returns<SetDTO>(updateValue =>
            {
                updateValue.ModifiedDate = DateTime.Now;
                var setIndex = _sets.FindIndex(set => set.Id == updateValue.Id);
                _sets[setIndex] = updateValue;

                return new OperationResult
                {
                    ResultItemId = updateValue.Id,
                    Succeed = true
                };
            });

            // Act
            var result = _setController.Update(updateSet.Id, updateSet);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
            Assert.AreEqual(_sets.Find(set => set.Id == updateSet.Id).SummaryTime, TimeWoOperations.FromTimeWoToSeconds(updateSet.SummaryTime));
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var idForRemove = 2;
            var currentItemsCount = _sets.Count;

            _mock.Setup(s => s.Delete(idForRemove)).Returns<int>(id =>
            {
                var itemForRemove = _sets.Where(set => set.Id == id).FirstOrDefault();
                _sets.Remove(itemForRemove);

                return new OperationResult { ResultItemId = id, Succeed = true };
            });

            // Act
            var result = _setController.Delete(idForRemove);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(_sets.Count, currentItemsCount - 1);
            Assert.IsTrue(result.Succeed);
            Assert.IsFalse(_sets.Any(set => set.Id == idForRemove));
        }
    }
}
