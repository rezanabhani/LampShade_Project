using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }
        public string ProductColor { get; set; }
        public long ProductColorId { get; set; }
        public double UnitPrice { get; set; }
        public bool InStock { get; set; }
        public long CurrentCount { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}