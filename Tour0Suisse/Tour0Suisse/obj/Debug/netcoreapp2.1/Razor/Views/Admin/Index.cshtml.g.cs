#pragma checksum "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32fce16a568906bae9bcc77467265541c3028e3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Index.cshtml", typeof(AspNetCore.Views_Admin_Index))]
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
#line 2 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\_ViewImports.cshtml"
using Tour0Suisse.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32fce16a568906bae9bcc77467265541c3028e3d", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c3a5f40b083326dcec4f1b39a5f0cc2ac12e470", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Tour0Suisse.Model.ViewTournament>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tournois", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Tournoi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(97, 104, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(202, 40, false);
#line 13 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(242, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(298, 40, false);
#line 16 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(338, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(394, 47, false);
#line 19 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(441, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(497, 51, false);
#line 22 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MaxNumberPlayer));

#line default
#line hidden
            EndContext();
            BeginContext(548, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(604, 50, false);
#line 25 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DeckListNumber));

#line default
#line hidden
            EndContext();
            BeginContext(654, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(710, 41, false);
#line 28 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ppwin));

#line default
#line hidden
            EndContext();
            BeginContext(751, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(807, 42, false);
#line 31 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ppdraw));

#line default
#line hidden
            EndContext();
            BeginContext(849, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(905, 42, false);
#line 34 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Pplose));

#line default
#line hidden
            EndContext();
            BeginContext(947, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1003, 40, false);
#line 37 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Over));

#line default
#line hidden
            EndContext();
            BeginContext(1043, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1099, 40, false);
#line 40 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Game));

#line default
#line hidden
            EndContext();
            BeginContext(1139, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 46 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1274, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1335, 39, false);
#line 50 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1374, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1442, 39, false);
#line 53 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1481, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1549, 46, false);
#line 56 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1595, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1663, 50, false);
#line 59 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MaxNumberPlayer));

#line default
#line hidden
            EndContext();
            BeginContext(1713, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1781, 49, false);
#line 62 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DeckListNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1830, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1898, 40, false);
#line 65 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Ppwin));

#line default
#line hidden
            EndContext();
            BeginContext(1938, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2006, 41, false);
#line 68 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Ppdraw));

#line default
#line hidden
            EndContext();
            BeginContext(2047, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2115, 41, false);
#line 71 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Pplose));

#line default
#line hidden
            EndContext();
            BeginContext(2156, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2224, 39, false);
#line 74 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Over));

#line default
#line hidden
            EndContext();
            BeginContext(2263, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2331, 39, false);
#line 77 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Game));

#line default
#line hidden
            EndContext();
            BeginContext(2370, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2437, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25cb8c50566f47f8978bf0a0ff409092", async() => {
                BeginContext(2521, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 80 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
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
            BeginContext(2532, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(2556, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6e8cdcd80544114b4e9b8361fdddbe7", async() => {
                BeginContext(2637, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 81 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
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
            BeginContext(2645, 23, true);
            WriteLiteral("|\r\n                    ");
            EndContext();
            BeginContext(2668, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "023e27d5abc2470eab1406900ea9f040", async() => {
                BeginContext(2749, 5, true);
                WriteLiteral("Admin");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 82 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
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
            BeginContext(2758, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 85 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Admin\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2813, 24, true);
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
