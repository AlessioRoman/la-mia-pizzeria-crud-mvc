using LaMiaPizzeriaRefactoring.Database;
using LaMiaPizzeriaRefactoring.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            using (PizzaContext db = new())
            {
                List<CategoryModel> categories = db.Categories.ToList();
                PizzaFormModel model = new();
                model.Pizza = new PizzaModel();
                model.Categories = categories;

                return View("Create", model);
            }
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
                PizzaModel? pizzaDetails = db.Pizzas.Where(PizzaModel => PizzaModel.Id == id)
                    .Include(PizzaModel => PizzaModel.Category).FirstOrDefault();

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

        public IActionResult Manage()
        {
            using (PizzaContext db = new())
            {
                List<PizzaModel> pizze = db.Pizzas.ToList();
                return View(pizze);
            }
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new())
            {
                PizzaModel? pizzaToEdit = db.Pizzas.Where(PizzaModel => PizzaModel.Id == id).FirstOrDefault();

                if (pizzaToEdit != null)
                {
                    List<CategoryModel> categories = db.Categories.ToList();
                    PizzaFormModel model = new();
                    model.Pizza = pizzaToEdit;
                    model.Categories = categories;

                    return View("Update", model);
                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaModel modifiedPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modifiedPizza);
            }

            using (PizzaContext db = new())
            {
                PizzaModel? pizzaToModify = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {

                    pizzaToModify.Name = pizzaToModify.Name;
                    pizzaToModify.Description = pizzaToModify.Description;
                    pizzaToModify.ImageUrl = pizzaToModify.ImageUrl;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("L'articolo da modificare non esiste!");
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (PizzaContext db = new())
            {
                PizzaModel? pizzaToDelete = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("Non ho torvato l'articolo da eliminare");

                }
            }
        }
    }
}
