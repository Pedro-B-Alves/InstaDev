using System.Collections.Generic;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller 
    {
        Usuario usuarioModel = new Usuario();
        Publicacao publicacaoModel = new Publicacao();
        
        public IActionResult Perfil()
        {
            var id = HttpContext.Session.GetString("_IdUsuario");
            
            ViewBag.Usuario = usuarioModel.Mostrar(2);
            ViewBag.Publicao = publicacaoModel.ListarPublicacao();
            
            return View();
        }
        //public List<Publicacao> exibirPubli();




    }

}