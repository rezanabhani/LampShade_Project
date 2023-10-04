using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.CategoryTypeAgg
{
    public class CategoryType : EntityBase
    {
        public string Name { get; private set; }
        public List<ProductCategory> ProductCategories { get; private set; }

        public CategoryType()
        {
            ProductCategories = new List<ProductCategory>();
        }

        public CategoryType(string name)
        {
            Name = name;
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }

}
