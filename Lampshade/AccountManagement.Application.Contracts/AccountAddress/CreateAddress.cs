namespace AccountManagement.Application.Contracts.AccountAddress
{
    public class CreateAddress
    {
        public long AccountId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CompleteAddress { get; set; }
    }

    public class AccountAddressSearchModel
    {
        public string FullName { get; set; }
        public string PostalCode { get; set; }
    }
}
