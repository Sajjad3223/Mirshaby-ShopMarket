#pragma checksum "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\RandomCategoryProducts\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b4edd29753f1d25b4a542ddddeda43b1d94b4a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RandomCategoryProducts_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RandomCategoryProducts/Default.cshtml")]
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
#line 1 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\RandomCategoryProducts\Default.cshtml"
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b4edd29753f1d25b4a542ddddeda43b1d94b4a8", @"/Views/Shared/Components/RandomCategoryProducts/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b756740630bb4a94654630f01c4852c83997f0d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RandomCategoryProducts_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ProductCard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<section class=\"product-carousel in-box\">\r\n    <div class=\"section-title\">\r\n        <i class=\"fad fa-pen-nib\"></i>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 296, "\"", 384, 2);
            WriteAttributeValue("", 303, "/home/search?categoryId=", 303, 24, true);
#nullable restore
#line 8 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\RandomCategoryProducts\Default.cshtml"
WriteAttributeValue("", 327, (ViewBag.Category as ShopCategoryViewModel).CategoryId, 327, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 9 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\RandomCategoryProducts\Default.cshtml"
        Write((ViewBag.Category as ShopCategoryViewModel).Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </a>\r\n    </div>\r\n    <div class=\"swiper-container slider-lg\">\r\n        <div class=\"swiper-wrapper\">\r\n");
#nullable restore
#line 14 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\RandomCategoryProducts\Default.cshtml"
             foreach (var product in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"swiper-slide\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2b4edd29753f1d25b4a542ddddeda43b1d94b4a85232", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 17 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\RandomCategoryProducts\Default.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = product;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 19 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\RandomCategoryProducts\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <!-- Add Arrows -->\r\n        <div class=\"swiper-button-next\"></div>\r\n        <div class=\"swiper-button-prev\"></div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
