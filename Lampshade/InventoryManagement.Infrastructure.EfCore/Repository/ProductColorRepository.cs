using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contract.ProductColor;
using InventoryManagement.Domain.ProductColorAgg;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class ProductColorRepository : RepositoryBase<long,ProductColor> , IProductColorRepository
    {
        private readonly InventoryContext _context;
        public ProductColorRepository(InventoryContext context) : base(context)
        {
            _context = context;
        }

        public EditColor GetDetails(long id)
        {
            return _context.ProductColors.Select(x => new EditColor()
            {
                Id = x.Id,
                Color = x.Color
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductColorViewModel> GetList()
        {
            return _context.ProductColors.Select(x => new ProductColorViewModel()
            {
                Id =x.Id,
                Color = x.Color
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
