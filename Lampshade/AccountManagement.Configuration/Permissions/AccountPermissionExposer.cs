using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace AccountManagement.Configuration.Permissions
{
    public class AccountPermissionExposer : IPermissionsExposer
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {
                {
                    "ShowAccountManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(AccountPermissions.ShowAccountManagement, "ShowAccountManagement"),
                        new PermissionsDto(AccountPermissions.LoginPanelAdmin, "LoginPanelAdmin")
                    }
                },
                {
                    "AccountManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(AccountPermissions.ShowAccount, "ShowAccount"),
                        new PermissionsDto(AccountPermissions.ListAccounts, "ListAccounts"),
                        new PermissionsDto(AccountPermissions.SearchAccounts, "SearchAccounts"),
                        new PermissionsDto(AccountPermissions.RegisterAccount, "RegisterAccount"),
                        new PermissionsDto(AccountPermissions.EditAccount, "EditAccount"),
                        new PermissionsDto(AccountPermissions.ChangePassword, "ChangePassword"),
                    }
                },
                {
                    "RoleManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(AccountPermissions.ShowRoleManagement, "ShowRoleManagement"),
                        new PermissionsDto(AccountPermissions.ListRoles, "ListRoles"),
                        new PermissionsDto(AccountPermissions.SearchRoles, "SearchRoles"),
                        new PermissionsDto(AccountPermissions.CreateRole, "CreateRole"),
                        new PermissionsDto(AccountPermissions.EditRole, "EditRole"),
                    }
                },
                {
                    "AccountAddressManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(AccountPermissions.ShowAccountAddress, "ShowAccountAddress"),
                        new PermissionsDto(AccountPermissions.ListAccountAddress, "ListAccountAddress"),
                    }
                    }
            };
        }
    }
}
