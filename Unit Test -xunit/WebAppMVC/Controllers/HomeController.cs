using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using System.Diagnostics;
using WebAppMVC.Models;
using WebAppMVC.Models.Entities;
using WebAppMVC.Models.Services;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMessage _message;

        public HomeController(IProductService productService, IMessage message)
        {
           _productService= productService;
            _message= message;
        }

        public IActionResult AddProduct(Product product)
        {
            // save Status
            _productService.Add(product);
            _productService.ProductCount += 1;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        // چک کردن رفتار توابع
        public IActionResult SendMessage(string message, int userId, MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Sms:
                    _message.Sms(message, userId); 
                    ;break;
                case MessageType.Email:
                    _message.Email(message, userId);
                    ; break;
                case MessageType.Notif:
                    _message.Notif(message, userId);
                    ; break;
            }
            return Json(true);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}