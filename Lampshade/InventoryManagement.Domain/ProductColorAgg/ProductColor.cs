using System.Collections.Generic;
using _0_Framework.Domain;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Domain.ProductColorAgg
{
    public class ProductColor : EntityBase
    {
        public string Color { get; private set; }
        public string ColorP { get; private set; }
        public List<Inventory> Inventories { get; private set; }

        public ProductColor(string color, string colorP)
        {
            Color = color;
            Inventories = new List<Inventory>();
            ColorP = colorP;
        }

        public void Edit(string color, string colorP)
        {
            Color = color;
            ColorP = colorP;
        }

    }
}
