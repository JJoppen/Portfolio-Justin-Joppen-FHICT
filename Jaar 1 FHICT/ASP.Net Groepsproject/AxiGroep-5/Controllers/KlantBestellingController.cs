using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiGroep_5.Models;
using LogicaLaag.KlantBestelling;
using DAL;
using Microsoft.AspNetCore.Authorization;
using LogicaLaag.AlleLocaties;

namespace AxiGroep_5.Controllers
{
    [Authorize(Roles = "Manager,Admin,Medewerker")]
    public class KlantBestellingController : Controller
    {
        KlantBestellingContainer container = new KlantBestellingContainer(new KlantBestellingMSSQL());
        LocatieContainer locatieContainer = new LocatieContainer(new LocatieMSSQL());
        public Converter converter = new Converter();

        public IActionResult Index()
        {
            List<KlantBestellingModel> klantBestellingen = converter.KlantBestellingNaarKlantBestellingModel(container.GetKlantBestellingen());
            return View("KlantBestellingOverzicht", klantBestellingen);
        }
        public IActionResult KlantBestellingDetails(int bestellingid)
        {
            List<KlantBestellingModel> klantBestellingen = converter.KlantBestellingNaarKlantBestellingModel(container.GetBestellingDetails(bestellingid));
            return View("KlantBestellingDetails", klantBestellingen);
        }
        public IActionResult OrderPickenOverzicht(int bestellingid)
        {

            return RedirectToAction("OrderPickenOverzicht", new { controller = "Locatie", Action = "OrderPickenOverzicht", bestellingid = bestellingid });
        }

        public IActionResult BestellingAfronden(int bestellingid)
        {
            List<KlantBestelling> klantBestellingen = container.GetBestellingDetails(bestellingid);
            List<Tuple<Locatie, int>> locatiesMetAantal = new List<Tuple<Locatie, int>>();
            List<int> artikelIDs = new List<int>();
            foreach (KlantBestelling klantBestelling in klantBestellingen)
            {
                artikelIDs.Add(klantBestelling.BesteldeArtikelID);
            }
            List<Locatie> locaties = locatieContainer.SelectLaagsteAantalInLocatie(bestellingid);
            foreach (Locatie locatie in locaties)
            {
                foreach (KlantBestelling bestelling in klantBestellingen)
                {
                    if(locatie.ArtikelId == bestelling.BesteldeArtikelID)
                    {
                        Tuple<Locatie, int> tuple = new Tuple<Locatie, int>(locatieContainer.SelecteerLocatieOpId(locatie.LocatieId), locatie.AantalInLocatie);
                        locatiesMetAantal.Add(tuple);
                    }
                }
            }
            if (!locatieContainer.VoorraadBijwerkenNaBestelling(locatiesMetAantal))
            {
                return RedirectToAction();
            }
            container.BestellingAfronden(bestellingid);
            return RedirectToAction("Index");
        }

        public IActionResult DrieOudsteBestellingen()
        {

            List<KlantBestellingModel> klantBestellingModels = new List<KlantBestellingModel>();
            List<KlantBestellingModel> klantBestellingen = converter.KlantBestellingNaarKlantBestellingModel(container.GetKlantBestellingen());
            for (int i = 0; i < 3; i++)
            {
                klantBestellingModels.Add(klantBestellingen[i]);
            }
            return View("MedewerkerDashboard", klantBestellingModels);
        }
    }
}
