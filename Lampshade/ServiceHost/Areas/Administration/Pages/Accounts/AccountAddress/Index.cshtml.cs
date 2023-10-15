using System.Collections.Generic;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.AccountAddress;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.AccountAddress
{
    public class IndexModel : PageModel
    {
       
        public AccountAddressSearchModel SearchModel;
        public List<AccountAddressViewModel> AccountAddress;


        private readonly IAccountAddressApplication _accountAddressApplication;

        public IndexModel(IAccountAddressApplication accountAddressApplication)
        {
           _accountAddressApplication = accountAddressApplication;
        }

        [NeedsPermission(AccountPermissions.ListAccountAddress)]
        public void OnGet(AccountAddressSearchModel searchModel)
        {
            AccountAddress = _accountAddressApplication.GetAccountAddresses(searchModel);
        }
    }
}
