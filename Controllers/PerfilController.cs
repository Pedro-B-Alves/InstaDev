using System.Collections.Generic;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Perfil-@viewBag.Usuario.Username")]
    public class PerfilController : Controller 
    {
        Usuario usuarioModel = new Usuario();
        Publicacao publicacaoModel = new Publicacao();
        public IActionResult Perfil()
        {
            
            var id = int.Parse(HttpContext.Session.GetString("_IdUsuario"));
            
            ViewBag.Usuario = usuarioModel.Mostrar(id);
            ViewBag.Publicao = publicacaoModel.ListarPublicacao();
            
            return View();
        }




    }

}