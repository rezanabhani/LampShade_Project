using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.CategoryType;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.CategoryTypeAgg
{
    public interface ICategoryTypeRepository : IRepository<long,CategoryType>
    {
        List<CategoryTypeViewModel> GetCategoryTypes();
        List<CategoryTypeViewModel> List();
        EditCategoryType GetDetails(long id);

    }
}
