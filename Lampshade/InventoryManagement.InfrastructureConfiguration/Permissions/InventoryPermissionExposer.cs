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
                        new PermissionsDto(50,"ListInventory"),
                        new PermissionsDto(51,"SearchInventory"),
                        new PermissionsDto(52,"CreateInventory"),
                        new PermissionsDto(53,"EditInventory"),
                    }
                },
                {
                    "ProductColor", new List<PermissionsDto>
                    {
                        new PermissionsDto(54,"ListProductColor"),
                        new PermissionsDto(55,"CreateProductColor"),
                        new PermissionsDto(56,"EditProductColor"),
                    }
                }
            };
        }
    }
}
