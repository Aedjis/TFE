#pragma checksum "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e0d889799b840598fcfd7798ab93cf4fcadcf52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tournoi_Drop), @"mvc.1.0.view", @"/Views/Tournoi/Drop.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tournoi/Drop.cshtml", typeof(AspNetCore.Views_Tournoi_Drop))]
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
#line 1 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\_ViewImports.cshtml"
using Tour0Suisse;

#line default
#line hidden
#line 1 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
using Tour0Suisse.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e0d889799b840598fcfd7798ab93cf4fcadcf52", @"/Views/Tournoi/Drop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c82a8c00f03253429d48af680cbef87b67d4e4a", @"/Views/_ViewImports.cshtml")]
    public class Views_Tournoi_Drop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tour0Suisse.Model.Tournoi>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Drop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(65, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
  
    TexteFr TB = TexteFr.Instance;

#line default
#line hidden
            BeginContext(110, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(117, 17, false);
#line 8 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(134, 65, true);
            WriteLiteral("</h2>\r\n\r\n<h3>Voulez-vous vraiment Abandonner ce tournoi?</h3>\r\n\r\n");
            EndContext();
#line 12 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
 if (ViewBag.error != null)
{

#line default
#line hidden
            BeginContext(231, 61, true);
            WriteLiteral("    <div class=\"warning\">\r\n        <span class=\"text-danger\">");
            EndContext();
            BeginContext(294, 24, false);
#line 15 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
                              Write( (string)@ViewBag.error );

#line default
#line hidden
            EndContext();
            BeginContext(319, 21, true);
            WriteLiteral("</span>\r\n    </div>\r\n");
            EndContext();
#line 17 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
}

#line default
#line hidden
            BeginContext(343, 15, true);
            WriteLiteral("<div>\r\n    <h4>");
            EndContext();
            BeginContext(359, 30, false);
#line 19 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
   Write(TB.Tournoi_Unregister_SubTitle);

#line default
#line hidden
            EndContext();
            BeginContext(389, 77, true);
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(467, 40, false);
#line 23 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(507, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(551, 36, false);
#line 26 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(587, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(631, 40, false);
#line 29 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(671, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(715, 36, false);
#line 32 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(751, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(795, 47, false);
#line 35 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(842, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(886, 43, false);
#line 38 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(929, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(973, 51, false);
#line 41 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayNameFor(model => model.MaxNumberPlayer));

#line default
#line hidden
            EndContext();
            BeginContext(1024, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1068, 47, false);
#line 44 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayFor(model => model.MaxNumberPlayer));

#line default
#line hidden
            EndContext();
            BeginContext(1115, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1159, 50, false);
#line 47 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayNameFor(model => model.DeckListNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1209, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1253, 46, false);
#line 50 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayFor(model => model.DeckListNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1299, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1343, 39, false);
#line 53 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayNameFor(model => model.jeu));

#line default
#line hidden
            EndContext();
            BeginContext(1382, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1426, 40, false);
#line 56 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
       Write(Html.DisplayFor(model => model.jeu.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1466, 34, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n    ");
            EndContext();
            BeginContext(1500, 169, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11f2b8f9b8144b6f9be721a55e9b86b5", async() => {
                BeginContext(1524, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1534, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e1a9ec1b94cf4d9ab4a2e5c615c13790", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 61 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdTournament);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1580, 82, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Abandonner\" class=\"btn btn-default\" />\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1669, 21, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1690, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09509a856e8c4a0cb327fa9c0679a270", async() => {
                BeginContext(1713, 27, false);
#line 66 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
                     Write(TB.Tournoi_Unregister_Index);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1744, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(1750, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c43991574cb48539d7bb3374a071933", async() => {
                BeginContext(1810, 26, false);
#line 67 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
                                                          Write(TB.Tournoi_Unregister_Back);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 67 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Drop.cshtml"
                              WriteLiteral(Model.IdTournament);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1840, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tour0Suisse.Model.Tournoi> Html { get; private set; }
    }
}
#pragma warning restore 1591
