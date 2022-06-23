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
using M = HoliDayRental.Models;

namespace HoliDayRental.Controllers
{
    public class MembreController : Controller
    {
        private readonly IMembreRepository<Membre> _membreService;
        private readonly IPaysRepository<B.Pays> _paysService;

        public MembreController(IMembreRepository<Membre> membreService, IPaysRepository<B.Pays> paysService)
        {
            _membreService = membreService;
            _paysService = paysService;

        }


        // GET: MembreController

        [Route("Membre/ListeMembre")]
        public IActionResult Index()
        {
            try
            {

                IEnumerable<MembreList> model = _membreService.Get().Select(c => c.ToListItem());
                model = model.Select(m => { m.Pays = _paysService.Get((int)m.idPays).ToDetails(); return m; });
                return View(model);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }


            //public IActionResult ListeMembre()
            //{
            //    try
            //    {
            //        IEnumerable<MembreList> model = _membreService.Get().Select(c => c.ToListItem());
            //        model = model.Select(m => { m.Pays = _paysService.Get((int)m.idPays).ToDetails(); return m; });
            //        return View(model);
            //    }
            //    catch (Exception e)
            //    {
            //        return Json(e);
            //    }
            //}
            // GET: MembreController/Details/5
            public IActionResult Details(int id)
        {
            MembreDetails model = _membreService.Get(id).ToDetails();
            model.Pays = _paysService.Get((int)model.idPays).ToDetails();
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
        // [ValidateAntiForgeryToken]
        public ActionResult Create(MembreCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.CheckCondition) throw new ArgumentException("Merci d'accepter les conditions");
                Membre result = new Membre(
                    0,
                    collection.Nom,
                    collection.Prenom,
                    collection.Email,
                    collection.idPays,
                    collection.Telephone,
                    collection.Login,
                    collection.Password
                );
                result.idMembre = this._membreService.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                collection.ListePays = _paysService.Get().Select(s => s.ToDetails());
                return View(collection);
            }
        }

        // GET: MembreController/Edit/5
        public ActionResult Edit(int id)
        {
            MembreEdit model = this._membreService.Get(id).ToEdit();
            model.ListePays = _paysService.Get().Select(s => s.ToDetails());

            return View(model);
        }

        // POST: MembreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MembreEdit collection)
        {
            Membre result = this._membreService.Get(id);
            try
            {
                if (result is null) throw new Exception("Pas de membre avec cet identifiant");
                if (!(ModelState.IsValid)) throw new Exception();
                //Les tests de validations étant correct, on met à jour l'étudiant 'result' avant l'envoi dans la DB
                result.Nom = collection.Nom;
                result.Prenom = collection.Prenom;
                result.Email = collection.Email;
                result.Pays_Id= collection.idPays;
                result.Telephone = collection.Telephone;
                result.Login = collection.Login;
                if (collection.Password is not null) result.Password = collection.Password;
                this._membreService.Update(id, result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                if (result is null) return RedirectToAction(nameof(Index));
                collection.ListePays = _paysService.Get().Select(s => s.ToDetails());
                return View(result.ToEdit());
            }
        }

        // GET: MembreController/Delete/5
        public ActionResult Delete(int id)
        {
            MembreDelete model = this._membreService.Get(id).ToDelete();
            return View(model);
        }

        // POST: MembreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MembreDelete collection)
        {
            Membre result = this._membreService.Get(id);
            try
            {
                if (result is null) throw new Exception("Pas de membre avec cet identifiant.");
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.Validate) throw new Exception("Action non validée...");
                this._membreService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
