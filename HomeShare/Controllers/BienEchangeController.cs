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
using B = HoliDayRental.BLL.Entities;


namespace HoliDayRental.Controllers
{
    public class BienEchangeController : Controller
    {
        private readonly IBienEchangeRepository<BienEchange> _bienService;
        private readonly IPaysRepository<B.Pays> _paysService;
        private readonly SessionManager _session;

        //private readonly IOptionsBienRepository<OptionsBien> _optionBienService;
        //private readonly IOptionsRepository<Options> _optionService;

        public BienEchangeController(IBienEchangeRepository<BienEchange> bienService, IPaysRepository<B.Pays> paysService, SessionManager session)
        {
            _bienService = bienService;
            _paysService = paysService;
            _session = session;

        }

        // GET: BienEchangeController

        [Route("BienEchange/ListeBiens")]
        [Route("BienEchange")]

        public IActionResult Index()
        {
            try
            {
                IEnumerable<BienEchangeList> model = _bienService.Get().Select(c => c.ToListItem());
                model = model.Select(m => { m.Pays= _paysService.Get((int)m.idPays).ToDetails(); return m; });
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
        model.ListePays = _paysService.Get((int)model.idPays).ToDetails();
        return View(model);
        }

        // GET: BienEchangeController/Create
        public ActionResult Create()
        {
            if (!_session.IsConnected) return RedirectToAction("Login", "Account");

            BienEchangeCreate model = new BienEchangeCreate();
        
            model.ListePays = _paysService.Get().Select(s => s.ToDetails());
            model.idMembre = 1;

            return View(model);
        }

        // POST: BienEchangeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(BienEchangeCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                BienEchange result = new BienEchange(
                    0,
                    collection.titre,
                    collection.DescCourte,
                    collection.DescLong,
                    collection.NombrePerson,
                    collection.idPays,
                    collection.Ville,
                    collection.Rue,
                    collection.Numero,
                    collection.CodePostal,
                    collection.Photo,
                    collection.AssuranceObligatoire,
                    collection.Latitude,
                    collection.Longitude,
                    collection.idMembre
                    );

                result.idBien = this._bienService.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                collection.ListePays = _paysService.Get().Select(s => s.ToDetails());
                return View(collection);
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
