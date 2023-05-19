using LaMiaPizzeriaRefactoring.Database;
using LaMiaPizzeriaRefactoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeriaRefactoring.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new())
            {
                List<PizzaModel> pizze = db.Pizzas.ToList();
                return View(pizze);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaModel newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newPizza);
            }

            using (PizzaContext db = new())
            {
                db.Pizzas.Add(newPizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new())
            {
                PizzaModel? pizzaDetails = db.Pizzas.Where(PizzaModel => PizzaModel.Id == id).FirstOrDefault();

                if (pizzaDetails != null)
                {
                    return View("Details", pizzaDetails);
                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }
            }

        }
    }
}
