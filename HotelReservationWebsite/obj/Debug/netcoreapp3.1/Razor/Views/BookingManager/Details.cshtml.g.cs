#pragma checksum "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe43dc800308a20462d97d479a0101fd4a658a14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BookingManager_Details), @"mvc.1.0.view", @"/Views/BookingManager/Details.cshtml")]
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
#line 1 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.Services.IService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.Services.Service;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\_ViewImports.cshtml"
using HotelReservationWebsite.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe43dc800308a20462d97d479a0101fd4a658a14", @"/Views/BookingManager/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24568e5d181a623e84ea2790a3202d4b0bb05c6c", @"/Views/_ViewImports.cshtml")]
    public class Views_BookingManager_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Booking>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BookingManager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
  
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
             foreach (var item in Model.Items)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""row"">
                    <div class=""col-md-3""><hr/></div>
                    <div class=""col-md-6"" >
                        <div style=""text-align:center"">
                            <h1 class=""title-1 m-b-25"">Hotel reservation details ");
#nullable restore
#line 12 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                            Write(item.HotelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-3\"><hr/></div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-4\"><img");
            BeginWriteAttribute("src", " src=\"", 655, "\"", 675, 1);
#nullable restore
#line 18 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
WriteAttributeValue("", 661, item.ImageUri, 661, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""266.6px"" height=""300px"" /></div>
                    <div class=""col-md-8"">
                        <div class=""row"">
                            <div class=""col-md-6""><h1>Full name:</h1></div>
                            <div class=""col-md-6"">");
#nullable restore
#line 22 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                             Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h1>Phone:</h1></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 26 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                             Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h1>Identity card:</h1></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 30 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                             Write(Model.IdentityCard);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h1>Booking date:</h1></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 34 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                             Write(Model.BookingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        \r\n                    </div>\r\n                </div>\r\n");
            WriteLiteral(@"                <div class=""row shadow p-3 mb-5 bg-white rounded"" style=""margin-top:20px"">
                    <div class=""col-md-6"">
                        <div class=""row"">
                            <div class=""col-md-7""><h1>Hotel name:</h1></div>
                            <div class=""col-md-5"" style=""font-size:25px"">");
#nullable restore
#line 45 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.HotelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-7\"><h1>Room name:</h1></div>\r\n                            <div class=\"col-md-5\" style=\"font-size:25px\">");
#nullable restore
#line 49 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.RoomName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-7\"><h1>Room number:</h1></div>\r\n                            <div class=\"col-md-5\" style=\"font-size:25px\">");
#nullable restore
#line 53 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.RoomNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-7\"><h1>Address:</h1></div>\r\n                            <div class=\"col-md-5\" style=\"font-size:25px\">");
#nullable restore
#line 57 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 57 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                                   Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-7\"><h1>Category name:</h1></div>\r\n                            <div class=\"col-md-5\" style=\"font-size:25px\">");
#nullable restore
#line 61 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                        </div>
                        
                    </div>
                    <div class=""col-md-6"">
                        <div class=""row"">
                            <div class=""col-md-7""><h1>Check in:</h1></div>
                            <div class=""col-md-5"" style=""font-size:25px"">");
#nullable restore
#line 68 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.CheckIn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-7\"><h1>Check out:</h1></div>\r\n                            <div class=\"col-md-5\" style=\"font-size:25px\">");
#nullable restore
#line 72 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.CheckOut);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-7\"><h1>Unit price:</h1></div>\r\n                            <div class=\"col-md-5\" style=\"font-size:25px\">");
#nullable restore
#line 76 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" USD</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-7\"><h1>Day number:</h1></div>\r\n                            <div class=\"col-md-5\" style=\"font-size:25px\">");
#nullable restore
#line 80 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.DayNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-7\"><h1>Cost:</h1></div>\r\n                            <div class=\"col-md-5\" style=\"font-size:25px\">");
#nullable restore
#line 84 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                    Write(item.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe43dc800308a20462d97d479a0101fd4a658a1415069", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
                                                                                                                             WriteLiteral(Int32.Parse(item.HotelId));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                </div>\r\n");
#nullable restore
#line 91 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\BookingManager\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            \r\n");
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
