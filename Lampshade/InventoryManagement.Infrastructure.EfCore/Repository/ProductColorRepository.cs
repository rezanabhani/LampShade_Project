using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contract.ProductColor;
using InventoryManagement.Domain.ProductColorAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;


namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class ProductColorRepository : RepositoryBase<long, ProductColor>, IProductColorRepository
    {
        private readonly InventoryContext _context;
        private readonly ShopContext _shopContext;
        public ProductColorRepository(InventoryContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
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
                Id = x.Id,
                Color = x.Color
            }).OrderByDescending(x => x.Id).ToList();
        }




        public List<ProductColorViewModel> GetListWithProduct()
        {
            throw new System.NotImplementedException();

            //var product = _shopContext.Products.Select(x => new { x.Id }).ToList();
            //var inventory = _context.Inventory.Select(x => new { x.ProductId }).ToList();

            //var productInventory = product.FirstOrDefault(x => x.Id == inventory.)

            //return  _context.Inventory
            //    .Include(x => x.ProductColor)
            //    .Where(x => x.ProductId == product.Id)
            //    .Select(x => new ProductColorViewModel()
            //    {
            //        Id = x.Id,
            //        Color = x.ProductColor.Color
            //    }).ToList();
        }


    }
}
