#pragma checksum "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5adfc1df2a40f7fbdd897bbb3cd329e22aa7372"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tournoi_Admin), @"mvc.1.0.view", @"/Views/Tournoi/Admin.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tournoi/Admin.cshtml", typeof(AspNetCore.Views_Tournoi_Admin))]
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
#line 1 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 2 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
using Tour0Suisse.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5adfc1df2a40f7fbdd897bbb3cd329e22aa7372", @"/Views/Tournoi/Admin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c3a5f40b083326dcec4f1b39a5f0cc2ac12e470", @"/Views/_ViewImports.cshtml")]
    public class Views_Tournoi_Admin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Tour0Suisse.Model.Round>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Start", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Pairing", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(105, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(150, 77, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Tournoi</h4>\r\n    <hr />\r\n    \r\n</div>\r\n");
            EndContext();
#line 16 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
  
    if (!Model.Any())
    {

#line default
#line hidden
            BeginContext(261, 46, true);
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(307, 201, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6396f77105074bd1a165d6db1b82df25", async() => {
                BeginContext(394, 107, true);
                WriteLiteral("\r\n                <input type=\"submit\" value=\"Commencer le tournoi\" class=\"btn btn-default\"/>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 20 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                        WriteLiteral(((Tournoi)ViewData["Tournoi"]).IdTournament);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(508, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 24 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(550, 48, true);
            WriteLiteral("        <div class=\"form-group\">\r\n            \r\n");
            EndContext();
#line 29 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                 foreach (var round in Model)
                {

#line default
#line hidden
            BeginContext(664, 24, true);
            WriteLiteral("                    <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 688, "\"", 721, 1);
#line 31 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
WriteAttributeValue("", 693, "Round"+round.RoundNumber, 693, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(722, 34, true);
            WriteLiteral(">\r\n                        <button");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 756, "\"", 795, 1);
#line 32 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
WriteAttributeValue("", 761, "ButtonRound"+round.RoundNumber, 761, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(796, 53, true);
            WriteLiteral(" class=\"btn btn\" data-toggle=\"collapse\" data-target=\"");
            EndContext();
            BeginContext(851, 34, false);
#line 32 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                                                                                                        Write("#collapseRound"+round.RoundNumber);

#line default
#line hidden
            EndContext();
            BeginContext(886, 22, true);
            WriteLiteral("\" aria-expanded=\"true\"");
            EndContext();
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 908, "\"", 960, 1);
#line 32 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
WriteAttributeValue("", 924, "collapseRound"+round.RoundNumber, 924, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(961, 60, true);
            WriteLiteral(">\r\n                            <label class=\"control-label\">");
            EndContext();
            BeginContext(1023, 26, false);
#line 33 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                                     Write("Round "+round.RoundNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1050, 75, true);
            WriteLiteral("</label>\r\n                        </button>\r\n\r\n                        <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1125, "\"", 1168, 1);
#line 36 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
WriteAttributeValue("", 1130, "collapseRound" + round.RoundNumber, 1130, 38, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1169, 232, true);
            WriteLiteral(" class=\"collapse\">\r\n                            <table class=\"table\">\r\n                                <thead>\r\n                                <tr>\r\n                                    <th>\r\n                                        ");
            EndContext();
            BeginContext(1402, 34, false);
#line 41 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                   Write(Html.DisplayName("Début de round"));

#line default
#line hidden
            EndContext();
            BeginContext(1436, 127, true);
            WriteLiteral("\r\n                                    </th>\r\n                                    <th>\r\n                                        ");
            EndContext();
            BeginContext(1564, 32, false);
#line 44 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                   Write(Html.DisplayName("Fin de round"));

#line default
#line hidden
            EndContext();
            BeginContext(1596, 287, true);
            WriteLiteral(@"
                                    </th>
                                </tr>
                                </thead>
                                <tbody>
                                <tr>
                                    <td>
                                        ");
            EndContext();
            BeginContext(1885, 30, false);
#line 51 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                    Write(round.StartRound.ToLocalTime());

#line default
#line hidden
            EndContext();
            BeginContext(1916, 87, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 54 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                           string End = (round.EndRound < round.StartRound) ? "" : round.EndRound.ToLocalTime().ToString();

#line default
#line hidden
            BeginContext(2143, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2146, 3, false);
#line 54 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                                                                                                                         Write(End);

#line default
#line hidden
            EndContext();
            BeginContext(2150, 164, true);
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n                                </tbody>\r\n                            </table>\r\n");
            EndContext();
#line 59 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                             if (round.Matches.Any())
                            {

#line default
#line hidden
            BeginContext(2400, 232, true);
            WriteLiteral("                                <table class=\"table\">\r\n                                    <thead>\r\n                                    <tr>\r\n                                        <th>\r\n                                            ");
            EndContext();
            BeginContext(2633, 28, false);
#line 65 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                       Write(Html.DisplayName("Joueur 1"));

#line default
#line hidden
            EndContext();
            BeginContext(2661, 139, true);
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
            EndContext();
            BeginContext(2801, 28, false);
#line 68 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                       Write(Html.DisplayName("Joueur 2"));

#line default
#line hidden
            EndContext();
            BeginContext(2829, 183, true);
            WriteLiteral("\r\n                                        </th>\r\n                                    </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
            EndContext();
#line 73 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                     foreach (var item in round.Matches)
                                    {

#line default
#line hidden
            BeginContext(3125, 144, true);
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                ");
            EndContext();
            BeginContext(3270, 42, false);
#line 77 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Player1));

#line default
#line hidden
            EndContext();
            BeginContext(3312, 71, true);
            WriteLiteral("<br/>\r\n                                                Pseudo en jeu : ");
            EndContext();
            BeginContext(3384, 42, false);
#line 78 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                                           Write(Html.DisplayFor(modelItem => item.Pseudo1));

#line default
#line hidden
            EndContext();
            BeginContext(3426, 151, true);
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            EndContext();
            BeginContext(3578, 42, false);
#line 81 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Player2));

#line default
#line hidden
            EndContext();
            BeginContext(3620, 71, true);
            WriteLiteral("<br/>\r\n                                                Pseudo en jeu : ");
            EndContext();
            BeginContext(3692, 42, false);
#line 82 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                                           Write(Html.DisplayFor(modelItem => item.Pseudo2));

#line default
#line hidden
            EndContext();
            BeginContext(3734, 98, true);
            WriteLiteral("\r\n                                            </td>\r\n                                        </tr>");
            EndContext();
#line 84 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                             }

#line default
#line hidden
            BeginContext(3835, 88, true);
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n");
            EndContext();
#line 87 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(4019, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(4051, 282, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bab382f5fd9043408383fea6e0d31e36", async() => {
                BeginContext(4179, 147, true);
                WriteLiteral("\r\n                                    <input type=\"submit\" value=\"crée tout les matchs\" class=\"btn btn-default\"/>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 90 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                                              WriteLiteral(((Tournoi)ViewData["Tournoi"]).IdTournament);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 90 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                                                                                                                               WriteLiteral(round.RoundNumber);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["round"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-round", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["round"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4333, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 93 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                            }

#line default
#line hidden
            BeginContext(4366, 90, true);
            WriteLiteral("                            \r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 97 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                }

#line default
#line hidden
            BeginContext(4475, 30, true);
            WriteLiteral("            \r\n        </div>\r\n");
            EndContext();
#line 100 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
    }

#line default
#line hidden
            BeginContext(4515, 11, true);
            WriteLiteral("<div>\r\n    ");
            EndContext();
            BeginContext(4526, 96, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90b13b3142834f9e89c89b525737a5a3", async() => {
                BeginContext(4612, 6, true);
                WriteLiteral("Retour");
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
#line 103 "E:\Aedjis-PC\Documents\Cours\TFE\TFE\Tour0Suisse\Tour0Suisse\Views\Tournoi\Admin.cshtml"
                               WriteLiteral(((Tournoi)ViewData["Tournoi"]).IdTournament);

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
            BeginContext(4622, 8, true);
            WriteLiteral("\r\n    | ");
            EndContext();
            BeginContext(4630, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d76e2137dc0452d8178dff876485724", async() => {
                BeginContext(4652, 12, true);
                WriteLiteral("Back to List");
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
            BeginContext(4668, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Tour0Suisse.Model.Round>> Html { get; private set; }
    }
}
#pragma warning restore 1591
