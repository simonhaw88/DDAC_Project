#pragma checksum "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09054968ec72461108f07afdc89b450727893ab7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Edit), @"mvc.1.0.view", @"/Views/Admin/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09054968ec72461108f07afdc89b450727893ab7", @"/Views/Admin/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a4660c087aad1d2de57759c0685d6b241e1a105", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DDAC_Project.Models.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/admin/profile.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09054968ec72461108f07afdc89b450727893ab74279", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"<div class=""container shadow-lg p-3 mt-5"" style=""width:auto;max-width:800px;"">

    <div class=""container mt-2"">
        <div class=""container p-4"">
            <div class=""row"">
                <h2 class=""fw-bolder"">Edit Admin's Profile</h2>
            </div>
        </div>
");
#nullable restore
#line 14 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
         using (Html.BeginForm("PostEdit", "Admin", FormMethod.Post))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
       Write(Html.HiddenFor(m => m.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 18 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Email, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 19 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter email address" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 20 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 23 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.FirstName, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 24 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Admin.FirstName, "", new { @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter first name" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 25 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.FirstName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 28 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.LastName, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 29 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Admin.LastName, new { @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter last name" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 30 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.LastName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 33 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.ContactNo, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 34 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Admin.ContactNo, "", new { @type = "number", @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter contact number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 35 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.ContactNo, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 39 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.DateOfBirth, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 40 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.EditorFor(m => m.Admin.DateOfBirth, new { htmlAttributes = new { @class = "form-control border border-dark mt-1 shadow" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 41 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.DateOfBirth, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 45 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.Gender, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <select class=\"form-control border border-dark mt-1 shadow\" name=\"Gender\">\r\n");
#nullable restore
#line 47 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
                     if (Model.Admin.Gender == 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09054968ec72461108f07afdc89b450727893ab712313", async() => {
                WriteLiteral("Male");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09054968ec72461108f07afdc89b450727893ab713806", async() => {
                WriteLiteral("Female");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 51 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
                    }
                    else if (Model.Admin.Gender == 2)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09054968ec72461108f07afdc89b450727893ab715281", async() => {
                WriteLiteral("Male");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09054968ec72461108f07afdc89b450727893ab716463", async() => {
                WriteLiteral("Female");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 56 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09054968ec72461108f07afdc89b450727893ab718220", async() => {
                WriteLiteral("Male");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09054968ec72461108f07afdc89b450727893ab719402", async() => {
                WriteLiteral("Female");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 61 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n                ");
#nullable restore
#line 63 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.Gender, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"row mt-3\">\r\n                <h2>Address</h2>\r\n            </div>\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 70 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.Address.Line, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 71 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Admin.Address.Line, "", new { @type = "text", @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter address's line" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 72 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.Address.Line, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 75 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.Address.City, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 76 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Admin.Address.City, "", new { @type = "text", @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter city" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 77 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.Address.City, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 80 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.Address.Region, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 81 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Admin.Address.Region, "", new { @type = "text", @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter region" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 82 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.Address.Region, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 85 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.Address.PostCode, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 86 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Admin.Address.PostCode, "", new { @type = "number", @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter post code" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 87 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.Address.PostCode, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group mt-2 mb-2\">\r\n                ");
#nullable restore
#line 90 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.LabelFor(m => m.Admin.Address.Country, new { @class = "fw-bold fs-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 91 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.TextBoxFor(m => m.Admin.Address.Country, "", new { @type = "text", @class = "form-control border border-dark mt-1 shadow", @placeholder = "Enter country" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 92 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.Admin.Address.Country, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"mt-3\">\r\n                <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n            </div>\r\n");
#nullable restore
#line 97 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
       Write(Html.ValidationMessage("fail", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Admin\Edit.cshtml"
                                                                           


        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
