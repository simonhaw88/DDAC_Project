#pragma checksum "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79e198fbf93959fda2dfb80f487b30cd521e44aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Password), @"mvc.1.0.view", @"/Views/Auth/Password.cshtml")]
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
#line 1 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\_ViewImports.cshtml"
using DDAC_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\_ViewImports.cshtml"
using DDAC_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79e198fbf93959fda2dfb80f487b30cd521e44aa", @"/Views/Auth/Password.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a4660c087aad1d2de57759c0685d6b241e1a105", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_Password : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DDAC_Project.Models.User>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container shadow-lg p-3 mt-5"" style=""width:auto;max-width:500px;"">

    <div class=""container mt-2"">
        <div class=""d-flex p-2 m-1 justify-content-center md-2"">
            <label class=""label fs-1 fw-bolder nav-blue text-justify"">
                Change Password
            </label>
        </div>
    </div>
    <div class=""container-xl mt-5 ps-3 pe-3"">
");
#nullable restore
#line 13 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
         using (Html.BeginForm("editpassword", "Auth", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79e198fbf93959fda2dfb80f487b30cd521e44aa3928", async() => {
                WriteLiteral("\r\n            ");
#nullable restore
#line 16 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
       Write(Html.HiddenFor(m => m.UserId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                <label class=\"fw-bold fs-6\">Current Password:</label>\r\n                ");
#nullable restore
#line 19 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
           Write(Html.PasswordFor(m => m.Password, new { required = "required", @class = "form-control border border-dark mt-1 shadow", @placeholder = "Password" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 20 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
           Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
            <div class=""form-group mt-2 mb-2"">
                <label class=""fw-bold fs-6"">New Password:</label>
                <input type=""password"" required name=""newPassword"" class=""form-control border border-dark mt-1 shadow"" placeholder=""Enter new password"" />
                ");
#nullable restore
#line 25 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
           Write(Html.ValidationMessage("newPassword", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
            <div class=""form-group mt-2 mb-2"">
                <label class=""fw-bold fs-6"">Confirm New Password:</label>
                <input type=""password"" required name=""confirmNewPassword"" class=""form-control border border-dark mt-1 shadow"" placeholder=""Enter confirmed new password"" />
                ");
#nullable restore
#line 30 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
           Write(Html.ValidationMessage("confirmNewPassword", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            ");
#nullable restore
#line 32 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
       Write(Html.ValidationMessage("success", new { @class = "text-success" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 33 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
       Write(Html.ValidationMessage("fail", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            <div class=""row"">
                <div class=""d-flex p-2 m-1 justify-content-center md-2"">
                    <button type=""submit"" class=""btn rounded rounded-3 nav-bg-colour text-white fs-4 shadow-lg col col-7 mt-4"">Submit</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 40 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Password.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("       \r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DDAC_Project.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
