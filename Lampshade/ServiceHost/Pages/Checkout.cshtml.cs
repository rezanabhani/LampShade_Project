using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _01_LampshadeQuery.Contracts;
using _01_LampshadeQuery.Contracts.Product;
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
        private readonly ICartService _cartService;
        private readonly ICartCalculatorService _cartCalculatorService;
        private readonly IZarinPalFactory _zarinPalFactory;
        private readonly IProductQuery _productQuery;
        private readonly IAccountAddressApplication _accountAddressApplication;
        private readonly IAuthHelper _authHelper;
        private readonly IOrderApplication _orderApplication;

        public CheckoutModel(ICartService cartService, ICartCalculatorService cartCalculatorService, IZarinPalFactory zarinPalFactory, IProductQuery productQuery, IAccountAddressApplication accountAddressApplication, IAuthHelper authHelper, IOrderApplication orderApplication)
        {
            _cartService = cartService;
            _cartCalculatorService = cartCalculatorService;
            _zarinPalFactory = zarinPalFactory;
            _productQuery = productQuery;
            _accountAddressApplication = accountAddressApplication;
            _authHelper = authHelper;
            _orderApplication = orderApplication;
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
            _cartService.Set(Cart);
        }

        public IActionResult OnGetPay()
        {
            var cart = _cartService.Get();

            var result = _productQuery.CheckInventoryStatus(cart.Items);
            if (result.Any(x => !x.IsInStock))
                return RedirectToPage("/Cart");

            var orderId = _orderApplication.PlaceOrder(cart);

            var paymentResponse = _zarinPalFactory.CreatePaymentRequest(
                cart.PayAmount.ToString(CultureInfo.InvariantCulture), "", "",
                "خرید از درگاه لوازم خانگی و دکوری", orderId);

            return Redirect(
              $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId)
        {
            return null;
        }

        public IActionResult OnPostAddAddress(CreateAddress command)
        {
            var result = _accountAddressApplication.Create(command);
            return RedirectToPage("/Checkout");
        }

    }
}
