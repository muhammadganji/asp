using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Controllers;
using WebAppMVC.Models.Entities;
using WebAppMVC.Models.MockData;
using WebAppMVC.Models.Services;
using Xunit;
using Xunit.Abstractions;

namespace WebAppMVC.Test
{
    public class ProductApiControllerTest
    {
        MockData _data;
        private readonly ITestOutputHelper _output;
        public ProductApiControllerTest( ITestOutputHelper ouput)
        {
            _data = new MockData();
            _output = ouput;
        }

        [Fact]
        public void GetTest()
        {
            // Arrange
            var moc = new Mock<IProductService>();
            moc.Setup(p => p.GetAll()).Returns(_data.GetAll());
            ProductApiController controller = new ProductApiController(moc.Object);
            // Act
            var result = controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(result);
            var list = result as OkObjectResult;
            Assert.IsType<List<Product>>(list.Value);
        }

        [Theory]
        [InlineData(1, -1)]
        public void GetByIdTest(int validId, int inValidId)
        {
            // Arrange
            var moc = new Mock<IProductService>();
            moc.Setup(p => p.GetById(validId)).Returns(_data.GetAll().FirstOrDefault(p => p.Id == validId));
            ProductApiController controller = new ProductApiController(moc.Object);

            // Act
            var result = controller.Get(validId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var typeResult = result as OkObjectResult;
            Assert.IsType<Product>(typeResult.Value);

            // ::::::::::: Bad Request ::::::::::::::

            // Arrange
            moc.Setup(p => p.GetById(inValidId)).Returns(_data.GetAll().FirstOrDefault(p => p.Id == inValidId));
            ProductApiController controller2 = new ProductApiController(moc.Object);

            // Act
            var invaliResult = controller2.Get(inValidId);

            // Assert
            Assert.IsType<NotFoundResult>(invaliResult);

        }

        [Fact]
        public void Post_Test()
        {
            //Areange
            var moq = new Mock<IProductService>();
            Product product = new Product()
            {
                Id = 1,
                Description = "cccc",
                Name = "Samsung",
                Price = 4500
            };
            moq.Setup(p => p.Add(product)).Returns(product);
            ProductApiController controller = new ProductApiController(moq.Object);

            //Act
            var result = controller.Post(product);

            //Assert
            Assert.IsType<CreatedAtActionResult>(result);

            // ::::::::: Bad Request :::::::::::

            // Arrange
            var moc = new Mock<IProductService>();
            Product invalidProduct = new Product()
            {
                Id = 1,
                Description = "des 2",
                Price = 10000
            };
            moc.Setup(p => p.Add(invalidProduct)).Returns(invalidProduct);
            ProductApiController invalidController = new ProductApiController(moc.Object);
            invalidController.ModelState.AddModelError("Name", "Insert Name, it can't be null");
            // Act
            var invalidResul = invalidController.Post(invalidProduct);

            // Assert
            Assert.IsType<BadRequestObjectResult>(invalidResul);

        }

        [Theory]
        [InlineData(1,-1)]
        public void DeleteTest(int validId, int inValidId)
        {
            // Arrange
            var moc = new Mock<IProductService>();
            moc.Setup(p => p.Remove(validId));
            moc.Setup(p => p.GetById(validId)).Returns(_data.GetAll().FirstOrDefault(p => p.Id== validId));
            ProductApiController controller = new ProductApiController(moc.Object);

            // Act
            var result = controller.Delete(validId);
            var invalidResult = controller.Delete(inValidId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<NotFoundResult>(invalidResult);
        }



    }
}
