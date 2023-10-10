namespace DiscountManagement.Configuration.Permissions
{
    public static class DiscountPermissions
    {
        //ShowDiscountManagement
        public const int ShowDiscountManagement = 99;

        // CustomerDiscount
        public const int ShowCustomerDiscountManagement = 100;
        public const int ListCustomerDiscounts = 101;
        public const int SearchCustomerDiscounts = 102;
        public const int CreateCustomerDiscount = 103;
        public const int EditCustomerDiscount = 104;

        // ColleagueDiscount
        public const int ShowColleagueDiscountManagement = 120;
        public const int ListColleagueDiscounts = 121;
        public const int SearchColleagueDiscounts = 122;
        public const int CreateColleagueDiscount = 123;
        public const int EditColleagueDiscount = 124;
        public const int RemoveColleagueDiscount = 125;
        public const int RestoreColleagueDiscount = 126;
    }
}
