using System.Collections.Generic;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using _01_LampshadeQuery.Contracts.ProductCategory;

namespace _01_LampshadeQuery
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticlesCategories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
