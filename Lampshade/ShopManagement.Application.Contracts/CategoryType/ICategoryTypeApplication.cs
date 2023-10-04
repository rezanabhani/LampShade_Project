using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.CategoryType
{
    public interface ICategoryTypeApplication
    {
        OperationResult Create(CreateCategoryType command);
        OperationResult Edit(EditCategoryType command);
        EditCategoryType GetDetails(long id);
        List<CategoryTypeViewModel> GetCategoryTypes();
        List<CategoryTypeViewModel> GetCategories();
    }
}
