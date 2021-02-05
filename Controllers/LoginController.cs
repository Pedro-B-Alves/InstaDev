using System.Collections.Generic;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{

    public class LoginController : Controller
    {
        Usuario usuarioModel = new Usuario();
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> csv = usuarioModel.ReadAllLinesCSV(usuarioModel.PATH);

            var logado = 
            csv.Find(
                x => 
                x.Split(";")[5] == form["Email"] && 
                x.Split(";")[7] == form["Senha"]
            );

            if(logado != null)
            {
                return LocalRedirect("~/Feed");
            }else
            {
                return LocalRedirect("~/");
            }
            
        }
    }
}