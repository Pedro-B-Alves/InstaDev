using System;
using System.Collections.Generic;
using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("EditarPerfil")]

    public class EditarPefilController : Controller
    {
        Usuario usuarioModel = new Usuario();

        public IActionResult editarPerfil()
        {
            var id = HttpContext.Session.GetString("_IdUsuario");
            ViewBag.Usuario = usuarioModel.Mostrar(int.Parse(id));

            return View();
        }

        // [Route("EditarPerfilUser")]
        // public IActionResult Update(IFormCollection form){
            
        //     //usuarioModel.Update(a);
        //     //ViewBag.usuario = usuarioModel;

        //     Usuario novoUsuario = new Usuario();
        //     novoUsuario.Nome = form["Nome"];
        //     novoUsuario.Foto = form["Foto"];
            
        //     if(form.Files.Count > 0){

        //         var file = form.Files[0];
        //         var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/perfil");

        //         if(!Directory.Exists(folder))
        //         {
        //             Directory.CreateDirectory(folder);
        //         }

        //         var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", folder, file.FileName);

        //         using(var stream = new FileStream(path, FileMode.Create))
        //         {
        //             file.CopyTo(stream);
        //         }
                
        //         novoUsuario.Foto = file.FileName;           
        //     }

        //     novoUsuario.Email = form["Email"];
        //     novoUsuario.Username = form["Username"];
            
        //     usuarioModel.Update(novoUsuario);

        //     ViewBag.UsuarioAtualizado = novoUsuario;

        //     return LocalRedirect("~/EditarPerfil");
        // }

        [Route("{id}")]
        public IActionResult Excluir(int id){

            usuarioModel.Deletar(id);
            
            return LocalRedirect("~/Login");
        }

    }
}