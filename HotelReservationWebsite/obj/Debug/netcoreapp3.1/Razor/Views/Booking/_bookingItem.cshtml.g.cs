#pragma checksum "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "daf13c27494e1417a65895e943011db2011c0f0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking__bookingItem), @"mvc.1.0.view", @"/Views/Booking/_bookingItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"daf13c27494e1417a65895e943011db2011c0f0a", @"/Views/Booking/_bookingItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24568e5d181a623e84ea2790a3202d4b0bb05c6c", @"/Views/_ViewImports.cshtml")]
    public class Views_Booking__bookingItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Booking>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
 for (int i = 0; i < Model.Items.Count; i++)
    {
        var item = Model.Items[i];

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"col-md-4\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 212, "\"", 232, 1);
#nullable restore
#line 7 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 218, item.ImageUri, 218, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"266.6px\" height=\"300px\">\r\n                        <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 311, "\"", 333, 1);
#nullable restore
#line 8 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 319, item.ImageUri, 319, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 334, "", 370, 1);
#nullable restore
#line 8 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 340, "items[" + i + "].ImageUri", 340, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </div>\r\n                    <div class=\"col-md-4\">\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Hotel name:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 13 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.HotelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 689, "\"", 710, 1);
#nullable restore
#line 14 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 697, item.HotelId, 697, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 711, "", 746, 1);
#nullable restore
#line 14 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 717, "items[" + i + "].HotelId", 717, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 799, "\"", 822, 1);
#nullable restore
#line 15 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 807, item.HotelName, 807, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 823, "", 860, 1);
#nullable restore
#line 15 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 829, "items[" + i + "].HotelName", 829, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Room name:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 19 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.RoomName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1137, "\"", 1157, 1);
#nullable restore
#line 20 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 1145, item.RoomId, 1145, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 1158, "", 1192, 1);
#nullable restore
#line 20 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 1164, "items[" + i + "].RoomId", 1164, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1245, "\"", 1267, 1);
#nullable restore
#line 21 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 1253, item.RoomName, 1253, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 1268, "", 1304, 1);
#nullable restore
#line 21 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 1274, "items[" + i + "].RoomName", 1274, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Room number:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 25 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.RoomNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1585, "\"", 1609, 1);
#nullable restore
#line 26 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 1593, item.RoomNumber, 1593, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 1610, "", 1648, 1);
#nullable restore
#line 26 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 1616, "items[" + i + "].RoomNumber", 1616, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Address:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 30 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 30 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                                            Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1934, "\"", 1955, 1);
#nullable restore
#line 31 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 1942, item.Address, 1942, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 1956, "", 1991, 1);
#nullable restore
#line 31 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 1962, "items[" + i + "].Address", 1962, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2044, "\"", 2062, 1);
#nullable restore
#line 32 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 2052, item.City, 2052, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 2063, "", 2095, 1);
#nullable restore
#line 32 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 2069, "items[" + i + "].City", 2069, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Category name:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 36 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2380, "\"", 2406, 1);
#nullable restore
#line 37 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 2388, item.CategoryName, 2388, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 2407, "", 2447, 1);
#nullable restore
#line 37 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 2413, "items[" + i + "].CategoryName", 2413, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                        </div>
                        
                    </div>
                    <div class=""col-md-4"">
                        <div class=""row"">
                            <div class=""col-md-6""><h3>Check in:</h3></div>
                            <div class=""col-md-6"">");
#nullable restore
#line 44 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.CheckIn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2820, "\"", 2841, 1);
#nullable restore
#line 45 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 2828, item.CheckIn, 2828, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 2842, "", 2877, 1);
#nullable restore
#line 45 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 2848, "items[" + i + "].CheckIn", 2848, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Check out:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 49 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.CheckOut);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 3154, "\"", 3176, 1);
#nullable restore
#line 50 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 3162, item.CheckOut, 3162, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 3177, "", 3213, 1);
#nullable restore
#line 50 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 3183, "items[" + i + "].CheckOut", 3183, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Unit price:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 54 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" USD</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 3496, "\"", 3519, 1);
#nullable restore
#line 55 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 3504, item.UnitPrice, 3504, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 3520, "", 3557, 1);
#nullable restore
#line 55 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 3526, "items[" + i + "].UnitPrice", 3526, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Day number:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 59 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.DayNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 3836, "\"", 3859, 1);
#nullable restore
#line 60 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 3844, item.DayNumber, 3844, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 3860, "", 3897, 1);
#nullable restore
#line 60 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 3866, "items[" + i + "].DayNumber", 3866, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Cost:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 64 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
                                             Write(item.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 4165, "\"", 4183, 1);
#nullable restore
#line 65 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 4173, item.Cost, 4173, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=", 4184, "", 4216, 1);
#nullable restore
#line 65 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
WriteAttributeValue("", 4190, "items[" + i + "].Cost", 4190, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-md-12""><hr style=""height:1px;border:none;color:#333;background-color:#333;""/></div>
                </div>
");
#nullable restore
#line 72 "D:\github-project\project-HotelReservationWebsite\HotelReservationWebsite\Views\Booking\_bookingItem.cshtml"
            }

#line default
#line hidden
#nullable disable
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
