using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.CategoryType;
using ShopManagement.Domain.CategoryTypeAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CategoryTypeRepository : RepositoryBase<long,CategoryType> , ICategoryTypeRepository
    {
        private readonly ShopContext _shopContext;

        public CategoryTypeRepository(DbContext context, ShopContext shopContext) : base(context)
        {
            _shopContext = shopContext;
        }

        public CategoryTypeRepository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }

        public List<CategoryTypeViewModel> GetCategoryTypes()
        {
            return _shopContext.CategoryTypes.Select(x => new CategoryTypeViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<CategoryTypeViewModel> List()
        {
            return _shopContext.CategoryTypes.Select(x => new CategoryTypeViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();
        }

        public EditCategoryType GetDetails(long id)
        {
            return _shopContext.CategoryTypes.Select(x => new EditCategoryType()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
