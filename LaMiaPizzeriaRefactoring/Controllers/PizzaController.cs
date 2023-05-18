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
    }
}
