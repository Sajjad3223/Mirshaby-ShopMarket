#pragma checksum "D:\C#Projects\ShopMarket\ShopMarket\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd849c652278b41d05e3a7de46a4f1308aa727e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\C#Projects\ShopMarket\ShopMarket\Views\_ViewImports.cshtml"
using ShopMarket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#Projects\ShopMarket\ShopMarket\Views\_ViewImports.cshtml"
using ShopMarket.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd849c652278b41d05e3a7de46a4f1308aa727e4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b756740630bb4a94654630f01c4852c83997f0d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\C#Projects\ShopMarket\ShopMarket\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "صفحه اصلی";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row mb-4\">\r\n        ");
#nullable restore
#line 8 "D:\C#Projects\ShopMarket\ShopMarket\Views\Home\Index.cshtml"
   Write(await Component.InvokeAsync("MainPageSlider"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 9 "D:\C#Projects\ShopMarket\ShopMarket\Views\Home\Index.cshtml"
   Write(await Component.InvokeAsync("TopCategories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"row align-items-center mb-4\">\r\n        ");
#nullable restore
#line 12 "D:\C#Projects\ShopMarket\ShopMarket\Views\Home\Index.cshtml"
   Write(await Component.InvokeAsync("TopCategories",new{ skip = 2 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n       ");
#nullable restore
#line 13 "D:\C#Projects\ShopMarket\ShopMarket\Views\Home\Index.cshtml"
  Write(await Component.InvokeAsync("SpecialSells"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    ");
#nullable restore
#line 15 "D:\C#Projects\ShopMarket\ShopMarket\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("RandomCategoryProducts"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 16 "D:\C#Projects\ShopMarket\ShopMarket\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("MostVisited"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591