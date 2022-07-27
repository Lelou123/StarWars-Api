using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarwarsAPI.Models;
using StarwarsAPI.Models.Services;
using StarWarsApiCSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StarwarsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {
            GetFilmsService gFilms = new();
            GetCharactersService gCharacter = new();
            GetPlanetService gPlanet = new();
            GetStarshipsService gStarship = new();
            GetVehiclesService getVehicles = new();
            
            await gFilms.Execute();
            await gCharacter.Execute();
            await gPlanet.Execute();
            await gStarship.Execute();
            await getVehicles.Execute();
                        

            var films = gFilms.Films;

            TempData["FilmsCount"] = films.Count;
            TempData["PeopleCount"] = gCharacter.PeopCount;
            TempData["PlanetCount"] = gPlanet.PlanetCount;
            TempData["StarshipsCount"] = gStarship.StarshipsCount;
            TempData["VehiclesCount"] = getVehicles.PlanetCount;

            return View(films);
        }

        
        public async Task<IActionResult> PrivacyAsync()
        {            
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = false)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
