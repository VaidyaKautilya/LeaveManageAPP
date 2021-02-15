#pragma checksum "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6c27790cbfc32bf233bbacf028cf40be15290b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LeaveRequest_Index), @"mvc.1.0.view", @"/Views/LeaveRequest/Index.cshtml")]
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
#line 1 "D:\git\LeaveManagement\LeaveManageAPP\Views\_ViewImports.cshtml"
using LeaveManageAPP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\git\LeaveManagement\LeaveManageAPP\Views\_ViewImports.cshtml"
using LeaveManageAPP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6c27790cbfc32bf233bbacf028cf40be15290b3", @"/Views/LeaveRequest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"488b1d843cb652cee2196d95b96afe0f5031623a", @"/Views/_ViewImports.cshtml")]
    public class Views_LeaveRequest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminLeaveRequestVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLTE.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-3"">
        <div class=""info-box"">
            <span class=""info-box-icon bg-info""><i class=""fas fa-tachometer-alt""></i></span>

            <div class=""info-box-content"">
                <span class=""info-box-text"">");
#nullable restore
#line 14 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                       Write(Model.TotalRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span class=\"info-box-number\">");
#nullable restore
#line 15 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                         Write(Html.DisplayNameFor(model => model.TotalRequests));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            </div>
            <!-- /.info-box-content -->
        </div>

    </div>
    <div class=""col-md-3"">
        <div class=""info-box"">
            <span class=""info-box-icon bg-warning""><i class=""fas fa-exclamation-circle""></i></span>

            <div class=""info-box-content"">
                <span class=""info-box-text"">");
#nullable restore
#line 26 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                       Write(Model.PendingRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span class=\"info-box-number\">");
#nullable restore
#line 27 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                         Write(Html.DisplayNameFor(model => model.PendingRequests));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            </div>
            <!-- /.info-box-content -->
        </div>

    </div>
    <div class=""col-md-3"">
        <div class=""info-box"">
            <span class=""info-box-icon bg-success""><i class=""far fa-check-circle""></i></span>

            <div class=""info-box-content"">
                <span class=""info-box-text"">");
#nullable restore
#line 38 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                       Write(Model.ApprovedRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span class=\"info-box-number\">");
#nullable restore
#line 39 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                         Write(Html.DisplayNameFor(model => model.ApprovedRequests));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            </div>
            <!-- /.info-box-content -->
        </div>

    </div>
    <div class=""col-md-3"">
        <div class=""info-box"">
            <span class=""info-box-icon bg-danger""><i class=""far fa-times-circle""></i></span>

            <div class=""info-box-content"">
                <span class=""info-box-text"">");
#nullable restore
#line 50 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                       Write(Model.RejectedRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span class=\"info-box-number\">");
#nullable restore
#line 51 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                         Write(Html.DisplayNameFor(model => model.RejectedRequests));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            </div>
            <!-- /.info-box-content -->
        </div>

    </div>
</div>

<br />
<br />

<hr />
<h1>Leave Request Log</h1>
<hr />
<table id=""tblData"" class=""table"">
    <thead>
        <tr>
            <th>
                Employee Name
            </th>
            <th>
                Start Date
            </th>
            <th>
                End Date
            </th>
            <th>
                Leave Type
            </th>
            <th>
                Date Requested
            </th>

            <th>
                Approval Status
            </th>

            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 92 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
         foreach (var item in Model.LeaveRequests)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 96 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.RequestingEmployee.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 96 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                                                                Write(Html.DisplayFor(modelItem => item.RequestingEmployee.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 99 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 102 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 105 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.LeaveType.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 108 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateRequested));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 111 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                     if (item.Cancelled)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-secondary\">Cancelled</span>\r\n");
#nullable restore
#line 114 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                    }
                    else if (item.Approved == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-success\">Approved</span>\r\n");
#nullable restore
#line 118 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                    }
                    else if (item.Approved == false)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-danger\">Rejected</span>\r\n");
#nullable restore
#line 122 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-warning\">Pending Approval</span>\r\n");
#nullable restore
#line 126 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 129 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                     if (!item.Cancelled)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6c27790cbfc32bf233bbacf028cf40be15290b312649", async() => {
                WriteLiteral("\r\n                            <i class=\"fa fa-file\"></i>Review\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 131 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                                                                                  WriteLiteral(item.Id);

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
            WriteLiteral("\r\n");
#nullable restore
#line 134 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 139 "D:\git\LeaveManagement\LeaveManageAPP\Views\LeaveRequest\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminLeaveRequestVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
