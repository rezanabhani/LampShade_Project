using System.Linq;
using _01_LampshadeReport.Contracts.Account;
using AccountManagement.Infrastructure.EFCore;

namespace _01_LampshadeReport.Query
{
    public class AccountReport : IAccountReport
    {
        private readonly AccountContext _accountContext;

        public AccountReport(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public long CountUsers()
        {
            var countUsers = _accountContext.Accounts.ToList().Count;
            return countUsers;
        }
    }
}
