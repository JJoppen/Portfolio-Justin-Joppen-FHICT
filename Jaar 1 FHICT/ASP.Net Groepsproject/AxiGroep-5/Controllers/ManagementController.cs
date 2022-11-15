using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiGroep_5.Models;
using LogicaLaag;
using DAL;
using LogicaLaag.Management;
using InterfaceLaag.IDal;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace AxiGroep_5.Controllers
{
    [Authorize(Roles = "Manager,Admin")]
    public class ManagementController : Controller
    {
        public Converter converter = new Converter();

        public IActionResult Index()
        {
            ManagementContainer container = new ManagementContainer(new ManagementMSSQL());
            List<ManagementViewModel> list = converter.LijstManagementNaarManagementViewModel(container.SelecteerAccounts());
            return View(list);
        }

        public IActionResult Wijzigen(int id, string email, string password, int prioritylevel)
        {
            ManagementViewModel managementViewModel = new ManagementViewModel { id = id, Email = email, Password = password, PriorityLevel = prioritylevel };
            return View("Wijzigen", managementViewModel);
        }

        public IActionResult AccountWijzigen(int id, string email, string password, int prioritylevel)
        {
            ManagementContainer container = new ManagementContainer(new ManagementMSSQL());
            Management management = new Management(id, email, password, prioritylevel);
            ManagementViewModel managementViewModel = new ManagementViewModel { id = id, Email = email, Password = password, PriorityLevel = prioritylevel };

            if (container.AccountWijzigen(management) == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Wijzigen", managementViewModel);
            }
        }

        public IActionResult Verwijderen(int id, string email, string password, int prioritylevel)
        {
            ManagementContainer container = new ManagementContainer(new ManagementMSSQL());
            Management management = new Management(id, email, password, prioritylevel);
            container.VerwijderAccount(management);
            return RedirectToAction("Index");
        }
    }
}
