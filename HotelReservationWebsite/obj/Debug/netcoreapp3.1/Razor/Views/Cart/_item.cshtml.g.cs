#pragma checksum "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89de8e644c14a9a100b43adc948cf0cf0ee84ebe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart__item), @"mvc.1.0.view", @"/Views/Cart/_item.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89de8e644c14a9a100b43adc948cf0cf0ee84ebe", @"/Views/Cart/_item.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24568e5d181a623e84ea2790a3202d4b0bb05c6c", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart__item : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CartItem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\" style=\"margin-top:20px;\">\r\n                    <div class=\"col-md-3\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 133, "\"", 154, 1);
#nullable restore
#line 4 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
WriteAttributeValue("", 139, Model.ImageUrl, 139, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""266.6px"" height=""300px""/>
                    </div>
                    <div class=""col-md-4"">
                        <div class=""row"">
                            <div class=""col-md-6""><h3>Hotel name:</h3></div>
                            <div class=""col-md-6"">");
#nullable restore
#line 9 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.HotelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Room name:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 13 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.RoomName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Room number:</h3></div>\r\n                            <div class=\"col-md-6\">\r\n                                ");
#nullable restore
#line 18 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                           Write(Model.RoomNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Room area:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 23 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.RoomArea);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Number of beds:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 27 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.NumberOfBeds);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Address:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 31 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 31 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                                             Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Category name:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 35 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.CategoryName);

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
#line 42 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.CheckIn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Check out:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 46 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.CheckOut);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Unit price:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 50 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" USD</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Day number:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 54 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.dayNumber().Days.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\"><h3>Cost:</h3></div>\r\n                            <div class=\"col-md-6\">");
#nullable restore
#line 58 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
                                             Write(Model.cost());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89de8e644c14a9a100b43adc948cf0cf0ee84ebe12397", async() => {
                WriteLiteral("\r\n                    <div class=\"col-md-1\">\r\n                        \r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "89de8e644c14a9a100b43adc948cf0cf0ee84ebe12760", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 64 "D:\project-HotelReservationWebsite\HotelReservationWebsite\Views\Cart\_item.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Id);

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
                WriteLiteral("\r\n                            <input type=\"submit\" value=\"Delete\">\r\n                    </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CartItem> Html { get; private set; }
    }
}
#pragma warning restore 1591
