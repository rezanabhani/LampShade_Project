using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using DiscountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CommentManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore;
using ProductQueryModel = _01_LampshadeQuery.Contracts.Product.ProductQueryModel;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.ProductAgg;

namespace _01_LampshadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        private readonly CommentContext _commentContext;

        public ProductQuery(ShopContext context, InventoryContext inventoryContext,
            DiscountContext discountContext, CommentContext commentContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
            _commentContext = commentContext;
        }

        public ProductQueryModel GetProductDetails(string slug)
        {
            var inventory = _inventoryContext.Inventory.Include(x => x.ProductColor).Select(x =>
                new { x.Id, x.ProductId, x.UnitPrice, x.InStock, x.ProductColorId, x.ProductColor }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

            var product = _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductPictures)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Category = x.Category.Name,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    CategorySlug = x.Category.Slug,
                    Code = x.Code,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    ShortDescription = x.ShortDescription,
                    Pictures = MapProductPictures(x.ProductPictures),
                }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);



            if (product == null)
                return new ProductQueryModel();


            //var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);

            //var priceColor = _inventoryContext.Inventory
            //    .Include(x => x.ProductColor)
            //    .Select(x => new { x.ProductId, x.ProductColorId, x.UnitPrice })
            //    .FirstOrDefault(x => x.ProductId == product.Id & x.ProductColorId == product.ProductColorId).UnitPrice;

            //if (productInventory != null)
            //{
            //    product.IsInStock = productInventory.InStock;
            //    var price = productInventory.UnitPrice;
            //    product.Price = price.ToMoney();
            //    product.DoublePrice = price;
            //    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
            //    if (discount != null)
            //    {
            //        var discountRate = discount.DiscountRate;
            //        product.DiscountRate = discountRate;
            //        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
            //        product.HasDiscount = discountRate > 0;
            //        var discountAmount = Math.Round((price * discountRate) / 100); 
            //       product.PriceWithDiscount = (price - discountAmount).ToMoney();


            //    }
            //}

            product.Comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Product)
                .Where(x => x.OwnerRecordId == product.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message
                }).OrderByDescending(x => x.Id).ToList();


            var discount2 = discounts.FirstOrDefault(x => x.ProductId == product.Id);
            if (discount2 != null)
            {
                var discountRate = discount2.DiscountRate;
                product.DiscountRate = discountRate;
                product.DiscountExpireDate = discount2.EndDate.ToDiscountFormat();
                product.HasDiscount = discountRate > 0;

                product.ProductColors = _inventoryContext.Inventory
                    .Where(x => product.Id == x.ProductId)
                    .Include(x => x.ProductColor)
                    .Select(x => new ProductColorQueryModel
                    {
                        ColorId = x.ProductColor.Id,
                        ColorName = x.ProductColor.Color,
                        Price = x.UnitPrice,
                        PriceWithDiscount = Math.Round((x.UnitPrice * discount2.DiscountRate) / 100) - (x.UnitPrice)
                    }).ToList();

            }
            else if (discount2 == null)
            {
                product.ProductColors = _inventoryContext.Inventory
                .Where(x => product.Id == x.ProductId)
                .Include(x => x.ProductColor)
                .Select(x => new ProductColorQueryModel
                {
                    ColorId = x.ProductColor.Id,
                    ColorName = x.ProductColor.Color,
                    Price = x.UnitPrice,
                }).ToList();
        }


            return product;
        }


        private static List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> pictures)
        {
            return pictures.Select(x => new ProductPictureQueryModel
            {
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).Where(x => !x.IsRemoved).ToList();
        }


        public List<ProductQueryModel> GetLatestArrivals()
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();
            var products = _context.Products.Include(x => x.Category)
                .Select(product => new ProductQueryModel
                {
                    Id = product.Id,
                    Category = product.Category.Name,
                    CategorySlug = product.Category.Slug,
                    Name = product.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug
                }).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();

            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }

            return products;
        }

        public List<ProductQueryModel> Search(string value)
        {
            var inventory = _inventoryContext.Inventory.Select(x =>
                new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

            var query = _context.Products
                .Include(a => a.Category)
                .Select(product => new ProductQueryModel
                {
                    Id = product.Id,
                    Category = product.Category.Name,
                    Name = product.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    ShortDescription = product.ShortDescription,
                    Slug = product.Slug,
                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));

            var products = query.OrderByDescending(x => x.Id).ToList();

            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }

            return products;
        }

        public string GetUnitPrice(long ColorId, long ProductId)
        {
            var priceColor = _inventoryContext.Inventory
                .Select(x => new { x.ProductId, x.ProductColorId, x.UnitPrice })
                .FirstOrDefault(x => x.ProductId == ProductId & x.ProductColorId == ColorId).UnitPrice;

            return priceColor.ToMoney();

        }

        public string GetUnitPriceWithDisCount(long ColorId, long ProductId)
        {
            var inventory = _inventoryContext.Inventory.Include(x => x.ProductColor).Select(x =>
                new { x.Id, x.ProductId, x.UnitPrice, x.InStock, x.ProductColorId, x.ProductColor }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

            var productInventory =
                inventory.FirstOrDefault(x => x.ProductId == ProductId && x.ProductColorId == ColorId);

            var product = _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductPictures)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Category = x.Category.Name,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    CategorySlug = x.Category.Slug,
                    Code = x.Code,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    ShortDescription = x.ShortDescription,
                    Pictures = MapProductPictures(x.ProductPictures),
                }).AsNoTracking().FirstOrDefault(x => x.Id == ProductId);


            var priceColor = _inventoryContext.Inventory
                .Select(x => new { x.ProductId, x.ProductColorId, x.UnitPrice })
                .FirstOrDefault(x => x.ProductId == ProductId & x.ProductColorId == ColorId).UnitPrice;

            //if (productInventory != null)
            //{
            var price = priceColor;
            product.Price = price.ToMoney();
            product.DoublePrice = price;
            var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
            //if (discount != null)
            //{
            var discountRate = discount.DiscountRate;
            product.DiscountRate = discountRate;
            product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
            product.HasDiscount = discountRate > 0;
            var discountAmount = Math.Round((price * discountRate) / 100);
            var priceWithDiscount = product.PriceWithDiscount = (price - discountAmount).ToMoney();

            //}
            //}
            return priceWithDiscount;
        }
    }
}
    