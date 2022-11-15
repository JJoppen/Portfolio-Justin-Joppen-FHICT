using AxiGroep_5.Models;
using DAL;
using LogicaLaag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AxiGroep_5.Controllers
{
    [Authorize(Roles = "Manager,Admin,Medewerker")]
    public class MagazijnController : Controller
    {

        MagazijnContainer container = new MagazijnContainer(new MagazijnMSSQL()); 
        public Converter converter = new Converter();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aanmaken()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Aanmaken(string naam, string straatnaam, int huisnummer, string postcode)
        {
            Magazijn magazijn = new Magazijn(naam, straatnaam, huisnummer, postcode);
            container.Aanmaken(magazijn);
            return View("Index");
        }

        public IActionResult Bewerken(int id)
        {
            MagazijnViewModel magazijnViewModel = converter.ModelMagazijnNaarMagazijnViewModel(container.Uitlezen(id));
            return View("Bewerken",magazijnViewModel);
        }

        [HttpPost]
        public IActionResult Bewerken(MagazijnViewModel model, int id)
        {
            Magazijn magazijn = converter.MagazijnViewModelNaarModel(model);
            magazijn.Id = id;
            bool bewerken = container.Bewerken(magazijn);
            if(bewerken == true)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
