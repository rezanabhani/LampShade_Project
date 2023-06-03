using _0_Framework.Application;
using _0_Framework.Domain;
using System.Collections.Generic;
using InventoryManagement.Application.Contract.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long,Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy(long productId);
        List<InventoryViewModel> GetList(InventorySearchModel searchModel);
    }
}
