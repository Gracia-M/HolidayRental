using HoliDayRental.BLL.Entities;
using HoliDayRental.Common.Repositories;
using HoliDayRental.Handlers;
using HoliDayRental.Infrastructure.Helpers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HoliDayRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMembreRepository<Membre>_membreService;
        private readonly SessionManager _session;

        public AccountController(ILogger<AccountController> logger, IMembreRepository<Membre> membreService, SessionManager session)
        {
            _logger = logger;
            _membreService = membreService;
            this._session = session;
        }

        //private readonly ILogger<AccountController> _logger;
        //private readonly IHttpContextAccessor _httpContext;

        //public AccountController(ILogger<AccountController> logger, IHttpContextAccessor httpContext)
        //{
        //    _logger = logger;
        //    _httpContext = httpContext;
        //}
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Login()
        {
            if (_session.IsConnected) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Login(ConnectionForm form)
        {
            //ValidateLoginForm(form, ModelState);
            if (!ModelState.IsValid) return View();
            //Session Manager
            _session.SetUser(form);
            //Création d'une méthode CheckPassword 
            int id = _membreService.checkPassword(form.Login, form.Password);
            if (id == -1) return View();
            _session.User = _membreService.Get(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        //Exemple d'ajout de valeur pour une session permettant de spécifier que l'utilisateur est connecté
        //[HttpPost]
        //public IActionResult Register()
        //{
        //    _httpContext.HttpContext.Session.SetObjectAsJson("IsLogged", true);
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
