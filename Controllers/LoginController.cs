using InstaDev.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{

    public class LoginController : Controller
    {
        Login LoginModel = new Login();
        public IActionResult Index()
        {
            return View();
        }
    }
}