using _0_Framework.Domain;
using System.Collections.Generic;
using InventoryManagement.Application.Contract.Inventory;
using ShopManagement.Application.Contracts.Order;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long,Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy(long productId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
        List<OrderItemViewModel> GetOrdersItems(long orderId);
    }
}
