using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagerTest.DAL.EF.Repositories;
using ManagerTest.DAL.Domain;
using System.Collections.Generic;


namespace ManagerTest.BL.Tests
{
    [TestClass]
    public class GetResourses
    {
        [TestMethod]
        public void ReturnResTest_output_list()
        {
           
            // Arrange
            var resourses = new GetResourse();
            var repository = new Mock<RepositoryResourseEF>();
            repository.Setup(arg => arg.GetAll()).Returns(new List<Resourse>());
            resourses.resourse = repository.Object;

            // Act
            var resultCollection = resourses.ReturnResourse();

            // Assert
            Assert.IsNotNull(resultCollection);
        }
    }
    
}
