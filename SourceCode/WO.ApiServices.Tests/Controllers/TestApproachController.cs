using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    public class TestApproachController
    {
        private Mock<IService<ApproachDTO>> _mock;
        private ApproachController _approachController;
        private List<ApproachDTO> _approaches;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock<IService<ApproachDTO>>();
            _approachController = new ApproachController(_mock.Object, null);

            _approaches = new List<ApproachDTO>
            {
                new ApproachDTO
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    PlannedTimeForRest = 5,
                    SpentTimeForRest = 5
                },
                new ApproachDTO
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    PlannedTimeForRest = 10,
                    SpentTimeForRest = 9
                },
                new ApproachDTO
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    PlannedTimeForRest = 15,
                    SpentTimeForRest = 14
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
                 return _approaches.Where(a => a.Id == id).FirstOrDefault();
             });

            //Act
            var result = _approachController.Get(searchId);
            var approachResult = result as OkNegotiatedContentResult<Approach>;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Approach>));
            Assert.AreEqual(approachResult.Content.Id, searchId);
        }

        [TestMethod]
        public void GetAll()
        {
            //Arrange
            _mock.Setup(s => s.GetAll()).Returns(_approaches);

            //Act
            var result = _approachController.GetAll();
            var approachResult = result as OkNegotiatedContentResult<List<Approach>>;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<Approach>>));
            Assert.AreEqual(approachResult.Content.Count(), _approaches.Count);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            var countApproaches = _approaches.Count;

            var approach = new Approach
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                PlannedTimeForRest = new TimeWO { Hours = 0, Minutes = 2, Seconds = 30 },
                SpentTimeForRest = new TimeWO { Hours = 0, Minutes = 2, Seconds = 0 }
            };

            _mock.Setup(s => s.Create(It.IsAny<ApproachDTO>())).Returns<ApproachDTO>(newItem =>
           {
               newItem.Id = _approaches.Count + 1;
               _approaches.Add(newItem);

               return new OperationResult
               {
                   Succeed = true,
                   ResultItemId = newItem.Id
               };
           });

            //Act
            var result = _approachController.Create(approach);
            var operationResult = result as OkNegotiatedContentResult<IOperationResult>;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IOperationResult>));
            Assert.IsTrue(operationResult.Content.Succeed);
            Assert.IsTrue(operationResult.Content.ResultItemId > 0);
            Assert.AreEqual(countApproaches + 1, _approaches.Count);
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            var plannedTimeForRest = new TimeWO { Hours = 0, Minutes = 10, Seconds = 30 };
            var spentTimeForRest = new TimeWO { Hours = 0, Minutes = 5, Seconds = 10 };

            var updateApproach = new Approach
            {
                Id = 2,
                PlannedTimeForRest = plannedTimeForRest,
                SpentTimeForRest = spentTimeForRest
            };

            _mock.Setup(s => s.Update(It.IsAny<ApproachDTO>())).Returns<ApproachDTO>(approach =>
             {
                 approach.ModifiedDate = DateTime.Now;
                 var indexUpdateItem = _approaches.FindIndex(ap => ap.Id == approach.Id);
                 _approaches[indexUpdateItem] = approach;

                 return new OperationResult
                 {
                     ResultItemId = approach.Id,
                     Succeed = true
                 };
             });

            //Act
            var result = _approachController.Update(updateApproach);
            var operationResult = result as OkNegotiatedContentResult<IOperationResult>;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IOperationResult>));
            Assert.IsTrue(operationResult.Content.Succeed);
            Assert.AreEqual(TimeWoOperations.FromTimeWoToSeconds(plannedTimeForRest), _approaches.Find(ap => ap.Id == updateApproach.Id).PlannedTimeForRest);
            Assert.AreEqual(TimeWoOperations.FromTimeWoToSeconds(spentTimeForRest), _approaches.Find(ap => ap.Id == updateApproach.Id).SpentTimeForRest);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            var countOfApproaches = _approaches.Count;
            var idForRemove = 2;
            _mock.Setup(s => s.Delete(It.IsAny<int>())).Returns<int>(id =>
             {
                 var approachForRemove = _approaches.Find(ap => ap.Id == id);
                 _approaches.Remove(approachForRemove);

                 return new OperationResult
                 {
                     Succeed = true,
                     ResultItemId = id
                 };
             });

            //Act
            var result = _approachController.Delete(idForRemove);
            var operationResult = result as OkNegotiatedContentResult<IOperationResult>;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IOperationResult>));
            Assert.AreEqual(countOfApproaches - 1, _approaches.Count);
            Assert.IsTrue(operationResult.Content.Succeed);
            Assert.IsFalse(_approaches.Any(tt => tt.Id == idForRemove));
        }
    }
}
