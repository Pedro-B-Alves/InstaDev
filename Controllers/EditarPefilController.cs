using System;
using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Usuario")]

    public class EditarPefilController : Controller
    {
        Usuario usuarioModel = new Usuario();

        [Route("Editar")]
        public IActionResult Update(Usuario a){
            
            usuarioModel.Update(a);
            ViewBag.usuario = usuarioModel.ReadAll();

            return LocalRedirect("~/Usuario");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id){

            usuarioModel.Deletar(id);
            
            return LocalRedirect("~/Login");
        }

    }
}