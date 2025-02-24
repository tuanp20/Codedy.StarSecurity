﻿using Codedy.StarSecurity.WebApp.Models;
using Codedy.StarSecurity.WebApp.Models.Catalog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Codedy.StarSecurity.WebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServicesService _servicesService;
        private readonly ILogger<HomeController> _logger;

        public ServiceController(ILogger<HomeController> logger, IServicesService servicesService)
        {
            _logger = logger;
            _servicesService = servicesService;
        }

        public IActionResult Index()
        {
            var services = _servicesService.Services();

            return View(services);
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = _servicesService.Service(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
