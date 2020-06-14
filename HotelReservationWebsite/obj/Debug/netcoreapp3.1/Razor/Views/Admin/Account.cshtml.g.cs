#pragma checksum "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Admin\Account.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed2871ecf1093021b5a817d426f45bb31932a8a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Account), @"mvc.1.0.view", @"/Views/Admin/Account.cshtml")]
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
#line 1 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.Services.IService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.Services.Service;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed2871ecf1093021b5a817d426f45bb31932a8a4", @"/Views/Admin/Account.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24568e5d181a623e84ea2790a3202d4b0bb05c6c", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Account : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Admin\Account.cshtml"
  
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-12"">
        <div class=""overview-wrap"">
            <h2 class=""title-1"">overview</h2>
            <button class=""au-btn au-btn-icon au-btn--blue"">
                <i class=""zmdi zmdi-plus""></i>add item</button>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-lg-12"">
        <h2 class=""title-1 m-b-25"">Account</h2>
        <div class=""table-responsive table--no-card m-b-40"">
            <table class=""table table-borderless table-striped table-earning"">
                <thead>
                    <tr>
                        <th>date</th>
                        <th>order ID</th>
                        <th>name</th>
                        <th class=""text-right"">price</th>
                        <th class=""text-right"">quantity</th>
                        <th class=""text-right"">total</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>2018-0");
            WriteLiteral(@"9-29 05:57</td>
                        <td>100398</td>
                        <td>iPhone X 64Gb Grey</td>
                        <td class=""text-right"">$999.00</td>
                        <td class=""text-right"">1</td>
                        <td class=""text-right"">$999.00</td>
                    </tr>
                    <tr>
                        <td>2018-09-28 01:22</td>
                        <td>100397</td>
                        <td>Samsung S8 Black</td>
                        <td class=""text-right"">$756.00</td>
                        <td class=""text-right"">1</td>
                        <td class=""text-right"">$756.00</td>
                    </tr>
                    <tr>
                        <td>2018-09-27 02:12</td>
                        <td>100396</td>
                        <td>Game Console Controller</td>
                        <td class=""text-right"">$22.00</td>
                        <td class=""text-right"">2</td>
                        <td class=""text-right");
            WriteLiteral(@""">$44.00</td>
                    </tr>
                    <tr>
                        <td>2018-09-26 23:06</td>
                        <td>100395</td>
                        <td>iPhone X 256Gb Black</td>
                        <td class=""text-right"">$1199.00</td>
                        <td class=""text-right"">1</td>
                        <td class=""text-right"">$1199.00</td>
                    </tr>
                    <tr>
                        <td>2018-09-25 19:03</td>
                        <td>100393</td>
                        <td>USB 3.0 Cable</td>
                        <td class=""text-right"">$10.00</td>
                        <td class=""text-right"">3</td>
                        <td class=""text-right"">$30.00</td>
                    </tr>
                    <tr>
                        <td>2018-09-29 05:57</td>
                        <td>100392</td>
                        <td>Smartwatch 4.0 LTE Wifi</td>
                        <td class=""text-right"">$199.00</td>");
            WriteLiteral(@"
                        <td class=""text-right"">6</td>
                        <td class=""text-right"">$1494.00</td>
                    </tr>
                    <tr>
                        <td>2018-09-24 19:10</td>
                        <td>100391</td>
                        <td>Camera C430W 4k</td>
                        <td class=""text-right"">$699.00</td>
                        <td class=""text-right"">1</td>
                        <td class=""text-right"">$699.00</td>
                    </tr>
                    <tr>
                        <td>2018-09-22 00:43</td>
                        <td>100393</td>
                        <td>USB 3.0 Cable</td>
                        <td class=""text-right"">$10.00</td>
                        <td class=""text-right"">3</td>
                        <td class=""text-right"">$30.00</td>
                    </tr>
                </tbody>
            </table>
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
