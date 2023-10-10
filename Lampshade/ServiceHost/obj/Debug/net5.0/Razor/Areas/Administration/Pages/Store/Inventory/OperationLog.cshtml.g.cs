#pragma checksum "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a9439717ebd0b3ab3d90d2850db4cfa8f33833a0a12ea8a2dcbf161d8098c8dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Administration.Pages.Store.Inventory.Areas_Administration_Pages_Store_Inventory_OperationLog), @"mvc.1.0.view", @"/Areas/Administration/Pages/Store/Inventory/OperationLog.cshtml")]
namespace ServiceHost.Areas.Administration.Pages.Store.Inventory
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a9439717ebd0b3ab3d90d2850db4cfa8f33833a0a12ea8a2dcbf161d8098c8dd", @"/Areas/Administration/Pages/Store/Inventory/OperationLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4e128e413e640fcff302de4da4560ffe7647658218a0c70ddc07ba038f526bc4", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administration_Pages_Store_Inventory_OperationLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
    <h4 class=""modal-title"">سوابق گردش انبار</h4>
</div>

    <div class=""modal-body"">
        <table class=""table table-bordered"">
            <thead>
            <tr>
                <th>#</th>
                <th>تعداد</th>
                <th>تاریخ</th>
                <th>عملیات</th>
                <th>موجودی فعلی</th>
                <th>عملگر</th>
                <th>توضیحات</th>
            </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 24 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("class", " class=\"", 765, "\"", 830, 2);
            WriteAttributeValue("", 773, "text-white", 773, 10, true);
#nullable restore
#line 26 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
WriteAttributeValue(" ", 783, item.Operation ? "bg-success" : "bg-danger", 784, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>");
#nullable restore
#line 27 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                   Write(item.OperationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 31 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                         if (item.Operation)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>افزایش</span>\r\n");
#nullable restore
#line 34 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>کاهش</span>\r\n");
#nullable restore
#line 38 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>");
#nullable restore
#line 40 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                   Write(item.CurrentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 41 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                   Write(item.Operator);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 42 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 44 "D:\Project\Code\Lampshade\ServiceHost\Areas\Administration\Pages\Store\Inventory\OperationLog.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("           \r\n            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n        <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n    </div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
