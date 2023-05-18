using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeriaRefactoring.Controllers
{
    public class GestoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
