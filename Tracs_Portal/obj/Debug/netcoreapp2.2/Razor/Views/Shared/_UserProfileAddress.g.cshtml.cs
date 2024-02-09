#pragma checksum "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "461ed1b864dbb00638c8ed9e1985d2eecbef9cd8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UserProfileAddress), @"mvc.1.0.view", @"/Views/Shared/_UserProfileAddress.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_UserProfileAddress.cshtml", typeof(AspNetCore.Views_Shared__UserProfileAddress))]
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
#line 1 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\_ViewImports.cshtml"
using TRACSPortal;

#line default
#line hidden
#line 2 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\_ViewImports.cshtml"
using TRACSPortal.Models;

#line default
#line hidden
#line 1 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
using Tracs.Common.Models;

#line default
#line hidden
#line 3 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"461ed1b864dbb00638c8ed9e1985d2eecbef9cd8", @"/Views/Shared/_UserProfileAddress.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db4c19fc9bfac4cea8c3f33d2a8d4d0ee2ef69c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UserProfileAddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserProfileModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(74, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
  
    ViewBag.QueryMode = (ViewBag.QueryMode ?? false);

    string is_asterik = ViewBag.QueryMode ? ": " : "*";
    
    Layout = ViewBag.Layout;
    var IsMobile = ViewBag.IsMobile??false;


#line default
#line hidden
            BeginContext(280, 119, true);
            WriteLiteral("<div class=\"row p-px-y5\">\r\n    <div class=\"col-md-8\">\r\n        <label for=\"street-txt\">Street Address</label>\r\n        ");
            EndContext();
            BeginContext(400, 212, false);
#line 17 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
   Write(Html.TextBoxFor(m => m.StreetAddress, new { @id = "street-txt", @class = "capitalize wpcf7-form-control address-updatable wpcf7-text rma-textfield form-control", @required = "", @placeholder = "Street Address" }));

#line default
#line hidden
            EndContext();
            BeginContext(612, 129, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"p-px-y5 row\">\r\n    <div class=\"col-md-4\">\r\n        <label for=\"city-txt\">City</label>\r\n        ");
            EndContext();
            BeginContext(742, 191, false);
#line 23 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
   Write(Html.TextBoxFor(m => m.City, new { @id = "city-txt", @class = "capitalize wpcf7-form-control address-updatable wpcf7-text rma-textfield form-control", @required = "", @placeholder = "City" }));

#line default
#line hidden
            EndContext();
            BeginContext(933, 16, true);
            WriteLiteral("\r\n\r\n    </div>\r\n");
            EndContext();
#line 26 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
       if (!IsMobile)
        {

#line default
#line hidden
            BeginContext(983, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(997, 25, true);
            WriteLiteral("<div class=\" col-md-4\">\r\n");
            EndContext();
#line 29 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1070, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1084, 20, true);
            WriteLiteral("</div>\r\n            ");
            EndContext();
            BeginContext(1106, 43, true);
            WriteLiteral("<div class=\"p-px-y5 row\">\r\n                ");
            EndContext();
            BeginContext(1151, 25, true);
            WriteLiteral("<div class=\" col-md-3\">\r\n");
            EndContext();
#line 35 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
                }
    

#line default
#line hidden
            BeginContext(1202, 148, true);
            WriteLiteral("    <div class=\"\">\r\n        <label class=\"col\" for=\"ProfileCountryId\">Country</label>\r\n    </div>\r\n\r\n    <div class=\"\" style=\"width:100%\">\r\n        ");
            EndContext();
            BeginContext(1352, 556, false);
#line 42 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
    Write(Html.Kendo().DropDownListFor(m => m.ProfileCountryId)
                                       .DataTextField("Name")
                                       .DataValueField("CountryId")
                                       .BindTo(Model.Countries)
                                       .Value(Model.ProfileCountryId.ToString())
                                       .HtmlAttributes(new { @id = "ProfileCountryId", @class = "address-updatable", @style = "width: 100%; height: 36px;", onchange = "ComboChangeEvent(this); CountryChangeEvent(this); " }));

#line default
#line hidden
            EndContext();
            BeginContext(1909, 141, true);
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n</div>\r\n<div class=\"row p-px-y5\">\r\n    <div class=\"col-md-4\">\r\n        <label for=\"zip-txt\">ZipCode</label>\r\n        ");
            EndContext();
            BeginContext(2051, 285, false);
