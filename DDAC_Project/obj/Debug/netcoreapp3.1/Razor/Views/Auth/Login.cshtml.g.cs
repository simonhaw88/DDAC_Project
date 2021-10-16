#pragma checksum "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ac9f2cbba834b7e95f1a42ee5aeba2c0db1be9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Login), @"mvc.1.0.view", @"/Views/Auth/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ac9f2cbba834b7e95f1a42ee5aeba2c0db1be9f", @"/Views/Auth/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6332f3157a7ea529a54fe739f3bf4fb28b528672", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DDAC_Project.Models.User>
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
            WriteLiteral("<div class=\"container border border-2\">\r\n    <div class=\"d-flex p-3 m-4 justify-content-between md-2\">\r\n        <label class=\"label fs-3 fw-bold\">\r\n            Login\r\n        </label>\r\n    </div>\r\n</div>\r\n<div class=\"container-xl mt-5 ps-3 pe-3\">\r\n");
#nullable restore
#line 12 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
     using (Html.BeginForm("Login", "Auth", FormMethod.Post))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ac9f2cbba834b7e95f1a42ee5aeba2c0db1be9f3768", async() => {
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 16 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.Label("Email"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 17 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.TextBoxFor(m => m.Email,"", new {@class="form-control", @placeholder= "Enter email" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 18 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 22 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.Label("Password"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 23 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.PasswordFor(m => m.Password, new { @class = "form-control", @placeholder = "Password" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 24 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 27 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.Label("Role"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 28 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.DropDownListFor(model => model.Role, new SelectList(Enum.GetValues(typeof(UserEnum)).OfType<UserEnum>().Select(
                m => new { Text = m.ToString(), Value = (int)m }).ToList(), "Value", "Text"), "Select Role", new { @class = "form-control form-control-sm" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 30 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.ValidationMessageFor(m => m.Role, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 31 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
           Write(Html.ValidationMessage("Global", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </div>\r\n            <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n        ");
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
#line 36 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Auth\Login.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
