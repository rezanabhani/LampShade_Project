using System.Collections.Generic;
using _0_Framework.Application;

namespace InventoryManagement.Application.Contract.ProductColor
{
    public interface IProductColorApplication
    {
        OperationResult Create(CreateColor command);
        OperationResult Edit(EditColor command);
        EditColor GetDetails(long id);
        List<ProductColorViewModel> GetList();
       
    }
}
