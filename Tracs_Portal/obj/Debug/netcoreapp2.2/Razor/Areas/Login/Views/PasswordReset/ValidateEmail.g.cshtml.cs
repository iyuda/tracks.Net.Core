#pragma checksum "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9d1481c208706aaea9c55522dedaa0c61f75743"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Login_Views_PasswordReset_ValidateEmail), @"mvc.1.0.view", @"/Areas/Login/Views/PasswordReset/ValidateEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Login/Views/PasswordReset/ValidateEmail.cshtml", typeof(AspNetCore.Areas_Login_Views_PasswordReset_ValidateEmail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9d1481c208706aaea9c55522dedaa0c61f75743", @"/Areas/Login/Views/PasswordReset/ValidateEmail.cshtml")]
    public class Areas_Login_Views_PasswordReset_ValidateEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"
  
    ViewBag.Title = "RMA TRACS System";
    ViewBag.SubTitle = "Forgot Password";
    Layout = "../Shared/_Layout.cshtml";
    var IsMobile = ViewBag.IsMobile ?? false;
    var wPercent = IsMobile ? "100" : "40";
    var ColSpan = IsMobile ? "3" : "3";

#line default
#line hidden
            BeginContext(268, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"
 using (Html.BeginForm("ValidateEmailUpdate", "Home", FormMethod.Post, new { @class = "center", @id = "frmValidateEmail" }))
{


#line default
#line hidden
            BeginContext(401, 97, true);
            WriteLiteral("    <div id=\"divForgotPassword\" class=\"m-y12\" align=\"center\">\r\n\r\n        <br />\r\n\r\n        <table");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 498, "\"", 536, 4);
            WriteAttributeValue("", 506, "width:", 506, 6, true);
#line 18 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"
WriteAttributeValue("", 512, wPercent, 512, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 521, "%;", 521, 2, true);
            WriteAttributeValue(" ", 523, "align:center", 524, 13, true);
            EndWriteAttribute();
            BeginContext(537, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
            BeginContext(801, 591, true);
            WriteLiteral(@"            <tr class=""blank_row"">
                <td colspan=""2"">&nbsp;</td>
            </tr>
            <tr>
                <td colspan=""2"">
                    <p id=""lblReturnMessage"" style=""text-align:center;font-style:italic;color:white;background-color:red; display:none;"">  </p>
                </td>
            </tr>
            <tr>
                <td width=""20%"" align=""left"">
                    <label style=""display:block;text-align:left""><span>E-Mail:</span> </label>
                </td>
                <td width=""60%"" align=""right"">
                    ");
            EndContext();
            BeginContext(1393, 217, false);
#line 38 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"
               Write(Html.TextBox("txtEmail", null, new { @style = "float:right; width:100%", @type = "email", @class = "wpcf7-form-control wpcf7-text rma-textfield form-control", @placeholder = "email", @required = "", @autofocus = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(1610, 600, true);
            WriteLiteral(@"
                </td>
                <td align=""left""></td>

            </tr>
            <tr class=""blank_row"">
                <td colspan=""2"">&nbsp;</td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td align=""right"">
                    <button class=""btn btn-lg btn-primary btn-block"" type=""submit"" id=""btnValidateEmail"">Request Temporary Password</button>
                </td>

            </tr>
            <tr class=""blank_row"">
                <td colspan=""2"">&nbsp;</td>
            </tr>

            <tr>
                <td");
            EndContext();
            BeginWriteAttribute("colspan", " colspan=\"", 2210, "\"", 2228, 1);
#line 59 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"
WriteAttributeValue("", 2220, ColSpan, 2220, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2229, 54, true);
            WriteLiteral(" align=\"center\">\r\n                    <a id=\"btnLogin\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2283, "\"", 2318, 1);
#line 60 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"
WriteAttributeValue("", 2290, Url.Action("Index", "Home"), 2290, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2319, 86, true);
            WriteLiteral(">Login</a>\r\n                </td>\r\n\r\n            </tr>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 66 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"


}

#line default
#line hidden
            BeginContext(2412, 1457, true);
            WriteLiteral(@"


<script src=""https://code.jquery.com/jquery-1.11.1.min.js""></script>
<script src=""https://cdn.jsdelivr.net/jquery.validation/1.16.0/jquery.validate.min.js""></script>
<script src=""https://cdn.jsdelivr.net/jquery.validation/1.16.0/additional-methods.min.js""></script>

<script>
    $(""#frmValidateEmail"").validate({
        errorClass: 'validate-error',
        errorPlacement: function (error, element) {
            var newCell = $('<td> </td>');
            var newRow = $('<tr> </tr>');
            newCell.appendTo(newRow);
            newCell = $('<td align=""right""> </td>')
            error.css(""width"", ""90%"");
            error.attr(""align"", ""left"");
            error.appendTo(newCell);
            newCell.appendTo(newRow);
            newRow.insertAfter(element.closest('tr'));


        }
    });



    $(document).ready(function () {
        $('.btn-primary').css('background-color', '#F57B20')
        $(""input"").each(function () {
            $(this).attr(""autocomplete"", ""no");
            WriteLiteral(@"ne"");
        });
    });
    $(""#frmValidateEmail"").submit(function (e) {
        e.preventDefault();
        if ($(""#frmValidateEmail"").find("".error:visible"").length > 0 || $(this).find("".validate-error:visible"").length > 0)
            return;
        $(""#lblReturnMessage"").hide();
        $(""#btnLogin"").hide();
        var sEmail = $('#txtEmail').val();
        $.ajax({
            type: ""POST"",
            url: '");
            EndContext();
            BeginContext(3870, 50, false);
#line 111 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"
             Write(Url.Action("ValidateEmailUpdate", "PasswordReset"));

#line default
#line hidden
            EndContext();
            BeginContext(3920, 374, true);
            WriteLiteral(@"',
            data: { email: $('#txtEmail').val()},
            async: false,
            success: function (result) {
                var message = result.message;
                var status = result.status;
                if (status == 1) {
                    //$(""#lblReturnMessage"").css('background-color', 'forestgreen');
                    var location = '");
            EndContext();
            BeginContext(4295, 27, false);
#line 119 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Login\Views\PasswordReset\ValidateEmail.cshtml"
                               Write(Url.Action("Index", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(4322, 827, true);
            WriteLiteral(@"';
                    changeToTapToDismissToastr();
                    changeFeedbackMessage('success', message, '',
                        '<br /><br /><br /><button onclick = ""href"" type=""button"" class=""para-btn clear"">Login</button>'.replace('href', 'window.location.href = \'' + location + '\'')
                    );
                }
                else
                    $(""#lblReturnMessage"").text(message);
                    $(""#lblReturnMessage"").css('background-color', 'red');
                    $(""#lblReturnMessage"").show();
                    $(""#btnLogin"").show();
                    //changeFeedbackMessage('error', message)

            },
            error: function (request, status, error) {
                alert(error);
            }

        });


    });


</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
