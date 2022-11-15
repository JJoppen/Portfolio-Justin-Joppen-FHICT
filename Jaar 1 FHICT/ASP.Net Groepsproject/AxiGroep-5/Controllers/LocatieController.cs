using AxiGroep_5.Models;
using DAL;
using LogicaLaag.AlleLocaties;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AxiGroep_5.Controllers
{
    public class LocatieController : Controller
    {
        LocatieContainer locatieContainer = new LocatieContainer(new LocatieMSSQL());
        Converter converter = new Converter();

        public IActionResult Index()
        {
            List<Locatie> locaties = locatieContainer.LocatiesOphalen();
            List<LocatieViewModel> viewModels = new List<LocatieViewModel>();
            LocatieViewModel viewModel;
            foreach (Locatie locatie in locaties)
            {
                viewModel = converter.LocatieNaarlocatieViewModel(locatie);
                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }

        public IActionResult LocatiesOpArtikel(int artikelId)
        {
            List<Locatie> locaties = locatieContainer.LocatiesOphalenOpArtikelId(artikelId);
            List<LocatieViewModel> locatieViewModels = new List<LocatieViewModel>();
            LocatieViewModel locatieViewModel = new LocatieViewModel();
            foreach (Locatie locatie in locaties)
            {
                locatieViewModel = new LocatieViewModel
                {
                    LocatieId = locatie.LocatieId,
                    MagazijnId = locatie.MagazijnId,
                    RijNummer = locatie.RijNummer,
                    NiveauId = locatie.NiveauId,
                    PlekId = locatie.PlekId,
                    IsBezet = locatie.IsBezet,
                    AantalInLocatie = locatie.AantalInLocatie
                };
                locatieViewModels.Add(locatieViewModel);
            }
            return View(locatieViewModels);
        }

        public IActionResult LocatieAanmaken()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LocatieAanmaken(LocatieViewModel model)
        {
            Locatie locatie = converter.LocatieViewModelNaarLocatie(model);
            locatieContainer.LocatieAanmaken(locatie, 5, 30);
            return RedirectToAction("Index");
        }

        public IActionResult OrderPickenOverzicht(int bestellingID)
        {

            List<Locatie> locaties = locatieContainer.SelectLaagsteAantalInLocatie(bestellingID);

            List<LocatieViewModel> viewmodels = converter.LijstLocatieModelNaarLijstViewModel(locaties);
            return View(viewmodels);
        }

        public IActionResult Details(int id)
        {
            Locatie locatie = locatieContainer.SelecteerLocatieOpId(id);
            LocatieViewModel model = converter.LocatieNaarlocatieViewModel(locatie);
            return View(model);
        }
    }
}
