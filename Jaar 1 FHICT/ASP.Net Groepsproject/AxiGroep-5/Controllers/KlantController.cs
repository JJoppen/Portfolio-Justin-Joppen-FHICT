using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaLaag;
using DAL;
using AxiGroep_5.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AxiGroep_5.HelperClasses;
using LogicaLaag.Winkelmandje;

namespace AxiGroep_5.Controllers
{
    public class KlantController : Controller
    {
        Converter converter = new Converter();
        WinkelmandjeContainer container = new WinkelmandjeContainer(new Winkelmandjemssql());
        ArtikelContainer artikelcontainer = new ArtikelContainer(new ArtikelMSSQL());

        public IActionResult Index()
        {
            List<ArtikelViewModel> list = converter.LijstArtikelNaarArtikelViewModel(artikelcontainer.SelecteerArtikels());
            return View(list);
        }

        public IActionResult ToevoegenAanWinkelmandje(string ArtikelNaam, string Beschrijving, double Prijs, int id)
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            ArtikelViewModel artikel = new ArtikelViewModel(ArtikelNaam, Prijs, Beschrijving, 1, id);
            List<ArtikelViewModel> Winkelmandje = sessionHandler.OphalenWinkelmandje();
            foreach(ArtikelViewModel artikelViewModel in Winkelmandje)
            {
                if(ArtikelNaam == artikelViewModel.Artikelnaam)
                {
                    VerhoogArtikelAantal(ArtikelNaam);
                    return RedirectToAction("index");
                }
            }
            if (Winkelmandje != null)
            {
                Winkelmandje.Add(artikel);
                sessionHandler.ToevoegenWinkelmandje(Winkelmandje);
            }
            return RedirectToAction("index");
        }
        public IActionResult Winkelmandje()
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            List<ArtikelViewModel> WinkelmandjeArtikelen = sessionHandler.OphalenWinkelmandje();
            double Totaalbedrag = 0;
            foreach(ArtikelViewModel artikelViewModel in WinkelmandjeArtikelen)
            {
                artikelViewModel.TotaalPrijs = artikelViewModel.Prijs * artikelViewModel.Aantal;
                Totaalbedrag += artikelViewModel.TotaalPrijs;
            }
            ViewBag.ArtikelTotaal = Totaalbedrag;
            return View("Winkelmandje",WinkelmandjeArtikelen);
        }

        public IActionResult VerhoogArtikelAantal(string Artikel)
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            List<ArtikelViewModel> Winkelmandje = sessionHandler.OphalenWinkelmandje();

            foreach(ArtikelViewModel artikel in Winkelmandje)
            if(artikel.Artikelnaam == Artikel)
                {
                    artikel.Aantal++;

                    artikel.TotaalPrijs = artikel.Aantal * artikel.Prijs;
                }
            sessionHandler.ToevoegenWinkelmandje(Winkelmandje);
            return RedirectToAction("Winkelmandje");
        }

        public IActionResult VerlaagArtikelAantal(string Artikel)
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            List<ArtikelViewModel> Winkelmandje = sessionHandler.OphalenWinkelmandje();

            foreach (ArtikelViewModel artikel in Winkelmandje)
                if (artikel.Artikelnaam == Artikel)
                {
                    artikel.Aantal--;
                    if(artikel.Aantal < 1)
                    {
                        artikel.Aantal = 1;
                    }

                    artikel.TotaalPrijs = artikel.Aantal * artikel.Prijs;
                }
            sessionHandler.ToevoegenWinkelmandje(Winkelmandje);
            return RedirectToAction("Winkelmandje");
        }

        public IActionResult BestelWinkelmandje()
        {
            SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
            List<ArtikelViewModel> Winkelmandje = sessionHandler.OphalenWinkelmandje();
            List<Artikel> artikels = new List<Artikel>();
            int GebruikerID = Convert.ToInt32(HttpContext.Session.GetString("GebruikerID"));
            foreach(ArtikelViewModel artikelViewModel in Winkelmandje)
            {
                artikels.Add(converter.ViewModelArtikelNaarModelVoorBestellen(artikelViewModel));
            }
            container.BestelWinkelmandje(artikels, GebruikerID);
            return View("Ordercompleted");
        }
    }
}
