#pragma checksum "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8165d2471bdfa2ef781456c3de1266b5cba4bb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Accounting_Views_Home__CaseListHome), @"mvc.1.0.view", @"/Areas/Accounting/Views/Home/_CaseListHome.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Accounting/Views/Home/_CaseListHome.cshtml", typeof(AspNetCore.Areas_Accounting_Views_Home__CaseListHome))]
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
#line 1 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
using TRACSPortal.Areas.Accounting.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8165d2471bdfa2ef781456c3de1266b5cba4bb8", @"/Areas/Accounting/Views/Home/_CaseListHome.cshtml")]
    public class Areas_Accounting_Views_Home__CaseListHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AccountingHomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 1173, true);
            WriteLiteral(@"<Style>
    .fixed_header tbody {
        display: block;
        overflow: auto;
        height: 530px;
        width: 100%;
    }
        .fixed_header tbody tr {
            line-height: 10px;
            display: table;
            table-layout: fixed;
        }
    .fixed_header thead tr {
        display: block;
        background-color: #f39c12;
        border-color: #e67e22;
        vertical-align: text-top;
        line-height: 10px;
    }
</Style>
<script>
    $("".detailCase"").click(function (e) {
        $(""#HiddleSelectedCaseId"").val(this.id);
        $.ajax({
            cache: false,
            type: ""GET"",
            url: ""/Accounting/Case/Index"",
            contentType: ""application/json; charset=utf-8"",
            data: $('#form1').serialize(),
            dataType: ""HTML"",
            async: true,
            success: function (response) {
               
                $('#divBody').html(response);
                $('#divBody').show();
            },
            WriteLiteral("\n            failure: function (response) {\r\n                alert(\'Customer content load failed.\');\r\n            }\r\n        })\r\n    });\r\n</script>\r\n");
            EndContext();
#line 45 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
 if (Model.CaseList == null)
{

#line default
#line hidden
            BeginContext(1282, 69, true);
            WriteLiteral("    <span>Please select the search type for searching cases.</span>\r\n");
            EndContext();
#line 48 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
}
else
{
    if (Model.CaseList.Count == 0)
    {

#line default
#line hidden
            BeginContext(1406, 41, true);
            WriteLiteral("        <span>No Case available.</span>\r\n");
            EndContext();
#line 54 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1471, 377, true);
            WriteLiteral(@"        <div class=""container grid-striped"">
            <div class=""panel-heading"">
                <h4>
                    Case List
                </h4>
            </div>
            <table class=""table fixed_header"" style=""width:100%"">
                <thead>
                    <tr>
                        <th style=""width:40%"">
                            ");
            EndContext();
            BeginContext(1849, 58, false);
#line 67 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                       Write(Html.DisplayNameFor(model => model.CaseList[0].CaseNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1907, 96, true);
            WriteLiteral("\r\n                        </th>\r\n                        <th style=\"width:20%;text-align:left;\">");
            EndContext();
            BeginContext(2004, 60, false);
#line 69 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                                                          Write(Html.DisplayNameFor(model => model.CaseList[0].ReceivedDate));

#line default
#line hidden
            EndContext();
            BeginContext(2064, 70, true);
            WriteLiteral("</th>\r\n                        <th style=\"width:20%;text-align:left;\">");
            EndContext();
            BeginContext(2135, 58, false);
#line 70 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                                                          Write(Html.DisplayNameFor(model => model.CaseList[0].ClientType));

#line default
#line hidden
            EndContext();
            BeginContext(2193, 70, true);
            WriteLiteral("</th>\r\n                        <th style=\"width:20%;text-align:left;\">");
            EndContext();
            BeginContext(2264, 61, false);
#line 71 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                                                          Write(Html.DisplayNameFor(model => model.CaseList[0].CaseStatusStr));

#line default
#line hidden
            EndContext();
            BeginContext(2325, 161, true);
            WriteLiteral("</th>\r\n                        <th style=\"width:20%;text-align:left;\">Option</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 76 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                     foreach (var item in Model.CaseList)
                    {

#line default
#line hidden
            BeginContext(2568, 102, true);
            WriteLiteral("                    <tr>\r\n                        <td style=\"width:40%\">\r\n                            ");
            EndContext();
            BeginContext(2671, 45, false);
#line 80 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CaseNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2716, 126, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"width:20%;text-align:left;\">\r\n                            ");
            EndContext();
            BeginContext(2843, 93, false);
#line 83 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ReceivedDateStr, new { @class = "datefield form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2936, 126, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"width:20%;text-align:left;\">\r\n                            ");
            EndContext();
            BeginContext(3063, 45, false);
#line 86 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ClientType));

#line default
#line hidden
            EndContext();
            BeginContext(3108, 126, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"width:20%;text-align:left;\">\r\n                            ");
            EndContext();
            BeginContext(3235, 48, false);
#line 89 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CaseStatusStr));

#line default
#line hidden
            EndContext();
            BeginContext(3283, 162, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"width:20%;text-align:left;\">\r\n                            <a href=\"#\" class=\"alink detailCase\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3445, "\"", 3466, 1);
#line 92 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
WriteAttributeValue("", 3450, item.CaseNumber, 3450, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3467, 153, true);
            WriteLiteral(" title=\"Case Details\"><i class=\"fa fa-file-text-o\" style=\'font-size:20px;color:blue\'></i></a>\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 95 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
                    }

#line default
#line hidden
            BeginContext(3643, 64, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n");
            EndContext();
#line 99 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Home\_CaseListHome.cshtml"
    }
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccountingHomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591