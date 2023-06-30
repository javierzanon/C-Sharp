using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace bpssgestion
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [Route("/")]
        public IActionResult defaultPage()
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultado = herramientas.LoginGet(HttpContext.Session);
            if (resultado == true)
                return  Redirect("../Documento/Busqueda");
            else 
                return View("login");
        }

        [HttpGet]
        [Route("")]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult loginSet([FromForm] String usuario, [FromForm] String clave)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultado = herramientas.LoginSet(HttpContext.Session, usuario, clave);
            if (resultado == true)
                return Content("OK");
            else
                return Content("NO");
        }

        [Route("check")]
        public IActionResult loginCheck()
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultado = herramientas.LoginGet(HttpContext.Session);
            if (resultado == true)
                return Content("OK");
            else 
                return Content("NO");
        }
    }
}