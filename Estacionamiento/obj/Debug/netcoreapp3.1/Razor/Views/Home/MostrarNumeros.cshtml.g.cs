#pragma checksum "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\Home\MostrarNumeros.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3d1f23027b1c280aca4c0efae592af416189281"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_MostrarNumeros), @"mvc.1.0.view", @"/Views/Home/MostrarNumeros.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3d1f23027b1c280aca4c0efae592af416189281", @"/Views/Home/MostrarNumeros.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b019c1467c58ef388819dbcc09adb19b2b3bbc6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_MostrarNumeros : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<int>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\Home\MostrarNumeros.cshtml"
 foreach (int num in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("               <p>");
#nullable restore
#line 5 "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\Home\MostrarNumeros.cshtml"
             Write(num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> \r\n");
#nullable restore
#line 6 "C:\Users\KarinaAuday\source\repos\2022-2C-Estacionamiento\Estacionamiento\Views\Home\MostrarNumeros.cshtml"
            }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
