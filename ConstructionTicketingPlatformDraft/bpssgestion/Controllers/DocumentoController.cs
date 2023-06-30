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
    public class DocumentoController : Controller
    {
        [Route("Acceder/{documentoid}")]
        public IActionResult Acceder(Int64 documentoid)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultado = herramientas.LoginGet(HttpContext.Session);
            if (resultado == false)
                return  Redirect("../../Login");
            else
            {
                bpssdbcheck verificarDocumento = new bpssdbcheck();
                if (! verificarDocumento.documentoBloqueado(documentoid))
                {
                    return Descripcion(documentoid);
                }
                else
                {
                    return Estado(documentoid);
                }
            }
        }
        [Route("{documentoid}/Estado")]
        public IActionResult Estado(Int64 documentoid)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultado = herramientas.LoginGet(HttpContext.Session);
            if (resultado == false)
                return  Redirect("../../Login");
            else
            {
                bpssdbparametros.DocumentoDescripcion datos = new bpssdbparametros.DocumentoDescripcion();
                bpssdblist almacenamiento = new bpssdblist();
                bpssdb parametros = new bpssdb();
                datos.documentoExtendido = almacenamiento.DocumentoExtendido(documentoid);
                datos.descripcionesCargadas = almacenamiento.listDocumentoDescripcion(documentoid);
                datos.descripcionesTodas = almacenamiento.listDescripcion();
                ViewBag.parametro = datos;
                // Devuelvo la vista que corresponde según el tipo de documento
                return View(parametros.documentoview(datos.documentoExtendido.documentoTipoId));
            }
        }
        [HttpGet]
        [Route("Busqueda")]
        public IActionResult Busqueda()
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultado = herramientas.LoginGet(HttpContext.Session);
            if (resultado == false)
                return  Redirect("../../Login");
            else
            {
                try
                {
                    bpssdblist dblist = new bpssdblist();
                    List<bpssdb.dbdocumentotipo> ListaDocumentoTipo = new List<bpssdb.dbdocumentotipo>();
                    ListaDocumentoTipo = dblist.listDocumentoTipo();
                    List<bpssdb.dbdocumentoestado> ListaDocumentoEstado = new List<bpssdb.dbdocumentoestado>();
                    ListaDocumentoEstado = dblist.listDocumentoEstado();
                    List<bpssdb.dbarea> ListaArea = new List<bpssdb.dbarea>();
                    ListaArea = dblist.listArea();
                    bpssdbparametros.BuscarDocumento parametro = new bpssdbparametros.BuscarDocumento();
                    List<bpssdb.dblote> ListaLote = new List<bpssdb.dblote>();
                    List<bpssdb.dbusuario> ListaUsuario = new List<bpssdb.dbusuario>();
                    ListaUsuario = dblist.listUsuario();
                    parametro.documentotipo = ListaDocumentoTipo;
                    parametro.documentoestado = ListaDocumentoEstado;
                    parametro.area = ListaArea;
                    parametro.lote = ListaLote;
                    parametro.usuario = ListaUsuario;                    
                    return View(parametro);
                } 
                catch (Exception e)
                {
                    bpsslog log = new bpsslog();
                    log.log(e.ToString());
                    return Content("Se produjo un error.");
                }
            }
        }
        [HttpPost]
        [Route("Lista")]
        public IActionResult Lista([FromForm] Int64 areaid, [FromForm] Int64 loteid, [FromForm] Int64 documentotipoid, [FromForm] Int64 documentoestadoid, [FromForm] DateTime fechainicio, [FromForm] DateTime fechafin, [FromForm] Int64 usuarioid)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultado = herramientas.LoginGet(HttpContext.Session);
            if (resultado == false)
                return  Redirect("../../Login");
            else
            {
                List<bpssdb.dbdocumentoExtendido> listaDocumento = new List<bpssdb.dbdocumentoExtendido>();
                bpssdblist almacenamiento = new bpssdblist();
                listaDocumento = almacenamiento.listDocumentoExtendido(areaid, loteid, documentotipoid, documentoestadoid, fechainicio, fechafin, usuarioid);
                if (listaDocumento != null)
                {
                    ViewBag.listaDocumento = listaDocumento;
                    return View("Lista"); 
                }
                else
                {
                    bpsslog log = new bpsslog();
                    log.log("El modelo de datos listaDocumento ha venido nulo. Esto se debe a algún error durante el procesamiento de esos datos en la base. Por esa razón no se intentará cargar la vista Lista del controller Documento.");
                    return Content("Se ha producido un error.");
                }
                
            }
        }
        [Route("Nuevo")]
        public IActionResult Nuevo()
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultado = herramientas.LoginGet(HttpContext.Session);
            if (resultado == false)
                return  Redirect("../../Login");
            else
            {
                try
                {
                    bpssdblist dblist = new bpssdblist();
                    List<bpssdb.dbdocumentotipo> ListaDocumentoTipo = new List<bpssdb.dbdocumentotipo>();
                    ListaDocumentoTipo = dblist.listDocumentoTipo();
                    List<bpssdb.dbarea> ListaArea = new List<bpssdb.dbarea>();
                    ListaArea = dblist.listArea();
                    bpssdbparametros.NuevoFormulario parametro = new bpssdbparametros.NuevoFormulario();
                    List<bpssdb.dblote> ListaLote = new List<bpssdb.dblote>();
                    ListaLote = dblist.listLote(ListaArea[0].areaid);
                    parametro.area = ListaArea;
                    parametro.documentotipo = ListaDocumentoTipo;
                    parametro.lote = ListaLote;
                    return View(parametro);
                } 
                catch (Exception e)
                {
                    bpsslog log = new bpsslog();
                    log.log(e.ToString());
                    return Content("Se produjo un error.");
                }
            }
        }
        [Route("Bloquear")]
        [HttpPost]  
        public IActionResult BloquearDocumento([FromForm] Int64 documentoId)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultadoLogin = herramientas.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return Content("Session Timeout");
            else
            {
                try
                {
                    bpssdbstorage actuar = new bpssdbstorage();
                    Boolean resultado = actuar.DocumentoBloquear(documentoId);
                    if (resultado == true)
                        return Content("OK");
                    else
                        return Content("Se ha producido un error");
                } 
                catch (Exception e)
                {
                    bpsslog log = new bpsslog();
                    log.log(e.ToString());
                    return Content("Se ha producido un error.");
                }
            }
        }
        [Route("Borrar/Descripcion")]
        [HttpPost]  
        public IActionResult BorrarDocumentoDescripcion([FromForm] Int64 documentoId, [FromForm] Int64 documentoDescripcionId)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultadoLogin = herramientas.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return Content("Session Timeout");
            else
            {
                try
                {
                    bpssdbcheck verificarDocumento = new bpssdbcheck();
                    if (! verificarDocumento.documentoBloqueado(documentoId))
                    {
                        bpssdbstorage actuar = new bpssdbstorage();
                        bpssdb.dbdocumentodescripcion documentoDescripcion = new bpssdb.dbdocumentodescripcion();
                        documentoDescripcion.documentoId = documentoId;
                        documentoDescripcion.documentoDescripcionId = documentoDescripcionId;
                        Int64 resultado = actuar.DocumentoDescripcionBorrar(documentoDescripcion);
                        if (resultado == 1)
                            return Content("OK");
                        else if (resultado == 0)
                            return Content("El documento se encuentra bloqueado para la edición de sus detalles.");
                        else if (resultado == -1)
                            return Content("Se ha producido un error.");
                        else 
                            return Content("Se ha producido un error.");
                    }
                    else
                    {
                        return Content("El documento se encuentra bloqueado para la edición de sus detalles.");
                    } 
                } 
                catch (Exception e)
                {
                    bpsslog log = new bpsslog();
                    log.log(e.ToString());
                    return Content("Se ha producido un error.");
                }
            }
        }
        [Route("Agregar/Descripcion")]
        [HttpPost]  
        public IActionResult AgregarDocumentoDescripcion([FromForm] Int64 documentoId, [FromForm] Int64 documentoDescripcionId, [FromForm] String documentoDescripcionNotas)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultadoLogin = herramientas.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return Content("Session Timeout");
            else
            {
                try
                {
                    bpssdbstorage actuar = new bpssdbstorage();
                    bpssdb.dbdocumentodescripcion documentoDescripcion = new bpssdb.dbdocumentodescripcion();
                    documentoDescripcion.documentoId = documentoId;
                    documentoDescripcion.documentoDescripcionId = documentoDescripcionId;
                    documentoDescripcion.documentoDescripcionNotas = documentoDescripcionNotas;
                    String resultado = actuar.DocumentoDescripcionAgregar(documentoDescripcion);
                    if (resultado == "-1")
                        return Content("La descripción elegida ya ha sido agregada con anterioridad. No puede volver a agegarse.");
                    else if (resultado == "-2")
                        return Content("El documento se encuentra bloqueado para la edición de sus detalles.");
                    else if (resultado == "-3")
                        return Content("Se ha producido un error.");
                    else 
                        //El resultado no es necesario realmente, el stored procedure igual devuelve los datos por si son necesarios en el futuro
                        //return Content(resultado);
                        return Content("OK");
                }       
                catch (Exception e)
                {
                    bpsslog log = new bpsslog();
                    log.log(e.ToString());
                    return Content("Se ha producido un error.");
                }
            }
        }
        [Route("Agregar/Documento")]
        [HttpPost]  
        public IActionResult AgregarDocumento([FromForm] Int64 DocumentoTipo, [FromForm] Int64 UbicacionArea, [FromForm] Int64 UbicacionLote)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultadoLogin = herramientas.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return Content("Session Timeout");
            else
            {
                try 
                {
                    bpssdblist accesodb = new bpssdblist();
                    bpssdb.dbdocumento documento = new bpssdb.dbdocumento();
                    bpssdbstorage guardarDatos = new bpssdbstorage();
                    Int64 documentoId = 0;
                    documento.documentoTipo = DocumentoTipo;
                    documento.area = UbicacionArea;
                    documento.lote = UbicacionLote;
                    documento.fecha = DateTime.Now;
                    documento.bloqueado = 0;
                    documento.documentoEstado = 1;
                    documento.documentoId = 0;
                    documento.accionfecha = DateTime.Now;
                    documento.accionusuarioid = 0;
                    documentoId = guardarDatos.DocumentoAgregar(documento);
                    return Content(documentoId.ToString());
                } 
                catch (Exception e)
                {
                    bpsslog log = new bpsslog();
                    log.log(e.ToString());
                    return Content("Se produjo un error.");
                }
            }
        }
        [Route("{documentoid}/Descripcion")]
        [HttpGet]
        public IActionResult Descripcion (Int64 documentoid)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultadoLogin = herramientas.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return  Redirect("../../Login");
            else
            {
                try
                {
                    bpssdbcheck verificarDocumento = new bpssdbcheck();
                    if (! verificarDocumento.documentoBloqueado(documentoid))
                    {
                        bpssdbparametros.DocumentoDescripcion datos = new bpssdbparametros.DocumentoDescripcion();
                        bpssdblist almacenamiento = new bpssdblist();
                        datos.documentoExtendido = almacenamiento.DocumentoExtendido(documentoid);
                        datos.descripcionesCargadas = almacenamiento.listDocumentoDescripcion(documentoid);
                        datos.descripcionesTodas = almacenamiento.listDescripcion();
                        ViewBag.parametro = datos;
                        return View("Descripcion");
                    }
                    else
                    {
                        return Content("El documento se encuentra bloqueado para la edición de sus detalles.");
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
        [Route("{documentoid}/Imagen")]
        [HttpGet]
        public IActionResult Imagen (Int64 documentoid)
        {
            bpsstools herramientas = new bpsstools();
            Boolean resultadoLogin = herramientas.LoginGet(HttpContext.Session);
            if (resultadoLogin == false)
                return  Redirect("../../Login");
            else
            {
                try
                {
                    bpssdbcheck verificarDocumento = new bpssdbcheck();
                    if (! verificarDocumento.documentoBloqueado(documentoid))
                    {
                        bpssdbparametros.DocumentoDescripcion datos = new bpssdbparametros.DocumentoDescripcion();
                        bpssdblist almacenamiento = new bpssdblist();
                        datos.documentoExtendido = almacenamiento.DocumentoExtendido(documentoid);
                        datos.descripcionesCargadas = almacenamiento.listDocumentoDescripcion(documentoid);
                        datos.descripcionesTodas = almacenamiento.listDescripcion();
                        ViewBag.parametro = datos;
                        return View("Imagen");
                    }
                    else
                    {
                        return Content("El documento se encuentra bloqueado para la edición de sus detalles.");
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