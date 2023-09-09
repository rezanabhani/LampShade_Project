using System.Collections.Generic;
using _0_Framework.Domain;
using InventoryManagement.Application.Contract.ProductColor;

namespace InventoryManagement.Domain.ProductColorAgg
{
    public interface IProductColorRepository : IRepository<long,ProductColor>
    {
        EditColor GetDetails(long id);
        List<ProductColorViewModel> GetList();
        List<ProductColorViewModel> GetListWithProduct();
    }
}
