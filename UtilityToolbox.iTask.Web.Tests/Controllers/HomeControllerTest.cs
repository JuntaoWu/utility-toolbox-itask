using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityToolbox.iTask.Web;
using UtilityToolbox.iTask.Web.Controllers;
using UtilityToolbox.iTask.Domain.Interface;
using UtilityToolbox.iTask.Domain.Entities;

namespace UtilityToolbox.iTask.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            Moq.Mock<ITaskRepository> mock = new Moq.Mock<ITaskRepository>();
            mock.Setup(m => m.NormalizedTasks).Returns(new NormalizedTask[] { });

            // Arrange
            HomeController controller = new HomeController();
            DefaultController defaultController = new DefaultController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
