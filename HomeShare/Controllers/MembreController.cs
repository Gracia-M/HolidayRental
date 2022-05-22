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
    public class MembreController : Controller
    {
        private readonly IMembreRepository<Membre> _membreService;
        private readonly IPaysRepository<Pays> _paysService;

        public MembreController(IMembreRepository<Membre> membreService, IPaysRepository<Pays> paysService)
        {
            _membreService = membreService;
            _paysService = paysService;

        }


        // GET: MembreController
        public IActionResult Index()
        {
            return View("Liste des membres ");
        }

        public IActionResult ListeMembre()
        {
            try
            {
                IEnumerable<MembreList> model = _membreService.Get().Select(c => c.ToListItem());
                model = model.Select(m => { m.ListePays = _paysService.Get((int)m.idPays).ToDetails(); return m; });
                return View(model);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
        // GET: MembreController/Details/5
        public IActionResult Details(int id)
        {
            MembreDetails model = _membreService.Get(id).ToDetails();
            model.ListePays = _paysService.Get((int)model.idPays).ToDetails();
            return View(model);
        }

        // GET: MembreController/Create
        public IActionResult Create()
        {
            MembreCreate model = new MembreCreate();
            model.ListePays = _paysService.Get().Select(s => s.ToDetails());

            return View(model);
        }

        // POST: MembreController/Create
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

        // GET: MembreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MembreController/Edit/5
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

        // GET: MembreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembreController/Delete/5
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
