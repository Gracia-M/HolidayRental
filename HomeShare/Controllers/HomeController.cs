using HoliDayRental.BLL.Entities;
using HoliDayRental.Common.Repositories;
using HoliDayRental.Handlers;
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
            _httpContext= httpContext;
            _bienService = bienService;
            _paysService = paysService;
        }

        //public IActionResult Index()
        //{
        //    _httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");
        //    return View();
        //}        

        public IActionResult Index()
        {
            //_httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");

            HomeIndex model = new HomeIndex();

            model.BiensEchanges = _bienService.Get().Select(c => c.ToListItem());
            model.BiensEchanges = model.BiensEchanges.Select(m => { m.ListePays = _paysService.Get((int)m.idPays).ToDetails(); return m; });

            model.BienEchange5Last = _bienService.LastFiveBiens().Select(c => c.ToListItem());
            model.BienEchange5Last = model.BienEchange5Last.Select(m => { m.ListePays = _paysService.Get((int)m.idPays).ToDetails(); return m; });
            return View(model);
        }

        public IActionResult conditions()
        {
            return View();
        }

        [Route("Last")]
        public IActionResult LastFiveBiens()
        {
            HomeIndex model = new HomeIndex();

            model.BiensEchanges = _bienService.LastFiveBiens().Select(c => c.ToListItem());
            //model.BienEchange5Last = _BienEchangeService.Last5Biens().Select(c => c.ToListItem5());
            model.BienEchange5Last = model.BiensEchanges.Select(m => { m.ListePays = _paysService.Get((int)m.idPays).ToDetails(); return m; });
            return View(model);

        }
    }
}

//try
//{
//    IEnumerable<BienEchangeList> model2 = _bienService.Get().Select(c => c.ToList());
//    model2 = model2.Select(m => { m.ListePays = _paysService.Get((int)m.idPays).ToDetails(); return m; });
//    return View(model);
//}
//catch (Exception e)
//{
//    return Json(e);
//}