using _0_Framework.Domain;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Domain.AccountAddressAgg
{
    public class AccountAddress : EntityBase
    {
        public string State { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string CompleteAddress { get; private set; }
        public long AccountId { get; private set; }
        public Account UserAddress { get; private set; }

        public AccountAddress(string state, string city, string postalCode, string completeAddress, long accountId)
        {
            State = state;
            City = city;
            PostalCode = postalCode;
            CompleteAddress = completeAddress;
            AccountId = accountId;
        }
    }
}
