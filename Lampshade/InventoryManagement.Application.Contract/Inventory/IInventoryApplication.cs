﻿using System.Collections.Generic;
using _0_Framework.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Decrease(List<DecreaseInventory> command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> GetList(InventorySearchModel searchModel);
    }
}
