#pragma checksum "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d333bf3418e23363de8d8e458e3490dc532777f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Album_Create), @"mvc.1.0.view", @"/Views/Album/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d333bf3418e23363de8d8e458e3490dc532777f", @"/Views/Album/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a4660c087aad1d2de57759c0685d6b241e1a105", @"/Views/_ViewImports.cshtml")]
    public class Views_Album_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DDAC_Project.Models.Album>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/album/create.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d333bf3418e23363de8d8e458e3490dc532777f4517", async() => {
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
            WriteLiteral("<div class=\"container p-4 border border-2\">\r\n    <div class=\"row border border-2\">\r\n        <h3>Create Album</h3>\r\n    </div>\r\n");
#nullable restore
#line 13 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
     using (Html.BeginForm("Create", "Album", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 17 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 18 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.TextBoxFor(m => m.Name, "", new { @class = "form-control", @placeholder = "Enter album's name" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 19 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 22 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("Description"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 23 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.TextAreaFor(m => m.Description, new { @class = "form-control", @placeholder = "Enter album's description" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 24 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.Description, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 27 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("Price"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 28 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.TextBoxFor(m => m.Price, "", new { @type = "number", @step = "0.01", @class = "form-control", @placeholder = "Enter album's price" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 29 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.Price, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 33 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("Quantity"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 34 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.TextBoxFor(m => m.Stock, "", new { @type = "number", @class = "form-control", @placeholder = "Enter album's stock" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 35 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.Stock, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 39 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("CountryOfOrigin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 40 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.DropDownListFor(model => model.CountryOfOrigin, new SelectList(Enum.GetValues(typeof(CountryEnum)).OfType<CountryEnum>().Select(
            m => new { Text = m.ToString(), Value = m.ToString() }).ToList(), "Value", "Text"), "Select Country", new { @class = "form-control form-control-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 42 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.CountryOfOrigin, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 45 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("ReleaseDate"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 46 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.TextBoxFor(m => m.ReleaseDate, "", new { @type = "date", @class = "form-control", @placeholder = "Enter album's release date" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 47 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.ReleaseDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 50 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("Category"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <select class=\"form-control\" name=\"AlbumCategoryId\">\r\n");
#nullable restore
#line 52 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
                 if (ViewBag.AlbumCategory != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
                     foreach (var category in ViewBag.AlbumCategory)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d333bf3418e23363de8d8e458e3490dc532777f12999", async() => {
#nullable restore
#line 56 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
                                                             Write(category.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
                           WriteLiteral(category.AlbumCategoryId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 57 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\r\n            ");
#nullable restore
#line 60 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.AlbumCategoryId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 63 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("Author"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 64 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.TextBoxFor(m => m.Author, "", new { @class = "form-control", @placeholder = "Enter artist's name" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 65 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.Author, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 68 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("FormFile"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d333bf3418e23363de8d8e458e3490dc532777f16833", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 69 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.FormFile);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </div>\r\n        <div class=\"row border border-2 mt-3\">\r\n            <h3>Tracks</h3>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 76 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.Label("Track.Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"row track-row\">\r\n                <div class=\"col col-11 mt-2 track\">\r\n                    ");
#nullable restore
#line 79 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
               Write(Html.TextBoxFor(m => m.TrackNames, "", new { @class = "form-control track-input", @placeholder = "Enter track's name" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"col col-1 mt-2 track-action\">\r\n                    <i class=\"fas fa-plus\" id=\"add-track\" style=\"cursor: pointer;\"></i> \r\n                </div>\r\n            </div>\r\n            ");
#nullable restore
#line 86 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.TrackNames, "", new { @class = "text-danger " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div> \r\n");
            WriteLiteral("            <div class=\"mt-3\">\r\n                <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n            </div>\r\n");
#nullable restore
#line 92 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessage("fail", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
       Write(Html.ValidationMessage("success", new { @class = "text-success" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Users\simon\source\repos\DDAC_Project\DDAC_Project\Views\Album\Create.cshtml"
                                                                               


            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DDAC_Project.Models.Album> Html { get; private set; }
    }
}
#pragma warning restore 1591
