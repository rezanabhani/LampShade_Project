using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.CategoryType;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories;
        public SelectList CategoryTypes;

        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly ICategoryTypeApplication _categoryTypeApplication;
        public IndexModel(IProductCategoryApplication productCategoryApplication,ICategoryTypeApplication categoryTypeApplication)
        {
            _productCategoryApplication = productCategoryApplication;
            _categoryTypeApplication = categoryTypeApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            CategoryTypes = new SelectList(_categoryTypeApplication.GetCategoryTypes(), "Id", "Name");
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductCategory()
            {
                CategoryTypes = _categoryTypeApplication.GetCategoryTypes()
            };
            ;
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryApplication.GetDetails(id);
            productCategory.CategoryTypes = _categoryTypeApplication.GetCategoryTypes();
            return Partial("./Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if (ModelState.IsValid)
            {

            }
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
