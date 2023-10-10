using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace DiscountManagement.Configuration.Permissions
{
    public class DiscountPermissionExposer : IPermissionsExposer
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {
                {
                    "ShowDiscountManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(DiscountPermissions.ShowDiscountManagement, "ShowDiscountManagement"),
                    }
                },
                {
                    "CustomerDiscount", new List<PermissionsDto>
                    {
                        new PermissionsDto(DiscountPermissions.ShowCustomerDiscountManagement,
                            "ShowCustomerDiscountManagement"),
                        new PermissionsDto(DiscountPermissions.ListCustomerDiscounts, "ListCustomerDiscounts"),
                        new PermissionsDto(DiscountPermissions.SearchCustomerDiscounts, "SearchCustomerDiscounts"),
                        new PermissionsDto(DiscountPermissions.CreateCustomerDiscount, "CreateCustomerDiscount"),
                        new PermissionsDto(DiscountPermissions.EditCustomerDiscount, "EditCustomerDiscount"),
                    }
                },
                {
                    "ColleagueDiscount", new List<PermissionsDto>
                    {
                        new PermissionsDto(DiscountPermissions.ShowColleagueDiscountManagement, "ShowColleagueDiscountManagement"),
                        new PermissionsDto(DiscountPermissions.ListColleagueDiscounts, "ListColleagueDiscounts"),
                        new PermissionsDto(DiscountPermissions.SearchColleagueDiscounts, "SearchColleagueDiscounts"),
                        new PermissionsDto(DiscountPermissions.CreateColleagueDiscount, "CreateColleagueDiscount"),
                        new PermissionsDto(DiscountPermissions.EditColleagueDiscount, "EditColleagueDiscount"),
                        new PermissionsDto(DiscountPermissions.RemoveColleagueDiscount, "RemoveColleagueDiscount"),
                        new PermissionsDto(DiscountPermissions.RestoreColleagueDiscount, "RestoreColleagueDiscount"),
                    }
                }
            };
        }
    }
}
