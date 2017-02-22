using System;
using System.Collections.Generic;
using System.ServiceModel;
using GeneralFrame.Application;
using GeneralFrame.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeneralFrame.Tests.Services
{
    [TestClass]
    public class GeneralFrameAppServiceTests
    {
        [TestMethod]
        public void WhenMethodReturnPositiveResult()
        {
        }

        [TestMethod]
        public void WhenMethodsReturnValidResult()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<CustomError>), "String should contain only numbers from 0 to 9")]
        public void WhenMethodThrowsFaultException()
        {
        }
    }
}
