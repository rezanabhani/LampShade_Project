using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Infrastructure.EfCore;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly AccountContext _accountContext;
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _context;

        public InventoryRepository(InventoryContext context, ShopContext shopContext, 
            AccountContext accountContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public Inventory GetBy(long productId)
        {
            return _context.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetails(long id)
        {
            return _context.Inventory.Select(x => new EditInventory()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductColorId = x.ProductColorId,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }



        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _context.Inventory
                .Include(x => x.ProductColor)
                .Select(x => new InventoryViewModel()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductColor = x.ProductColor.Color,
                ProductColorId = x.ProductColorId,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                CurrentCount = x.CalculateCurrentCount(),
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

                inventory.ForEach(item =>
                {
                    item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
                });

            return inventory;

        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var account = _accountContext.Accounts.Select(x => new { x.Id, x.Fullname }).ToList();

            var inventory = _context.Inventory.FirstOrDefault(x => x.Id == inventoryId);

            var operations = inventory.Operations.Select(x => new InventoryOperationViewModel()
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToFarsi(),
                OperatorId = x.OperatorId,
                OrderId = x.OrderId
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var operation in operations)
            {
                operation.Operator = account.FirstOrDefault(x => x.Id == operation.OperatorId)?.Fullname;
            }

            return operations;
        }


        public List<OrderItemViewModel> GetOrdersItems(long orderId)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var inventory = _context.Inventory.Include(x => x.ProductColor)
                .Select(x => new { x.ProductId, x.ProductColor.ColorP }).ToList();
            var order = _shopContext.Orders.Include(o => o.Items).FirstOrDefault(x => x.Id == orderId);
            if (order == null)
                return new List<OrderItemViewModel>();

            var items = order.Items.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).ToList();

            foreach (var item in items)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
                item.ProductColor = inventory.FirstOrDefault(x => x.ProductId == item.ProductId)?.ColorP;
            }

            return items;
        }
    }
}
