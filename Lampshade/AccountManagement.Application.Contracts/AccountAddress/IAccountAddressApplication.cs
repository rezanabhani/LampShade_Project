using System.Collections.Generic;
using _0_Framework.Application;

namespace AccountManagement.Application.Contracts.AccountAddress
{
    public interface IAccountAddressApplication
    {
        OperationResult Create(CreateAddress command);
        List<AccountAddressViewModel> GetAccountAddresses(AccountAddressSearchModel searchModel);
        bool HasAddress(long id);
        List<AccountAddressViewModel> GetAccountAddress();
    }
}
