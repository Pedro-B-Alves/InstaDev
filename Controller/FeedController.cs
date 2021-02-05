using Microsoft.AspNetCore.Mvc;
using InstaDev.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace InstaDev.Controllers
{
    [Route ("Feed")]
    public class FeedController : Controller
    {
        Publicacao PublicacaoFeed = new Publicacao();
        Usuario UsuarioModel = new Usuario();
        Comentario ComentarioFeed = new Comentario();

        public int Count { get; }

        public IActionResult Index()
        {
            ViewBag.AllPubli = PublicacaoFeed.ListarPublicacao();
            ViewBag.AllUser = UsuarioModel.ReadAll();
            ViewBag.AllComent = ComentarioFeed.LerComentario();
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
            novaPublicao.IdUsuario = 1;
            novaPublicao.Likes = 0;
            if(form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagem/ImgPublicacao");

                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagem/", folder, file.FileName);
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                novaPublicao.Imagem = file.FileName;
            }else{
                novaPublicao.Imagem = "padrao.png";
            }

            Console.WriteLine($"publicacao+{novaPublicao.Legenda}");

            PublicacaoFeed.CriarPublicacao(novaPublicao);
            ViewBag.AllPubli = PublicacaoFeed.ListarPublicacao();

            return LocalRedirect("~/Feed");
        }

        [Route("Comentar")]
        public IActionResult Comentar (IFormCollection form)
        {
            Publicacao novaPublicao = new Publicacao();
            Comentario novoComentario = new Comentario();
            novoComentario.Mensagem = form["Mensagem"];
            novoComentario.IdComentario = ComentarioFeed.LerComentario().Count +1;
            novoComentario.IdPublicacao = novaPublicao.IdPublicacao;
            novoComentario.IdUsuario = int.Parse(HttpContext.Session.GetString("_IdUsuario"));

            ComentarioFeed.CriarComentario(novoComentario);
            ViewBag.AllComent = ComentarioFeed.LerComentario();
            return LocalRedirect("~/Feed");
        }

        // public IActionResult AllPubli ()
        // {
        //     ViewBag.AllPubli = PublicacaoFeed.ListarPublicacao();
        //     return View();
        // }

    }
} 