using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebAppMVC.Controllers;
using WebAppMVC.Models.Entities;
using WebAppMVC.Models.Services;
using Xunit;
using Moq;
using Moq.Protected;
using Castle.DynamicProxy;
using System.Security.Policy;

namespace WebAppMVC.Test
{
    public class UnitTest
    {
        [Fact]
        public void Test_MockBehavior()
        {
            var moq = new Mock<IProductService>(MockBehavior.Strict);
            moq.Setup(p => p.GetProductPrice(1)).Returns(1500);

            var result = moq.Object.GetProductPrice(1);
        }

        [Fact]
        public void Test_PropertySetupTest()
        {
            // Arranghe
            var moq = new Mock<IProductService>(MockBehavior.Strict);
            // Setup Method
            moq.Setup(p => p.GetProductPrice(1)).Returns(25);
            // Setup Property
            moq.Setup(p => p.ProductCount).Returns(15);

            // Act
            var result = moq.Object.GetProductPrice(1);

            // Assert
        }

        [Fact]
        public void Test_Add_Product_SaveState()
        {
            // Arrange
            var moq = new Mock<IProductService>();
            Product product = new Product() { Id = 1, Name= "Name Test" , Description = "Dec", Price=1500 };
            moq.Setup(p => p.Add(product)).Returns(product);
            HomeController controller = new HomeController(moq.Object, null);
            // Setup property
            moq.SetupProperty(p => p.ProductCount);
            // Setup All Property
            //moq.SetupAllProperties();
            // Act
            controller.AddProduct(product);

            // Assert
            Assert.Equal(1, moq.Object.ProductCount);

        }

        [Fact]
        public void Test_SetupSequence()
        {
            var moq = new Mock<IProductService>(MockBehavior.Strict);
            moq.SetupSequence(p => p.GetProductPrice(1)).Returns(1500).Returns(2000).Returns(10000);
             
            var result = moq.Object.GetProductPrice(1);
        }

        [Fact]
        public void Test_ProtectedMock()
        {
            var moq = new Mock<IProductService>();
            moq.Protected().Setup<int>("GetPriceProtected",15).Returns(25000);

        }

        [Fact]
        public void Test_It()
        {
            int [] ids = new int[] { 1, 2, 3 ,15,20,35,1,12589};
            var moq = new Mock<IProductService>();
            //moq.Setup(p => p.GetProductPrice(100)).Returns(15000);
            moq.Setup(p => p.GetProductPrice(It.IsAny<int>())).Returns(15000);
            moq.Setup(p => p.GetProductPrice(It.IsInRange(1, 1000, Moq.Range.Inclusive))).Returns(15000);
            moq.Setup(p => p.GetProductPrice(It.IsIn(ids))).Returns(15000);
            moq.Setup(p => p.GetProductPrice(It.IsNotIn(ids))).Returns(25000);
        }

        [Fact]
        public void Test_OutProgram()
        {
            var moq = new Mock<IProductService>();
            int price = 0;
            moq.Setup(p => p.GetProductPrice(1, out price));

        }

        [Fact]
        public void Test_ChaninMock()
        {
            var moq = new Mock<IProductService>();
            moq.Setup( p => p.Brand.BrandId).Returns(1);
        }


        [Fact]
        public void Test_Behavior_SendMessageWithEmail()
        {
            // Arrange
            var moqMessage = new Mock<IMessage>();
            var moqProduct = new Mock<IProductService>();
            HomeController controller = new HomeController(moqProduct.Object, moqMessage.Object);
            // Act
            controller.SendMessage("Salam", 1, MessageType.Email);

            // Assert
            // مطمئن میشیم که این تابع حتما یکبار اجرا شده است
            moqMessage.Verify(p => p.Email(It.IsAny<string>(), It.IsAny<int>()),Times.Once,"ایمیل ارسال استفاده نشده است");

            //moqMessage.Verify(p => p.Sms(It.IsAny<string>(), It.IsAny<int>()), "اس ام اس اجرا نشده اشت");
        }







    }
}
