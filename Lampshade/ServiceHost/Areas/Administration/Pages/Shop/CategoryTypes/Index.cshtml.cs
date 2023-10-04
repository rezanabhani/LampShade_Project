using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.CategoryType;

namespace ServiceHost.Areas.Administration.Pages.Shop.CategoryTypes
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<CategoryTypeViewModel> Categories;
       

        private readonly ICategoryTypeApplication _categoryTypeApplication;


        public IndexModel(ICategoryTypeApplication categoryTypeApplication)
        {
            _categoryTypeApplication = categoryTypeApplication;
        }

        public void OnGet()
        {
            Categories = _categoryTypeApplication.GetCategories();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateCategoryType();

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateCategoryType command)
        {
            var result = _categoryTypeApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var categoryType = _categoryTypeApplication.GetDetails(id);
            return Partial("./Edit", categoryType);
        }

        public JsonResult OnPostEdit(EditCategoryType command)
        {
            var result = _categoryTypeApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
