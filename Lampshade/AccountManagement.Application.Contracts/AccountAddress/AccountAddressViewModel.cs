namespace AccountManagement.Application.Contracts.AccountAddress
{
    public class AccountAddressViewModel
    {
        public long Id { get; set; }
        public string Account { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CompleteAddress { get; set; }
        public string CreationDate { get; set; }
    }
}