#pragma checksum "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7ff5e1075311d83fcb39b6b1458985d4c02257c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tournoi_Index), @"mvc.1.0.view", @"/Views/Tournoi/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tournoi/Index.cshtml", typeof(AspNetCore.Views_Tournoi_Index))]
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
#line 1 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7ff5e1075311d83fcb39b6b1458985d4c02257c", @"/Views/Tournoi/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c82a8c00f03253429d48af680cbef87b67d4e4a", @"/Views/_ViewImports.cshtml")]
    public class Views_Tournoi_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Tour0Suisse.Model.ViewTournament>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(88, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(131, 25, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n");
            EndContext();
#line 11 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
     if (bool.TryParse(Context.Session.GetString("Orga"), out bool Orga) && Orga)
    {

#line default
#line hidden
            BeginContext(246, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(254, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "039a15664ab742cd865409ceae4fdf21", async() => {
                BeginContext(277, 24, true);
                WriteLiteral("Creer un nouveau tournoi");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(305, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(314, 109, true);
            WriteLiteral("</p>\r\n<table class=\"table List table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(424, 40, false);
#line 20 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(464, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(520, 40, false);
#line 23 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(560, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(616, 47, false);
#line 26 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(663, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(719, 51, false);
#line 29 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MaxNumberPlayer));

#line default
#line hidden
            EndContext();
            BeginContext(770, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(826, 50, false);
#line 32 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DeckListNumber));

#line default
#line hidden
            EndContext();
            BeginContext(876, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(932, 41, false);
#line 35 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ppwin));

#line default
#line hidden
            EndContext();
            BeginContext(973, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1029, 42, false);
#line 38 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ppdraw));

#line default
#line hidden
            EndContext();
            BeginContext(1071, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1127, 42, false);
#line 41 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Pplose));

#line default
#line hidden
            EndContext();
            BeginContext(1169, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1225, 40, false);
#line 44 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Over));

#line default
#line hidden
            EndContext();
            BeginContext(1265, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1321, 40, false);
#line 47 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Game));

#line default
#line hidden
            EndContext();
            BeginContext(1361, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 53 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1479, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1528, 39, false);
#line 56 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1567, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1623, 39, false);
#line 59 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1662, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1718, 46, false);
#line 62 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1764, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1820, 50, false);
#line 65 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.MaxNumberPlayer));

#line default
#line hidden
            EndContext();
            BeginContext(1870, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1926, 49, false);
#line 68 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DeckListNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1975, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2031, 40, false);
#line 71 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ppwin));

#line default
#line hidden
            EndContext();
            BeginContext(2071, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2127, 41, false);
#line 74 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ppdraw));

#line default
#line hidden
            EndContext();
            BeginContext(2168, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2224, 41, false);
#line 77 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Pplose));

#line default
#line hidden
            EndContext();
            BeginContext(2265, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2321, 39, false);
#line 80 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Over));

#line default
#line hidden
            EndContext();
            BeginContext(2360, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2416, 39, false);
#line 83 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Game));

#line default
#line hidden
            EndContext();
            BeginContext(2455, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2510, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ecb427a30ffb4540bc2c524b5ff83dd8", async() => {
                BeginContext(2568, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 86 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
                                          WriteLiteral(item.IdTournament);

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
            BeginContext(2579, 37, true);
            WriteLiteral(" \r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 89 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2619, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Tour0Suisse.Model.ViewTournament>> Html { get; private set; }
    }
}
#pragma warning restore 1591
