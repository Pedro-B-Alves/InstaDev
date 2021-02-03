using Microsoft.AspNetCore.Mvc;
using InstaDev.Models;
using System.Collections.Generic;

namespace InstaDev.Controllers
{
    [Route ("Feed")]
    public class FeedController : Controller
    {
        Publicacao PublicacaoFeed = new Publicacao();

        public ActionResult Index ()
        {
            ViewBag.AllPubli = PublicacaoFeed.ListarPublicacao();
            return View();
        }
    }
} 