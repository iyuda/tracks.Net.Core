#pragma checksum "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Part\_TestInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ca393a99786eca723fd97bce23049de8bc893b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Accounting_Views_Part__TestInfo), @"mvc.1.0.view", @"/Areas/Accounting/Views/Part/_TestInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Accounting/Views/Part/_TestInfo.cshtml", typeof(AspNetCore.Areas_Accounting_Views_Part__TestInfo))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ca393a99786eca723fd97bce23049de8bc893b7", @"/Areas/Accounting/Views/Part/_TestInfo.cshtml")]
    public class Areas_Accounting_Views_Part__TestInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tracs.Common.Models.TestInfoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 247, true);
            WriteLiteral("<div class=\"card border-light mb-3\" style=\"width:20rem;max-width: 15rem;\">\r\n    <div class=\"card-header font-weight-light cardheaderfixed\">Test Info</div>\r\n    <div class=\"card-body\" style=\"font-size:small;padding:2px 2px 2px 2px;height:120px;\">\r\n");
            EndContext();
#line 5 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Part\_TestInfo.cshtml"
         if (Model == null)
        {

#line default
#line hidden
            BeginContext(329, 50, true);
            WriteLiteral("            <span>No Test Info available.</span>\r\n");
            EndContext();
#line 8 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Part\_TestInfo.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(415, 113, true);
            WriteLiteral("            <table>\r\n                <tr>\r\n                    <td class=\"headerBasic\">\r\n                        ");
            EndContext();
            BeginContext(529, 47, false);
#line 14 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Part\_TestInfo.cshtml"
                   Write(Html.DisplayNameFor(model => model.TestDateStr));

#line default
#line hidden
            EndContext();
            BeginContext(576, 80, true);
            WriteLiteral(":\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(657, 43, false);
#line 17 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Part\_TestInfo.cshtml"
                   Write(Html.DisplayFor(model => model.TestDateStr));

#line default
#line hidden
            EndContext();
            BeginContext(700, 144, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"headerBasic\">\r\n                        ");
            EndContext();
            BeginContext(845, 57, false);
#line 22 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Part\_TestInfo.cshtml"
                   Write(Html.DisplayNameFor(model => model.TestResultDescription));

#line default
#line hidden
            EndContext();
            BeginContext(902, 80, true);
            WriteLiteral(":\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(983, 53, false);
#line 25 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Part\_TestInfo.cshtml"
                   Write(Html.DisplayFor(model => model.TestResultDescription));

#line default
#line hidden
            EndContext();
            BeginContext(1036, 74, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n");
            EndContext();
#line 29 "C:\Users\igor\source\repos\Tracs_Portal\TRACSPortal\Areas\Accounting\Views\Part\_TestInfo.cshtml"
        }

#line default
#line hidden
            BeginContext(1121, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tracs.Common.Models.TestInfoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
