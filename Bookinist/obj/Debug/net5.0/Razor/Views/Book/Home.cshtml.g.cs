#pragma checksum "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\Book\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a57a0daadd7fcf885eac825a8111b3d86ed0cd6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_Home), @"mvc.1.0.view", @"/Views/Book/Home.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a57a0daadd7fcf885eac825a8111b3d86ed0cd6", @"/Views/Book/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e2a72bf0bf50ce2144dfaf04f64c111bd3a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Bookinist.Models.DTO.BookDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\Book\Home.cshtml"
  
    ViewData["Title"] = "Bookinist Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<div class=\"row\">\r\n");
#nullable restore
#line 7 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\Book\Home.cshtml"
     foreach (var book in Model)
    {
        //var routeDate = new Dictionary<string, string>()
        //{
        //    {"id",book.Id.ToString() },
        //    {"CategoryId",book.CategoryId.ToString() }
        //};

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-3 col-xs-12 col-lg-4\">\r\n            <div class=\"card bg-dark\" style=\"height:230px; padding:10px; margin-top:5px;\">\r\n                <div class=\"card-body\">\r\n                    <h4 class=\"card-title text-info\">");
#nullable restore
#line 17 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\Book\Home.cshtml"
                                                Write(book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <h5 class=\"card-text text-white\">");
#nullable restore
#line 18 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\Book\Home.cshtml"
                                                Write(book.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text text-white\">");
#nullable restore
#line 19 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\Book\Home.cshtml"
                                               Write(book.ShortDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p class=\"card-text text-white\">");
#nullable restore
#line 20 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\Book\Home.cshtml"
                                               Write(book.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 24 "D:\alif C#\GraduationProj\Bookinist\Bookinist\Views\Book\Home.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Bookinist.Models.DTO.BookDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591