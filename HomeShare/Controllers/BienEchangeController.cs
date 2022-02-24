using HoliDayRental.BLL.Entities;
using HoliDayRental.Common.Repositories;
using HoliDayRental.Handlers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class BienEchangeController : Controller
    {
        private readonly IBienEchangeRepository<BienEchange> _bienService;
        private readonly IPaysRepository<Pays> _paysService;

        //private readonly IOptionsBienRepository<OptionsBien> _optionBienService;
        //private readonly IOptionsRepository<Options> _optionService;

        public BienEchangeController(IBienEchangeRepository<BienEchange> bienService, IPaysRepository<Pays> paysService)
        {
            _bienService = bienService;
            _paysService = paysService;

        }

        // GET: BienEchangeController

        [Route("BienEchange/ListeBiens")]
        [Route("BienEchange")]

        public IActionResult Index()
        {
            try
            {
                IEnumerable<BienEchangeList> model = _bienService.Get().Select(c => c.ToListItem());
                model = model.Select(m => { m.ListePays = _paysService.Get((int)m.Pays).ToDetails(); return m; });
                return View(model);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        // GET: BienEchangeController/Details/5
        public IActionResult Details(int id)
        {
        BienEchangeDetails model = _bienService.Get(id).ToDetails();
        model.ListePays = _paysService.Get((int)model.Pays).ToDetails();
        return View(model);
        }

        // GET: BienEchangeController/Create
        public ActionResult Create()
        {
        BienEchangeCreate model = new BienEchangeCreate();
        
        model.ListePays = _paysService.Get().Select(s => s.ToDetails());

        return View(model);
    }

        // POST: BienEchangeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BienEchangeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BienEchangeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BienEchangeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BienEchangeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
