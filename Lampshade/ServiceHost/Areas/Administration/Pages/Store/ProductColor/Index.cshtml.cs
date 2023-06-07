using System.Collections.Generic;
using InventoryManagement.Application.Contract.ProductColor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Store.ProductColor
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<ProductColorViewModel> ProductColors;


        private readonly IProductColorApplication _productColorApplication;

        public IndexModel(IProductColorApplication productColorApplication)
        {
            _productColorApplication = productColorApplication;
        }

        public void OnGet()
        {
            ProductColors = _productColorApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateColor();
            return Partial("./Create",command );
        }

        public JsonResult OnPostCreate(CreateColor command)
        {
            var result = _productColorApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _productColorApplication.GetDetails(id);
          
            return Partial("./Edit", slide);
        }

        public JsonResult OnPostEdit(EditColor command)
        {
            var result = _productColorApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
