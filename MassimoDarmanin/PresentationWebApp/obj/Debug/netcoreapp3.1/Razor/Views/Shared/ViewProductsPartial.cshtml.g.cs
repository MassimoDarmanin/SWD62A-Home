#pragma checksum "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be01a3f043050f950318621285e4dc1471c1c973"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ViewProductsPartial), @"mvc.1.0.view", @"/Views/Shared/ViewProductsPartial.cshtml")]
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
#line 1 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\_ViewImports.cshtml"
using PresentationWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\_ViewImports.cshtml"
using PresentationWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be01a3f043050f950318621285e4dc1471c1c973", @"/Views/Shared/ViewProductsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d37c9bc11724120768bc51102823a04d56debf5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ViewProductsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShoppingCart.Application.ViewModels.ProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n\n");
#nullable restore
#line 5 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
 foreach (var p in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"col-6\">\n    <div class=\"card\" style=\"width: 18rem;\">\n        <img");
            BeginWriteAttribute("src", " src=\"", 181, "\"", 198, 1);
#nullable restore
#line 9 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
WriteAttributeValue("", 187, p.ImageUrl, 187, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top card-image\"");
            BeginWriteAttribute("alt", " alt=\"", 231, "\"", 244, 1);
#nullable restore
#line 9 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
WriteAttributeValue("", 237, p.Name, 237, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        <div class=\"card-body\">\n            <h5 class=\"card-title\">");
#nullable restore
#line 11 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
                              Write(p.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n            <p class=\"card-text\">€");
#nullable restore
#line 12 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
                             Write(p.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <a");
            BeginWriteAttribute("href", " href=\"", 388, "\"", 421, 2);
            WriteAttributeValue("", 395, "/Products/Details?id=", 395, 21, true);
#nullable restore
#line 13 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
WriteAttributeValue("", 416, p.Id, 416, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">View Specifications</a>\n\n");
#nullable restore
#line 15 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
             if (User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 541, "\"", 573, 2);
            WriteAttributeValue("", 548, "/Products/Delete?id=", 548, 20, true);
#nullable restore
#line 17 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
WriteAttributeValue("", 568, p.Id, 568, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a>");
#nullable restore
#line 17 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
                                                                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n</div>");
#nullable restore
#line 21 "C:\Users\Massimo\source\repos\SWD62A-Home\Solution3\PresentationWebApp\Views\Shared\ViewProductsPartial.cshtml"
      }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShoppingCart.Application.ViewModels.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591