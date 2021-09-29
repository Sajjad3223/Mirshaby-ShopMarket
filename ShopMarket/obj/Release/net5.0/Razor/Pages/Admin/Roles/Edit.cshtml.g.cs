#pragma checksum "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85b421a0686efe7fa80d7d858748a0402290c7e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Admin_Roles_Edit), @"mvc.1.0.razor-page", @"/Pages/Admin/Roles/Edit.cshtml")]
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
#line 1 "D:\C#Projects\ShopMarket\ShopMarket\Pages\_ViewImports.cshtml"
using ShopMarket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#Projects\ShopMarket\ShopMarket\Pages\_ViewImports.cshtml"
using ShopMarket.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
using ShopMarket.Domain.UserEntities.Permissions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85b421a0686efe7fa80d7d858748a0402290c7e3", @"/Pages/Admin/Roles/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b756740630bb4a94654630f01c4852c83997f0d4", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Roles_Edit : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("عنوان دسترسی"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row match-height"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
  
    ViewData["Title"] = "ویرایش نقش ";
    ViewData["page"] = "roles";
    ViewData["sub-page"] = "roles";
    IEnumerable<Permission> permissions = ViewData["Permissions"] as IEnumerable<Permission>;
    IEnumerable<int> selectedPermissions = ViewData["SelectedPermissions"] as IEnumerable<int>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85b421a0686efe7fa80d7d858748a0402290c7e36013", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85b421a0686efe7fa80d7d858748a0402290c7e36275", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 13 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Role.RoleId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85b421a0686efe7fa80d7d858748a0402290c7e37971", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 14 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Role.IsDelete);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <div class=""col-md-6 col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">مشخات نقش</h4>
            </div>
            <div class=""card-content"">
                <div class=""card-body row"">
                    <div class=""form-group col-12"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85b421a0686efe7fa80d7d858748a0402290c7e310017", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 23 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Role.RoleTitle);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "85b421a0686efe7fa80d7d858748a0402290c7e311527", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 24 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Role.RoleTitle);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85b421a0686efe7fa80d7d858748a0402290c7e313206", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 25 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Role.RoleTitle);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                    <div class=""col-12"">
                        <button class=""btn btn-primary"">ویرایش نقش</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">دسترسی ها</h4>
            </div>
            <div class=""card-content"">
                <div class=""card-body"">
                    <ul>
");
#nullable restore
#line 42 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                         foreach (var permission in permissions.Where(p => p.ParentID == null))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <li>\r\n                                <input type=\"checkbox\" name=\"SelectedPermissions\"");
                BeginWriteAttribute("value", " value=\"", 1904, "\"", 1936, 1);
#nullable restore
#line 45 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
WriteAttributeValue("", 1912, permission.PermissionId, 1912, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" ");
#nullable restore
#line 45 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                                                                               Write(selectedPermissions.Any(p=>p == permission.PermissionId)? "checked":"");

#line default
#line hidden
#nullable disable
                WriteLiteral("/>");
#nullable restore
#line 45 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                                                                                                                                                         Write(permission.PermissionTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 46 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                 if (permissions.Any(p => p.ParentID == permission.PermissionId))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <ul>\r\n");
#nullable restore
#line 49 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                         foreach (var subPermission in permissions.Where(p => p.ParentID == permission.PermissionId))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <li>\r\n                                                <input type=\"checkbox\" name=\"SelectedPermissions\"");
                BeginWriteAttribute("value", " value=\"", 2543, "\"", 2578, 1);
#nullable restore
#line 52 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
WriteAttributeValue("", 2551, subPermission.PermissionId, 2551, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" ");
#nullable restore
#line 52 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                                                                                                  Write(selectedPermissions.Any(p=>p == subPermission.PermissionId)? "checked":"");

#line default
#line hidden
#nullable disable
                WriteLiteral("/>");
#nullable restore
#line 52 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                                                                                                                                                                               Write(subPermission.PermissionTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 53 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                 if (permissions.Any(p => p.ParentID == subPermission.PermissionId))
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <ul>\r\n");
#nullable restore
#line 56 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                         foreach (var per in permissions.Where(p => p.ParentID == subPermission.PermissionId))
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <li>\r\n                                                                <input type=\"checkbox\" name=\"SelectedPermissions\"");
                BeginWriteAttribute("value", " value=\"", 3299, "\"", 3324, 1);
#nullable restore
#line 59 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
WriteAttributeValue("", 3307, per.PermissionId, 3307, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" ");
#nullable restore
#line 59 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                                                                                                        Write(selectedPermissions.Any(p=>p == per.PermissionId)? "checked":"");

#line default
#line hidden
#nullable disable
                WriteLiteral("/>");
#nullable restore
#line 59 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                                                                                                                                                                           Write(per.PermissionTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                            </li>\r\n");
#nullable restore
#line 61 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    </ul>\r\n");
#nullable restore
#line 63 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            </li>\r\n");
#nullable restore
#line 65 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </ul>\r\n");
#nullable restore
#line 67 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </li>\r\n");
#nullable restore
#line 69 "D:\C#Projects\ShopMarket\ShopMarket\Pages\Admin\Roles\Edit.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopMarket.Pages.Admin.Roles.EditModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShopMarket.Pages.Admin.Roles.EditModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShopMarket.Pages.Admin.Roles.EditModel>)PageContext?.ViewData;
        public ShopMarket.Pages.Admin.Roles.EditModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
