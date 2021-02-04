using Microsoft.AspNetCore.Mvc;
using InstaDev.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace InstaDev.Controllers
{
    [Route ("Feed")]
    public class FeedController : Controller
    {
        Publicacao PublicacaoFeed = new Publicacao();
        Usuario UsuarioController = new Usuario();

        public int Count { get; }

        public IActionResult Index()
        {
            ViewBag.AllPubli = PublicacaoFeed.ListarPublicacao();
            ViewBag.AllUser = UsuarioController.ReadAll();
            return View();
        } 
        
        // public IActionResult AllUser()
        // {
        //     ViewBag.AllUser = UsuarioController.ReadAll();
        //     return View();
        // }
        [Route("Postar")]
        public IActionResult Postar (IFormCollection form)
        {
            Publicacao novaPublicao = new Publicacao();
            novaPublicao.Legenda = form["Descrição da imagem"];
            novaPublicao.IdPublicacao = PublicacaoFeed.ListarPublicacao().Count +1; 
            novaPublicao.IdUsuario = int.Parse(HttpContext.Session.GetString("_IdUsuario"));

            return View();
        }

        // public IActionResult AllPubli ()
        // {
        //     ViewBag.AllPubli = PublicacaoFeed.ListarPublicacao();
        //     return View();
        // }

    }
} 