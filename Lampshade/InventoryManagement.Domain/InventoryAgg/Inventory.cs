using System.Collections.Generic;
using System.Linq;
using _0_Framework.Domain;
using InventoryManagement.Domain.ProductColorAgg;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public long ProductColorId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }
        public ProductColor ProductColor { get; private set; }

        public Inventory(long productId, long productColorId,  double unitPrice)
        {
            ProductId = productId;
            ProductColorId = productColorId;
            UnitPrice = unitPrice;
            InStock = false;
        }

        public void Edit(long productColorId, long productId, double unitPrice)
        {
            ProductColorId = productColorId;
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long count, long operationId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operationId, currentCount, description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Reduce(long count, long operationId, string description,long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operationId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
      
    }
}
