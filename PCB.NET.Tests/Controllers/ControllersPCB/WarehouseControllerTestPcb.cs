//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PCB.NET.Domain.Abstract.PCB;
//using PCB.NET.Web.Areas.PCB.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace PCB.NET.Tests.Controllers.ControllersPCB
//{
//    [TestClass]
//    class WarehouseControllerTestPcb
//    {
//        [TestMethod]
//        public void Index()
//        {
//            // Arrange
//            WarehouseController controller = new WarehouseController(IRepositoryPCBwarehouse repository);

//            // Act
//            ViewResult result = controller.Index() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result);
//        }

//        [TestMethod]
//        public void About()
//        {
//            // Arrange
//            WarehouseController controller = new WarehouseController();

//            // Act
//            ViewResult result = controller.GasBalloonList() as ViewResult;

//            // Assert
//            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
//        }

//        [TestMethod]
//        public void Contact()
//        {
//            // Arrange
//            WarehouseController controller = new WarehouseController();

//            // Act
//            ViewResult result = controller.Create_Balloon() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result);
//        }
//    }
//}
