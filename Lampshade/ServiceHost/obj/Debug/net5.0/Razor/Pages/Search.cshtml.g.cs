#pragma checksum "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d9517f03c3ee7aa46e253778c3f5cd5ca4cfbd3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_Search), @"mvc.1.0.razor-page", @"/Pages/Search.cshtml")]
namespace ServiceHost.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d9517f03c3ee7aa46e253778c3f5cd5ca4cfbd3", @"/Pages/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49bdd27e8b016acb3c031a38b8da4d14315ca499", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Search : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
  
    ViewData["Title"] = "نتیجه جستجو";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <div class=""breadcrumb-content"">
                        <h2 class=""breadcrumb-content__title"">نتیجه جستجو برای ");
#nullable restore
#line 12 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                          Write(Model.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""shop-page-content"">

                                    <div class=""row shop-product-wrap grid three-column"">
");
#nullable restore
#line 30 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                         foreach (var product in Model.Products)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""col-12 col-lg-4 col-md-4 col-sm-6"">
                                                <div class=""single-grid-product grid-view-product"">
                                                    <div class=""single-grid-product__image"">
");
#nullable restore
#line 35 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                         if (product.HasDiscount)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"single-grid-product__label\">\r\n                                                                <span class=\"sale\">-");
#nullable restore
#line 38 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                               Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n                                                            </div>\r\n");
#nullable restore
#line 40 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a href=\"single-product.html\">\r\n                                                            <img");
            BeginWriteAttribute("src", " src=\"", 2096, "\"", 2118, 1);
#nullable restore
#line 42 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
WriteAttributeValue("", 2102, product.Picture, 2102, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", "\r\n                                                             alt=\"", 2137, "\"", 2224, 1);
#nullable restore
#line 43 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
WriteAttributeValue("", 2205, product.PictureAlt, 2205, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 2225, "\"", 2254, 1);
#nullable restore
#line 43 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
WriteAttributeValue("", 2233, product.PictureTitle, 2233, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                        </a>
                                                    </div>
                                                    <div class=""single-grid-product__content"">
                                                        <div class=""single-grid-product__category-rating"">
                                                            <span class=""category"">
                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d9517f03c3ee7aa46e253778c3f5cd5ca4cfbd38381", async() => {
#nullable restore
#line 49 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                                                                               Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                                                 WriteLiteral(product.CategorySlug);

#line default
#line hidden
#nullable disable
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
            WriteLiteral(@"
                                                            </span>
                                                            <span class=""rating"">
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star-outline""></i>
                                                            </span>
                                                        </div>

                                                        <h3 class=""single-grid-product__title"">
                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d9517f03c3ee7aa46e253778c3f5cd5ca4cfbd311815", async() => {
#nullable restore
#line 61 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                                     Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        </h3>\r\n                                                        <p class=\"single-grid-product__price\">\r\n");
#nullable restore
#line 64 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                             if (product.HasDiscount)
                                                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"discounted-price\">");
#nullable restore
#line 67 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                                          Write(product.PriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                                <span class=\"main-price discounted\">");
#nullable restore
#line 68 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                                               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 69 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"

                                                            }
                                                            else
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"main-price\">");
#nullable restore
#line 73 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                                    Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 74 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        </p>\r\n");
#nullable restore
#line 76 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                         if (product.HasDiscount)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"product-countdown\" data-countdown=\"");
#nullable restore
#line 78 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                                                                      Write(product.DiscountExpireDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \"></div>\r\n");
#nullable restore
#line 79 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </div>\r\n                                                </div>\r\n\r\n                                            </div>\r\n");
#nullable restore
#line 84 "D:\آموزش\رزومه\Code\Lampshade\ServiceHost\Pages\Search.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                    </div>

                                </div>

                                <div class=""pagination-area"">
                                    <div class=""pagination-area__left"">
                                        Showing 1 to 9 of 11 (2 Pages)
                                    </div>
                                    <div class=""pagination-area__right"">
                                        <ul class=""pagination-section"">
                                            <li>
                                                <a class=""active"" href=""#"">1</a>
                                            </li>
                                            <li>
                                                <a href=""#"">2</a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
               ");
            WriteLiteral("         </div>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.SearchModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.SearchModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.SearchModel>)PageContext?.ViewData;
        public ServiceHost.Pages.SearchModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591