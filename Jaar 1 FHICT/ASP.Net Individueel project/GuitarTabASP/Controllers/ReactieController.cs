using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabASP.Models;
using Logic_layer;
using GuitarTabASP.ViewModelConverters;
using DAL_laag;
using Microsoft.AspNetCore.Http;


namespace GuitarTabASP.Controllers
{
    public class ReactieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MaakComment(int Id)
        {
            HttpContext.Session.SetInt32("NummerID", Id);
            return View();
        }
        [HttpPost]
        public IActionResult MaakComment(ReactieViewModel reactieViewModel)
        {
            ReactieModelConverter converter = new ReactieModelConverter();
            reactieViewModel.PlaatsTijd = DateTime.Now;
            reactieViewModel.NummerID = (int)HttpContext.Session.GetInt32("NummerID");
            HttpContext.Session.Remove("NummerID");

            Reactie reactie = converter.ViewModelNaarModel(reactieViewModel);
            User user = new User((int)HttpContext.Session.GetInt32("UserID"));
            reactie.user = user;
            reactie.InsertReactie( new ReactieDAL());
            return RedirectToAction("ViewNummer","MuziekNummer",new { id = reactie.NummerID });
        }
        public IActionResult DeleteComment(int id, int nummerid)
        {

            ReactieContainer reactieContainer = new ReactieContainer(new ReactieDAL());
            reactieContainer.DeleteComment(id);
            return RedirectToAction("ViewNummer","MuziekNummer", new { id = nummerid});
        }
    }
}
