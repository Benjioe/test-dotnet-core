#pragma checksum "C:\Users\benja\source\repos\test-dotnet-core\Views\Home\TrucCool\Elm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56db513b0ca3a1123a421329856d3b8d7206f978"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TrucCool_Elm), @"mvc.1.0.view", @"/Views/Home/TrucCool/Elm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/TrucCool/Elm.cshtml", typeof(AspNetCore.Views_Home_TrucCool_Elm))]
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
#line 1 "C:\Users\benja\source\repos\test-dotnet-core\Views\_ViewImports.cshtml"
using test_dotnet_core;

#line default
#line hidden
#line 2 "C:\Users\benja\source\repos\test-dotnet-core\Views\_ViewImports.cshtml"
using test_dotnet_core.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56db513b0ca3a1123a421329856d3b8d7206f978", @"/Views/Home/TrucCool/Elm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"431c47704a82aa6d5a95f8852b7b3d38cd0d05df", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TrucCool_Elm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 454, true);
            WriteLiteral(@"<h3>Logs IIS</h3>
<p>
    L'affichage des logs IIS se fait via une simple configuration. <br />
    On télécharge le paquet <strong>Microsoft.AspNetCore.Diagnostics.Elm</strong>.
    Puis dans le fichier Startup.cs, dans la méthode ConfigureServices on ajoute <span class=""code"">services.AddElm();</span>, et <span>app.UseElmPage();<br />app.UseElmCapture();</span> dans la méthode configure.
    L'accès aux logs se fait depuis l'url /elm
</p>

");
            EndContext();
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
