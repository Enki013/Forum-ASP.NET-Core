#pragma checksum "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "93f5077772703df10cccae41e3e6c85e8350f8c154f68e7a4b86efc87daa7b6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Index), @"mvc.1.0.view", @"/Views/Profile/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profile/Index.cshtml", typeof(AspNetCore.Views_Profile_Index))]
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
#line 1 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\_ViewImports.cshtml"
using AspNetCoreMvcIdentity;

#line default
#line hidden
#line 3 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\_ViewImports.cshtml"
using AspNetCoreMvcIdentity.Models;

#line default
#line hidden
#line 4 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\_ViewImports.cshtml"
using AspNetCoreMvcIdentity.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\_ViewImports.cshtml"
using AspNetCoreMvcIdentity.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"93f5077772703df10cccae41e3e6c85e8350f8c154f68e7a4b86efc87daa7b6c", @"/Views/Profile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"c4b182b9a6db07814298e833b79f872714b4d55cb4f9f9f2de5ae4b5f0fe6faa", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AspNetCoreMvcIdentity.Models.ApplicationUserViewModels.ProfileListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(118, 387, true);
            WriteLiteral(@"
<h1>Index</h1>

<div class=""row"">
    List of all users
</div>

<div class=""row"">
    <table class=""table table-bordered table-hover"">
        <thead>
            <tr>
                <th>Image</th>
                <th>Username</th>
                <th>Email</th>
                <th>Member Since</th>
                <th>Rating </th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 24 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml"
             foreach( var user in Model.Profiles)
            {

#line default
#line hidden
            BeginContext(569, 49, true);
            WriteLiteral("                <tr>\n                    <td><img");
            EndContext();
            BeginWriteAttribute("src", "  src=\"", 618, "\"", 646, 1);
#line 27 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml"
WriteAttributeValue("", 625, user.ProfileImageUrl, 625, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(647, 45, true);
            WriteLiteral(" width=\"50px\"/></td>\n                    <td>");
            EndContext();
            BeginContext(693, 13, false);
#line 28 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml"
                   Write(user.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(706, 30, true);
            WriteLiteral("</td>\n                    <td>");
            EndContext();
            BeginContext(737, 10, false);
#line 29 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml"
                   Write(user.Email);

#line default
#line hidden
            EndContext();
            BeginContext(747, 30, true);
            WriteLiteral("</td>\n                    <td>");
            EndContext();
            BeginContext(778, 16, false);
#line 30 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml"
                   Write(user.MemberSince);

#line default
#line hidden
            EndContext();
            BeginContext(794, 30, true);
            WriteLiteral("</td>\n                    <td>");
            EndContext();
            BeginContext(825, 15, false);
#line 31 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml"
                   Write(user.UserRating);

#line default
#line hidden
            EndContext();
            BeginContext(840, 28, true);
            WriteLiteral("</td>\n                </tr>\n");
            EndContext();
#line 33 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Profile\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(882, 37, true);
            WriteLiteral("        </tbody>\n    </table>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AspNetCoreMvcIdentity.Models.ApplicationUserViewModels.ProfileListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
