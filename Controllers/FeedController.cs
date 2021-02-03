using Microsoft.AspNetCore.Mvc;
using InstaDev.Models;
using System.Collections.Generic;

namespace InstaDev.Controllers
{
    [Route ("Feed")]
    public class FeedController : Controller
    {
        List<Publicacao> publicacoes = new List<Publicacao>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ()
        {
            ViewBag.AllPubli = publicacoes.ReadAll();
        }
    }
}