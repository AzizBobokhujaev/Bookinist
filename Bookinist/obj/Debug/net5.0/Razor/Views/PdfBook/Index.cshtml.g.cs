#pragma checksum "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ee5b1931da7c8f714b6111a748c47afeb7a4c45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PdfBook_Index), @"mvc.1.0.view", @"/Views/PdfBook/Index.cshtml")]
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
#line 1 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\_ViewImports.cshtml"
using Bookinist;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\_ViewImports.cshtml"
using Bookinist.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\_ViewImports.cshtml"
using Bookinist.Models.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee5b1931da7c8f714b6111a748c47afeb7a4c45", @"/Views/PdfBook/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f5b64a5a96312a9b76827a6e59cab65d7f757dc", @"/Views/_ViewImports.cshtml")]
    public class Views_PdfBook_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Bookinist.Models.Entity.PdfBook>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PdfBook", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"d-flex justify-content-between mt-3 mb-3\">\r\n    <h5 style=\"color: rgb(94,187,241);\">Электронные книги</h5>\r\n");
#nullable restore
#line 10 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ee5b1931da7c8f714b6111a748c47afeb7a4c455118", async() => {
                WriteLiteral("Добавить");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 13 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<table class=""table"">
    <thead>
        <tr>
            <th>
                <h4 class=""text-white"">Название</h4>
            </th>
            <th>
                <h4 class=""text-white"">Файл</h4>
            </th>

            <th>
                <h4 class=""text-white"">Описание</h4>
            </th>
            <th>
                <h4 class=""text-white"">Время добавления</h4>
            </th>
            <th>
                <h4 class=""text-white"">Владелец</h4>

            </th>
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 40 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
         foreach (var item in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"text-white\">\r\n                    ");
#nullable restore
#line 45 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1171, "\"", 1233, 1);
#nullable restore
#line 48 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
WriteAttributeValue("", 1178, Url.Content("~/PDF/"+item.CreatedAt.ToString()+".pdf"), 1178, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 48 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
                                                                                                                      Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span style=\"font-size:.8em;\">.pdf</span></a>\r\n                </td>\r\n                <td class=\"text-white\">\r\n                    ");
#nullable restore
#line 51 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"text-white\">\r\n                    ");
#nullable restore
#line 54 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
               Write(item.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"text-white\">\r\n                    ");
#nullable restore
#line 57 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
               Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 61 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\PdfBook\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Bookinist.Models.Entity.PdfBook>> Html { get; private set; }
    }
}
#pragma warning restore 1591