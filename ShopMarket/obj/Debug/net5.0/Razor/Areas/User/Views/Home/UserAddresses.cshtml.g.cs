#pragma checksum "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\Home\UserAddresses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c46d6dcee3bb352a8aab1946947fa1ed3d7ab8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Home_UserAddresses), @"mvc.1.0.view", @"/Areas/User/Views/Home/UserAddresses.cshtml")]
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
#line 1 "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\_ViewImports.cshtml"
using ShopMarket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\_ViewImports.cshtml"
using ShopMarket.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\Home\UserAddresses.cshtml"
using ShopMarket.Core.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c46d6dcee3bb352a8aab1946947fa1ed3d7ab8f", @"/Areas/User/Views/Home/UserAddresses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b756740630bb4a94654630f01c4852c83997f0d4", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_Home_UserAddresses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\Home\UserAddresses.cshtml"
  
    ViewData["Title"] = "آدرس ها";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""modal fade"" id=""Modal"" tabindex=""-1"" aria-labelledby=""editAddressModalLabel"" style=""display: none;"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""ModalTitle"">ویرایش آدرس</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
            </div>
            <div class=""modal-body"" id=""ModalBody"">
               
            </div>
        </div>
    </div>
</div>

<div class=""section-title mb-2"">
    نشانی‌ها
</div>
<div class=""checkout-section shadow-around"">
");
#nullable restore
#line 28 "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\Home\UserAddresses.cshtml"
         if (TempData["Result"]?.ToString() == "success")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-success\">\r\n                آدرس با موفقیت ثبت شد!\r\n            </div>\r\n");
#nullable restore
#line 33 "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\Home\UserAddresses.cshtml"
        }
        else if(TempData["Result"]?.ToString() == "fail")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-danger\">\r\n                در ثبت آدرس مشکلی پیش آمد!!!\r\n            </div>\r\n");
#nullable restore
#line 39 "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\Home\UserAddresses.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"checkout-section-content\">\r\n        ");
#nullable restore
#line 41 "D:\C#Projects\ShopMarket\ShopMarket\Areas\User\Views\Home\UserAddresses.cshtml"
   Write(await Component.InvokeAsync("UserAddresses",new
        {
            userId = Model
        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
