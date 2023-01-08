using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
