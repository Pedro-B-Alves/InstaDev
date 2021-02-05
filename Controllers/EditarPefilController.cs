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

        [Route("EditarPerfilUser")]
        public IActionResult Update(Usuario a){
            
            usuarioModel.Update(a);
            ViewBag.usuario = usuarioModel;

            Usuario novoUsuario = MostrarUsuario();
            novoUsuario.Nome = Form["Nome"];
            novoUsuario.Foto = Form["Foto"];
            
            if(Form.Files.Count > 0){

                var file = Form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/perfil");

                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", folder, file.FileName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                
                novoUsuario.Foto = file.FileName;           
            }

            // novoUsuario.DataNascimento = DateTime.Parse(form["DataNascimento"]);
            novoUsuario.Email = Form["Email"];
            novoUsuario.Username = Form["Username"];
            
            usuarioModel.Update(novoUsuario);

            ViewBag.UsuarioAtualizado = novoUsuario;

            return LocalRedirect("~/EditarPerfil");
        }

        //     return LocalRedirect("~/EditarPerfil");
        // }

        [Route("{id}")]
        public IActionResult Excluir(int id){

            usuarioModel.Deletar(id);
            
            return LocalRedirect("~/Login");
        }

    }
}