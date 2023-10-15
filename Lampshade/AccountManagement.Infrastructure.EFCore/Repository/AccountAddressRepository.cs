using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.AccountAddress;
using AccountManagement.Domain.AccountAddressAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountAddressRepository : RepositoryBase<long, AccountAddress>, IAccountAddressRepository
    {
        private readonly AccountContext _context;
        public AccountAddressRepository(AccountContext context) : base(context)
        {
            _context = context;

        }


        public List<AccountAddressViewModel> GetAccountAddresses(AccountAddressSearchModel searchModel)
        {
            var query = _context.AccountAddresses
                .Include(x => x.UserAddress)
                .Select(x => new AccountAddressViewModel()
                {
                    Id = x.Id,
                    Account = x.UserAddress.Fullname,
                    State = x.State,
                    City = x.City,
                    PostalCode = x.PostalCode,
                    CompleteAddress = x.CompleteAddress,
                    CreationDate = x.CreationDate.ToFarsi()
                });

            
            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
                query = query.Where(x => x.Account.Contains(searchModel.FullName));

            if (!string.IsNullOrWhiteSpace(searchModel.PostalCode))
                query = query.Where(x => x.PostalCode.Contains(searchModel.PostalCode));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
