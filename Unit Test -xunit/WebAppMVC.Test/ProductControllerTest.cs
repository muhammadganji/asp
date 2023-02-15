using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Controllers;
using WebAppMVC.Models.Entities;
using WebAppMVC.Models.MockData;
using WebAppMVC.Models.Services;
using Xunit.Abstractions;

namespace WebAppMVC.Test
{
    public class ProductControllerTest
    {
        private readonly ITestOutputHelper _outputHelper;
        MockData _data;
        public ProductControllerTest(ITestOutputHelper outputHelper)
        {
            _data = new MockData();
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Index_Test()
        {
            // Arrange
            var moq = new Mock<IProductService>();
            moq.Setup(p => p.GetAll()).Returns(_data.GetAll());

            ProductController productController = new ProductController(moq.Object);

            // Act
            var result = productController.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsAssignableFrom<List<Product>>(viewResult.ViewData.Model);
        }

        [Theory]
        [InlineData(1, -1)]
        public void Details_Test(int ValidId, int inValidId)
        {
            // Arrange
            var moq = new Mock<IProductService>();
            moq.Setup(p => p.GetById(ValidId)).Returns(_data.GetAll().FirstOrDefault(p => p.Id == ValidId));
            ProductController productController = new ProductController(moq.Object);
            // Act
            var result = productController.Details(ValidId);
            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsAssignableFrom<Product>(viewResult.ViewData.Model);

            // ::::::::::::: Bad Request :::::::::

            // Arrange
            moq.Setup(p => p.GetById(inValidId)).Returns(_data.GetAll().FirstOrDefault(p => p.Id == inValidId));
            // Act
            var invalidResult = productController.Details(inValidId);
            // Assert
            Assert.IsType<NotFoundResult>(invalidResult);


        }

        [Fact]
        public void Create_Test()
        {
            // Arrange
            var moq = new Mock<IProductService>();
            ProductController productController = new ProductController(moq.Object);
            Product product = new Product()
            {
                Id = 1,
                Description = "Desc 10",
                Name = "Product Name",
                Price = 2000
            };

            // Act
            var Result = productController.Create(product);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(Result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Null(redirect.ControllerName);

            // :::::::::::::: Bad Request :::::::::::

            // Arrange
            Product invalidProduct = new Product()
            {
                Price = 3000
            };
            productController.ModelState.AddModelError("Name", "نام را وارد کنید");
            // Act
            var invalidResult = productController.Create(invalidProduct);

            // Assert
            Assert.IsType<BadRequestObjectResult>(invalidResult);
             

        }

        [Theory]
        [InlineData(1,-1)]
        public void Remove_Test(int ValidId, int invalidId)
        {
            // Arrange
            var moq = new Mock<IProductService>();
            MockData data = new MockData();
            moq.Setup(p => p.Remove(ValidId));
            moq.Setup(p => p.GetById(ValidId)).Returns(_data.GetAll().FirstOrDefault(p => p.Id == ValidId));
            ProductController controller = new ProductController(moq.Object);
            Product product = new Product()
            {
                Id = ValidId
            };

            // Act
            var result = controller.Delete(ValidId, product);

            // Assert
            var direct = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", direct.ActionName);

            // :::::::::: Bad Request :::::::::::::
            
            // Arrange

            // Act
            var invalidResult = controller.Delete(invalidId, product);

            // Assert
            Assert.IsType<NotFoundResult>(invalidResult);


        }
    }
}
