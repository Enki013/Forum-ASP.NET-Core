#pragma checksum "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "67400b1a3d934883e9cb3fd8ec99a09f5def1f823ca7976406339ebaa0c19331"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Post/Index.cshtml", typeof(AspNetCore.Views_Post_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"67400b1a3d934883e9cb3fd8ec99a09f5def1f823ca7976406339ebaa0c19331", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"c4b182b9a6db07814298e833b79f872714b4d55cb4f9f9f2de5ae4b5f0fe6faa", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AspNetCoreMvcIdentity.Models.PostViewModels.PostIndexModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Forum", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Reply", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" text-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(104, 5, true);
            WriteLiteral("\n<h1>");
            EndContext();
            BeginContext(110, 11, false);
#line 6 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(121, 6, true);
            WriteLiteral("</h1>\n");
            EndContext();
            BeginContext(127, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67400b1a3d934883e9cb3fd8ec99a09f5def1f823ca7976406339ebaa0c193318030", async() => {
                BeginContext(204, 13, true);
                WriteLiteral("Back to forum");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 7 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                                                 WriteLiteral(Model.ForumId);

#line default
#line hidden
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
            EndContext();
            BeginContext(221, 111, true);
            WriteLiteral("\n\n\n<div class=\"card\">\n\n    <div class=\"card-body row\">\n        <div class=\"col-2 text-center\">\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 332, "\"", 359, 1);
#line 14 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
WriteAttributeValue("", 338, Model.AuthorImageUrl, 338, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(360, 49, true);
            WriteLiteral(" width=\"60px\" />\n\n            <br />\n            ");
            EndContext();
            BeginContext(409, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67400b1a3d934883e9cb3fd8ec99a09f5def1f823ca7976406339ebaa0c1933111234", async() => {
                BeginContext(490, 16, false);
#line 17 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                                                                                       Write(Model.AuthorName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 17 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                                                               WriteLiteral(Model.AuthorId);

#line default
#line hidden
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
            EndContext();
            BeginContext(510, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 18 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
             if (Model.IsAuthorAdmin)
            {

#line default
#line hidden
            BeginContext(563, 98, true);
            WriteLiteral("                <br />\n                <p class=\"badge badge-dark\" style=\"width: 60px;\">Admin</p>\n");
            EndContext();
#line 22 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(675, 52, true);
            WriteLiteral("            <br />\n            Points:\n            (");
            EndContext();
            BeginContext(728, 18, false);
#line 25 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
        Write(Model.AuthorRating);

#line default
#line hidden
            EndContext();
            BeginContext(746, 82, true);
            WriteLiteral(")\n\n        </div>\n        <div class=\"col-10\">\n\n            <p class=\"card-text\"> ");
            EndContext();
            BeginContext(829, 17, false);
#line 30 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                             Write(Model.PostContent);

#line default
#line hidden
            EndContext();
            BeginContext(846, 92, true);
            WriteLiteral("</p>\n\n        </div>\n    </div>\n    <div class=\"card-footer text-muted\">\n        Posted on: ");
            EndContext();
            BeginContext(939, 13, false);
#line 35 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
              Write(Model.Created);

#line default
#line hidden
            EndContext();
            BeginContext(952, 28, true);
            WriteLiteral("\n    </div>\n</div>\n\n<br />\n\n");
            EndContext();
#line 41 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
 if (Model.Replies.Any())
{
    foreach (var reply in Model.Replies)
    {



#line default
#line hidden
            BeginContext(1057, 15, true);
            WriteLiteral("        <br />\n");
            EndContext();
            BeginContext(1073, 140, true);
            WriteLiteral("        <div class=\"card\">\n\n            <div class=\"card-body row\">\n                <div class=\"col-2 text-center\">\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1213, "\"", 1240, 1);
#line 53 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
WriteAttributeValue("", 1219, reply.AuthorImageUrl, 1219, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1241, 65, true);
            WriteLiteral(" width=\"60px\" />\n\n                    <br />\n                    ");
            EndContext();
            BeginContext(1306, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67400b1a3d934883e9cb3fd8ec99a09f5def1f823ca7976406339ebaa0c1933117195", async() => {
                BeginContext(1387, 16, false);
#line 56 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                                                                                               Write(reply.AuthorName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 56 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                                                                       WriteLiteral(reply.AuthorId);

#line default
#line hidden
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
            EndContext();
            BeginContext(1407, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 57 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                     if (reply.IsAuthorAdmin)
                    {

#line default
#line hidden
            BeginContext(1476, 114, true);
            WriteLiteral("                        <br />\n                        <p class=\"badge badge-dark\" style=\"width: 60px;\">Admin</p>\n");
            EndContext();
#line 61 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1612, 76, true);
            WriteLiteral("                    <br />\n                    Points:\n                    (");
            EndContext();
            BeginContext(1689, 18, false);
#line 64 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                Write(reply.AuthorRating);

#line default
#line hidden
            EndContext();
            BeginContext(1707, 106, true);
            WriteLiteral(")\n\n                </div>\n                <div class=\"col-10\">\n\n                    <p class=\"card-text\"> ");
            EndContext();
            BeginContext(1814, 18, false);
#line 69 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                                     Write(reply.ReplyContent);

#line default
#line hidden
            EndContext();
            BeginContext(1832, 124, true);
            WriteLiteral("</p>\n\n                </div>\n            </div>\n            <div class=\"card-footer text-muted\">\n                Posted on: ");
            EndContext();
            BeginContext(1957, 13, false);
#line 74 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                      Write(reply.Created);

#line default
#line hidden
            EndContext();
            BeginContext(1970, 35, true);
            WriteLiteral("\n            </div>\n        </div>\n");
            EndContext();
#line 77 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"




    }

}
else
{

#line default
#line hidden
            BeginContext(2024, 94, true);
            WriteLiteral(" <div class=\"text-center text-primary\">\n    <h3>There are no replies to this post</h3>\n</div>\n");
            EndContext();
#line 88 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2120, 19, true);
            WriteLiteral("\n\n\n<br />\n\n\n\n\n\n\n\n\n\n");
            EndContext();
#line 102 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
            BeginContext(2177, 36, true);
            WriteLiteral("    <div class=\"row\">\n        <span>");
            EndContext();
            BeginContext(2213, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67400b1a3d934883e9cb3fd8ec99a09f5def1f823ca7976406339ebaa0c1933123223", async() => {
                BeginContext(2305, 11, true);
                WriteLiteral("Add a Reply");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 105 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
                                                                                   WriteLiteral(Model.Id);

#line default
#line hidden
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
            EndContext();
            BeginContext(2320, 19, true);
            WriteLiteral("</span>\n    </div>\n");
            EndContext();
#line 107 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(2348, 88, true);
            WriteLiteral("<p class=\"text-center text-dark\">\n    You must be a registered user to add a reply.\n    ");
            EndContext();
            BeginContext(2436, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67400b1a3d934883e9cb3fd8ec99a09f5def1f823ca7976406339ebaa0c1933126313", async() => {
                BeginContext(2505, 5, true);
                WriteLiteral("Login");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2514, 8, true);
            WriteLiteral(" or\n    ");
            EndContext();
            BeginContext(2522, 96, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67400b1a3d934883e9cb3fd8ec99a09f5def1f823ca7976406339ebaa0c1933128003", async() => {
                BeginContext(2606, 8, true);
                WriteLiteral("Register");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2618, 15, true);
            WriteLiteral("\n    now.\n</p>\n");
            EndContext();
#line 116 "C:\Users\Enes\Desktop\bunu hallet\Forum-ASP.NET-Core-master\AspNetCoreMvcIdentity\Views\Post\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2635, 3, true);
            WriteLiteral("\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AspNetCoreMvcIdentity.Models.PostViewModels.PostIndexModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
