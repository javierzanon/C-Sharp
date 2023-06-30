using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace bpssgestion
{

    [ApiController]
    [Route("[controller]")]
    public class FotoController : Controller
    {
        [HttpGet]
        public IActionResult SubirFoto()
        {
            return View("SubirFoto");
        }
        [Consumes("multipart/form-data")]
        [HttpPost]
        public IActionResult SubirFoto([FromForm] IFormFile formFile)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultadoLogin = herramientas.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return Content("Por favor vuelva a iniciar sesión.");
            else
            {
                try
                {
                    bpsslog log = new bpsslog();
                    
                    if (formFile.Length > 0)
                    {
                        bpssdb configData = new bpssdb();
                        String filePath = configData.dbconfig("FotosPath") + "\\lala.jpg";

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyToAsync(stream);
                        }
                        log.log("Guardada imagen de tamaño: " + formFile.Length.ToString());
                    }
                    
                    return Ok(new { });
                } 
                catch (Exception e)
                {
                    bpsslog log = new bpsslog();
                    log.log(e.ToString());
                    return Content("Se produjo un error.");
                }
            }
        }
    }
}