using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using DiscountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using _01_LampshadeQuery.Contracts.Comment;
using CommentManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Infrastructure.EfCore;
using ProductQueryModel = _01_LampshadeQuery.Contracts.Product.ProductQueryModel;
using ShopManagement.Domain.ProductPictureAgg;

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
                new { x.Id, x.ProductId, x.UnitPrice, x.InStock, x.ProductColorId, x.ProductColor, x.IsRemoved }).ToList();
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



            product.Comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Product)
                .Where(x => x.OwnerRecordId == product.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();



            var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
            var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
            if (productInventory != null)
            {
                product.IsInStock = productInventory.InStock;
                if (discount != null)
                {
                    var discountRate = discount.DiscountRate;
                    product.DiscountRate = discountRate;
                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    product.HasDiscount = discountRate > 0;

                    product.ProductColors = _inventoryContext.Inventory
                        .Where(x => !x.IsRemoved)
                        .Where(x => product.Id == x.ProductId)
                        .Include(x => x.ProductColor)
                        .Select(x => new ProductColorQueryModel
                        {
                            ColorId = x.ProductColor.Id,
                            ColorName = x.ProductColor.Color,
                            ColorPName = x.ProductColor.ColorP,
                            Price = x.UnitPrice.ToMoney(),
                            DoublePrice = x.UnitPrice,
                            //PriceWithDiscount = Math.Round((x.UnitPrice * discount.DiscountRate) / 100) - (x.UnitPrice),
                            PriceWithDiscount = Math.Round((x.UnitPrice * discount.DiscountRate) / 100 - (x.UnitPrice)).ToMoney(),
                            CurrentCount = x.CalculateCurrentCount()
                        }).ToList();

                }
                else if (discount == null)
                {
                    product.ProductColors = _inventoryContext.Inventory
                        .Where(x => !x.IsRemoved)
                        .Where(x => product.Id == x.ProductId)
                        .Include(x => x.ProductColor)
                        .Select(x => new ProductColorQueryModel
                        {
                            ColorId = x.ProductColor.Id,
                            ColorName = x.ProductColor.Color,
                            ColorPName = x.ProductColor.ColorP,
                            Price = x.UnitPrice.ToMoney(),
                            DoublePrice = x.UnitPrice,
                            CurrentCount = x.CalculateCurrentCount()
                        }).ToList();
                }
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

            var products = _context.Products
                .Include(x => x.Category)
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
                }).AsNoTracking().OrderByDescending(x => x.Id).Take(8).ToList();

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
                    CategorySlug = product.Category.Slug
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
                        var discountRate = discount.DiscountRate;
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

        public List<CartItem> CheckInventoryStatus(List<CartItem> cartItems)
        {
            var inventory = _inventoryContext.Inventory.ToList();

            foreach (var cartItem in cartItems.Where(cartItem =>
                         inventory.Any(x => x.ProductId == cartItem.Id && x.InStock)))
            {
                var itemInventory = inventory.Find(x => x.ProductId == cartItem.Id);
                cartItem.IsInStock = itemInventory.CalculateCurrentCount() >= cartItem.Count;
            }

            return cartItems;
        }

        public List<ProductQueryModel> GetRelatedProducts(string productId)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var productCategoryId = _context.Products.Select(x => new { x.Slug, x.CategoryId })
                .FirstOrDefault(x => x.Slug == productId)?.CategoryId;

            //var productId = _context.Products.Select(x => new { x.Slug, x.CategoryId })
            //    .FirstOrDefault(x => x.Slug == productId)?.CategoryId;


            var products = _context.Products
                .Include(x => x.Category)
                .Where(x => x.Slug != productId)
                .Where(x => productCategoryId == x.Category.Id)
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
    }
}
