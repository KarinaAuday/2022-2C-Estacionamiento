#pragma checksum "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\Personas\MostrarPersonas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f251062da6f17cfc693957bb05e9e2075342c88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Personas_MostrarPersonas), @"mvc.1.0.view", @"/Views/Personas/MostrarPersonas.cshtml")]
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
#nullable restore
#line 1 "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\_ViewImports.cshtml"
using Estacionamiento;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\_ViewImports.cshtml"
using Estacionamiento.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f251062da6f17cfc693957bb05e9e2075342c88", @"/Views/Personas/MostrarPersonas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b019c1467c58ef388819dbcc09adb19b2b3bbc6", @"/Views/_ViewImports.cshtml")]
    public class Views_Personas_MostrarPersonas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<p>Mostrando las Personas por ID despues de la /</p>\r\n");
#nullable restore
#line 2 "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\Personas\MostrarPersonas.cshtml"
Write(ViewBag.Persona.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\Personas\MostrarPersonas.cshtml"
Write(ViewBag.Persona.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\Personas\MostrarPersonas.cshtml"
Write(ViewBag.Persona.Dni);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
