using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System.Web.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var controller = new CalculateController();

            // Act
            var result = controller.Index() as ViewResult;
            

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Index_Post_Addition_ReturnsCorrectResult()
        {
            // Arrange
            var controller = new CalculateController();

            // Act
            var result = controller.Index(10, 5, "Addition") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(15.0, result.ViewBag.Result);
        }

        [TestMethod]
        public void Index_Post_DivisionByZero_ReturnsError()
        {
            // Arrange
            var controller = new CalculateController();

            // Act
            var result = controller.Index(10, 0, "Division") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Cannot divide by zero.", result.ViewBag.Error);
        }

        [TestMethod]
        public void Index_Post_InvalidOperation_ReturnsError()
        {
            // Arrange
            var controller = new CalculateController();

            // Act
            var result = controller.Index(10, 5, "Modulus") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Invalid Operation Selected.", result.ViewBag.Error);
        }
    }
}
