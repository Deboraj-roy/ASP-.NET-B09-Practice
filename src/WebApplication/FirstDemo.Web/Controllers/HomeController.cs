﻿using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, ISmsSender smsSender)
        {
            _logger = logger;
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        public IActionResult Index()
        {
            var user = new UserClass() {
                Id = 1,
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "password123",
                Phone = "1234567890"
            };
            var k = user.Sum(71 , 2);
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult UserData() 
        {
            var user = new UserClass()
            {
                Id = 1,
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "password123",
                Phone = "1234567890"
            };
            var k = user.Sum(71, 2);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}