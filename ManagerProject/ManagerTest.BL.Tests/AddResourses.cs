using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagerTest.DAL.EF.Repositories;
using ManagerTest.DAL.Domain;
using ManagerTest.BL;


namespace ManagerTest.BL.Tests
{
    [TestClass]
    public class AddResourses
    {
        [TestMethod]
       
        public void AddResourseTest_input_name_serialn_time_purposetouse_output_true()
        {

            // Arrange
            string name = "Шевченко Тараc";
            int  serialn = 111;
            string time = "34567";
            string purposetouse = "ergeg9";
            var resourses = new AddResourse();
            var repository = new Mock<RepositoryResourseEF>();

            repository.Setup(arg => arg.Create(new Resourse() { Name=name,SerialN=serialn,Time=time,PurposeToUse=purposetouse}));
            repository.Setup(arg => arg.Save());
            resourses.resourse = repository.Object;

             
            var result = resourses.AddRes(name, serialn, time, purposetouse);

            
            Assert.IsTrue(result);
            repository.Verify(arg => arg.Create(It.IsAny<Resourse>()), Times.Once());
            repository.Verify(arg => arg.Save(), Times.Once());
        }
    }
    
}
