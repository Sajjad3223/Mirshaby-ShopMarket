#pragma checksum "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46821e72ef9ceb9594ea094de85fb100f39e1cf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_LikedProduct_Default), @"mvc.1.0.view", @"/Views/Shared/Components/LikedProduct/Default.cshtml")]
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
#nullable restore
#line 1 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
using ShopMarket.Core.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46821e72ef9ceb9594ea094de85fb100f39e1cf2", @"/Views/Shared/Components/LikedProduct/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b756740630bb4a94654630f01c4852c83997f0d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_LikedProduct_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels.LikedProductViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"col-12 mb-4\">\r\n    <div class=\"product-list-section\">\r\n        <div class=\"product-thumbnail\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 250, "\"", 294, 4);
            WriteAttributeValue("", 257, "/product/", 257, 9, true);
#nullable restore
#line 8 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
WriteAttributeValue("", 266, Model.ProductId, 266, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 282, "/", 282, 1, true);
#nullable restore
#line 8 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
WriteAttributeValue("", 283, Model.Slug, 283, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 318, "\"", 391, 1);
#nullable restore
#line 9 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
WriteAttributeValue("", 324, Directories.GetProductImage(Model.MainImageName,Model.ProductId), 324, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"product title\">\r\n            </a>\r\n        </div>\r\n        <div class=\"product-info\">\r\n            <div class=\"product-title\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 544, "\"", 588, 4);
            WriteAttributeValue("", 551, "/product/", 551, 9, true);
#nullable restore
#line 14 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
WriteAttributeValue("", 560, Model.ProductId, 560, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 576, "/", 576, 1, true);
#nullable restore
#line 14 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
WriteAttributeValue("", 577, Model.Slug, 577, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
#nullable restore
#line 15 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </a>\r\n            </div>\r\n            <div class=\"text-danger\">\r\n                ");
#nullable restore
#line 19 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
           Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <span class=\"text-sm\">??????????</span>\r\n            </div>\r\n            <button class=\"remove-item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 848, "\"", 887, 3);
            WriteAttributeValue("", 858, "AddToWishlist(", 858, 14, true);
#nullable restore
#line 22 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\LikedProduct\Default.cshtml"
WriteAttributeValue("", 872, Model.LikedId, 872, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 886, ")", 886, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"far fa-trash-alt\"></i>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels.LikedProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
