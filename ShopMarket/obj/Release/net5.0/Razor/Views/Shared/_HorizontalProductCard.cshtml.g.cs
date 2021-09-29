#pragma checksum "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cedad5e2e0f3234556fa9ecdb4d409a390f755a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__HorizontalProductCard), @"mvc.1.0.view", @"/Views/Shared/_HorizontalProductCard.cshtml")]
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
#line 1 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
using ShopMarket.Core.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cedad5e2e0f3234556fa9ecdb4d409a390f755a3", @"/Views/Shared/_HorizontalProductCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b756740630bb4a94654630f01c4852c83997f0d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__HorizontalProductCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels.ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-add-to-cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
  
    var price = PriceCalculator.CalculateDiscountPrice(Model.Price, Model.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"product-card product-card-horizontal border-bottom\">\r\n    <div class=\"product-card-top\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 324, "\"", 368, 4);
            WriteAttributeValue("", 331, "/Product/", 331, 9, true);
#nullable restore
#line 8 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
WriteAttributeValue("", 340, Model.ProductId, 340, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 356, "/", 356, 1, true);
#nullable restore
#line 8 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
WriteAttributeValue("", 357, Model.Slug, 357, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"product-image\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 410, "\"", 477, 1);
#nullable restore
#line 9 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
WriteAttributeValue("", 416, Directories.GetProductImage(Model.MainImage,Model.ProductId), 416, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"product image\">\r\n        </a>\r\n");
#nullable restore
#line 11 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
         if (User.Identity.IsAuthenticated)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"product-card-actions\">\r\n                <button class=\"add-to-wishlist\"");
            BeginWriteAttribute("onclick", " onclick=\"", 666, "\"", 707, 3);
            WriteAttributeValue("", 676, "AddToWishlist(", 676, 14, true);
#nullable restore
#line 14 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
WriteAttributeValue("", 690, Model.ProductId, 690, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 706, ")", 706, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-heart\"></i></button>\r\n            </div>\r\n");
#nullable restore
#line 16 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"product-card-middle\">\r\n        <div class=\"ratings-container\">\r\n            <div class=\"ratings\">\r\n                <div class=\"ratings-val\"");
            BeginWriteAttribute("style", " style=\"", 946, "\"", 977, 3);
            WriteAttributeValue("", 954, "width:", 954, 6, true);
#nullable restore
#line 21 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
WriteAttributeValue(" ", 960, Model.Score, 961, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 975, "%;", 975, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n            </div>\r\n        </div>\r\n        <h6 class=\"product-name\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1072, "\"", 1116, 4);
            WriteAttributeValue("", 1079, "/Product/", 1079, 9, true);
#nullable restore
#line 25 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
WriteAttributeValue("", 1088, Model.ProductId, 1088, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1104, "/", 1104, 1, true);
#nullable restore
#line 25 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
WriteAttributeValue("", 1105, Model.Slug, 1105, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 25 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
                                                        Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n        </h6>\r\n        <div class=\"product-price product-price-clone\">");
#nullable restore
#line 27 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
                                                  Write(price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</div>\r\n    </div>\r\n    <div class=\"product-card-bottom\">\r\n        <div class=\"product-price\">\r\n            ");
#nullable restore
#line 31 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
       Write(price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان\r\n        </div>\r\n");
#nullable restore
#line 33 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
         if (User.Identity.IsAuthenticated)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
             if (Model.Remaining > 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 1486, "\"", 1493, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-add-to-cart\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1518, "\"", 1555, 3);
            WriteAttributeValue("", 1528, "AddToCart(", 1528, 10, true);
#nullable restore
#line 37 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
WriteAttributeValue("", 1538, Model.ProductId, 1538, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1554, ")", 1554, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <i class=\"fad fa-cart-plus\"></i>\r\n                    افزودن به سبد خرید\r\n                </a>\r\n");
#nullable restore
#line 41 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 1741, "\"", 1748, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-add-to-cart btn-danger bg-danger\">\r\n                    <i class=\"fad fa-cart-plus\"></i>\r\n                    درانبار موجود نیست\r\n                </a>\r\n");
#nullable restore
#line 48 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cedad5e2e0f3234556fa9ecdb4d409a390f755a312089", async() => {
                WriteLiteral("\r\n                برای خرید وارد شوید\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
            WriteLiteral("\r\n");
#nullable restore
#line 55 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_HorizontalProductCard.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
