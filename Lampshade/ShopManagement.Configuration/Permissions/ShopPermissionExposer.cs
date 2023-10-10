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
                    "ShopManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(ShopPermissions.ShowShopManagement,"ShowShopManagement"),
                    }
                },
                {
                    "Product", new List<PermissionsDto>
                    {
                          new PermissionsDto(ShopPermissions.ShowProductManagement,"ShowProductManagement"),
                          new PermissionsDto(ShopPermissions.ListProducts,"ListProducts"),
                          new PermissionsDto(ShopPermissions.SearchProducts,"SearchProducts"),
                          new PermissionsDto(ShopPermissions.CreateProduct,"CreateProducts"),
                          new PermissionsDto(ShopPermissions.EditProduct,"EditProducts"),
                    }
                },
                {
                    "ProductCategory", new List<PermissionsDto>
                    {
                        new PermissionsDto(ShopPermissions.ShowProductCategoryManagement,"ShowProductCategoryManagement"),
                         new PermissionsDto(ShopPermissions.SearchProductCategories,"SearchProductCategories"),
                         new PermissionsDto(ShopPermissions.ListProductCategories,"ListProductCategories"),
                         new PermissionsDto(ShopPermissions.CreateProductCategory,"CreateProductCategory"),
                         new PermissionsDto(ShopPermissions.EditProductCategory,"EditProductCategory"),
                    }
                },
                {
                    "ProductPicture", new List<PermissionsDto>
                    {
                        new PermissionsDto(ShopPermissions.ShowProductPictureManagement,"ShowProductPictureManagement"),
                        new PermissionsDto(ShopPermissions.SearchProductPictures,"SearchProductPictures"),
                        new PermissionsDto(ShopPermissions.ListProductPictures,"ListProductPictures"),
                        new PermissionsDto(ShopPermissions.CreateProductPicture,"CreateProductPicture"),
                        new PermissionsDto(ShopPermissions.EditProductPicture,"EditProductPicture"),
                        new PermissionsDto(ShopPermissions.RemoveSlide,"Remove"),
                        new PermissionsDto(ShopPermissions.RestoreSlide,"Restore"),
                    }
                },
                {
                    "CategoryType", new List<PermissionsDto>
                    {
                        new PermissionsDto(ShopPermissions.ShowCategoryTypeManagement,"ShowCategoryTypeManagement"),
                        new PermissionsDto(ShopPermissions.ListCategoryTypes,"ListCategoryTypes"),
                        new PermissionsDto(ShopPermissions.CreateCategoryType,"CreateCategoryType"),
                        new PermissionsDto(ShopPermissions.EditCategoryType,"EditCategoryType"),
                    }
                },
                {
                    "Slide", new List<PermissionsDto>
                    {
                        new PermissionsDto(ShopPermissions.ShowSlideManagement,"ShowSlideManagement"),
                        new PermissionsDto(ShopPermissions.ListSlides,"ListSlides"),
                        new PermissionsDto(ShopPermissions.CreateSlide,"CreateSlide"),
                        new PermissionsDto(ShopPermissions.EditSlide,"EditSlide"),
                        new PermissionsDto(ShopPermissions.RemoveSlide,"RemoveSlide"),
                        new PermissionsDto(ShopPermissions.RestoreSlide,"RestoreSlide"),
                    } }
            };
        }
    }
}
