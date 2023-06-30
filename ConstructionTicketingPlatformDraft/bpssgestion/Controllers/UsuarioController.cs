using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bpssgestion
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet]  
        public IActionResult UsuarioList()
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultadoLogin = herramientas.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return  Redirect("../../Login");
            else
            {
                try 
                {
                    bpssdb.dbusuario apidata = new bpssdb.dbusuario();
                    // cargo una variable con los datos en blanco
                    apidata.usuarioid = 0;
                    apidata.usuario = "";
                    apidata.clave = "";
                    apidata.accionidusuario = 0;
                    // Como datetime no se puede enviar null al mssql uso esta fecha como fecha null
                    apidata.accionfecha = new DateTime(1945, 09, 02, 0,0,0);
                    bpssdblist dblist = new bpssdblist();
                    List<bpssdb.dbusuario> dbresult = dblist.getUsuario (apidata);
                    if (dbresult != null)
                        return View(dbresult);
                    else    
                    {
                        List<bpssdb.dbusuario> nulldata = new List<bpssdb.dbusuario>();
                        nulldata.Add (new bpssdb.dbusuario { usuarioid = null,  usuario = null,  clave = null, accionidusuario = null, accionfecha = null });
                        return View(nulldata);
                    }
                        
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