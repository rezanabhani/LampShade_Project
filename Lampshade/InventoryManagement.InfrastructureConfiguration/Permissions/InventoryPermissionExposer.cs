using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace InventoryManagement.InfrastructureConfiguration.Permissions
{
    public class InventoryPermissionExposer : IPermissionsExposer
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {
                {
                    "Inventory", new List<PermissionsDto>
                    {
                        new PermissionsDto(InventoryPermissions.ListInventory,"ListInventory"),
                        new PermissionsDto(InventoryPermissions.SearchInventory,"SearchInventory"),
                        new PermissionsDto(InventoryPermissions.CreateInventory,"CreateInventory"), 
                        new PermissionsDto(InventoryPermissions.EditInventory,"EditInventory"),
                        new PermissionsDto(InventoryPermissions.Increase,"Increase"),
                        new PermissionsDto(InventoryPermissions.Reduce,"Reduce"),
                        new PermissionsDto(InventoryPermissions.OperationLog,"OperationLog"),
                        new PermissionsDto(InventoryPermissions.Remove,"Remove"),
                        new PermissionsDto(InventoryPermissions.Restore,"Restore"),
                    }
                },
                {
                    "ProductColor", new List<PermissionsDto>
                    {
                        new PermissionsDto(InventoryPermissions.ListProductColor,"ListProductColor"),
                        new PermissionsDto(InventoryPermissions.CreateProductColor,"CreateProductColor"),
                        new PermissionsDto(InventoryPermissions.EditProductColor,"EditProductColor"),
                    }
                }
            };
        }
    }
}
