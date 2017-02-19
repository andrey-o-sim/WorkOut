using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Tests.Services
{
    [TestClass]
    public class TestSetService
    {
        private Mock<IRepositoryDTO<SetDTO>> _mock;
        private SetService _setService;
        private List<SetDTO> _sets;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IRepositoryDTO<SetDTO>>();
            _setService = new SetService(_mock.Object);

            _sets = new List<SetDTO>
            {
                new SetDTO
                {
                   Id = 1,
                   CountApproaches = 5,
                   CountMadeApproaches = 5,
                   PlainTime = 1000,
                   TimeForRest = 120,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                },
                new SetDTO
                {
                   Id = 2,
                   CountApproaches = 4,
                   CountMadeApproaches = 4,
                   PlainTime = 500,
                   TimeForRest = 60,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                },
                new SetDTO
                {
                   Id = 3,
                   CountApproaches = 6,
                   CountMadeApproaches = 6,
                   PlainTime = 1100,
                   TimeForRest = 100,
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
            var result = _setService.Get(searchSetId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SetDTO));
            Assert.IsTrue(result.Id > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            // Arrange
            _mock.Setup(s => s.GetAll()).Returns(_sets);

            // Act
            var result = _setService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<SetDTO>));
            Assert.AreEqual(_sets.Count, result.Count());
        }

        [TestMethod]
        public void Find()
        {
            //Arrange
            var searchSetId = 1;
            _mock.Setup(s => s.Find(It.IsAny<Func<SetDTO, bool>>())).Returns<Func<SetDTO, bool>>(predicate =>
           {
               return _sets.Where(predicate).FirstOrDefault();
           });

            //Act
            var result = _setService.Find(set => set.Id == searchSetId);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SetDTO));
            Assert.AreEqual(result.Id, searchSetId);
        }

        [TestMethod]
        public void FindMany()
        {
            //Arrange
            _mock.Setup(s => s.FindMany(It.IsAny<Func<SetDTO, bool>>())).Returns<Func<SetDTO, bool>>(predicate =>
           {
               return _sets.Where(predicate).ToList();
           });

            //Act
            var result = _setService.FindMany(set => set.Id > 0);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<SetDTO>));
            Assert.AreEqual(result.Count(), _sets.Count);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var countSets = _sets.Count;
            var newSet = new SetDTO
            {
                CountApproaches = 7,
                CountMadeApproaches = 7,
                PlainTime = 1800,
                TimeForRest = 90,
            };

            _mock.Setup(s => s.Create(It.IsAny<SetDTO>())).Returns<SetDTO>(newItem =>
           {
               newItem.Id = _sets.Count + 1;
               newItem.CreatedDate = DateTime.Now;
               newItem.ModifiedDate = DateTime.Now;

               _sets.Add(newItem);

               return newItem.Id;
           });

            // Act
            var result = _setService.Create(newSet);

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
            var updateSet = new SetDTO
            {
                Id = 2,
                SummaryTime = 355
            };

            _mock.Setup(s => s.Update(It.IsAny<SetDTO>())).Callback<SetDTO>(updateValue =>
           {
               updateValue.ModifiedDate = DateTime.Now;
               var setIndex = _sets.FindIndex(set => set.Id == updateValue.Id);
               _sets[setIndex] = updateValue;
           });

            // Act
            var result = _setService.Update(updateSet);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultItemId > 0);
            Assert.AreEqual(_sets.Find(set => set.Id == updateSet.Id).SummaryTime, updateSet.SummaryTime);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var idForRemove = 2;
            var currentItemsCount = _sets.Count;

            _mock.Setup(s => s.Delete(idForRemove)).Callback<int>(id =>
           {
               var itemForRemove = _sets.Where(set => set.Id == id).FirstOrDefault();
               _sets.Remove(itemForRemove);
           });

            // Act
            var result = _setService.Delete(idForRemove);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOperationResult));
            Assert.AreEqual(_sets.Count, currentItemsCount - 1);
            Assert.IsTrue(result.Succeed);
            Assert.IsFalse(_sets.Any(set => set.Id == idForRemove));
        }
    }
}
