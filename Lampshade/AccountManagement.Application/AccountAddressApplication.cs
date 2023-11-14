using System.Collections.Generic;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.AccountAddress;
using AccountManagement.Domain.AccountAddressAgg;

namespace AccountManagement.Application
{
    public class AccountAddressApplication : IAccountAddressApplication
    {
        private readonly IAccountAddressRepository _accountAddressRepository;

        public AccountAddressApplication(IAccountAddressRepository accountAddressRepository)
        {
            _accountAddressRepository = accountAddressRepository;
        }

        public OperationResult Create(CreateAddress command)
        {
            var operation = new OperationResult();
            if (_accountAddressRepository.Exists(x =>
                    x.AccountId == command.AccountId && x.PostalCode == command.PostalCode))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var accountAddress = new AccountAddress(command.State, command.City, command.PostalCode,
                command.CompleteAddress, command.AccountId);

            _accountAddressRepository.Create(accountAddress);
            _accountAddressRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<AccountAddressViewModel> GetAccountAddresses(AccountAddressSearchModel searchModel)
        {
            return _accountAddressRepository.GetAccountAddresses(searchModel);
        }

        public bool HasAddress(long id)
        {
            if(_accountAddressRepository.Exists(x => x.AccountId == id))
                return true;
            return false;
        }

        public List<AccountAddressViewModel> GetAccountAddress()
        {
            return _accountAddressRepository.GetAccountAddress();
        }
    }
}
