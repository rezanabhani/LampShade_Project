using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionsExposer
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {
                {
                    "Product", new List<PermissionsDto>
                    {
                          new PermissionsDto(10,"ListProducts"),
                          new PermissionsDto(11,"SearchProducts"),
                          new PermissionsDto(12,"CreateProducts"),
                          new PermissionsDto(13,"EditProducts"),
                    } 
                },
                {
                    "ProductCategory", new List<PermissionsDto>
                    {
                         new PermissionsDto(20,"SearchProductCategories"),
                         new PermissionsDto(21,"ListProductCategories"),
                         new PermissionsDto(22,"CreateProductCategory"),
                         new PermissionsDto(23,"EditProductCategory"),
                    }
                }
            };
        }
    }
}
