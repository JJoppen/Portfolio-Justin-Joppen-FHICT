using AxiGroep_5.Models;
using DAL;
using LogicaLaag;
using LogicaLaag.AlleLocaties;
using LogicaLaag.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AxiGroep_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Data data = new Data(new DataMSSQL());
        MagazijnContainer magazijn = new MagazijnContainer(new MagazijnMSSQL());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminManagerDashboard()
        {
            DataViewModel viewmodel = new DataViewModel();
            viewmodel.DataIEnum = data.AantalPerProductDezeMaand();
            viewmodel.DataIEnum2 = data.DataDezeMaand();
            viewmodel.Percentage = magazijn.VulPercentage();
            return View("AdminManagerDashboard", viewmodel);
        }

        public IActionResult MedewerkerDashboard()
        {

            return View("MedewerkerDashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
