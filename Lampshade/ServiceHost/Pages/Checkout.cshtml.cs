using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts;
using AccountManagement.Application.Contracts.AccountAddress;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Pages
{
    public class CheckoutModel : PageModel
    {
        public Cart Cart;
        public const string CookieName = "cart-items";
        public bool HasAccountAddress;
        public long accountId;
        public CreateAddress command;
        private readonly ICartCalculatorService _cartCalculatorService;
        private readonly IAccountAddressApplication _accountAddressApplication;
        private readonly IAuthHelper _authHelper;

        public CheckoutModel(ICartCalculatorService cartCalculatorService, IAccountAddressApplication accountAddressApplication, IAuthHelper authHelper)
        {
            _cartCalculatorService = cartCalculatorService;
            _accountAddressApplication = accountAddressApplication;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
            HasAccountAddress = _accountAddressApplication.HasAddress(_authHelper.CurrentAccountId());
            accountId = _authHelper.CurrentAccountId();
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
                item.CalculateTotalItemPrice();

            Cart = _cartCalculatorService.ComputeCart(cartItems);
        }

        public IActionResult OnPostAddAddress(CreateAddress command)
        {
           var result = _accountAddressApplication.Create(command);
            return RedirectToPage("/Checkout");
        }
    }
}
