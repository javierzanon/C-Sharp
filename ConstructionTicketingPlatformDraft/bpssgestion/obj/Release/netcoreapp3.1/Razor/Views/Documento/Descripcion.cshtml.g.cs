#pragma checksum "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff0812abcc0e7ccd2b686e466477c88fe3ecbd2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Documento_Descripcion), @"mvc.1.0.view", @"/Views/Documento/Descripcion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff0812abcc0e7ccd2b686e466477c88fe3ecbd2e", @"/Views/Documento/Descripcion.cshtml")]
    public class Views_Documento_Descripcion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff0812abcc0e7ccd2b686e466477c88fe3ecbd2e2776", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff0812abcc0e7ccd2b686e466477c88fe3ecbd2e4048", async() => {
                WriteLiteral("\r\n  <dd class=\"col-sm-10\">\r\n      <p class=\"lead text-muted\" style=\"text-align: center\">\r\n        <b>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
      Write(ViewBag.parametro.documentoExtendido.documentoTipo);

#line default
#line hidden
#nullable disable
                WriteLiteral(" nº <i>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                                                                Write(ViewBag.parametro.documentoExtendido.documentoId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</i> | Lote <i>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                                                                                                                                Write(ViewBag.parametro.documentoExtendido.lote);

#line default
#line hidden
#nullable disable
                WriteLiteral("</i> Área <i>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                                                                                                                                                                                       Write(ViewBag.parametro.documentoExtendido.area);

#line default
#line hidden
#nullable disable
                WriteLiteral("</i> | Creada el <i>");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                                                                                                                                                                                                                                                     Write(ViewBag.parametro.documentoExtendido.fecha);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</i></b>
      </p>
      <hr>
  </div>
    <main role=""main"">
          <section class=""jumbotron"">
              <div class=""container"">
                  <h1 class=""jumbotron-heading"" style=""text-align: left"">
                      Descripciones de Documento
                  </h1>
              </div>
          </section>
    <dd class=""col-sm-10"">    
        <p style=""text-align: center"">
            <table class=""table"" name=""tableListadoDescripcionCargada"" id=""tableListadoDescripcionCargada"">
");
#nullable restore
#line 31 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
               foreach (var dato in ViewBag.parametro.descripcionesCargadas)
              {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 35 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                       Write(dato.documentoDescripcion);

#line default
#line hidden
#nullable disable
                WriteLiteral(" | ");
#nullable restore
#line 35 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                                                    Write(dato.documentoDescripcionNotas);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input type=\"submit\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1609, "\"", 1673, 4);
                WriteAttributeValue("", 1619, "BorrarDescripcion(", 1619, 18, true);
#nullable restore
#line 38 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
WriteAttributeValue("", 1637, dato.documentoDescripcionId, 1637, 28, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1665, ",", 1665, 1, true);
                WriteAttributeValue(" ", 1666, "this);", 1667, 7, true);
                EndWriteAttribute();
                WriteLiteral(" value=\"Eliminar\"/>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 41 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
              }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </table>
        </p>
        <hr>
        <p style=""text-align: center"">
          <form action=""./Descripcion/Agregar"" 
                    enctype=""multipart/form-data"" onsubmit=""AgregarDescripcion(this);return false;"" 
                    method=""post"" id=""formularioDescripcionNueva"" name=""formularioDescripcionNueva"">
                  <dl>
                      <dt>
                          <label for=""Descripcion_FormDescripcionNueva"">Agregar Descripcion</label>
                      </dt>
                      <dd>
                        <select id=""documentoDescripcionId"" name=""documentoDescripcionId"" />
");
#nullable restore
#line 55 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                             foreach (var item in @ViewBag.parametro.descripcionesTodas)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <option");
                BeginWriteAttribute("value", " value=\"", 2577, "\"", 2613, 1);
#nullable restore
#line 57 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
WriteAttributeValue("", 2585, item.documentoDescripcionId, 2585, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                  ");
#nullable restore
#line 58 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                             Write(item.documentoDescripcion);

#line default
#line hidden
#nullable disable
                WriteLiteral(" \r\n                                </option>\r\n");
#nullable restore
#line 60 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </select>
                      </dd>
                      <dt>
                          <label for=""Notas_FormDescripcionNueva"">Notas de la descripción</label>
                      </dt>
                      <dd>
                        <input type=""text"" id=""documentoDescripcionNotas"" name=""documentoDescripcionNotas"" />
                      </dd>
                  <div name=""botonSubmit"" id=""botonSubmit"">
                    <input class=""btn"" type=""submit"" value=""Agregar"" name=""agregarSubmit"" id=""agregarSubmit""/>
                  </div>
                  <div style=""margin-top:15px"">
                      <output name=""result""></output>
                  </div>
          </form>
        </p>
    </dd>
    <div name=""divMensaje"" id=""divMensaje"" style=""display: none""></div>
    <hr>
    <div name=""divBotones"" id=""divBotones"">
      <table name=""tableBotones"" id=""tabletBotones"">
        <tr>
          <td>
            <div name=""botonSiguiente"" id=""botonSig");
                WriteLiteral(@"uiente"">
              <input class=""btn"" type=""submit"" value=""Cargar Imágenes"" name=""cargarImagenes"" id=""cargarImagenes"" onclick=""cargarImagen();""/>
            </div>
          </td>
          <td>
            <div name=""botonBloquear"" id=""botonBloquear"">
              <input class=""btn"" type=""submit"" value=""Finalizar la creación del documento"" name=""bloquearDocumento"" id=""bloquearDocumento"" onclick=""bloquearDocumento();""/>
            </div>
          </td>
        </tr>
      </table>
    </div>
    </main>      
    <script>
      function cargarImagen()
      {
        window.location.href = '/Documento/' + ");
#nullable restore
#line 100 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
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
#line 109 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
                                            Write(ViewBag.parametro.documentoExtendido.documentoId);

#line default
#line hidden
#nullable disable
                WriteLiteral("}, function(result){\r\n          window.location.href = \'/Documento/\' + ");
#nullable restore
#line 110 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
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
#line 123 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
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
#line 153 "C:\Users\Usuario\Documents\GitHub\bpssgestion\bpssgestion\Views\Documento\Descripcion.cshtml"
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
