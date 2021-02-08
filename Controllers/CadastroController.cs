using System;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Cadastro")]
    public class CadastroController : Controller
    {
        Usuario usuarioModel = new Usuario();
        public IActionResult Index()
        {
            return View();
        }

        [Route("CadastroDeUsuario")]
        public IActionResult CadastroDeUsuario(IFormCollection form)
        {
            Usuario novoUser            = new Usuario();
            novoUser.IdUsuario          = novoUser.Id();
            novoUser.Nome               = form["Nome"];
            novoUser.Seguidos           = int.Parse("123");
            novoUser.Foto               = "user.png";
            novoUser.Email              = form["Email"];
            novoUser.Username           = form["Username"];
            novoUser.senha              = form["Senha"];

            usuarioModel.Create(novoUser);
            ViewBag.Usuario = usuarioModel.ReadAll();
            
            return LocalRedirect("~/Logar");

        }
        
    }
}