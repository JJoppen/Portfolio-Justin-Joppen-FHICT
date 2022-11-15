using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabASP.Models;
using DAL.Layer;
using Logic_layer;
using GuitarTabASP.ViewModelConverters;
using Microsoft.AspNetCore.Http;

namespace GuitarTabASP.Controllers
{
    public class UserController : Controller
    {
        UserModelConverter converter = new UserModelConverter();
        MuziekNummerModelConverter nummerconverter = new MuziekNummerModelConverter();
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("UserID") != null)
            {
                int userID = (int)HttpContext.Session.GetInt32("UserID");
                UserContainer container = new UserContainer(new UserDAL());
                MuziekNummerContainer muziekNummerContainer = new MuziekNummerContainer(new MuziekNummerDAL());
                UserViewModel userViewModel = converter.ModelNaarViewModel(container.UserDetails(userID));
                List<MuziekNummerViewModel> nummers = nummerconverter.ModelListToViewModelList(muziekNummerContainer.SelectNummersWithUserID(userID));
                userViewModel.nummers = nummers;
                return View(userViewModel);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public IActionResult UserDetails(int id)
        {
            UserContainer container = new UserContainer(new UserDAL());
            MuziekNummerContainer muziekNummerContainer = new MuziekNummerContainer(new MuziekNummerDAL());
            UserViewModel userViewModel = converter.ModelNaarViewModel(container.UserDetails(id));
            List<MuziekNummerViewModel> nummers = nummerconverter.ModelListToViewModelList(muziekNummerContainer.SelectNummersWithUserID(id));
            userViewModel.nummers = nummers;
            return View(userViewModel);

        }
        public IActionResult AddOrUpdateUserRating(int rating, int targetUserID)
        {

            if(HttpContext.Session.GetInt32("UserID")!=null)
            {
                RatingContainer container = new RatingContainer(new RatingDAL());
                Rating userrating = new Rating(rating, targetUserID, (int)HttpContext.Session.GetInt32("UserID"), new RatingDAL());
                
                if(!container.HasUserRatedUserYet((int)HttpContext.Session.GetInt32("UserID"),targetUserID))
                {
                    userrating.InsertUserRating(new RatingDAL());
                    return RedirectToAction("UserDetails", "User", new { id = targetUserID });
                }
                else
                {
                    userrating.UpdateUserRating(new RatingDAL());
                    return RedirectToAction("UserDetails", "User", new { id = targetUserID });
                }
            }
            else
            {
                return RedirectToAction("UserDetails","User",new { id = targetUserID });
            }

        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel userViewModel)
        {
            UserContainer container = new UserContainer(new UserDAL());
            User user = converter.ViewModelNaarModel(userViewModel);
            if (container.CompareNewEmail(user))
            {
                ViewBag.response = "Email bestaat al.";
            }
            else
            {
                if (container.CompareNewUsername(user))
                {
                    ViewBag.response = "Gebruikersnaam bestaat al.";
                }
                else
                {

                    user.InsertUser( new UserDAL());
                    ViewBag.response = "Uw account is aangemaakt.";
                }
            }
            return View();


        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserViewModel userViewModel)
        {
            UserContainer container = new UserContainer(new UserDAL());
            User user = converter.ViewModelNaarModel(userViewModel);

            bool Login = container.loginUser(user);
            if(Login == true)
            {
                int id = container.SelectUserID(user);
                HttpContext.Session.SetInt32("UserID", id);
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.response = "Uw logingegevens zijn incorrect.";
                return View();
            }
        }

        public IActionResult Update()
        {
            if(HttpContext.Session.GetInt32("UserID")!= null)
            {
                int id = (int)HttpContext.Session.GetInt32("UserID");
                UserContainer container = new UserContainer(new UserDAL());
                UserViewModel userViewModel = converter.ModelNaarViewModel(container.UserDetails(id));
                userViewModel.userID = (int)HttpContext.Session.GetInt32("UserID");
                return View(userViewModel);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        [HttpPost]
        public IActionResult update(UserViewModel userViewModel)
        {
            UserContainer container = new UserContainer(new UserDAL());
            User user = converter.ViewModelNaarModel(userViewModel);
            user.userID = (int)HttpContext.Session.GetInt32("UserID");
            if (container.CompareNewEmailUpdate(user))
            {
                ViewBag.response = "Email bestaat al.";
            }
            else
            {
                if (container.CompareNewUsernameUpdate(user))
                {
                    ViewBag.response = "Gebruikersnaam bestaat al.";
                }
                else
                {
                    user.UpdateUser(new UserDAL());
                    ViewBag.response = "Uw account is geupdate.";
                }
            }
            return View();
        }

        public IActionResult Uitloggen()
        {
            if(HttpContext.Session.GetInt32("UserID")!= null)
            {
                HttpContext.Session.Remove("UserID");
                return RedirectToAction("Login");

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult AllUsers()
        {
            UserContainer container = new UserContainer(new UserDAL());
            UserModelConverter converter = new UserModelConverter();

            List<User> allusers = container.SelectAllUsers();
            List<UserViewModel> users = converter.AllUserModelsToViewModels(allusers);

            return View(users);
        }
    }
}
