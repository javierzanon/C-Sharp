#pragma checksum "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef4d491a765ba36a17660cbb93cd5429aea9a4c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Documento_EstadoActa), @"mvc.1.0.view", @"/Views/Documento/EstadoActa.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef4d491a765ba36a17660cbb93cd5429aea9a4c1", @"/Views/Documento/EstadoActa.cshtml")]
    public class Views_Documento_EstadoActa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!doctype html>\r\n<html lang=\"es\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef4d491a765ba36a17660cbb93cd5429aea9a4c12771", async() => {
                WriteLiteral(@"
    <!-- Required meta tags -->
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">

    <!-- Bootstrap CSS -->
    <link rel=""stylesheet"" href=""../../../css/bootstrap.min.css"">

    <title>Descripción de Documento</title>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef4d491a765ba36a17660cbb93cd5429aea9a4c14043", async() => {
                WriteLiteral("\r\n  <dd class=\"col-sm-10\">\r\n      <p class=\"lead text-muted\" style=\"text-align: center\">\r\n        <b>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
      Write(ViewBag.parametro.documentoExtendido.documentoTipo);

#line default
#line hidden
#nullable disable
                WriteLiteral(" nº <i>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                                                Write(ViewBag.parametro.documentoExtendido.documentoId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</i> | Lote <i>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                                                                                                                Write(ViewBag.parametro.documentoExtendido.lote);

#line default
#line hidden
#nullable disable
                WriteLiteral("</i> Área <i>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                                                                                                                                                                       Write(ViewBag.parametro.documentoExtendido.area);

#line default
#line hidden
#nullable disable
                WriteLiteral("</i> | Creada el <i>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                                                                                                                                                                                                                                     Write(ViewBag.parametro.documentoExtendido.fecha);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</i></b>
      </p>
      <hr>
  </div>
    <main role=""main"">
          Estimados, se informa acta por irregularidades
          <br>
          Las faltas constatadas deberán ser resueltas dentro del plazo máximo de 48 hs., bajo apercibimiento de la paralización de la obra y la aplicación de las multas que puedan resultar corresponder. 
          <br>
          En caso de no haber respuesta las multas se incrementarán según reglamento. 
          <br>
          Sin perjuicio de la presente notificación e intimación, quedamos a su disposición para aclarar cualquier consulta al respecto.
          <br>
    <dd class=""col-sm-10"">    
        <p style=""text-align: center"">
            <table class=""table"" name=""tableListadoDescripcionCargada"" id=""tableListadoDescripcionCargada"">
");
#nullable restore
#line 32 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
               foreach (var dato in ViewBag.parametro.descripcionesCargadas)
              {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 36 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                       Write(dato.documentoDescripcion);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 39 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                       Write(dato.documentoDescripcionNotas);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 42 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
              }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </table>
        </p>
        <hr>
    </dd>
    
    <div name=""divMensaje"" id=""divMensaje"" style=""display: none""></div>
    <hr>
    </main>      
    <script>
      function cargarImagen()
      {
        window.location.href = '/Documento/' + ");
#nullable restore
#line 54 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                          Write(ViewBag.parametro.documentoExtendido.documentoId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" + '/Imagen';
      }
      function bloquearDocumento()
      {
        document.getElementById(""formularioDescripcionNueva"").style.display=""none"";
        document.getElementById(""tableListadoDescripcionCargada"").style.display=""none"";
        document.getElementById(""divBotones"").style.display=""none"";
        document.getElementById(""divMensaje"").style.display=""block"";
        document.getElementById(""divMensaje"").innerHTML = ""Finalizando la creación del documento. Por favor espere.""
        jQuery.post(""../Bloquear"", {DocumentoId: ");
#nullable restore
#line 63 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                            Write(ViewBag.parametro.documentoExtendido.documentoId);

#line default
#line hidden
#nullable disable
                WriteLiteral("}, function(result){\r\n          window.location.href = \'/Documento/\' + ");
#nullable restore
#line 64 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                            Write(ViewBag.parametro.documentoExtendido.documentoId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" + '/Estado';
        })
        .fail(function() {
          document.getElementById(""divMensaje"").innerHTML = ""Se ha producido un error"";
        });
      }
      async function BorrarDescripcion (documentodescripcionid, tableRow) 
      {
        document.getElementById(""formularioDescripcionNueva"").style.display=""none"";
        document.getElementById(""tableListadoDescripcionCargada"").style.display=""none"";
        document.getElementById(""divBotones"").style.display=""none"";
        document.getElementById(""divMensaje"").style.display=""block"";
        document.getElementById(""divMensaje"").innerHTML = ""Borrando la descripción. Por favor espere.""
        jQuery.post(""../Borrar/Descripcion"", {documentoId: ");
#nullable restore
#line 77 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                                      Write(ViewBag.parametro.documentoExtendido.documentoId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@", documentoDescripcionId: documentodescripcionid}, function(result){
          if (result == ""OK"")
          {
            var filaBorrar = tableRow.parentNode.parentNode.rowIndex;
            document.getElementById(""tableListadoDescripcionCargada"").deleteRow(filaBorrar);
            document.getElementById(""formularioDescripcionNueva"").style.display=""block"";
            document.getElementById(""tableListadoDescripcionCargada"").style.display=""block"";
            document.getElementById(""divBotones"").style.display=""block"";
            document.getElementById(""divMensaje"").style.display=""none"";
          }
          else
          {
            document.getElementById(""formularioDescripcionNueva"").style.display=""block"";
            document.getElementById(""tableListadoDescripcionCargada"").style.display=""block"";
            document.getElementById(""divBotones"").style.display=""block"";
            document.getElementById(""divMensaje"").style.display=""none"";
            alert (result)
          }
");
                WriteLiteral(@"        })
        .fail(function() {
          document.getElementById(""divMensaje"").innerHTML = ""Se ha producido un error"";
        });
      }
      async function AgregarDescripcion () 
      {
        document.getElementById(""formularioDescripcionNueva"").style.display=""none"";
        document.getElementById(""tableListadoDescripcionCargada"").style.display=""none"";
        document.getElementById(""divBotones"").style.display=""none"";
        document.getElementById(""divMensaje"").style.display=""block"";
        document.getElementById(""divMensaje"").innerHTML = ""Agregando descripción. Por favor espere.""
        jQuery.post(""../Agregar/Descripcion"", {DocumentoId: ");
#nullable restore
#line 107 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\EstadoActa.cshtml"
                                                       Write(ViewBag.parametro.documentoExtendido.documentoId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@", DocumentoDescripcionId: document.getElementById(""documentoDescripcionId"").value, DocumentoDescripcionNotas: document.getElementById(""documentoDescripcionNotas"").value}, function(result){
          if (result == ""OK"")
          {
            
            var table = document.getElementById(""tableListadoDescripcionCargada"");
            var row = table.insertRow(table.rows.length);
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            var dataList=document.getElementById(""documentoDescripcionId"");
            cell1.innerHTML = dataList.options[dataList.selectedIndex].text + "" | "" + document.getElementById(""documentoDescripcionNotas"").value;
            cell2.innerHTML = ""<input type='submit' value='Eliminar' onclick='BorrarDescripcion("" + document.getElementById(""documentoDescripcionId"").value + "",this);'/>"";
            
            document.getElementById(""formularioDescripcionNueva"").style.display=""block"";
            document.getElementById(""tableLi");
                WriteLiteral(@"stadoDescripcionCargada"").style.display=""block"";
            document.getElementById(""divBotones"").style.display=""block"";
            document.getElementById(""divMensaje"").style.display=""none"";
          }
          else
          {
            document.getElementById(""formularioDescripcionNueva"").style.display=""block"";
            document.getElementById(""tableListadoDescripcionCargada"").style.display=""block"";
            document.getElementById(""divBotones"").style.display=""block"";
            document.getElementById(""divMensaje"").style.display=""none"";
            alert (result)
          }
        })
        .fail(function() {
          document.getElementById(""divMensaje"").innerHTML = ""Se ha producido un error"";
        });
      }
    </script>
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src=""../../../../js/jquery-3.2.1.min.js""></script>
    <script src=""../../../../js/popper.min.js""></script>
    <script src=""../../../../js/bootstrap.min.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
