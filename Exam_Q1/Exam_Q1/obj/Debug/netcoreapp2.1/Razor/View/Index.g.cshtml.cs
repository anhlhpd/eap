#pragma checksum "C:\Users\Phuong Anh\Desktop\EAP\Exam_Q1\Exam_Q1\View\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb627140b9264390a64ffdc7b074902c2d19a376"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.View_Index), @"mvc.1.0.razor-page", @"/View/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/View/Index.cshtml", typeof(AspNetCore.View_Index), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb627140b9264390a64ffdc7b074902c2d19a376", @"/View/Index.cshtml")]
    public class View_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 1347, true);
            WriteLiteral(@"
<section class=""content-header"">
    <div class=""limiter"">
        <div class=""container-table150"">
            <div class=""wrap-table100"">
                <div class=""table100 ver1"">
                    <div class=""#"">
                        <table>
                            <thead>
                                <tr class=""row100 head"">
                                    <th class="""" style=""padding: 20px;"">ID</th>
                                    <th class=""cell100 column2"">Username</th>
                                    <th class=""cell100 column3"">FirstName</th>
                                    <th class=""cell100 column4"">LastName</th>
                                    <th class=""cell100 column5"">Gender</th>
                                    <th class=""cell100 column6"">Birthday</th>
                                    <th class=""cell100 column7"">Email</th>
                                    <th class=""cell100 column7"">Status</th>
                                    <th ");
            WriteLiteral(@"class=""cell100 column8"">Action</th>
                                </tr>
                            </thead>
                            <tbody class="" tb-content""></tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Exam_Q1.Model.Currency> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Exam_Q1.Model.Currency> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Exam_Q1.Model.Currency>)PageContext?.ViewData;
        public Exam_Q1.Model.Currency Model => ViewData.Model;
    }
}
#pragma warning restore 1591
