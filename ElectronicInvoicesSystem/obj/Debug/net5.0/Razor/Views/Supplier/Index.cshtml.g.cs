#pragma checksum "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c15f222347a57902ca5cfe4e179658de343d5827"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supplier_Index), @"mvc.1.0.view", @"/Views/Supplier/Index.cshtml")]
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
#line 1 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\_ViewImports.cshtml"
using ElectronicInvoicesSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\_ViewImports.cshtml"
using ElectronicInvoicesSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c15f222347a57902ca5cfe4e179658de343d5827", @"/Views/Supplier/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"920d1180230752c81324fac2600ea527f70bce72", @"/Views/_ViewImports.cshtml")]
    public class Views_Supplier_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElectronicInvoicesSystem.ModelsView.SuppliersViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-v4-rtl-main/dist/css/bootstrap-rtl.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_NewLayout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c15f222347a57902ca5cfe4e179658de343d58275136", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-10\"><h1> <i class=\"fa fa-file-o\"> </i>  ???????????????? </h1></div>\r\n    <div class=\"col-md-2\"> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c15f222347a57902ca5cfe4e179658de343d58276397", async() => {
                WriteLiteral(" <i class=\"fa fa-file-o\"></i> ???????? ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>   \r\n</div>\r\n\r\n<table class=\"table table-hover table-striped table-responsive-md\">\r\n    <thead>\r\n        <tr class=\"bg-secondary\">\r\n            <th>\r\n                ");
#nullable restore
#line 18 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NameAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Tel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Mobile));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 36 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NationalID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 39 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Governate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 47 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.CreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NameAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Tel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 67 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Mobile));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 70 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NationalID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 73 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Governate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>               \r\n                <td>\r\n                    ");
#nullable restore
#line 76 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.ActionLink("??????????", "Edit", new { id = item.UniqueId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |                   \r\n                    ");
#nullable restore
#line 77 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
               Write(Html.ActionLink("??????", "Delete", new { id = item.UniqueId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 80 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\Supplier\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElectronicInvoicesSystem.ModelsView.SuppliersViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
