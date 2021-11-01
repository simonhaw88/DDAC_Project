#pragma checksum "C:\Users\User\Documents\DDAC_Project\DDAC_Project\Views\Orders\OrdersConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a502f0d938abf1812f499c02f7e74051115afaec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_OrdersConfirmation), @"mvc.1.0.view", @"/Views/Orders/OrdersConfirmation.cshtml")]
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
#line 1 "C:\Users\User\Documents\DDAC_Project\DDAC_Project\Views\_ViewImports.cshtml"
using DDAC_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Documents\DDAC_Project\DDAC_Project\Views\_ViewImports.cshtml"
using DDAC_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a502f0d938abf1812f499c02f7e74051115afaec", @"/Views/Orders/OrdersConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a4660c087aad1d2de57759c0685d6b241e1a105", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_OrdersConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container mt-5 mb-5"">
    <div class=""row d-flex justify-content-center"">
        <div class=""col-md-8"">
            <div class=""card"">
                <div class=""text-left logo p-2 px-5""> <img src=""https://i.imgur.com/2zDU056.png"" width=""50""> </div>
                <div class=""invoice p-5"">
                    <h5>Your order Confirmed!</h5> <span class=""font-weight-bold d-block mt-4"">Hello, Calvin</span> <span>You order has been confirmed</span>
                    <div class=""payment border-top mt-3 mb-3 border-bottom table-responsive"">
                        <table class=""table table-borderless"">
                            <tbody>
                                <tr>
                                    <td>
                                        <div class=""py-2""> <span class=""d-block text-muted"">Order Date</span> <span>12 Jan,2018</span> </div>
                                    </td>
                                    <td>
                                        <div class=""py-2""> <span");
            WriteLiteral(@" class=""d-block text-muted"">Order No</span> <span>MT12332345</span> </div>
                                    </td>
                                    <td>
                                        <div class=""py-2""> <span class=""d-block text-muted"">Payment</span> <span><img src=""https://img.icons8.com/color/48/000000/mastercard.png"" width=""20"" /></span> </div>
                                    </td>
                                    <td>
                                        <div class=""py-2""> <span class=""d-block text-muted"">Shiping Address</span> <span>414 Advert Avenue, NY,USA</span> </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class=""product border-bottom table-responsive"">
                        <table class=""table table-borderless"">
                            <tbody>
                                <tr>
                              ");
            WriteLiteral(@"      <td width=""20%""> <img src=""https://i.imgur.com/u11K1qd.jpg"" width=""90""> </td>
                                    <td width=""60%"">
                                        <div class=""product-qty""> <span class=""d-block"">Quantity:1</span> <span>Color:Dark</span> </div>
                                    </td>
                                    <td width=""20%"">
                                        <div class=""text-right""> <span class=""font-weight-bold"">$67.50</span> </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td width=""20%""> <img src=""https://i.imgur.com/SmBOua9.jpg"" width=""70""> </td>
                                    <td width=""60%"">
                                        <span class=""font-weight-bold"">Album 2</span>
                                        <div class=""product-qty""> <span class=""d-block"">Quantity:1</span> <span>Color:Orange</span> </div>
                             ");
            WriteLiteral(@"       </td>
                                    <td width=""20%"">
                                        <div class=""text-right""> <span class=""font-weight-bold"">$77.50</span> </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class=""row d-flex justify-content-end"">
                        <div class=""col-md-5"">
                            <table class=""table table-borderless"">
                                <tbody class=""totals"">
                                    <tr>
                                        <td>
                                            <div class=""text-left""> <span class=""text-muted"">Subtotal</span> </div>
                                        </td>
                                        <td>
                                            <div class=""text-right""> <span>$30.0</span> </div>
                                        </");
            WriteLiteral(@"td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class=""text-left""> <span class=""text-muted"">Shipping Fee</span> </div>
                                        </td>
                                        <td>
                                            <div class=""text-right""> <span>$22</span> </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class=""text-left""> <span class=""text-muted"">Tax Fee</span> </div>
                                        </td>
                                        <td>
                                            <div class=""text-right""> <span>$7.65</span> </div>
                                        </td>
                                    </tr>
                         ");
            WriteLiteral(@"           <tr>
                                        <td>
                                            <div class=""text-left""> <span class=""text-muted"">Discount</span> </div>
                                        </td>
                                        <td>
                                            <div class=""text-right""> <span class=""text-success"">$168.50</span> </div>
                                        </td>
                                    </tr>
                                    <tr class=""border-top border-bottom"">
                                        <td>
                                            <div class=""text-left""> <span class=""font-weight-bold"">Subtotal</span> </div>
                                        </td>
                                        <td>
                                            <div class=""text-right""> <span class=""font-weight-bold"">$238.50</span> </div>
                                        </td>
                                    </tr>
        ");
            WriteLiteral(@"                        </tbody>
                            </table>
                        </div>
                    </div>
                    <p>We will be sending shipping confirmation email when the item shipped successfully!</p>
                    <p class=""font-weight-bold mb-0"">Thanks for shopping with us!</p> <span>Nike Team</span>
                </div>
                <div class=""d-flex justify-content-between footer p-3""> <span>Need Help? visit our <a href=""#""> help center</a></span> <span>12 June, 2020</span> </div>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
