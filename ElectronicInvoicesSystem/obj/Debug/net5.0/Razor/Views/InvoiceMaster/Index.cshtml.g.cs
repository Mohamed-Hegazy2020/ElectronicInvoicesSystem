#pragma checksum "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "288a7799e1a61f78a0075fabb9d87a5862f431b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InvoiceMaster_Index), @"mvc.1.0.view", @"/Views/InvoiceMaster/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"288a7799e1a61f78a0075fabb9d87a5862f431b8", @"/Views/InvoiceMaster/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"920d1180230752c81324fac2600ea527f70bce72", @"/Views/_ViewImports.cshtml")]
    public class Views_InvoiceMaster_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElectronicInvoicesSystem.ModelsView.InvoiceMasterViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-v4-rtl-main/dist/css/bootstrap-rtl.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
  
    ViewData["Title"] = "المستندات";
    Layout = "~/Views/Shared/_NewLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "288a7799e1a61f78a0075fabb9d87a5862f431b85572", async() => {
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
            WriteLiteral("\r\n<h1> <i class=\"fa fa-file-o\"></i> ");
#nullable restore
#line 9 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                             Write(ViewBag.docType);

#line default
#line hidden
#nullable disable
            WriteLiteral("   </h1>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "288a7799e1a61f78a0075fabb9d87a5862f431b87085", async() => {
                WriteLiteral(" <i class=\"fa fa-file-o\"></i> مستند جديد ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <div class=""col"">
        <div class=""input-group"">
            <input id=""search"" name=""search"" type=""text"" class=""form-control"" placeholder=""بحث"">
            <div class=""input-group-append"">
                <button class=""btn btn-secondary"" type=""button"">
                    <i class=""fa fa-search""></i>
                </button>
            </div>
        </div>
    </div>
</div>
<div class=""table-responsive"">
    <table class=""table table-hover table-striped table-responsive-md"" id=""dtBasicExample"">
        <thead>
            <tr class=""bg-secondary"">

                <th scope=""row"">
                    ");
#nullable restore
#line 32 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th scope=\"row\">\r\n                    ");
#nullable restore
#line 35 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th scope=\"row\">\r\n                    ");
#nullable restore
#line 38 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.invTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th scope=\"row\">\r\n                    ");
#nullable restore
#line 41 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.invDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th scope=\"row\">\r\n                    ");
#nullable restore
#line 44 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.invTax));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th scope=\"row\">\r\n                    ");
#nullable restore
#line 47 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.invNet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th scope=\"row\">\r\n                    ");
#nullable restore
#line 50 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.DocTypeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th scope=\"row\">\r\n                    ");
#nullable restore
#line 53 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.invState));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th scope=\"row\"></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 59 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 63 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 66 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 69 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.invTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 72 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.invDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 75 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.invTax));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 78 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.invNet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 81 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DocTypeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 84 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.invState));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td scope=\"row\">\r\n                        ");
#nullable restore
#line 88 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.ActionLink("", "Refresh", new { id = item.id }, htmlAttributes: new { @class = "fa fa-refresh", @title = "تحديث" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n");
            WriteLiteral("                        ");
#nullable restore
#line 90 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.ActionLink("", "Details", new { id = item.id }, htmlAttributes: new { @class = "fa fa-info-circle", @title = "التفاصيل" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 91 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.ActionLink("", "PrintViewToPdf", new { id = item.id }, htmlAttributes: new { @class = "fa fa-file-pdf-o", @title = "تصدير PDF" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 92 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
                   Write(Html.ActionLink("", "CancelDocument", new { id = item.id }, htmlAttributes: new { @class = "fa fa-times-circle-o", @title = "إلغاء" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 96 "F:\sys programs\myGithubProfile\ElectronicInvoice\E_InvoiceSystem\ElectronicInvoicesSystem\Views\InvoiceMaster\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "288a7799e1a61f78a0075fabb9d87a5862f431b817912", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>

    $(document).ready(function () {

        $('input[name=search]').change(function () {
            debugger;
            var docCode = $(this).val();
            $.ajax({
                type: ""GET"",
                url: ""/InvoiceMaster/getDocumentByCode"",
                data: { 'docCode': docCode },
                success: function (data) {
                    debugger;

                    $(""#dtBasicExample > tbody tr"").remove()
                    var html = '';
                    for (var i = 0; i < data.length; i++) {
                        html += '<tr>' +
                            '<td>' + data[i].code + '</td>' +
                            '<td>' + data[i].date + '</td>' +
                            '<td>' + data[i].invTotal + '</td>' +
                            '<td>' + data[i].invDiscount + '</td>' +
                            '<td>' + data[i].invTax + '</td>' +
                            '<td>' + data[i].invNet + '</td>' +
                      ");
            WriteLiteral(@"      '<td>' + data[i].docTypeName + '</td>' +
                            '<td>' + data[i].invState + '</td>' +
                            '<td><a class = ""fa fa-refresh"" href=""/InvoiceMaster/Refresh/' + data[i].id + '""></a></td>' +
                            '<td>|<a class = ""fa fa-info-circle"" href=""/InvoiceMaster/Details/' + data[i].id + '""></a></td>' +
                            '<td>|<a class = ""fa fa-file-pdf-o"" href=""/InvoiceMaster/PrintViewToPdf/' + data[i].id + '""></a> </td>' +
                            '<td>|<a class = ""fa fa-times-circle-o"" href=""/InvoiceMaster/CancelDocument/' + data[i].id + '""></a></td>' +
                            '</tr>';
                    }
                    $('#dtBasicExample tbody').append(html);
                }
            });
        });
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElectronicInvoicesSystem.ModelsView.InvoiceMasterViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
