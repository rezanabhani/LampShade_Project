using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using Newtonsoft.Json;
using ShopManagement.Application.Contracts.Order;


namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public const string CookieName = "cart-items";
        private readonly IProductQuery _productQuery;
        private readonly IAuthHelper _authHelper;
        public List<CartItem> CartItems;

        public CartModel(IProductQuery productQuery, IAuthHelper authHelper)
        {
            CartItems = new List<CartItem>();
            _productQuery = productQuery;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
                item.CalculateTotalItemPrice();

            CartItems = _productQuery.CheckInventoryStatus(cartItems);
        }

        public IActionResult OnGetRemoveFromCart(int id)
        {
            var cart = HttpContext.Request.Cookies["cart-items"];
            var items = JsonConvert.DeserializeObject<List<CartItem>>(cart) ?? new List<CartItem>();

            // Find the item to remove from the cart
            var itemToRemove = items.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);

                // Update the cart cookie
                HttpContext.Response.Cookies.Append("cart-items", JsonConvert.SerializeObject(items));
            }

            return RedirectToPage("/Cart");
        }
        

        public IActionResult OnGetGoToCheckOut()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
                item.CalculateTotalItemPrice();

            CartItems = _productQuery.CheckInventoryStatus(cartItems);

            if (!_authHelper.IsAuthenticated())
                return RedirectToPage("/Account");

            return RedirectToPage(CartItems.Any(x => !x.IsInStock) ? "/Cart" : "/CheckOut");
        }

    }
}
