using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Areas.PCB.Controllers;
using System.Web.Mvc;

namespace PCB.NET.Tests.Controllers.ControllersPCB
{
    [TestClass]
    public class WarehouseControllerTestPcb
    {
        [TestMethod]
        public void IndexWarehouse()
        {
            var moq = new Mock<IRepositoryPCBwarehouse>();
            // Arrange
            WarehouseController controller = new WarehouseController(moq.Object);
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GasBalloonList()
        {
            var moq = new Mock<IRepositoryPCBwarehouse>();
            // Arrange
            WarehouseController controller = new WarehouseController(moq.Object);
            // Act
            ViewResult result = controller.GasBalloonList() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_Balloon()
        {
            var moq = new Mock<IRepositoryPCBwarehouse>();
            // Arrange
            WarehouseController controller = new WarehouseController(moq.Object);
            // Act
            ViewResult result = controller.Create_Balloon() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void Edit_Balloon()
        //{
        //    var moq = new Mock<IRepositoryPCBwarehouse>();
        //    //moq.Setup(m => m.GasBalloon).Returns((GasBalloon balloon) => { return } );
        //    // Arrange
        //    WarehouseController controller = new WarehouseController(moq.Object);
        //    // Act
        //    ViewResult result = controller.Edit_Balloon() as ViewResult;
        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void Delete_Balloon()
        //{
        //    var moq = new Mock<IRepositoryPCBwarehouse>();
        //    // Arrange
        //    WarehouseController controller = new WarehouseController(moq.Object);
        //    // Act
        //    ViewResult result = controller.Delete_Balloon() as ViewResult;
        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void Details_Balloon()
        //{
        //    var moq = new Mock<IRepositoryPCBwarehouse>();
        //    // Arrange
        //    WarehouseController controller = new WarehouseController(moq.Object);
        //    // Act
        //    ViewResult result = controller.Details_Balloon() as ViewResult;
        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
