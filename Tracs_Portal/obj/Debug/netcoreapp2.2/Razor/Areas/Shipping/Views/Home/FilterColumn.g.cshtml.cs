#pragma checksum "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Shipping\Views\Home\FilterColumn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "795a95a6e67b0f46e648e8b6b15e75e840121e2a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Shipping_Views_Home_FilterColumn), @"mvc.1.0.view", @"/Areas/Shipping/Views/Home/FilterColumn.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Shipping/Views/Home/FilterColumn.cshtml", typeof(AspNetCore.Areas_Shipping_Views_Home_FilterColumn))]
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
#line 1 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Shipping\Views\Home\FilterColumn.cshtml"
using Tracs.Common.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"795a95a6e67b0f46e648e8b6b15e75e840121e2a", @"/Areas/Shipping/Views/Home/FilterColumn.cshtml")]
    public class Areas_Shipping_Views_Home_FilterColumn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Shipping\Views\Home\FilterColumn.cshtml"
  
    //Layout = null;
    var lstColumns = new List<SelectListItem>();
    Type T;
    if ((ViewBag.ListType??"") == "Ship")
    {
        T = typeof(ShippingModel);
    }
    else
    {
        T = typeof(ReceivingModel);
    }
    foreach (var prop in (T.GetProperties()))
    {
        var displayName = prop.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), true).FirstOrDefault() as System.ComponentModel.DisplayNameAttribute;
        lstColumns.Add(new SelectListItem { Text = displayName?.DisplayName ?? prop.Name, Value = prop.Name });
    }

#line default
#line hidden
            BeginContext(623, 195, true);
            WriteLiteral("<div class=\"p-px-y5 row\" style=\"text-align:center\">\r\n    <div class=\"section1\" style=\"width:20%\"></div>\r\n    <div class=\"section1\" style=\"width:60%\">\r\n        <div class=\"col-md-5\">\r\n            ");
            EndContext();
            BeginContext(819, 393, false);
#line 24 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Shipping\Views\Home\FilterColumn.cshtml"
       Write(Html.DropDownList("column-list", new SelectList(lstColumns, "Value", "Text", lstColumns.Count==1? lstColumns[0].Value:null), "-- Select Field To Search --",
                new { @onchange = "SetColumnSearch(this)", @style = "padding:4px", @aria_invalid = "false", @aria_required = "true", @required = "", @class = "wpcf7-form-control wpcf7-select wpcf7-validates-as-required form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1212, 1781, true);
            WriteLiteral(@"
        </div>


        <div class=""form-group search-value para-input-group col-md-5"">
            <input style=""width:70%"" id=""ship-search-txt"" class=""search-input form-control"" placeholder=""Search Selected Field"" spellcheck=""false"" aria-label=""Search"" type=""text"">
            <button disabled class=""btn btn-primary search-button"" type=""button"" onclick=""SearchGrid()"" style=""background-color: rgb(245, 123, 32);"">
                <span class=""fa fa-search icon""></span>
            </button>



        </div>
        <div class="" col-md-2 para-input-group"">

            <button id=""clear-search"" style=""float:right;""
                    class=""btn btn-primary""
                    onclick=""ClearSearch()"">
                <span>Clear Search</span>
            </button>
        </div>
    </div>
</div>
<script>
    $(document).ready(function () {
        SetColumnSearch($(""#column-list""));
    });
    $(""#ship-search-txt"").keypress(function (event) {
        if (event.which == 13) {
");
            WriteLiteral(@"            SearchGrid();
        }
    });
    function SetColumnSearch(e) {
        $(""#ship-search-txt"").val('');
        $('#ship-search-txt').attr('type', 'text')
        $(""#ship-search-txt"").attr('placeholder', $(e).val() ? ""Search "" + $(e).find('option:selected').text() : ""Search Selected Field"");
      }
    function ClearSearch(e) {
        if ($('#column-list').children('option').length <= 2)
            $(""#column-list"").prop('selectedIndex', 1);
        else
            $(""#column-list"").prop('selectedIndex', 0);
          SetColumnSearch($(""#column-list""));
          SearchGrid(true);
      }
      function SearchGrid(reset) {
          reset = reset || false;
          var listType = $(""#shipping-type"").text(); //'");
            EndContext();
            BeginContext(2994, 16, false);
#line 72 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Shipping\Views\Home\FilterColumn.cshtml"
                                                   Write(ViewBag.SubTitle);

#line default
#line hidden
            EndContext();
            BeginContext(3010, 81, true);
            WriteLiteral("\'.replace(\'-\', \'\').trim(); //$(\".top-subheading\").text();\r\n          var sURL = \'");
            EndContext();
            BeginContext(3092, 39, false);
#line 73 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Shipping\Views\Home\FilterColumn.cshtml"
                 Write(Url.Action("listType" + "List", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(3131, 1238, true);
            WriteLiteral(@"';
          if (!reset) {
                var queryString = $.param({ SearchColumn: $(""#column-list"").val(), SearchValue: $(""#ship-search-txt"").val() });
                sURL = sURL.replace('listType', listType) + '?' + queryString;
          }
          else
                sURL = sURL.replace('listType', listType);
                $.get(sURL)
                .done(function (data) {
                    var navHeight = $(""#shipNavigation"").length > 0 ? $(""#shipNavigation"").height() : 0;
                    var max_height = ($(""#divBody"").height() - $(""#divFilterRecords"").height() - navHeight) * .75;
                    if (listType == ""Receive"") {
                        $(""#divReceiveList"").html(data);
                        $('#divReceiving').css({ 'max-height': max_height });
                    }
                    else {
                        $(""#divShipList"").html(data);
                        $('#divShipping').css({ 'max-height': max_height });
                    }
           ");
            WriteLiteral("         SetGridEvents();\r\n                    \r\n                })\r\n                .fail(function (error) {\r\n                    changeFeedbackMessage(\'error\', error);\r\n            });\r\n\r\n\r\n\r\n    }\r\n\r\n</script>\r\n");
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
