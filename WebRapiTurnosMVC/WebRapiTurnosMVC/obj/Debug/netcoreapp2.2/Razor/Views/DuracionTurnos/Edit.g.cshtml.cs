#pragma checksum "C:\RapiTurnos\WebRapiTurnosMVC\WebRapiTurnosMVC\Views\DuracionTurnos\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86d2c949bbf9ad4797b922087d2b0140bdb7bef6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DuracionTurnos_Edit), @"mvc.1.0.view", @"/Views/DuracionTurnos/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DuracionTurnos/Edit.cshtml", typeof(AspNetCore.Views_DuracionTurnos_Edit))]
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
#line 1 "C:\RapiTurnos\WebRapiTurnosMVC\WebRapiTurnosMVC\Views\_ViewImports.cshtml"
using WebRapiTurnosMVC;

#line default
#line hidden
#line 2 "C:\RapiTurnos\WebRapiTurnosMVC\WebRapiTurnosMVC\Views\_ViewImports.cshtml"
using WebRapiTurnosMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86d2c949bbf9ad4797b922087d2b0140bdb7bef6", @"/Views/DuracionTurnos/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375681c5eeafdaa034c40f69a34e5836e5085ee4", @"/Views/_ViewImports.cshtml")]
    public class Views_DuracionTurnos_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RapiTurnosDTO.DTOs.DuracionTurnosDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/DuracionTurnos/EditPost"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\RapiTurnos\WebRapiTurnosMVC\WebRapiTurnosMVC\Views\DuracionTurnos\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
            BeginContext(85, 386, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86d2c949bbf9ad4797b922087d2b0140bdb7bef64611", async() => {
                BeginContext(91, 373, true);
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js""></script>
");
                EndContext();
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
            EndContext();
            BeginContext(471, 69, true);
            WriteLiteral("\r\n\r\n\r\n<div class=\"container\">\r\n\r\n  \r\n    <p>Ingrese datos</p>\r\n\r\n    ");
            EndContext();
            BeginContext(540, 869, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86d2c949bbf9ad4797b922087d2b0140bdb7bef66259", async() => {
                BeginContext(613, 90, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label for=\"usr\">ID:</label>\r\n            ");
                EndContext();
                BeginContext(704, 104, false);
#line 21 "C:\RapiTurnos\WebRapiTurnosMVC\WebRapiTurnosMVC\Views\DuracionTurnos\Edit.cshtml"
       Write(Html.TextBoxFor(model => model.IdDuracionTurno, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
                EndContext();
                BeginContext(808, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(866, 113, true);
                WriteLiteral("        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"usr\">Descripcion:</label>\r\n            ");
                EndContext();
                BeginContext(980, 76, false);
#line 26 "C:\RapiTurnos\WebRapiTurnosMVC\WebRapiTurnosMVC\Views\DuracionTurnos\Edit.cshtml"
       Write(Html.TextBoxFor(model => model.Descripcion, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(1056, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(1114, 121, true);
                WriteLiteral("        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"pwd\">Duracion en minutos:</label>\r\n            ");
                EndContext();
                BeginContext(1236, 72, false);
#line 31 "C:\RapiTurnos\WebRapiTurnosMVC\WebRapiTurnosMVC\Views\DuracionTurnos\Edit.cshtml"
       Write(Html.TextBoxFor(model => model.Minutos, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(1308, 94, true);
                WriteLiteral("\r\n        </div>\r\n        <input type=\"submit\" value=\"Grabar\" class=\"btn btn-primary\" />\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1409, 173, true);
            WriteLiteral("\r\n</div>\r\n\r\n<a href=\"https://localhost:44343/DuracionTurnos\" class=\"btn btn-info btn-lg\">\r\n    <span class=\"glyphicon glyphicon-circle-arrow-left\"> Volver  </span>\r\n</a>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RapiTurnosDTO.DTOs.DuracionTurnosDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
