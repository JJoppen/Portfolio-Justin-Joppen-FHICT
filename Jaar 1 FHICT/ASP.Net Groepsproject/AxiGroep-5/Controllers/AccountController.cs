using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiGroep_5.Models;
using LogicaLaag;
using DAL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using LogicaLaag.Login;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using AxiGroep_5.HelperClasses;

namespace AxiGroep_5.Controllers
{
    public class AccountController : Controller
    {
        GebruikerContainer gebruikerContainer = new GebruikerContainer(new LoginMSSQL());
       
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login(AccountViewModel gebruiker)
        {
            Gebruiker gebruiker1 = new Gebruiker(gebruiker.Email, gebruiker.Password);
            var ID = gebruikerContainer.LoginGebruiker(gebruiker1);
            if (ID != 0)
            {
                int PriorityLevel = gebruikerContainer.GetGebruikerPriorityLevel(ID);
                HttpContext.Session.SetString("GebruikerID",Convert.ToString(ID));
                HttpContext.Session.SetString("PriorityLevel", Convert.ToString(PriorityLevel));
                ClaimsIdentity Identity = null;
                bool IsAuthenticate = false;
                if(PriorityLevel == 1)
                {
                    Identity = new ClaimsIdentity(new[]{
                            new Claim(ClaimTypes.Name,gebruiker.Email),
                            new Claim(ClaimTypes.Role,"Klant")
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuthenticate = true;

                    SessieBehandelaar sessionHandler = new SessieBehandelaar(HttpContext);
                    List<ArtikelViewModel> leegWinkelmandje = new List<ArtikelViewModel>();
                    sessionHandler.ToevoegenWinkelmandje(leegWinkelmandje);
                } 
                else if(PriorityLevel == 2)
                {
                    Identity = new ClaimsIdentity(new[]{
                            new Claim(ClaimTypes.Name,gebruiker.Email),
                            new Claim(ClaimTypes.Role,"Medewerker")
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuthenticate = true;
                } 
                else if(PriorityLevel == 3)
                {
                    Identity = new ClaimsIdentity(new[]{
                            new Claim(ClaimTypes.Name,gebruiker.Email),
                            new Claim(ClaimTypes.Role,"Manager")
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuthenticate = true;
                }
                else
                {
                    Identity = new ClaimsIdentity(new[]{
                            new Claim(ClaimTypes.Name,gebruiker.Email),
                            new Claim(ClaimTypes.Role,"Admin")
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuthenticate = true;
                }

                if (IsAuthenticate)
                {
                    var principal = new ClaimsPrincipal(Identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    if (PriorityLevel == 1) 
                    {
                        return RedirectToAction("Index", "Klant");
                    }
                    else if(PriorityLevel == 3 || PriorityLevel == 4)
                    {
                        return RedirectToAction("AdminManagerDashboard", "Home");
                    } else if(PriorityLevel == 2)
                    {
                        return RedirectToAction("DrieOudsteBestellingen", "KlantBestelling");
                    }
                }  
             return View("../artikel/ArtikelAanmaken");
            }
            ViewBag.ErrorMessage = "Error, Please try again";
            return View("../Home/Index");
        }

        [Authorize(Roles = "Manager,Admin,Medewerker,Klant")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            
            return View("../Home/Index");
        }
    }
}
