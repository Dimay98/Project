using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerTest.DAL.EF.Repositories;
using Moq;
using ManagerTest.DAL.Domain;

namespace ManagerTest.BL.Tests
{
    [TestClass]
    public class AddUsers
    {
        [TestMethod]
        public void AddUserTest_input_name_serialn_time_purposetouse_output_true()
        {
            string fio = "Шевченко Тарас Григорович";
            string login = "kpi123";
            string password = "34567";
            string role = "user";
            var users = new AddUser();
            var repository = new Mock<RepositoryUserEF>();

            repository.Setup(arg => arg.Create(new User() { FIO = fio, Login = login, Password = password, Role = role }));
            repository.Setup(arg => arg.Save());
            users.user = repository.Object;


            var result = users.AddUsr(fio, login, password, role);


            Assert.IsTrue(result);
            repository.Verify(arg => arg.Create(It.IsAny<User>()), Times.Once());
            repository.Verify(arg => arg.Save(), Times.Once());
        }
    }
}
