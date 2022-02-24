using HoliDayRental.BLL.Entities;
using HoliDayRental.Common.Repositories;
using HoliDayRental.Infrastructure.Helpers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        private readonly IBienEchangeRepository<BienEchange> _bienService;
        private readonly IPaysRepository<Pays> _paysService;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext, IBienEchangeRepository<BienEchange> bienService, IPaysRepository<Pays> paysService)
        {
            _logger = logger; 
            _httpContext=httpContext;
            _bienService = bienService;
            _paysService = paysService;
        }

        //public IActionResult Index()
        //{
        //    _httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");
        //    return View();
        //}        

    }
}
