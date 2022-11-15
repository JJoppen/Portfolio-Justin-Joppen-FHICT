using AxiGroep_5.HelperClasses;
using AxiGroep_5.Models;
using LogicaLaag;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using LogicaLaag.AlleLocaties;

namespace AxiGroep_5.Controllers
{
    [Authorize(Roles = "Manager,Admin,Medewerker")]
    public class LeveringController : Controller
    {
        private readonly string leveringKey = "Levering";
        private readonly string alleArtikelsKey = "alleArtikels";

        public IActionResult Index()
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);

            // Kijk of er een levering bestaat in de sessie, zo niet maak deze aan.
            if (sessionHandler.OphalenArtikelVMList(leveringKey) == null)
            {
                List<ArtikelViewModel> emptyLevering = new List<ArtikelViewModel>();
                sessionHandler.ToevoegenArtikelVMList(emptyLevering, leveringKey);
            }

            ArtikelContainer container = new ArtikelContainer(new ArtikelMSSQL());
            Converter converter = new Converter();

            // Haal alle bestaande artikelen op en voeg ze toe aan de sessie
            List<Artikel> alleArtikels = container.SelecteerArtikels();
            List<ArtikelViewModel> artikelViewModels = converter.LijstArtikelNaarArtikelViewModel(alleArtikels);
            sessionHandler.ToevoegenArtikelVMList(artikelViewModels, alleArtikelsKey);

            // Haal de levering op uit de sessie en geef deze mee aan de ViewBag. 
            List<ArtikelViewModel> levering = sessionHandler.OphalenArtikelVMList(leveringKey);
            ViewBag.Levering = levering;

            return View(artikelViewModels);
        }


        public IActionResult ArtikelToevoegen(int id)
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);

            List<ArtikelViewModel> alleArtikels = sessionHandler.OphalenArtikelVMList(alleArtikelsKey);
            List<ArtikelViewModel> levering = sessionHandler.OphalenArtikelVMList(leveringKey);

            ArtikelViewModel artikel = alleArtikels.First(a => a.ArtikelID == id);

            if (levering != null)
            {
                artikel.Aantal = 1;
                levering.Add(artikel);
                sessionHandler.ToevoegenArtikelVMList(levering, leveringKey);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult LeveringVerwerken()
        {
            // Verwerk alle artikelen in de levering en voeg ze to aan de warehouse database.

            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            List<ArtikelViewModel> huidigeLevering = sessionHandler.OphalenArtikelVMList(leveringKey);
            Converter converter = new Converter();
            List<Artikel> artikels = new List<Artikel>();

            foreach (ArtikelViewModel artikelVM in huidigeLevering)
            {
                Artikel artikel = converter.ViewModelArtikelNaarModel(artikelVM);
                artikels.Add(artikel);
            }

            ArtikelContainer artikelContainer = new ArtikelContainer(new ArtikelMSSQL());
            LocatieContainer locatieContainer = new LocatieContainer(new LocatieMSSQL());

            // Haal het oude aantal van het artikel om het totaal aantal te verhogen met het aantal in de levering.
            foreach (Artikel artikel in artikels)
            {
                //Artikel oudAantalArtikel = artikelContainer.SelecteerArtikel(artikel.ArtikelID);
                //int nieuwAantal = oudAantalArtikel.Aantal + artikel.Aantal;
                //artikel.Aantal = nieuwAantal;
                List<Tuple<Locatie, int>> locaties = locatieContainer.VerdeelArtikel(artikel);

                if (!locatieContainer.ArtikelIndelenOpLocatie(locaties))
                {
                    return View("../Home/Index");
                }
            }
            
            artikelContainer.LeveringToevoegen(artikels);

            // Wanneer de levering is verwerkt, maak de levering leeg. 
            List<ArtikelViewModel> legeLevering = new List<ArtikelViewModel>();
            sessionHandler.ToevoegenArtikelVMList(legeLevering, leveringKey);

            return RedirectToAction("Index");
        }

        public IActionResult verwijderUitLevering(int id)
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            List<ArtikelViewModel> currentLevering = sessionHandler.OphalenArtikelVMList(leveringKey);
            
            // Verwijder het eerste artikel met het aangegeven artikel id uit de levering.
            // Lambda expression gebruikt om het artikel te verwijderen met een id gelijk aan het meegegeven id
            currentLevering.Remove(currentLevering.First(a => a.ArtikelID == id));
            sessionHandler.ToevoegenArtikelVMList(currentLevering, leveringKey);
            
            return RedirectToAction("Index");
        }


        public IActionResult AantalAanpassenPagina(int id)
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            List<ArtikelViewModel> currentLevering = sessionHandler.OphalenArtikelVMList(leveringKey);

            ArtikelViewModel artikel = currentLevering.First(a => a.ArtikelID == id);

            return View(artikel);
        }


        [HttpPost]
        public IActionResult AantalAanpassen(ArtikelViewModel artikel, int id)
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            List<ArtikelViewModel> currentLevering = sessionHandler.OphalenArtikelVMList(leveringKey);

            int artikelIndex = currentLevering.FindIndex(a => a.ArtikelID == id);
            currentLevering[artikelIndex].Aantal = artikel.Aantal;

            sessionHandler.ToevoegenArtikelVMList(currentLevering, leveringKey);

            return RedirectToAction("Index");
        }
    }
}

