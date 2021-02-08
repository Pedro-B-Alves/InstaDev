using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

    }
}