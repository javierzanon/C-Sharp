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
    public class FormularioController : Controller
    {
        [Route("Lote")]
        [HttpPost]  
        public IActionResult LoteList([FromForm] Int64 areaId)
        {
            bpsstools herramientasLogin = new bpsstools();
            Boolean resultadoLogin = herramientasLogin.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return Content("Session Timeout");
            else
            {
                try 
                {
                    bpssdblist accesodb = new bpssdblist();
                    List<bpssdb.dblote> lote = new List<bpssdb.dblote>();
                    lote = accesodb.listLote(areaId);
                    bpsstools herramientas = new bpsstools();
                    return Content(herramientas.jsonLote(lote));
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