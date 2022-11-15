using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic_layer;
using DAL.Layer;
using GuitarTabASP.Models;
using GuitarTabASP.ViewModelConverters;
using Microsoft.AspNetCore.Http;
using DAL_laag;

namespace GuitarTabASP.Controllers
{
    public class MuziekNummerController : Controller
    {
        MuziekNummerModelConverter converter = new MuziekNummerModelConverter();
        public IActionResult Index()
        {
            MuziekNummerContainer container = new MuziekNummerContainer(new MuziekNummerDAL());
            List<MuziekNummerViewModel> viewModels = converter.ModelListToViewModelList(container.Selectnummers());
            return View(viewModels);
        }
        public IActionResult CreateNummer()
        {
            if(HttpContext.Session.GetInt32("UserID")!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","User");

            }
        }
        [HttpPost]
        public IActionResult CreateNummer(MuziekNummerViewModel muziekNummerViewModel)
        {
        
                Muzieknummer muzieknummer = converter.ViewmodelToModel(muziekNummerViewModel);
                MuziekNummerContainer muziekNummerContainer = new MuziekNummerContainer(new MuziekNummerDAL());
                muzieknummer.userID = (int)HttpContext.Session.GetInt32("UserID");
                muziekNummerContainer.InsertNummer(muzieknummer);
                return View();
            
        }
        public IActionResult ViewNummer(int id)
        {
            MuziekNummerContainer container = new MuziekNummerContainer(new MuziekNummerDAL());
            MuziekNummerViewModel muziekNummerViewModel = converter.ModelToViewModel(container.SelectNummer(id));
            muziekNummerViewModel.NummerID = id;
            ReactieModelConverter reactieModelConverter = new ReactieModelConverter();
            ReactieContainer reactieContainer = new ReactieContainer(new ReactieDAL());
            List<ReactieViewModel> reactieViewModels = reactieModelConverter.ListModelNaarViewModel(reactieContainer.SelectCommentsVanNummer(id));

            MuziekNummerDetailsMetReacties muziekNummerDetailsMetReacties = new MuziekNummerDetailsMetReacties
            {
                muziekNummerViewModel = muziekNummerViewModel,
                reactieViewModels = reactieViewModels
            };
            return View(muziekNummerDetailsMetReacties);
        }
        public IActionResult AddOrUpdateNummerRating(int rating, int TargetNummerID)
        {

            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                RatingContainer container = new RatingContainer(new RatingDAL());
                Rating userrating = new Rating(rating, TargetNummerID, (int)HttpContext.Session.GetInt32("UserID"), new RatingDAL());

                if (!container.HasUserRatedNummerYet((int)HttpContext.Session.GetInt32("UserID"), TargetNummerID))
                {
                    userrating.InsertNummerRating( new RatingDAL());
                    return RedirectToAction("ViewNummer", "MuziekNummer", new { id = TargetNummerID });
                }
                else
                {
                    userrating.UpdateNummerRating( new RatingDAL());
                    return RedirectToAction("ViewNummer", "MuziekNummer", new { id = TargetNummerID });
                }
            }
            else
            {
                return RedirectToAction("ViewNummer", "MuziekNummer", new { id = TargetNummerID });
            }
        }
        public IActionResult EditNummer(int id)
        {
            if(HttpContext.Session.GetInt32("UserID") !=null)
            {
                MuziekNummerContainer container = new MuziekNummerContainer(new MuziekNummerDAL());
                MuziekNummerViewModel muziekNummerViewModel = converter.ModelToViewModel(container.SelectNummer(id));
                if (muziekNummerViewModel.userid != (int)HttpContext.Session.GetInt32("UserID"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    HttpContext.Session.SetInt32("NummerID", muziekNummerViewModel.NummerID);
                    return View(muziekNummerViewModel);
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }
        [HttpPost]
        public IActionResult EditNummer(MuziekNummerViewModel muziekNummerViewModel)
        {
            muziekNummerViewModel.NummerID = (int)HttpContext.Session.GetInt32("NummerID");
            Muzieknummer muzieknummer = converter.ViewmodelToModel(muziekNummerViewModel);
            MuziekNummerContainer container = new MuziekNummerContainer(new MuziekNummerDAL());
            container.UpdateNummer(muzieknummer);
            return View();
        }
        public IActionResult DeleteNummer(int id)
        {
            if(HttpContext.Session.GetInt32("UserID")!=null)
            {
                MuziekNummerContainer container = new MuziekNummerContainer(new MuziekNummerDAL());
                
                return View();
            }
            else
            {
                return RedirectToAction("Login","User");
            }
        }
        public IActionResult SearchTerm(string zoekterm)
        {
            MuziekNummerContainer cont = new MuziekNummerContainer(new MuziekNummerDAL());
            List<MuziekNummerViewModel> viewModels = converter.ModelListToViewModelList(cont.SelectNummersWithQuery(zoekterm));
            return View("Index", viewModels);
        }
    }
}
