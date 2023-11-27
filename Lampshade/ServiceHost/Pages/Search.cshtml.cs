using System;
using System.Collections.Generic;
using System.Linq;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {

        public string Value;
        public string Message;
        public List<ProductQueryModel> Products;
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; private set; }
        public const int PageSize = 8; // Number of items p
        private readonly IProductQuery _productQuery;

        public SearchModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string value, int pageIndex = 1)
        {
            Value = value;
            Products = _productQuery.Search(value);

            TotalPages = (int)Math.Ceiling(Products.Count / (double)PageSize);

            // Ensure pageIndex is within valid range
            PageIndex = Math.Max(1, Math.Min(pageIndex, TotalPages));

            // Update Products to include only items for the current page
            Products = Products.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();

            if (!Products.Any())
            {
                Message = " نتیجه ای مرتبط با جستجو شما یافت نشد .";
            }
        }
    }
}