namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public long ProductColorId { get; set; }
        public double UnitPrice { get; set; }
    }
}
