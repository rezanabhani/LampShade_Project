using System.Collections.Generic;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Application.Contract.ProductColor;
using InventoryManagement.InfrastructureConfiguration.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Store.Inventory
{
    [Authorize(Roles = Roles.Administrator)]
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public InventorySearchModel SearchModel;
        public List<InventoryViewModel> Inventory;
        public SelectList Products;
        public SelectList ProductColors;

        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;
        private readonly IProductColorApplication _productColorApplication;

        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication, IProductColorApplication productColorApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
            _productColorApplication = productColorApplication;
        }


        [NeedsPermission(InventoryPermissions.ListInventory)]
        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductColors = new SelectList(_productColorApplication.GetList(), "Id", "Color");
            Inventory = _inventoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory()
            {
                Products = _productApplication.GetProducts(),
                ProductColors = _productColorApplication.GetList()
            };
            return Partial("./Create", command);
        }

        [NeedsPermission(InventoryPermissions.CreateInventory)]
        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var inventory = _inventoryApplication.GetDetails(id);
            inventory.Products = _productApplication.GetProducts();
            inventory.ProductColors =_productColorApplication.GetList();
            return Partial("./Edit", inventory);
        }

        [NeedsPermission(InventoryPermissions.EditInventory)]
        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryId = id
            };
            return Partial("./Increase", command);
        }

        [NeedsPermission(InventoryPermissions.Increase)]
        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventory()
            {
                InventoryId = id
            };
            return Partial("./Reduce", command);
        }

        [NeedsPermission(InventoryPermissions.Reduce)]
        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }

        [NeedsPermission(InventoryPermissions.OperationLog)]
        public IActionResult OnGetLog(long id)
        {
            var log = _inventoryApplication.GetOperationLog(id);
            return Partial("OperationLog", log);
        }

        [NeedsPermission(InventoryPermissions.Remove)]
        public IActionResult OnGetRemove(long id)
        {
            var result = _inventoryApplication.Remove(id);

            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }

        [NeedsPermission(InventoryPermissions.Restore)]

        public IActionResult OnGetRestore(long id)
        {
            var result = _inventoryApplication.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

    }
}
