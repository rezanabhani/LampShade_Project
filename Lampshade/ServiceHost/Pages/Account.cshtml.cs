using _0_Framework.Application;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        [TempData]
        public string Mobile { get; set; }

        public bool SendCode = false;

        public string Pass { get; set; }

        public bool IsMobile = false;
        public bool ErrorVerify = false;

        private readonly IAccountApplication _accountApplication;
        private readonly IPasswordHasher _passwordHasher;

        public AccountModel(IAccountApplication accountApplication, IPasswordHasher passwordHasher)
        {
            _accountApplication = accountApplication;
            _passwordHasher = passwordHasher;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(Login command)
        {

            var pass = _accountApplication.GetPassword(command.Mobile);
            if (pass != command.Password)
            {
                Message = "کد تایید وارد شده صحیح نمی باشد";
                ErrorVerify = true;
                Pass = command.Password;
                Mobile = command.Mobile;
                IsMobile = true;
                return Page();
            }


            var result = _accountApplication.Login(command);
            if (result.IsSuccedded)
                return RedirectToPage("/Index");


            return RedirectToPage("/Account");

        }

        public IActionResult OnPostSendCode(Login command)
        {
            var operation = new OperationResult();
            var result = _accountApplication.SendCode(command);
            if (result.IsSuccedded)
            {
                Mobile = command.Mobile;
                SendCode = true;
                IsMobile = true;
            }

            if (!result.IsSuccedded)
            {
                Message = "کاربری با شماره وارد شده یافت نشد";
            }

            return Page();
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostRegister(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            if (result.IsSuccedded)
            {
                SuccessMessage = " ثبت نام شما با موفقیت انجام شد";
            }

            if (!result.IsSuccedded)
            {
                RegisterMessage = "کاربر با اطلاعات وارد شده قبلا در سایت ثبت نام شده است .";
            }
          
            return Page();
        }

    }
}
