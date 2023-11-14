using _0_Framework.Domain;
using AccountManagement.Application.Contracts.AccountAddress;
using System.Collections.Generic;

namespace AccountManagement.Domain.AccountAddressAgg
{
    public interface IAccountAddressRepository : IRepository<long,AccountAddress>
    {
        List<AccountAddressViewModel> GetAccountAddresses(AccountAddressSearchModel searchModel);
        List<AccountAddressViewModel> GetAccountAddress();
    }
}
