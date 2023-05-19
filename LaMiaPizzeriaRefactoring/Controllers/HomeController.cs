using LaMiaPizzeriaRefactoring.Database;
using LaMiaPizzeriaRefactoring.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaMiaPizzeriaRefactoring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prenota()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Prenota(PrenotazioneModel newBooking)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", newBooking);
            }

            using (PizzaContext db = new())
            {
                db.Prenotazioni.Add(newBooking);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}