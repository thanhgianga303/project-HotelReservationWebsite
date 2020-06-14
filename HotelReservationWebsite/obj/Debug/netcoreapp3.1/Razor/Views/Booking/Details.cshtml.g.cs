#pragma checksum "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "525c65da589ae66b186cc713192f59f6cf02d768"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking_Details), @"mvc.1.0.view", @"/Views/Booking/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"525c65da589ae66b186cc713192f59f6cf02d768", @"/Views/Booking/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24568e5d181a623e84ea2790a3202d4b0bb05c6c", @"/Views/_ViewImports.cshtml")]
    public class Views_Booking_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Booking>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Booking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""col-md-12"">
        <div class=""row"">
            <div class=""col-md-3""><hr style=""height:1px;border:none;color:#333;background-color:#333;""/></div>
            <div class=""col-md-6"" style=""text-align: center;""><h1>Details of the reservation list have id ");
#nullable restore
#line 7 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                                                                                     Write(Model.BookingId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h1></div>
            <div class=""col-md-3""><hr style=""height:1px;border:none;color:#333;background-color:#333;""/></div>
        </div>
        <div class=""row"">
            <div class=""col-md-12"">
                <table class=""table table-dark"">
                    <thead>
                        <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Booking ID</th>
                        <th scope=""col"">Name</th>
                        <th scope=""col"">Phone</th>
                        <th scope=""col"">Identity Card</th>
                        <th scope=""col"">Booking Date</th>
                        <th scope=""col"">Status</th>
                        <th scope=""col"">Total cost</th>
                        <th scope=""col"">Operation</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                        <th scope=""row"">1</th>
                        <td>");
#nullable restore
#line 29 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                       Write(Model.BookingId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                       Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                       Write(Model.IdentityCard);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                       Write(Model.BookingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                       Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                       Write(Model.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "525c65da589ae66b186cc713192f59f6cf02d7688446", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                        </tr> \r\n                    </tbody>\r\n                    </table>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 42 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
             foreach (var item in Model.Items)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"col-md-4\"><img");
            BeginWriteAttribute("src", " src=\"", 1996, "\"", 2016, 1);
#nullable restore
#line 45 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
WriteAttributeValue("", 2002, item.ImageUri, 2002, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""266.6px"" height=""300px"" /></div>
                    <div class=""col-md-4"">
                        <div class=""row"">
                            <div class=""col-md-6""><h3>Hotel name:</h3></div>
                            <div class=""col-md-6"">");
#nullable restore
#line 49 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.HotelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Room name:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 53 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.RoomName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Room number:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 57 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.RoomNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Address:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 61 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 61 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                                            Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Category name:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 65 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                        </div>
                        
                    </div>
                    <div class=""col-md-4"">
                        <div class=""row"">
                            <div class=""col-md-6""><h3>Check in:</h3></div>
                            <div class=""col-md-6"">");
#nullable restore
#line 72 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.CheckIn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Check out:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 76 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.CheckOut);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Unit price:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 80 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" USD</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Day number:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 84 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.DayNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Cost:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 88 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
                                             Write(item.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 92 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\Details.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Booking> Html { get; private set; }
    }
}
#pragma warning restore 1591
