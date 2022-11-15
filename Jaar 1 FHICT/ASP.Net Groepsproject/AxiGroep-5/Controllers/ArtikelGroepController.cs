using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaLaag;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace AxiGroep_5.Controllers
{
    [Authorize(Roles = "Manager,Admin,Medewerker")]
    public class ArtikelGroepController : Controller
    {
        ArtikelGroepContainer artikelgroep = new ArtikelGroepContainer(new ArtikelGroepMSSQL());

        // GET: ArtikelGroepController
        public ActionResult Index()
        {
            return View(artikelgroep.ArtikelGroepBekijken());
        }

        // GET: ArtikelGroepController/Details/5
        public ActionResult Details(int id)
        {
            ArtikelGroep eenartikelgroep = artikelgroep.ArtikelGroepDetails(id);

            return View(eenartikelgroep);
        }

        // GET: ArtikelGroepController/Create
        public ActionResult Aanmaken()
        {
            return View();
        }

        // POST: ArtikelGroepController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NaAanmaken(string naam, string beschrijving)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            ArtikelGroep artikelgroepmaken = new ArtikelGroep(naam, beschrijving);
            artikelgroep.ArtikelGroepAanmaken(artikelgroepmaken);
            return RedirectToAction("Index");
        }

        // POST: ArtikelGroepController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, string naam, string beschrijving)
        {
            ArtikelGroep artikelgroepupdate = new ArtikelGroep(id, naam, beschrijving);
            artikelgroep.ArtikelGroepUpdaten(artikelgroepupdate);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateFormulier(int id)
        {
            ArtikelGroep eenartikelgroep = artikelgroep.ArtikelGroepDetails(id);

            return View("Update", eenartikelgroep);
        }

        // GET: ArtikelGroepController/Delete/5
        public ActionResult Verwijderen(int id)
        {
            artikelgroep.ArtikelGroepVerwijderen(id);
            return RedirectToAction("Index");
        }

        // POST: ArtikelGroepController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Verwijderen(int id, IFormCollection collection)
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