#line 55 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
   Write(Html.TextBoxFor(m => m.Zip, new { @id = "zip-txt", @pattern = "[0-9]{3} [0-9]{2}|[0-9]{5}|[0-9]{5}-[0-9]{4}|[0-9]{5} [0-9]{4}", @required = "", @class = "zipcode wpcf7-form-control address-updatable wpcf7-text rma-textfield form-control", @placeholder = "Zip Code", maxlength = "10" }));

#line default
#line hidden
            EndContext();
            BeginContext(2336, 201, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-4\">\r\n        <div class=\"\">\r\n            <label class=\"\" for=\"ProfileStateId\">State</label>\r\n        </div>\r\n        <div class=\"\" style=\"width:100%\">\r\n            ");
            EndContext();
            BeginContext(2538, 89, false);
#line 62 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
       Write(Html.Hidden("hiddenProfileStateId", Model == null ? "" : Model.ProfileStateId.ToString()));

#line default
#line hidden
            EndContext();
            BeginContext(2627, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(2643, 401, false);
#line 63 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
        Write(Html.Kendo().DropDownListFor(m => m.ProfileStateId)
                                .DataTextField("Name")
                                .DataValueField("StateId")
                                //.BindTo(ViewBag.States ?? new List<StateModel>())
                                .HtmlAttributes(new { @id = "ProfileStateId", @class = "address-updatable", @style = "width: 100%; height: 36px;"}));

#line default
#line hidden
            EndContext();
            BeginContext(3045, 40, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
#line 72 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
   if (IsMobile)
    {

#line default
#line hidden
            BeginContext(3110, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(3116, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 75 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
}

#line default
#line hidden
            BeginContext(3130, 4950, true);
            WriteLiteral(@"
<script>

    //ProfileComboChangeEvent('');

    function ValidateProfile(FormName) {
        var status = true;

        $(""#"" + FormName).find(""input[data-role='combobox'][optional!='true'], input[data-role='dropdownlist'][optional!='true']"").each(function () {

            var divParent = $(this).closest('div');
            if ($(divParent).css('display') == 'none')
                return true;
            $(divParent).find("".error"").each(function () {
                $(this).remove();
            });
            if (($(this).data(""kendoComboBox"") || $(this).data('kendoDropDownList')).text().length == 0 && $(this).closest('form').attr('id') == FormName) {
                if ($(divParent).find(""label.validate-error:visible"").length == 0) {


                    var $label = $(""<label  class='validate-error' for='"" + this.id + ""'>"");
                    $label.attr('id', this.id + ""-error"");
                    $label.text(""This field is required.""); $label.css(""color"", ""red"");
     ");
            WriteLiteral(@"               var divParent = $(this).closest('div');
                    $(divParent).find(""label.error, label.validate-error"").each(function () {
                        $(this).remove();
                    });
                    $label.appendTo(divParent);

                }
                status = false;
            }

        });
        // See if the other (unselected) tab has errors
        var profileTabErrorFree = $(""#edit-profile"").find('.error, .validate-error').length == 0;
        var addressTabErrorFree = $(""#edit-address"").find('.error, .validate-error').length == 0;
        var activeProfileTabErrorFree = $(""#edit-profile"").find('.error:visible, .validate-error:visible').length == 0;
        var activeAddressTabErrorFree = $(""#edit-address"").find('.error:visible, .validate-error:visible').length == 0;
        $(""#"" + FormName).find(""input[data-role!='combobox'][optional!='true']"").each(function () {

            if ($(this).val().length == 0 || $(this).hasClass('validate-");
            WriteLiteral(@"error')) {

                var divParent = $(this).closest('div');
                if ($(divParent).css('display') == 'none')
                    return true;
                if (profileTabErrorFree && $(this).hasClass('address-updatable') && $(""#navEditProfile"").is(':visible') && $(""#edit-profile"").hasClass(""active"")) {

                    status = false;
                }
                if (addressTabErrorFree && $(this).hasClass('profile-updatable') && $(""#navEditAddress"").is(':visible') && $(""#edit-address"").hasClass(""active"")) {


                    status = false;
                }
            }
        });
        if (activeAddressTabErrorFree && !profileTabErrorFree && $(""#navEditProfile"").is(':visible') && $(""#edit-address"").hasClass(""active"")) {
            $(""#navEditAddress"").removeClass(""active"");
            $(""#edit-address"").removeClass(""active"");
            $(""#navEditProfile"").addClass(""active"");
            $(""#edit-profile"").addClass(""active"");
        }
        ");
            WriteLiteral(@"else if (activeProfileTabErrorFree && !addressTabErrorFree && $(""#navEditProfile"").is(':visible') && $(""#edit-profile"").hasClass(""active"")) {
            $(""#navEditProfile"").removeClass(""active"");
            $(""#edit-profile"").removeClass(""active"");
            $(""#navEditAddress"").addClass(""active"");
            $(""#edit-address"").addClass(""active"");
        }
        return status;
    }

    function ProfileComboChangeEvent(e) {
        var divParent = $(e).closest('div');
        $(divParent).find(""label.error:visible, label.validate-error:visible"").each(function () {
            $(this).remove();
        });
        var combobox = $(e).data(""kendoComboBox"");
        if (combobox.selectedIndex === -1 && combobox.value()) {
            if (combobox.dataSource.view().length > 0) {
                combobox.select(0);
            }
            else {
                combobox.value("""");
                var $label = $(""<label  class='error' for='"" + $(e).id + ""'>"");
                $labe");
            WriteLiteral(@"l.attr('id', $(e).id + ""-error"");
                $label.text(""This field is required.""); $label.css(""color"", ""red"");
                $label.appendTo(divParent);
            }
        }
    }

    function CountryChangeEvent(e) {
        //$(""#combobox"").data(""kendoComboBox"").value("""");
        var chosenId = $(""#ProfileCountryId"").data('kendoDropDownList').value();

        if (!chosenId) return;

        $(""#ProfileStateId"").kendoDropDownList({
            dataTextField: ""name"",
            dataValueField: ""id"",
            dataSource: {
                autoSync: true,
                transport: {
                    read: {
                        cache: false,
                        serverFiltering: true,
                        async: false,
                        dataType: ""json"",
                        url: '");
            EndContext();
            BeginContext(8081, 63, false);
#line 186 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Views\Shared\_UserProfileAddress.cshtml"
                         Write(Url.Action("GetStatesByCountryJson", "Home", new { area = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(8144, 2127, true);
            WriteLiteral(@"?countryId=' + chosenId,
                    }
                },
            }
        });
        if ($('#hiddenProfileStateId'))
            if ($('#hiddenProfileStateId').val())
                $(""#ProfileStateId"").data('kendoDropDownList').value($('#hiddenProfileStateId').val());
            else
                $(""#ProfileStateId"").data('kendoDropDownList').select(0);
        else
            $(""#ProfileStateId"").data('kendoDropDownList').select(0);
    }
</script>
<script>
    $(document).ready(function () {
        CheckIsContractor();

        //var profile_country_val = $(""#ProfileCountryId"").data(""kendoDropDownList"").value();
        //var profile_country_combo = $(""#ProfileCountryId"").data(""kendoDropDownList"");

        //if (!profile_country_val) {
        //    profile_country_val = ""240"";
        //}

        //profile_country_combo.select(function (dataItem) {
        //    return dataItem.CountryId == profile_country_val;
        //});
        //CountryChangeEvent(");
            WriteLiteral(@");

    });

    function CheckIsContractor() {

        var checkValue = $("".is-subcontractor"").is("":checked"");

        if (checkValue) {
            $(""#divContractor"").show();
        } else {
            $(""#divContractor"").hide();
        }
    };

    $('#divIsContractor :checkbox').change(function () {
        CheckIsContractor();
    });

    function LoadContractorFirms(e) {
        var company_id = $(e).data('kendoComboBox').value();
        var firmsCombobox = $(e).data(""kendoComboBox"");

        if (!company_id) return;
        $(""#prof-contractor-txt"").kendoComboBox({
            dataTextField: ""FirmName"",
            dataValueField: ""id"",
            dataSource: firmsCombobox.dataSource,
            filter: ""contains"",
            suggest: true
        });

        var contractorCombobox = $(""#prof-contractor-txt"").data(""kendoComboBox"");
        contractorCombobox.dataSource.filter({
            field: 'id',
            operator: 'neq',
            value: com");
            WriteLiteral("pany_id\r\n        });\r\n        contractorCombobox.value(null);\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserProfileModel> Html { get; private set; }
    }
}
#pragma warning restore 1591