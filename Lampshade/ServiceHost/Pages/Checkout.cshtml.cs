﻿using Microsoft.AspNetCore.Mvc.RazorPages;
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
using Microsoft.AspNetCore.Authorization;

namespace ServiceHost.Pages
{
    [Authorize]
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
            Cart = new Cart();
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

        public IActionResult OnPostPay(int paymentMethod)
        {
            var cart = _cartService.Get();
            cart.SetPaymentMethod(paymentMethod);

            var result = _productQuery.CheckInventoryStatus(cart.Items);
            if (result.Any(x => !x.IsInStock))
                return RedirectToPage("/Cart");

            var orderId = _orderApplication.PlaceOrder(cart);
            if (paymentMethod == 1)
            {
                var paymentResponse = _zarinPalFactory.CreatePaymentRequest(
                    cart.PayAmount.ToString(CultureInfo.InvariantCulture), "", "",
                    "خرید از درگاه لوازم خانگی و دکوری", orderId);

                return Redirect(
                    $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
            }

            var paymentResult = new PaymentResult();
            return RedirectToPage("/PaymentResult",
                paymentResult.Succeeded(
                    "سفارش شما با موفقیت ثبت شد. پس از تماس کارشناسان ما و پرداخت وجه، سفارش ارسال خواهد شد.", null));
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId)
        {
            var orderAmount = _orderApplication.GetAmountBy(oId);
            var verificationResponse = _zarinPalFactory.CreateVerificationRequest(authority, orderAmount.ToString());

            var result = new PaymentResult();
            if (status == "OK" && verificationResponse.Status == 100)
            {
                var issueTrackingNo = _orderApplication.PaymentSucceeded(oId, verificationResponse.RefID);
                Response.Cookies.Delete("cart-items");
                result = result.Succeeded("پرداخت با موفقیت انجام شد .", issueTrackingNo);
                return RedirectToPage("/PaymentResult", result);
            }

            result = result.Failed("پرداخت با موفقیت انجام نشد. در صورت کسر  وجه  از حساب  مبلغ  تا  24 ساعت  دیگر  به حساب  شما  بازگردانده  خواهد شد .");
            return RedirectToPage("/PaymentResult", result);

        }

        public IActionResult OnPostAddAddress(CreateAddress command)
        {
            var result = _accountAddressApplication.Create(command);
            return RedirectToPage("/Checkout");
        }

    }
}
