#pragma checksum "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_ForgetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c938277151e229688aa1a96580423780ceac586c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ForgetPassword), @"mvc.1.0.view", @"/Views/Shared/_ForgetPassword.cshtml")]
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
#line 1 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_ForgetPassword.cshtml"
using ShopMarket.Core.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c938277151e229688aa1a96580423780ceac586c", @"/Views/Shared/_ForgetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b756740630bb4a94654630f01c4852c83997f0d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ForgetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopMarket.Core.ViewModels.UserViewModels.UserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div style=\"padding: 20px\">\r\n    <h1> ");
#nullable restore
#line 5 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_ForgetPassword.cshtml"
    Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ???????? !!!</h1>\r\n\r\n    <p>\r\n        ???????? ?????????? ?????? ???????? ?????? ???? ???????? ?????? ?????????????? ????????\r\n    </p>\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 254, "\"", 330, 1);
#nullable restore
#line 10 "D:\C#Projects\ShopMarket\ShopMarket\Views\Shared\_ForgetPassword.cshtml"
WriteAttributeValue("", 261, $"{Directories.DOMAIN}userpanel/verify-account/{Model.ActiveCode}", 261, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" > ???????? ???????? ???????? ????????????</a>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopMarket.Core.ViewModels.UserViewModels.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
