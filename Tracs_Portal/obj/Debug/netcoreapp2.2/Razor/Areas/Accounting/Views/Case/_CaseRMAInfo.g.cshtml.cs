#pragma checksum "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45a533e9e7860f08e3f4cb4aeb6d2dbd6058e99d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Accounting_Views_Case__CaseRMAInfo), @"mvc.1.0.view", @"/Areas/Accounting/Views/Case/_CaseRMAInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Accounting/Views/Case/_CaseRMAInfo.cshtml", typeof(AspNetCore.Areas_Accounting_Views_Case__CaseRMAInfo))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45a533e9e7860f08e3f4cb4aeb6d2dbd6058e99d", @"/Areas/Accounting/Views/Case/_CaseRMAInfo.cshtml")]
    public class Areas_Accounting_Views_Case__CaseRMAInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TRACSPortal.Areas.Accounting.Models.AccountingCaseViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 2179, true);
            WriteLiteral(@"<script>
    var rmaNumber = $(""#hiddenRMANumber"").val();
    if (rmaNumber == null || rmaNumber == """") {
        $(""#divEditRMANumber"").hide();
        $(""#divAddRMANumber"").show();
        $(""#cancelEditRMANumber"").hide();
    }
    else {
        $(""#divEditRMANumber"").show();
        $(""#divAddRMANumber"").hide();
    }
    $("".btnAddRMANumber"").click(function (e) {
        var $form = $(this.form);
        $form[0].classList.add('was-validated');
        if ($form[0].checkValidity() === false) {
            e.preventDefault();
            e.stopPropagation();
            return false;
        }
        var rma = $(""#txtNewRMANumber"").val();
        $(""#hiddenRMANumber"").val(rma);
        $.ajax({
            cache: false,
            type: ""GET"",
            url: ""/Accounting/Case/AddRMANumber"",
            contentType: ""application/json; charset=utf-8"",
            data: { caseid: $(""#hiddenCaseId"").val(), id: rma},
            dataType: ""HTML"",
            async: true,
     ");
            WriteLiteral(@"       success: function (response) {
                $('#divCaseRMAInfo').html(response);
                $('#divCaseRMAInfo').show();
            },
            failure: function (response) {
                alert('Customer content load failed.');
            }
        })
    });
    $(""#txtNewRMANumber"").prop('required', true);
    $(""#txtNewRMANumber"").prop('pattern', '[A-Za-z0-9]{1,24}');
    $("".btnEditRMANumber"").click(function (e) {
        var rma = $(""#hiddenRMANumber"").val();
        $(""#txtNewRMANumber"").val(rma);
        $(""#divEditRMANumber"").hide();
        $(""#divAddRMANumber"").show();
        $(""#cancelEditRMANumber"").show();
    });
    $("".btnCancelRMANumber"").click(function (e) {
        $(""#divEditRMANumber"").show();
        $(""#divAddRMANumber"").hide();
    });
</script>
<form method=""POST"" id=""formRMA"" name=""formRMA"" enctype=""multipart/form-data"">
    <div class=""card border-light mb-3"" style=""width:15rem;"">
        <div class=""card-header font-weight-light card");
            WriteLiteral("headerfixed\">RMA number Info</div>\r\n        <div class=\"card-body\" style=\"font-size:small;padding:2px 2px 2px 2px;height:150px;\">\r\n");
            EndContext();
#line 58 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
             if (Model.SelectedCase == null)
            {

#line default
#line hidden
            BeginContext(2308, 54, true);
            WriteLiteral("                <span>No Case Info available.</span>\r\n");
            EndContext();
#line 61 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
            }
            else
            {
                

#line default
#line hidden
            BeginContext(2427, 85, false);
#line 64 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
           Write(Html.HiddenFor(model => model.SelectedCase.RMANumber, new { id = "hiddenRMANumber" }));

#line default
#line hidden
            EndContext();
            BeginContext(2531, 70, false);
#line 65 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
           Write(Html.HiddenFor(model => model.CaseNumber, new { id = "hiddenCaseId" }));

#line default
#line hidden
            EndContext();
            BeginContext(2605, 230, true);
            WriteLiteral("                <div id=\"divAddRMANumber\">\r\n                    <table style=\"width:100%;\">\r\n                        <tr style=\"height:100px;vertical-align:top;\">\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2836, 61, false);
#line 71 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
                           Write(Html.DisplayNameFor(model => model.SelectedCase.NewRMANumber));

#line default
#line hidden
            EndContext();
            BeginContext(2897, 110, true);
            WriteLiteral(":&nbsp;\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(3008, 213, false);
#line 74 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
                           Write(Html.TextBoxFor(model => model.SelectedCase.NewRMANumber, new { @class = "form-control placeholdertext", id = "txtNewRMANumber", style = "width:100px;height:25px;font-size:12px", placeholder = "Please input..." }));

#line default
#line hidden
            EndContext();
            BeginContext(3221, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(3256, 91, false);
#line 75 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
                           Write(Html.HiddenFor(model => model.SelectedCase.NewRMANumber, new { id = "hiddenNewRMANumber" }));

#line default
#line hidden
            EndContext();
            BeginContext(3347, 993, true);
            WriteLiteral(@"
                                <div class=""invalid-feedback"">
                                    Alphanumeric only with length 1-24.
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan=""2"" align=""right"" style=""padding-right:10px;"">
                                <button type=""button"" class=""btn btn-warning btnCancelRMANumber btn-sm"" id=""cancelEditRMANumber"">Cancel</button>
                                <button type=""button"" class=""btn btn-warning btnAddRMANumber btn-sm"" id=""addRMANumber"">Add</button>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id=""divEditRMANumber"">
                    <table style=""width:100%;"">
                        <tr style=""height:100px;vertical-align:top;"">
                            <td>
                                ");
            EndContext();
            BeginContext(4341, 58, false);
#line 93 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
                           Write(Html.DisplayNameFor(model => model.SelectedCase.RMANumber));

#line default
#line hidden
            EndContext();
            BeginContext(4399, 110, true);
            WriteLiteral(":&nbsp;\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(4510, 54, false);
#line 96 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
                           Write(Html.DisplayFor(model => model.SelectedCase.RMANumber));

#line default
#line hidden
            EndContext();
            BeginContext(4564, 444, true);
            WriteLiteral(@"

                            </td>
                        </tr>
                        <tr>
                            <td colspan=""2"" align=""right"" style=""padding-right:10px;"">
                                <button type=""button"" class=""btn btn-warning btnEditRMANumber btn-sm"" id=""editRMANumber"">Edit</button>
                            </td>
                        </tr>
                    </table>
                </div>
");
            EndContext();
#line 107 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Case\_CaseRMAInfo.cshtml"
            }

#line default
#line hidden
            BeginContext(5023, 35, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</form>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TRACSPortal.Areas.Accounting.Models.AccountingCaseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591