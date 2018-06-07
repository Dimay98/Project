using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerTest.DAL.EF.Repositories;
using ManagerTest.DAL.Domain;
using System.Collections.Generic;
using Moq;

namespace ManagerTest.BL.Tests
{
    [TestClass]
    public class GetUsers
    {
        [TestMethod]
        public void ReturnUserTest_output_list()
        {
            // Arrange
            var users = new GetUser();
            var repository = new Mock<RepositoryUserEF>();
            repository.Setup(arg => arg.GetAll()).Returns(new List<User>());
            users.user = repository.Object;

            // Act
            var resultCollection = users.ReturnUser();

            // Assert
            Assert.IsNotNull(resultCollection);
        }
    }
}
