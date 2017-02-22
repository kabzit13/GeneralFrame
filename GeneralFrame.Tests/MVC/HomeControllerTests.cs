using System.Web.Mvc;
using GeneralFrame.Application.Contracts;
using GeneralFrame.Core.Wcf;
using GeneralFrame.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeneralFrame.Tests.MVC
{
    [TestClass]
    public class HomeControllerTests
    {
        Mock<IServiceProxy<IGeneralFrameService>> mockCalcService;
        HomeController mockHomeController;

        [TestInitialize]
        public void InitTest()
        {
            //Assign
            this.mockCalcService = new Mock<IServiceProxy<IGeneralFrameService>>();
            this.mockCalcService.SetupAllProperties();
            this.mockHomeController = new HomeController(this.mockCalcService.Object);
        }

        [TestMethod]
        public void TestIndexView()
        {
            //Act
            var result = this.mockHomeController.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }

       
       
    }
}
