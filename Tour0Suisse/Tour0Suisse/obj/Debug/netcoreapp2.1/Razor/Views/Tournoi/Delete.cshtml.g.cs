#pragma checksum "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0865bdd51daf011c25d3f2ca8872554e4ab2c04a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tournoi_Delete), @"mvc.1.0.view", @"/Views/Tournoi/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tournoi/Delete.cshtml", typeof(AspNetCore.Views_Tournoi_Delete))]
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
#line 1 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
using Tour0Suisse.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0865bdd51daf011c25d3f2ca8872554e4ab2c04a", @"/Views/Tournoi/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c82a8c00f03253429d48af680cbef87b67d4e4a", @"/Views/_ViewImports.cshtml")]
    public class Views_Tournoi_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tour0Suisse.Model.Tournoi>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
  
    TexteFr TB = TexteFr.Instance;

#line default
#line hidden
            BeginContext(110, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(117, 17, false);
#line 8 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(134, 13, true);
            WriteLiteral("</h2>\r\n\r\n<h3>");
            EndContext();
            BeginContext(148, 26, false);
#line 10 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
Write(TB.Tournoi_Delete_Warrning);

#line default
#line hidden
            EndContext();
            BeginContext(174, 22, true);
            WriteLiteral("</h3>\r\n<div>\r\n    <h4>");
            EndContext();
            BeginContext(197, 23, false);
#line 12 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
   Write(TB.Tournoi_Delete_Title);

#line default
#line hidden
            EndContext();
            BeginContext(220, 77, true);
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(298, 40, false);
#line 16 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(338, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(382, 36, false);
#line 19 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(418, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(462, 40, false);
#line 22 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(502, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(546, 36, false);
#line 25 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(582, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(626, 47, false);
#line 28 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(673, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(717, 43, false);
#line 31 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(760, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(804, 51, false);
#line 34 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MaxNumberPlayer));

#line default
#line hidden
            EndContext();
            BeginContext(855, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(899, 47, false);
#line 37 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MaxNumberPlayer));

#line default
#line hidden
            EndContext();
            BeginContext(946, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(990, 50, false);
#line 40 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DeckListNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1040, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1084, 46, false);
#line 43 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DeckListNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1130, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1174, 41, false);
#line 46 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Ppwin));

#line default
#line hidden
            EndContext();
            BeginContext(1215, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1259, 37, false);
#line 49 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Ppwin));

#line default
#line hidden
            EndContext();
            BeginContext(1296, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1340, 42, false);
#line 52 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Ppdraw));

#line default
#line hidden
            EndContext();
            BeginContext(1382, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1426, 38, false);
#line 55 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Ppdraw));

#line default
#line hidden
            EndContext();
            BeginContext(1464, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1508, 42, false);
#line 58 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Pplose));

#line default
#line hidden
            EndContext();
            BeginContext(1550, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1594, 38, false);
#line 61 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Pplose));

#line default
#line hidden
            EndContext();
            BeginContext(1632, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1676, 40, false);
#line 64 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Over));

#line default
#line hidden
            EndContext();
            BeginContext(1716, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1760, 36, false);
#line 67 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Over));

#line default
#line hidden
            EndContext();
            BeginContext(1796, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1840, 43, false);
#line 70 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Deleted));

#line default
#line hidden
            EndContext();
            BeginContext(1883, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1927, 39, false);
#line 73 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Deleted));

#line default
#line hidden
            EndContext();
            BeginContext(1966, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2010, 39, false);
#line 76 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.jeu));

#line default
#line hidden
            EndContext();
            BeginContext(2049, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2093, 40, false);
#line 79 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.jeu.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2133, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(2171, 192, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66698ec2c3914985a08b1baa7af83e06", async() => {
                BeginContext(2197, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2207, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ce1a0090cbc14da5aa0821edd65c5ed6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 84 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
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
                BeginContext(2253, 30, true);
                WriteLiteral("\r\n        <input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2283, "\"", 2322, 1);
#line 85 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
WriteAttributeValue("", 2291, TB.Tournoi_Delete_SubmitDelete, 2291, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2323, 33, true);
                WriteLiteral(" class=\"btn btn-default\" />\r\n    ");
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
            BeginContext(2363, 17, true);
            WriteLiteral("\r\n    <br/>\r\n    ");
            EndContext();
            BeginContext(2380, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b681a16cbf8488b96e1bcb82845f2da", async() => {
                BeginContext(2442, 24, false);
#line 88 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
                                                            Write(TB.Tournoi_Delete_Retour);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 88 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
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
            BeginContext(2470, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2478, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71753f8364a34e7997ec090db289176a", async() => {
                BeginContext(2501, 23, false);
#line 89 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Delete.cshtml"
                     Write(TB.Tournoi_Delete_Index);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2528, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
