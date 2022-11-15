using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiGroep_5.Models;
using LogicaLaag;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace AxiGroep_5.Controllers
{
    [Authorize(Roles = "Manager,Admin,Medewerker")]
    public class ArtikelController : Controller
    {
        public Converter converter = new Converter();
        public IActionResult Index()
        {
            ArtikelContainer container = new ArtikelContainer(new ArtikelMSSQL());
            List<ArtikelViewModel> list = converter.LijstArtikelNaarArtikelViewModel(container.SelecteerArtikels());
            return View(list);
        }
        public IActionResult ArtikelAanmaken()
        {
            ArtikelGroepContainer artikelGroepContainer = new ArtikelGroepContainer(new ArtikelGroepMSSQL());
            List<ArtikelGroepViewModel> artikelGroepViewModelsGeselecteerd = converter.LijstArtikelGroepModelNaarViewModel(artikelGroepContainer.ArtikelGroepBekijken());
            ArtikelAanmakenViewModel artikelAanmakenViewModel = new ArtikelAanmakenViewModel
            {
                artikelGroepViewModels = artikelGroepViewModelsGeselecteerd
            };
            return View(artikelAanmakenViewModel);
        }
        [HttpPost]
        public IActionResult ArtikelAanmaken(ArtikelAanmakenViewModel model)
        {
            ArtikelGroepViewModel artikelGroep = new ArtikelGroepViewModel
            {
                groepID = model.GroepID
            };
            model.artikelViewModel.ArtikelGroepViewmodel = artikelGroep;
            Artikel artikel = converter.ViewModelArtikelNaarModel(model.artikelViewModel);
            artikel.ArtikelAanmaken(artikel, new ArtikelMSSQL());
            return RedirectToAction("index");
        }
        public IActionResult ArtikelAanpassen(int id)
        {
            ArtikelContainer container = new ArtikelContainer(new ArtikelMSSQL());
            ArtikelViewModel artikelViewModelSelected = converter.ModelArtikelNaarViewModel(container.SelecteerArtikel(id));
            ArtikelGroepContainer artikelGroepContainer = new ArtikelGroepContainer(new ArtikelGroepMSSQL());
            List<ArtikelGroepViewModel> artikelGroepViewModelsSelected = converter.LijstArtikelGroepModelNaarViewModel(artikelGroepContainer.ArtikelGroepBekijken());
            ArtikelWijzigenViewmodel artikelWijzigenViewmodel = new ArtikelWijzigenViewmodel
            {
                artikelViewModel = artikelViewModelSelected,
                ArtikelGroepViewModels = artikelGroepViewModelsSelected
            };
            return View(artikelWijzigenViewmodel);
        }
        [HttpPost]
        public IActionResult ArtikelAanpassen(ArtikelWijzigenViewmodel model, int id)
        {
            ArtikelGroepViewModel artikelgroepviewmodel = new ArtikelGroepViewModel
            {
                groepID = model.GroepID
            };
            model.artikelViewModel.ArtikelGroepViewmodel = artikelgroepviewmodel;
            Artikel artikel = converter.ViewModelArtikelNaarModel(model.artikelViewModel);
            artikel.ArtikelID = id;
            artikel.ArtikelUpdaten(artikel, new ArtikelMSSQL());

            return RedirectToAction("index");
        }
        public IActionResult ArtikelDetails(int id)
        {
            ArtikelContainer container = new ArtikelContainer(new ArtikelMSSQL());
            ArtikelViewModel artikelViewModel = converter.ModelArtikelNaarViewModel(container.SelecteerArtikel(id));


            return View(artikelViewModel);
        }
        public IActionResult ArtikelVerwijderen(int id)
        {
            ArtikelContainer container = new ArtikelContainer(new ArtikelMSSQL());
            container.VerwijderArtikel(id);
            return RedirectToAction("index");
        }

    }
}
