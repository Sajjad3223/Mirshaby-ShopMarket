#pragma checksum "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5876c2f7fc477f7ca3d7892bf3d46d73e8d6653"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_MostVisited_Default), @"mvc.1.0.view", @"/Views/Shared/Components/MostVisited/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5876c2f7fc477f7ca3d7892bf3d46d73e8d6653", @"/Views/Shared/Components/MostVisited/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b756740630bb4a94654630f01c4852c83997f0d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_MostVisited_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_HorizontalProductCard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml"
  
    int skip = 0;
    int loopCount = Model.Count() / 3;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row mb-5\">\r\n    <div class=\"col-12 mb-4\">\r\n        <div class=\"section-title\">\r\n            <i class=\"fad fa-sort-size-up-alt\"></i>\r\n            پربازدید ترین ها\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 13 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml"
         if (Model.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml"
             for (int i = 0; i < loopCount; i++)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml"
                 foreach (var product in Model.Skip(skip).Take(3))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-4\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d5876c2f7fc477f7ca3d7892bf3d46d73e8d66534817", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 20 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml"
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
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 22 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml"
                    skip++;
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\Components\MostVisited\Default.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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