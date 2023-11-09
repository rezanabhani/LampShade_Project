using System.Collections.Generic;
using _01_LampshadeQuery.Contracts.Product;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EfCore;
using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        [TempData]
        public string SuccessMessage { get; set; }

        public ProductQueryModel Product;
        public List<ProductQueryModel> RelatedProducts;
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication,
            IInventoryApplication inventoryApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }


        public void OnGet(string id)
        {
            Product = _productQuery.GetProductDetails(id);
            RelatedProducts = _productQuery.GetRelatedProducts(id);
        }

        public IActionResult OnPost(AddComment command, string productSlug)
        {
            command.Type = CommentType.Product;
            var result = _commentApplication.Add(command);

            return RedirectToPage("/Product", new { Id = productSlug });
        }

    }
}