using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller 
    {
        Usuario usuarioModel = new Usuario();
        public IActionResult Perfil()
        {
            //HttpContext.Session.GetString("_IdUsuario");
            //ViewBag.Usuario = usuarioModel.Mostrar();
            
            return View();
        }
    }
}